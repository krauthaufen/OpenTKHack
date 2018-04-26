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

using OpenTK.Input;

namespace OpenTK.Platform.Windows
{
    internal static class WinKeyMap
    {
        public static Key GetKey(int code)
        {
            switch (code)
            {
                // 0 - 15
                case 0: return Key.Unknown;
                case 1: return Key.Escape;
                case 2: return Key.Number1;
                case 3: return Key.Number2;
                case 4: return Key.Number3;
                case 5: return Key.Number4;
                case 6: return Key.Number5;
                case 7: return Key.Number6;
                case 8: return Key.Number7;
                case 9: return Key.Number8;
                case 10: return Key.Number9;
                case 11: return Key.Number0;
                case 12: return Key.Minus;
                case 13: return Key.Plus;
                case 14: return Key.BackSpace;
                case 15: return Key.Tab;

                // 16-31
                case 16: return Key.Q;
                case 17: return Key.W;
                case 18: return Key.E;
                case 19: return Key.R;
                case 20: return Key.T;
                case 21: return Key.Y;
                case 22: return Key.U;
                case 23: return Key.I;
                case 24: return Key.O;
                case 25: return Key.P;
                case 26: return Key.BracketLeft;
                case 27: return Key.BracketRight;
                case 28: return Key.Enter;
                case 29: return Key.ControlLeft;
                case 30: return Key.A;
                case 31: return Key.S;

                // 32 - 47
                case 32: return Key.D;
                case 33: return Key.F;
                case 34: return Key.G;
                case 35: return Key.H;
                case 36: return Key.J;
                case 37: return Key.K;
                case 38: return Key.L;
                case 39: return Key.Semicolon;
                case 40: return Key.Quote;
                case 41: return Key.Grave;
                case 42: return Key.ShiftLeft;
                case 43: return Key.BackSlash;
                case 44: return Key.Z;
                case 45: return Key.X;
                case 46: return Key.C;
                case 47: return Key.V;

                // 48 - 63
                case 48: return Key.B;
                case 49: return Key.N;
                case 50: return Key.M;
                case 51: return Key.Comma;
                case 52: return Key.Period;
                case 53: return Key.Slash;
                case 54: return Key.ShiftRight;
                case 55: return Key.PrintScreen;
                case 56: return Key.AltLeft;
                case 57: return Key.Space;
                case 58: return Key.CapsLock;
                case 59: return Key.F1;
                case 60: return Key.F2;
                case 61: return Key.F3;
                case 62: return Key.F4;
                case 63: return Key.F5;

                // 64 - 79
                case 64: return Key.F6;
                case 65: return Key.F7;
                case 66: return Key.F8;
                case 67: return Key.F9;
                case 68: return Key.F10;
                case 69: return Key.NumLock;
                case 70: return Key.ScrollLock;
                case 71: return Key.Home;
                case 72: return Key.Up;
                case 73: return Key.PageUp;
                case 74: return Key.KeypadMinus;
                case 75: return Key.Left;
                case 76: return Key.Keypad5;
                case 77: return Key.Right;
                case 78: return Key.KeypadPlus;
                case 79: return Key.End;

                // 80 - 95
                case 80: return Key.Down;
                case 81: return Key.PageDown;
                case 82: return Key.Insert;
                case 83: return Key.Delete;
                case 84: return Key.Unknown;
                case 85: return Key.Unknown;
                case 86: return Key.NonUSBackSlash;
                case 87: return Key.F11;
                case 88: return Key.F12;
                case 89: return Key.Pause;
                case 90: return Key.Unknown;
                case 91: return Key.WinLeft;
                case 92: return Key.WinRight;
                case 93: return Key.Menu;
                case 94: return Key.Unknown;
                case 95: return Key.Unknown;

                // 96 - 106
                case 96: return Key.Unknown;
                case 97: return Key.Unknown;
                case 98: return Key.Unknown;
                case 99: return Key.Unknown;
                case 100: return Key.F13;
                case 101: return Key.F14;
                case 102: return Key.F15;
                case 103: return Key.F16;
                case 104: return Key.F17;
                case 105: return Key.F18;
                case 106: return Key.F19;

                default: return Key.Unknown;
            }
        }

