using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace CWExpert
{

    public static class DXLogHelper
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool IsWindow(IntPtr hWnd);

        private const int SW_RESTORE = 9;

        private static readonly object _lock = new object();
        private static IntPtr _hwnd = IntPtr.Zero;

        /// <summary>
        /// 1) INIT - Locate DXLog.net and cache its window handle.
        /// </summary>
        public static IntPtr Init(bool forceRefresh = false)
        {
            lock (_lock)
            {
                // Use cached handle if valid
                if (!forceRefresh && _hwnd != IntPtr.Zero && IsWindow(_hwnd))
                {
                    return _hwnd;
                }

                _hwnd = IntPtr.Zero;

                foreach (Process p in Process.GetProcesses())
                {
                    try
                    {
                        string pname = (p.ProcessName ?? string.Empty).ToLower();
                        string title = (p.MainWindowTitle ?? string.Empty).ToLower();

                        bool isDXLog = false;

                        if (pname.Equals("dxlog") || pname.Equals("dxlog.net"))
                        {
                            isDXLog = true;
                        }
                        else if (title.Contains("dxlog.net"))
                        {
                            isDXLog = true;
                        }
                        else if (title.Contains("dxlog") &&
                                 !title.Contains("helper") &&
                                 !title.Contains("cwexpert") &&
                                 !title.Contains("visual studio"))
                        {
                            isDXLog = true;
                        }

                        if (isDXLog && p.MainWindowHandle != IntPtr.Zero)
                        {
                            _hwnd = p.MainWindowHandle;
                            Debug.WriteLine("DXLogHelper: Found DXLog.net - " + p.MainWindowTitle);
                            break;
                        }
                    }
                    catch { }
                }

                if (_hwnd == IntPtr.Zero)
                {
                    MessageBox.Show("DXLog.net window not found. Please ensure DXLog.net is running.",
                        "DXLogHelper", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                return _hwnd;
            }
        }

        private static bool ActivateWindow()
        {
            if (_hwnd == IntPtr.Zero) return false;
            if (!IsWindow(_hwnd))
            {
                _hwnd = IntPtr.Zero;
                return false;
            }

            ShowWindow(_hwnd, SW_RESTORE);
            SetForegroundWindow(_hwnd);
            Thread.Sleep(50);
            return true;
        }

        /// <summary>
        /// 2) HISCL - Send callsign to DXLog's callsign field and return to start.
        /// ESC ensures we're at callsign field, types callsign, then ESC to reset cursor.
        /// </summary>
        public static bool HISCL(string callsign)
        {
            if (string.IsNullOrEmpty(callsign)) return false;

            lock (_lock)
            {
                if (_hwnd == IntPtr.Zero) Init();
                if (!ActivateWindow()) return false;

                // endKeys.SendWait("{ESC}");
                //Thread.Sleep(30);

                SendKeys.SendWait(callsign);
                Thread.Sleep(50);

                SendKeys.SendWait(" ");

                return true;
            }
        }

        /// <summary>
        /// 3) RPRT - Send report to DXLog. Does NOT press ENTER - operator must confirm.
        /// Sends report string to current field position.
        /// </summary>
        public static bool RPRT(string report)
        {
            if (string.IsNullOrEmpty(report)) return false;

            lock (_lock)
            {
                if (_hwnd == IntPtr.Zero) Init();
                if (!ActivateWindow()) return false;

                SendKeys.SendWait(report);
                SendKeys.SendWait("{ENTER}");

                return true;
            }
        }

        /// <summary>
        /// 4) FXTX - Send function keys F1..F12 to DXLog.net.
        /// </summary>
        public static bool FXTX(string fkey)
        {
            if (string.IsNullOrEmpty(fkey)) return false;

            string normalized = fkey.Trim().ToUpper();
            if (!normalized.StartsWith("F") && int.TryParse(normalized, out int n))
            {
                normalized = "F" + n.ToString();
            }

            if (!int.TryParse(normalized.Substring(1), out int parsed) || parsed < 1 || parsed > 12)
            {
                return false;
            }

            lock (_lock)
            {
                if (_hwnd == IntPtr.Zero) Init();
                if (!ActivateWindow()) return false;

                SendKeys.SendWait("{" + normalized + "}");

                return true;
            }
        }

        public static bool FXTX(int fkeyNumber)
        {
            if (fkeyNumber < 1 || fkeyNumber > 12) return false;
            return FXTX("F" + fkeyNumber.ToString());
        }
    }
}