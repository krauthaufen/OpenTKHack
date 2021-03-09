//
// The Open Toolkit Library License
//
// Copyright (c) 2006 - 2010 the Open Toolkit library.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do
// so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
#if !MINIMAL
using Microsoft.Win32;
#endif

namespace OpenTK.Platform.Windows
{
    internal sealed class WinDisplayDeviceDriver : DisplayDeviceBase
    {
        private readonly object display_lock = new object();

        public WinDisplayDeviceDriver()
        {
            RefreshDisplayDevices();
            SystemEvents.DisplaySettingsChanged +=
                HandleDisplaySettingsChanged;
        }

        public sealed override bool TryChangeResolution(DisplayDevice device, DisplayResolution resolution)
        {
            DeviceMode mode = null;

            if (resolution != null)
            {
                mode = new DeviceMode();
                mode.PelsWidth = resolution.Width;
                mode.PelsHeight = resolution.Height;
                mode.BitsPerPel = resolution.BitsPerPixel;
                mode.DisplayFrequency = (int)resolution.RefreshRate;
                mode.Fields = Constants.DM_BITSPERPEL
                    | Constants.DM_PELSWIDTH
                    | Constants.DM_PELSHEIGHT
                    | Constants.DM_DISPLAYFREQUENCY;
            }

            return Constants.DISP_CHANGE_SUCCESSFUL ==
                Functions.ChangeDisplaySettingsEx((string)device.Id, mode, IntPtr.Zero,
                    ChangeDisplaySettingsEnum.Fullscreen, IntPtr.Zero);
        }

        public sealed override bool TryRestoreResolution(DisplayDevice device)
        {
            return TryChangeResolution(device, null);
        }