        public static Key GetKey(VirtualKeys vkey)
        {
            switch (vkey)
            {
                case VirtualKeys.QS_EVENT: return Key.Unknown;
                case VirtualKeys.VK_CANCEL: return Key.Unknown;
                case VirtualKeys.VK_BACK: return Key.BackSpace;
                case VirtualKeys.VK_CLEAR: return Key.Unknown;
                case VirtualKeys.VK_RETURN: return Key.Enter;
                case VirtualKeys.VK_PAUSE: return Key.Pause;
                case VirtualKeys.VK_CAPITAL: return Key.CapsLock;
                case VirtualKeys.VK_KANA: return Key.Unknown;
                case VirtualKeys.VK_JUNJA: return Key.Unknown;
                case VirtualKeys.VK_FINAL: return Key.Unknown;
                case VirtualKeys.VK_HANJA: return Key.Unknown;
                case VirtualKeys.VK_ESCAPE: return Key.Escape;
                case VirtualKeys.VK_CONVERT: return Key.Unknown;
                case VirtualKeys.VK_NONCONVERT: return Key.Unknown;
                case VirtualKeys.VK_ACCEPT: return Key.Unknown;
                case VirtualKeys.VK_MODECHANGE: return Key.Unknown;
                case VirtualKeys.VK_SPACE: return Key.Space;
                case VirtualKeys.VK_PRIOR: return Key.PageUp;
                case VirtualKeys.VK_NEXT: return Key.PageDown;
                case VirtualKeys.VK_END: return Key.End;
                case VirtualKeys.VK_HOME: return Key.Home;
                case VirtualKeys.VK_LEFT: return Key.Left;
                case VirtualKeys.VK_UP: return Key.Up;
                case VirtualKeys.VK_RIGHT: return Key.Right;
                case VirtualKeys.VK_DOWN: return Key.Down;
                case VirtualKeys.VK_SELECT: return Key.Unknown;
                case VirtualKeys.VK_PRINT: return Key.PrintScreen;
                case VirtualKeys.VK_EXECUTE: return Key.Unknown;
                case VirtualKeys.VK_SNAPSHOT: return Key.PrintScreen;
                case VirtualKeys.VK_INSERT: return Key.Insert;
                case VirtualKeys.VK_DELETE: return Key.Delete;
                case VirtualKeys.VK_HELP: return Key.Unknown;
                case VirtualKeys.VK_0: return Key.Number0;
                case VirtualKeys.VK_1: return Key.Number1;
                case VirtualKeys.VK_2: return Key.Number2;
                case VirtualKeys.VK_3: return Key.Number3;
                case VirtualKeys.VK_4: return Key.Number4;
                case VirtualKeys.VK_5: return Key.Number5;
                case VirtualKeys.VK_6: return Key.Number6;
                case VirtualKeys.VK_7: return Key.Number7;
                case VirtualKeys.VK_8: return Key.Number8;
                case VirtualKeys.VK_9: return Key.Number9;
                case VirtualKeys.VK_A: return Key.A;
                case VirtualKeys.VK_B: return Key.B;
                case VirtualKeys.VK_C: return Key.C;
                case VirtualKeys.VK_D: return Key.D;
                case VirtualKeys.VK_E: return Key.E;
                case VirtualKeys.VK_F: return Key.F;
                case VirtualKeys.VK_G: return Key.G;
                case VirtualKeys.VK_H: return Key.H;
                case VirtualKeys.VK_I: return Key.I;
                case VirtualKeys.VK_J: return Key.J;
                case VirtualKeys.VK_K: return Key.K;
                case VirtualKeys.VK_L: return Key.L;
                case VirtualKeys.VK_M: return Key.M;
                case VirtualKeys.VK_N: return Key.N;
                case VirtualKeys.VK_O: return Key.O;
                case VirtualKeys.VK_P: return Key.P;
                case VirtualKeys.VK_Q: return Key.Q;
                case VirtualKeys.VK_R: return Key.R;
                case VirtualKeys.VK_S: return Key.S;
                case VirtualKeys.VK_T: return Key.T;
                case VirtualKeys.VK_U: return Key.U;
                case VirtualKeys.VK_V: return Key.V;
                case VirtualKeys.VK_W: return Key.W;
                case VirtualKeys.VK_X: return Key.X;
                case VirtualKeys.VK_Y: return Key.Y;
                case VirtualKeys.VK_Z: return Key.Z;
                case VirtualKeys.VK_LWIN: return Key.WinLeft;
                case VirtualKeys.VK_RWIN: return Key.WinRight;
                case VirtualKeys.VK_APPS: return Key.Menu;
                case VirtualKeys.VK_POWER: return Key.Unknown;
                case VirtualKeys.VK_SLEEP: return Key.Sleep;
                case VirtualKeys.VK_NUMPAD0: return Key.Keypad0;
                case VirtualKeys.VK_NUMPAD1: return Key.Keypad1;
                case VirtualKeys.VK_NUMPAD2: return Key.Keypad2;
                case VirtualKeys.VK_NUMPAD3: return Key.Keypad3;
                case VirtualKeys.VK_NUMPAD4: return Key.Keypad4;
                case VirtualKeys.VK_NUMPAD5: return Key.Keypad5;
                case VirtualKeys.VK_NUMPAD6: return Key.Keypad6;
                case VirtualKeys.VK_NUMPAD7: return Key.Keypad7;
                case VirtualKeys.VK_NUMPAD8: return Key.Keypad8;
                case VirtualKeys.VK_NUMPAD9: return Key.Keypad9;
                case VirtualKeys.VK_MULTIPLY: return Key.KeypadMultiply;
                case VirtualKeys.VK_ADD: return Key.KeypadAdd;
                case VirtualKeys.VK_SEPARATOR: return Key.Unknown;
                case VirtualKeys.VK_SUBTRACT: return Key.KeypadSubtract;
                case VirtualKeys.VK_DECIMAL: return Key.KeypadDecimal;
                case VirtualKeys.VK_DIVIDE: return Key.KeypadDivide;
                case VirtualKeys.VK_F1: return Key.F1;
                case VirtualKeys.VK_F2: return Key.F2;
                case VirtualKeys.VK_F3: return Key.F3;
                case VirtualKeys.VK_F4: return Key.F4;
                case VirtualKeys.VK_F5: return Key.F5;
                case VirtualKeys.VK_F6: return Key.F6;
                case VirtualKeys.VK_F7: return Key.F7;
                case VirtualKeys.VK_F8: return Key.F8;
                case VirtualKeys.VK_F9: return Key.F9;
                case VirtualKeys.VK_F10: return Key.F10;
                case VirtualKeys.VK_F11: return Key.F11;
                case VirtualKeys.VK_F12: return Key.F12;
                case VirtualKeys.VK_F13: return Key.F13;
                case VirtualKeys.VK_F14: return Key.F14;
                case VirtualKeys.VK_F15: return Key.F15;
                case VirtualKeys.VK_F16: return Key.F16;
                case VirtualKeys.VK_F17: return Key.F17;
                case VirtualKeys.VK_F18: return Key.F18;
                case VirtualKeys.VK_F19: return Key.F19;
                case VirtualKeys.VK_F20: return Key.F20;
                case VirtualKeys.VK_F21: return Key.F21;
                case VirtualKeys.VK_F22: return Key.F22;
                case VirtualKeys.VK_F23: return Key.F23;
                case VirtualKeys.VK_F24: return Key.F24;
                case VirtualKeys.VK_NUMLOCK: return Key.NumLock;
                case VirtualKeys.VK_SCROLL: return Key.ScrollLock;
                case VirtualKeys.VK_RSHIFT: return Key.ShiftRight;
                case VirtualKeys.VK_BROWSER_BACK: return Key.Unknown;
                case VirtualKeys.VK_BROWSER_FORWARD: return Key.Unknown;
                case VirtualKeys.VK_BROWSER_REFRESH: return Key.Unknown;
                case VirtualKeys.VK_BROWSER_STOP: return Key.Unknown;
                case VirtualKeys.VK_BROWSER_SEARCH: return Key.Unknown;
                case VirtualKeys.VK_BROWSER_FAVORITES: return Key.Unknown;
                case VirtualKeys.VK_BROWSER_HOME: return Key.Unknown;
                case VirtualKeys.VK_VOLUME_MUTE: return Key.Unknown;
                case VirtualKeys.VK_VOLUME_DOWN: return Key.Unknown;
                case VirtualKeys.VK_VOLUME_UP: return Key.Unknown;
                case VirtualKeys.VK_MEDIA_NEXT_TRACK: return Key.Unknown;
                case VirtualKeys.VK_MEDIA_PREV_TRACK: return Key.Unknown;
                case VirtualKeys.VK_MEDIA_STOP: return Key.Unknown;
                case VirtualKeys.VK_MEDIA_PLAY_PAUSE: return Key.Unknown;
                case VirtualKeys.VK_LAUNCH_MAIL: return Key.Unknown;
                case VirtualKeys.VK_LAUNCH_MEDIA_SELECT: return Key.Unknown;
                case VirtualKeys.VK_LAUNCH_APP1: return Key.Unknown;
                case VirtualKeys.VK_LAUNCH_APP2: return Key.Unknown;
                case VirtualKeys.VK_PROCESSKEY: return Key.Unknown;
                case VirtualKeys.VK_PACKET: return Key.Unknown;
                case VirtualKeys.VK_ATTN: return Key.Unknown;
                case VirtualKeys.VK_CRSEL: return Key.Unknown;
                case VirtualKeys.VK_EXSEL: return Key.Unknown;
                case VirtualKeys.VK_EREOF: return Key.Unknown;
                case VirtualKeys.VK_PLAY: return Key.Unknown;
                case VirtualKeys.VK_ZOOM: return Key.Unknown;
                case VirtualKeys.VK_NONAME: return Key.Unknown;
                case VirtualKeys.VK_PA1: return Key.Unknown;
                case VirtualKeys.VK_OEM_CLEAR: return Key.Clear;
                case VirtualKeys.VK_TAB: return Key.Tab;
                case VirtualKeys.VK_SHIFT: return Key.ShiftLeft;
                case VirtualKeys.VK_CONTROL: return Key.ControlLeft;
                case VirtualKeys.VK_MENU: return Key.AltLeft;
                case VirtualKeys.WS_EX_NOACTIVATE: return Key.Unknown;
                case VirtualKeys.VK_LSHIFT: return Key.ShiftLeft;
                case VirtualKeys.VK_RMENU: return Key.ShiftRight;
                case VirtualKeys.VK_LMENU: return Key.ShiftLeft;
                case VirtualKeys.VK_LCONTROL: return Key.ControlLeft;
                case VirtualKeys.VK_RCONTROL: return Key.ControlRight;
                case VirtualKeys.VK_LBUTTON: return Key.Unknown;
                case VirtualKeys.VK_RBUTTON: return Key.Unknown;
                case VirtualKeys.VK_MBUTTON: return Key.Unknown;
                case VirtualKeys.VK_XBUTTON1: return Key.Unknown;
                case VirtualKeys.VK_XBUTTON2: return Key.Unknown;
                case VirtualKeys.VK_OEM_1: return Key.Unknown;
                case VirtualKeys.VK_OEM_PLUS: return Key.Plus;
                case VirtualKeys.VK_OEM_COMMA: return Key.Comma;
                case VirtualKeys.VK_OEM_MINUS: return Key.Minus;
                case VirtualKeys.VK_OEM_PERIOD: return Key.Period;
                case VirtualKeys.VK_OEM_2: return Key.Unknown;
                case VirtualKeys.VK_OEM_3: return Key.Unknown;
                case VirtualKeys.VK_C1: return Key.Unknown;
                case VirtualKeys.VK_C2: return Key.Unknown;
                case VirtualKeys.VK_OEM_4: return Key.Unknown;
                case VirtualKeys.VK_OEM_5: return Key.Unknown;
                case VirtualKeys.VK_OEM_6: return Key.Unknown;
                case VirtualKeys.VK_OEM_7: return Key.Unknown;
                case VirtualKeys.VK_OEM_8: return Key.Unknown;
                case VirtualKeys.VK_OEM_AX: return Key.Unknown;
                case VirtualKeys.VK_OEM_102: return Key.Unknown;
                case VirtualKeys.VK_OEM_RESET: return Key.Unknown;
                case VirtualKeys.VK_OEM_JUMP: return Key.Unknown;
                case VirtualKeys.VK_OEM_PA1: return Key.Unknown;
                case VirtualKeys.VK_OEM_PA2: return Key.Unknown;
                case VirtualKeys.VK_OEM_PA3: return Key.Unknown;
                case VirtualKeys.VK_OEM_WSCTRL: return Key.Unknown;
                case VirtualKeys.VK_OEM_CUSEL: return Key.Unknown;
                case VirtualKeys.VK_OEM_ATTN: return Key.Unknown;
                case VirtualKeys.VK_OEM_FINISH: return Key.Unknown;
                case VirtualKeys.VK_OEM_COPY: return Key.Unknown;
                case VirtualKeys.VK_OEM_AUTO: return Key.Unknown;
                case VirtualKeys.VK_OEM_ENLW: return Key.Unknown;
                case VirtualKeys.VK_OEM_BACKTAB: return Key.Unknown;
                case VirtualKeys.Invalid: return Key.Unknown;
                default: return Key.Unknown;
            }
        }


