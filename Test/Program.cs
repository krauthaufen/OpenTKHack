using OpenTK.Platform.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var win = OpenTK.Platform.Factory.Default.CreateNativeWindow(100, 100, 1024, 768, "asdfasd", null, OpenTK.GameWindowFlags.Default, OpenTK.DisplayDevice.Default);
            //var device = OpenTK.DisplayDevice.Default;
            //var win = new WinNativeHack(100, 100, 640, 480, "test", OpenTK.GameWindowFlags.Default, device);
            win.Visible = true;
            win.KeyDown += (s, e) => { Console.WriteLine("JADSF"); };
            while (win.Exists)
            {
                win.ProcessEvents();
            }
        }
    }
}
