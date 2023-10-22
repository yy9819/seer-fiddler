using System;
using System.Runtime.InteropServices;

namespace seer_fiddler.core
{

    public static class Win32Util
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hwnd, IntPtr hWndInsertAfter , int x, int y ,int cx ,int cy ,uint uFlags);
        [DllImport("user32.dll")]
        private static extern IntPtr ShowWindow(IntPtr hwnd, uint uFlags);
        [DllImport("user32.dll")]
        private static extern IntPtr ShowWindowAsync(IntPtr hwnd, uint uFlags);
        [DllImport("user32.dll")]
        private static extern IntPtr SetForegroundWindow(IntPtr hwnd);

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TOOLWINDOW = 0x00000080;
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_RESTORE = 0x0009;
        private const uint SWP_FORCEMINIMIZE = 0x0011;
        public static IntPtr FindWindowByWindowName(string windowName)
        {
            return FindWindow(null, windowName);
        }
        public static void SetWindowLong(IntPtr targetWindowHwnd)
        {
            SetWindowLong(targetWindowHwnd, GWL_EXSTYLE, GetWindowLong(targetWindowHwnd, GWL_EXSTYLE) | WS_EX_TOOLWINDOW);
        }
        public static void SetWindowPos(IntPtr targetWindowHwnd)
        {

            //SetWindowPos(targetWindowHwnd, IntPtr.Zero,0,0,0,0, SWP_NOSIZE | SWP_NOMOVE);
            ShowWindow(targetWindowHwnd, SWP_FORCEMINIMIZE);
            ShowWindowAsync(targetWindowHwnd,SWP_RESTORE);
            SetForegroundWindow(targetWindowHwnd);
        }
    }

}
