using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ScreenFighter
{
    public class GlobalKeyboardHook : IDisposable
    {
        delegate IntPtr KeyboardHookProc(int code, IntPtr wParam, IntPtr lParam);

        const int WH_KEYBOARD_LL = 13;
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        const int WM_SYSKEYDOWN = 0x104;
        const int WM_SYSKEYUP = 0x105;

        public List<Keys> HookedKeys;
        IntPtr hookId = IntPtr.Zero;

        public event KeyEventHandler KeyDown;
        public event KeyEventHandler KeyUp;

        // We have to store the HookProc, so that it is not garbage collected runtime
        KeyboardHookProc hookedKeyboardProc;

        public GlobalKeyboardHook()
        {
            HookedKeys = new List<Keys>();
            hookedKeyboardProc = (KeyboardHookProc)hookProc;
            Hook();
        }

        ~GlobalKeyboardHook()
        {
            Dispose();
        }

        public void Hook()
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                hookId = SetWindowsHookEx(WH_KEYBOARD_LL, hookedKeyboardProc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        public void UnHook()
        {
            UnhookWindowsHookEx(hookId);
        }

        public void Dispose()
        {
            UnHook();
        }

        IntPtr hookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code >= 0)
            {
                Keys key = (Keys)Marshal.ReadInt32(lParam);
                if (HookedKeys.Contains(key))
                {
                    KeyEventArgs keyArgs = new KeyEventArgs(key);
                    KeyEventHandler pKeyDown = KeyDown,
                        pKeyUp = KeyUp;
                    if ((wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN) && (pKeyDown != null))
                    {
                        pKeyDown(this, keyArgs);
                    }
                    else if ((wParam == (IntPtr)WM_KEYUP || wParam == (IntPtr)WM_SYSKEYUP) && (pKeyUp != null))
                    {
                        pKeyUp(this, keyArgs);
                    }

                    if (keyArgs.Handled)
                        return (IntPtr)1;
                }
            }

            return CallNextHookEx(hookId, code, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr SetWindowsHookEx(int idHook, KeyboardHookProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