        public static Key TranslateKey(uint scancode, VirtualKeys vkey, bool extended, out bool is_valid)
        {
            //is_valid = true;

        
            switch (vkey)
            {
                case VirtualKeys.VK_CONTROL:
                    vkey = (extended ? VirtualKeys.VK_RCONTROL : VirtualKeys.VK_LCONTROL);
                    break;
                    
                case VirtualKeys.VK_SHIFT:
                    vkey = (VirtualKeys)Functions.MapVirtualKey(scancode, MapVirtualKeyType.ScanCodeToVirtualKeyExtended);
                    break;

                case VirtualKeys.VK_MENU:
                    vkey = (extended ? VirtualKeys.VK_RMENU : VirtualKeys.VK_LMENU);
                    break;
            }
            var key = GetKey(vkey);
            is_valid = (key != Key.Unknown);

            //var virtualKey =
            //    (VirtualKeys)(
            //        Functions.MapVirtualKey((uint)scancode, MapVirtualKeyType.ScanCodeToVirtualKeyExtended)
            //    );
            

            //if (!extended0)
            //{
            //    switch (key)
            //    {
            //        case Key.Insert: key = Key.Keypad0; break;
            //        case Key.End: key = Key.Keypad1; break;
            //        case Key.Down: key = Key.Keypad2; break;
            //        case Key.PageDown: key = Key.Keypad3; break;
            //        case Key.Left: key = Key.Keypad4; break;
            //        case Key.Right: key = Key.Keypad6; break;
            //        case Key.Home: key = Key.Keypad7; break;
            //        case Key.Up: key = Key.Keypad8; break;
            //        case Key.PageUp: key = Key.Keypad9; break;
            //        case Key.PrintScreen: key = Key.KeypadMultiply; break;
            //        case Key.Delete: key = Key.KeypadDecimal; break;
            //        case Key.NumLock:
            //            if (vkey == VirtualKeys.Invalid)
            //            {
            //                is_valid = false;
            //            }
            //            else if (vkey == VirtualKeys.VK_PAUSE)
            //            {
            //                key = Key.Pause;
            //            }
            //            break;
            //    }
            //}
            //else
            //{
            //    switch (key)
            //    {
            //        case Key.Slash: key = Key.KeypadDivide; break;
            //        case Key.Enter: key = Key.KeypadEnter; break;
            //        case Key.AltLeft: key = Key.AltRight; break;
            //        case Key.AltRight: key = Key.AltLeft; break;
            //        case Key.ControlLeft: key = Key.ControlRight; break;
            //        case Key.ControlRight: key = Key.ControlLeft; break;
            //        case Key.ShiftLeft: is_valid = false; break;
            //    }
            //}

            //if (extended1)
            //{
            //    switch (key)
            //    {
            //        case Key.ControlLeft: key = Key.Pause; break;
            //    }
            //}

            return key;
        }
    }
}