        public void RefreshDisplayDevices()
        {
            lock (this.display_lock)
            {
                // Store an array of the current available DisplayDevice objects.
                // This is needed to preserve the original resolution.
                DisplayDevice[] previousDevices = this.AvailableDevices.ToArray();

                this.AvailableDevices.Clear();

                // We save all necessary parameters in temporary variables
                // and construct the device when every needed detail is available.
                // The main DisplayDevice constructor adds the newly constructed device
                // to the list of available devices.
                DisplayDevice opentk_dev;
                DisplayResolution opentk_dev_current_res = null;
                List<DisplayResolution> opentk_dev_available_res = new List<DisplayResolution>();
                bool opentk_dev_primary = false;
                int device_count = 0, mode_count = 0;

                // Get available video adapters and enumerate all monitors
                WindowsDisplayDevice dev1 = new WindowsDisplayDevice();
                while (Functions.EnumDisplayDevices(null, device_count++, dev1, 0))
                {
                    if ((dev1.StateFlags & DisplayDeviceStateFlags.AttachedToDesktop) == DisplayDeviceStateFlags.None) // NOTE: AttachedToDesktop is identical to Active
                    {
                        continue;
                    }

                    DeviceMode monitor_mode = new DeviceMode();

                    // The second function should only be executed when the first one fails
                    // (e.g. when the monitor is disabled)
                    if (Functions.EnumDisplaySettingsEx(dev1.DeviceName, DisplayModeSettingsEnum.CurrentSettings, monitor_mode, 0) ||
                        Functions.EnumDisplaySettingsEx(dev1.DeviceName, DisplayModeSettingsEnum.RegistrySettings, monitor_mode, 0))
                    {
                        VerifyMode(dev1, monitor_mode);

                        float scale = this.GetScale(ref monitor_mode);
                        var x = (int)(monitor_mode.Position.X / scale);
                        var y = (int)(monitor_mode.Position.Y / scale);
                        var width = (int)(monitor_mode.PelsWidth / scale);
                        var height = (int)(monitor_mode.PelsHeight / scale);

                        try
                        {
                            opentk_dev_current_res = new DisplayResolution(x, y, width, height, monitor_mode.BitsPerPel, monitor_mode.DisplayFrequency);
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            Debug.Print("[OpenTK] Invaild display mode on {0}: {1}, ({2},{3},{4},{5},{6},{7})", dev1.DeviceName, e.Message, x, y, width, height, monitor_mode.BitsPerPel, monitor_mode.DisplayFrequency);

                            // ingnore this output device -> continue with EnumDisplayDevices
                            continue;
                        }

                        opentk_dev_primary =
                            (dev1.StateFlags & DisplayDeviceStateFlags.PrimaryDevice) != DisplayDeviceStateFlags.None;
                    }

                    opentk_dev_available_res.Clear();
                    mode_count = 0;
                    while (Functions.EnumDisplaySettingsEx(dev1.DeviceName, mode_count++, monitor_mode, 0))
                    {
                        VerifyMode(dev1, monitor_mode);

                        float scale = this.GetScale(ref monitor_mode);
                        var x = (int)(monitor_mode.Position.X / scale);
                        var y = (int)(monitor_mode.Position.Y / scale);
                        var width = (int)(monitor_mode.PelsWidth / scale);
                        var height = (int)(monitor_mode.PelsHeight / scale);

                        try
                        {
                            var res = new DisplayResolution(x, y, width, height, monitor_mode.BitsPerPel, monitor_mode.DisplayFrequency);

                            opentk_dev_available_res.Add(res);
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            Debug.Print("[OpenTK] Invaild display mode on {0}: {1}, ({2},{3},{4},{5},{6},{7})", dev1.DeviceName, e.Message, x, y, width, height, monitor_mode.BitsPerPel, monitor_mode.DisplayFrequency);

                            // ingnore this mode for list of available modes -> continue with EnumDisplaySettingsEx
                            continue;
                        }
                    }

                    // Construct the OpenTK DisplayDevice through the accumulated parameters.
                    // The constructor will automatically add the DisplayDevice to the list
                    // of available devices.
                    #pragma warning disable 612,618
                    opentk_dev = new DisplayDevice(
                        opentk_dev_current_res,
                        opentk_dev_primary,
                        opentk_dev_available_res,
                        opentk_dev_current_res.Bounds,
                        dev1.DeviceName);
                    #pragma warning restore 612,618

                    // Set the original resolution if the DisplayDevice was previously available.
                    foreach (DisplayDevice existingDevice in previousDevices)
                    {
                        if ((string)existingDevice.Id == (string)opentk_dev.Id)
                        {
                            opentk_dev.OriginalResolution = existingDevice.OriginalResolution;
                        }
                    }

                    this.AvailableDevices.Add(opentk_dev);

                    if (opentk_dev_primary)
                    {
                        this.Primary = opentk_dev;
                    }

                    Debug.Print("DisplayDevice {0} ({1}) supports {2} resolutions.",
                        device_count, opentk_dev.IsPrimary ? "primary" : "secondary", opentk_dev.AvailableResolutions.Count);
                }
            }
        }

        private float GetScale(ref DeviceMode monitor_mode)
        {
            float scale = 1.0f;
            if ((monitor_mode.Fields & Constants.DM_LOGPIXELS) != 0)
            {
                if (monitor_mode.LogPixels > 0)
                    scale = monitor_mode.LogPixels / 96.0f;
                else
                    Debug.Print("[Warning] DisplayDevice '{0}' reported LogPixels of 0 or less", monitor_mode.DeviceName);
            }

            return scale;
        }

        private static void VerifyMode(WindowsDisplayDevice device, DeviceMode mode)
        {
            if (mode.BitsPerPel == 0)
            {
                Debug.Print(
                    "[Warning] DisplayDevice '{0}' reported a mode with 0 bpp. Please create a bug report at https://github.com/opentk/opentk/issues",
                    device.DeviceName);
                mode.BitsPerPel = 32;
            }
        }

        private void HandleDisplaySettingsChanged(object sender, EventArgs e)
        {
            RefreshDisplayDevices();
        }

        ~WinDisplayDeviceDriver()
        {
            SystemEvents.DisplaySettingsChanged -=
                HandleDisplaySettingsChanged;
        }
    }
}
