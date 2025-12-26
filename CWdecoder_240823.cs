//=================================================================
// CWDecoder.cs
//=================================================================
// Copyright (C) 2011 S56A YT7PWR
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
//=================================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

namespace CWExpert
{
    // private DXLogHelper dxlh;
    public class CWDecode
    {
        #region variable

        delegate void CrossThreadCallback(string command, string data);
        delegate void CrossThreadSetText(string command, int channel_no, double thd_txt, string out_txt);

        public bool crc = false;
        public bool qso = false;
        public bool rip = false;  // report in progress!
        public bool logmagn = false;
        public bool hamming = false;
        public bool medijan = false;
        public bool rx_only = false;
        public bool swl = true;
        public bool raem = false;
        public bool once = true;
        public int activech, donja, gornja;
        public int moni = 24;
        public int ponovi = 64;
        public bool repeat = false;
        public int loopend = 0;
        public const int F2L = 256;
        public const int wndw = 64;
        public int ovrlp = F2L / wndw;
        public int logf2l = 0;
        public const int rate = 8000;
        public const int FFTlen = F2L / 2;
        public int aver = 8;
        public double thld = 4.0;
        public int bwl = 8;
        public int bwh = FFTlen / 2 - 1;
        public bool run_thread = false;
        public Thread CWThread;
        public AutoResetEvent AudioEvent;
        public ushort[] audio_buffer;
        public int freq = 0;
        public bool key = false;
        public bool nr_agn = false;
        public bool transmit = false;
        public int serial = 0;
        public string rst = new string(' ', 3);
        public string report = new string(' ', 4);
        public string grid = new string(' ', 8);
        public string call_sent = new string(' ', 14);
        public string call = new string(' ', 14);
        public string mycall = new string(' ', 14);
        public string morsealpha = new string(' ', 28);
        public string morsedigit = new string(' ', 30);
        public string[] scp = new string[50315];
        public string[] output = new string[FFTlen];
        public string[] calls = new string[FFTlen];
        public string[] rprts = new string[FFTlen];
        public int[] sum = new int[FFTlen];
        public int[] ave = new int[FFTlen];
        public double[] Noise = new double[FFTlen];
        public double[] temp = new double[FFTlen];
        public double[] prag = new double[FFTlen];
        public double[] s2nr = new double[FFTlen];
        public double[] RealF = new double[F2L];
        public double[] ImagF = new double[F2L];
        public double[,] Mag = new double[FFTlen, 32];
        public double[,] medo = new double[FFTlen, 5];
        public double[] signal = new double[FFTlen];
        public double[] si = new double[F2L];
        public double[] co = new double[F2L];
        public double[] wd = new double[F2L];
        public int[] tim = new int[FFTlen];
        private double[] thd_txt;
        public int ctr = 0;
        public int tx_timer = 2;
        public int rx_timer = 40;
        public int dotmin = 0;
        public int[] bitrev = new int[F2L];
        public ushort[] old1 = new ushort[F2L];
        public bool[] keyes = new bool[FFTlen];
        public bool[] lids = new bool[FFTlen];
        public bool[] valid = new bool[FFTlen];
        public bool[] enable = new bool[FFTlen];
        public int nofs = 32;
        public int time_out = 0;
        public int watch_dog = 0;
        public string seti = "ETISH*";

        private CWExpert MainForm;

        #endregion

        #region constructor and destructor

        public CWDecode(CWExpert mainForm)
        {
            try
            {
                MainForm = mainForm;
                audio_buffer = new ushort[Audio.BlockSize * 2];
                // average_buffer = new double[Audio.BlockSize * 2];
                thd_txt = new double[FFTlen];
                AudioEvent = new AutoResetEvent(false);
                once = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        ~CWDecode()
        {

        }

        #endregion


        #region crossthread

        private void SetText(string action, int channel, double thd_txt, string text)
        {
            try
            {
                switch (action)
                {
                    case "Set text":
                        MainForm.WriteOutputText(channel, thd_txt, text);
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
            }
        }

        private void CrossThreadCommand(string action, string data)
        {
            try
            {
                if (!rx_only)
                {
                    watch_dog = tx_timer / 2;
                    switch (action)
                    {
                        case "Send CALL":
                            {
                                MainForm.txtCALL = data;
                                MainForm.btnSendCall_Click(null, null);
                            }
                            break;

                        case "Send RST":
                            {
                                MainForm.txtRst = data;
                                MainForm.btnSendRST_Click(null, null);
                            }
                            break;

                        case "Send NR":
                            {
                                MainForm.txtNR = data;
                                MainForm.btnSendNr_Click(null, null);
                            }
                            break;

                        case "Send F1":
                            {
                                MainForm.btnF1_Click(null, null);
                            }
                            break;

                        case "Send F2":
                            {
                                MainForm.btnF2_Click(null, null);
                            }
                            break;

                        case "Send F3":
                            {
                                MainForm.btnF3_Click(null, null);
                            }
                            break;

                        case "Send F4":
                            {
                                MainForm.btnF4_Click(null, null);
                            }
                            break;

                        case "Send F5":
                            {
                                MainForm.btnF5_Click(null, null);
                            }
                            break;

                        case "Send F6":
                            {
                                MainForm.btnF6_Click(null, null);
                            }
                            break;

                        case "Send F7":
                            {
                                MainForm.btnF7_Click(null, null);
                            }
                            break;

                        case "Send F8":
                            {
                                MainForm.btnF8_Click(null, null);
                            }
                            break;

                        case "Send F9":
                            {
                                MainForm.btnF9_Click(null, null);
                            }
                            break;

                        case "Send F10":
                            {
                                MainForm.btnF10_Click(null, null);
                            }
                            break;

                        case "Send F11":
                            {
                                MainForm.btnF11_Click(null, null);
                            }
                            break;

                        case "Send F12":
                            {
                                MainForm.btnF12_Click(null, null);
                            }
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex + "\n\n" + ex.StackTrace.ToString());
            }
        }

        #endregion

        public void CW_Thread()
        {
            try
            {
                while (run_thread)
                {
                    AudioEvent.WaitOne();
                    Spectrum();
                    if (once)
                    {
                        Channel();
                        // Debug.WriteLine(rx_only.ToString());
                    }
                    else if (transmit)
                        TRtiming();
                    else
                    {
                        Sig2ASCII();
                        ctr += nofs;
                        if (!rx_only)
                        {
                            Analyse();
                            Respond();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                run_thread = false;
            }
        }

        public bool CWdecodeStart()
        {
            bool result = false;
            once = true;
            bwl = 8;
            bwh = FFTlen / 2 - 1;

            if (Init())
            {
                run_thread = true;
                CWThread = new Thread(new ThreadStart(CW_Thread));
                CWThread.Name = "CW Thread";
                CWThread.Priority = ThreadPriority.Normal;
                CWThread.IsBackground = true;
                CWThread.Start();
            }
            return result;
        }

        public void CWdecodeStop()
        {
            try
            {
                run_thread = false;
                AudioEvent.Set();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
            }
        }

        public bool Init()
        {
            try
            {

                int n, n1, w, x, y, z;

                logf2l = (int)(Math.Round(Math.Log(F2L) / Math.Log(2.0)));
                for (n = 0; n < F2L; n++)
                {
                    x = n;
                    y = 0;
                    n1 = F2L;
                    for (w = 1; w <= logf2l; w++)
                    {
                        n1 = n1 >> 1;
                        if (x >= n1)
                        {
                            if (w == 1)
                                y++;
                            else
                                y = y + (2 << (w - 2));
                            x = x - n1;
                        }
                    }
                    bitrev[n] = (byte)y;
                }

                ovrlp = F2L / wndw;
                nofs = Audio.BlockSize / wndw; // number of overlaped segments
                dotmin = (int)Math.Round(1.2 * rate / (36 * wndw));
                aver = (int)Math.Round(1.2 * 2 * rate / (27 * wndw));
                morsealpha = "ETIANMSURWDKGOHVF*L*PJBXCYZQ";
                morsedigit = "54*3***2*******16*/*****7***8*90";

                for (n = 0; n < FFTlen; n++)
                {
                    prag[n] = 2 * thld;
                    Noise[n] = thld;
                    temp[n] = 0;
                    ave[n] = aver;
                    sum[n] = 0;
                    tim[n] = 1;
                    lids[n] = false;
                    enable[n] = false;
                    keyes[n] = false;
                    valid[n] = false;
                    output[n] = String.Empty;
                    calls[n] = String.Empty;
                    rprts[n] = String.Empty;
                    for (z = 0; z < 5; z++)
                        medo[n, z] = Noise[n];
                }

                double v = 2 * Math.PI / F2L;
                for (n = 0; n < F2L; n++)
                {
                    old1[n] = 0;
                    RealF[n] = 0;
                    ImagF[n] = 0;
                    si[n] = -Math.Sin(n * v);
                    co[n] = Math.Cos(n * v);
                    if (hamming)
                        wd[n] = (0.54 - 0.46 * co[n]) / F2L;
                    else
                        wd[n] = 1.0 / F2L;
                }
                mycall = MainForm.SetupForm.txtCALL.Text;
                call_sent = mycall;
                nr_agn = false;
                tx_timer = ponovi;
                rx_timer = ponovi / 4;  //  few seconds channel profiling
                transmit = false;
                serial = 1;
                repeat = false;
                SCP_Load();
                return true;
            }

            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                return false;
            }
        }


        // Call DXLogHelper to send callsign to DXLog (SWL mode: only HISCL, no RPRT)
        public void HisCall(string call)
        {
            if (MainForm.InvokeRequired)
                MainForm.Invoke(new MethodInvoker(delegate { DXLogHelper.HISCL(call); }));
            else
                DXLogHelper.HISCL(call);
            raem = DXLogHelper.rame;
        }

        public void DXLRaport(string rst)
        {
            DXLogHelper.RPRT(rst);
        }

  	public void FXcommand(string Fkey)
        {
            DXLogHelper.FXTX(Fkey);
        }



        private void SCP_Load()
        {
            int counter = 0;
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader("Master.scp");

            while ((line = file.ReadLine()) != null)
            {
                if (!line.StartsWith("#"))
                {
                    scp[counter] = line;
                    counter++;
                }
            }
            file.Close();
            Array.Sort(scp);
           
            Debug.WriteLine("SCP " + counter.ToString());
        }

        private void cw2asc(int z)
        {
            char ch = '*';
            int i = sum[z];
            if (i < 29) { ch = morsealpha[i - 1]; }
            else if (i >= 31 && i <= 62)
            {
                ch = morsedigit[i - 31];
                if (Char.IsDigit(ch))
                {
                    valid[z] = true;
                    if (qso)
                    {
                        if (activech == z) { rx_timer = ponovi; }
                    }
                      else if (!ch.Equals('5')) { rx_timer = ponovi; }
                }
            }
            else if (i == 75) { ch = '?'; }
            output[z] += ch;
            sum[z] = 0;
        }


        private void Channel()
        {
            int n = 0;

            for (n = bwl; n < bwh; n++)
                temp[n] += signal[n];
            if (transmit)
            {
                tx_timer--;
                if (tx_timer == 1)
                {
                    thld = 0;
                    for (n = bwl; n <= bwh; n++)
                    {
                        tim[n] = 1;
                        if (temp[n] > thld)
                        {
                            thld = temp[n];
                            moni = n;
                        }
                    }

                    bwl = moni / 2;
                    bwh = bwl + moni;

                    Debug.Write("  " + bwl + "  " + moni.ToString() + "  " + bwh);
                    for (n = bwl; n <= bwh; n++)
                        MainForm.Invoke(new CrossThreadSetText(SetText), "Set text", n, Noise[n], " ");
                    once = false;
                    ctr = 0;
                }
            }
            else
            {
                rx_timer--;
                if (rx_timer == 0)
                {
                    thld = 0;
                    for (n = bwl; n <= bwh; n++)
                    {
                        temp[n] = 4 * temp[n] / ponovi;
                        thld += temp[n];
                    }
                    thld /= bwh - bwl + 1;
                    // thld = 2 * thld;
                    for (n = bwl; n <= bwh; n++)
                    {
                        Noise[n] = 2 * temp[n];
                        if (Noise[n] < thld)
                            Noise[n] = thld;
                        temp[n] = 0;
                    }
                    cqcqcq();
                }
            }
        }

        private void Sig2ASCII()
        {
            try
            {
                for (int z = bwl; z <= bwh; z++)
                {
                    for (int n = 0; n < nofs; n++)
                    {
                        int t = n + ctr - tim[z];
                        if (Mag[z, n] > prag[z])
                            key = true;
                        else
                            key = false;
                        if (key != keyes[z])
                        {
                            keyes[z] = key;
                            tim[z] = n + ctr;
                        
                            if (!key)
                            {
                                if (t > ave[z]) { sum[z]++; }
                                sum[z]++;
                            }
                            else if (t < ave[z])
                            {
                                sum[z] = 2 * sum[z];
                                if (sum[z] > 75) { sum[z] = 0; }
                            }
                        }
                        else if (!key && t % ave[z] == 0)
                        {
                            if (t == ave[z])
                            {
                                if (sum[z] > 0)
                                    cw2asc(z);
                                enable[z] = false;
                            }
                            else if (t == 2 * ave[z])
                            {
                                if (rx_only)
                                {
                                    Debug.Write(z.ToString() + output[z]);
                                    output[z] = string.Empty;
                                }
                                else if (output[z].Length < 3)
                                {
                                    output[z] = string.Empty;
                                    valid[z] = false;
                                }
                                else
                                {
                                    output[z] += " ";
                                    enable[z] = false;
                                }
                            }
                            else if (t == 3 * ave[z]) 
                            {
                                //if (lids[z])
                                //{
                                //  lids[z] = false;
                                //    for (int i = z - 1; i <= z + 1; i++)
                                //    {
                                //        calls[i] = string.Empty;
                                //        enable[i] = false;
                                //    }
                                //}
                                //else
                                    enable[z] = true;
                                if (rx_only)
                                    Debug.WriteLine(" ");
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                run_thread = false;
            }
        }


        private void MyFFT()
        {
            int i, k, m, mx, I1, I2, I3, I4, I5, x;
            double A1, A2, B1, B2, Z1, Z2;

            I1 = F2L / 2;
            I2 = 1;
            for (i = 1; i <= logf2l; i++)
            {
                I3 = 0;
                I4 = I1;
                for (k = 1; k <= I2; k++)
                {
                    x = I3 / I1;
                    I5 = bitrev[x];
                    Z1 = co[I5];
                    Z2 = si[I5];
                    loopend = I4 - 1;
                    for (m = I3; m <= loopend; m++)
                    {
                        A1 = RealF[m];
                        A2 = ImagF[m];
                        mx = m + I1;
                        B1 = Z1 * RealF[mx] - Z2 * ImagF[mx];
                        B2 = Z2 * RealF[mx] + Z1 * ImagF[mx];
                        RealF[m] = (A1 + B1);
                        ImagF[m] = (A2 + B2);
                        RealF[mx] = (A1 - B1);
                        ImagF[mx] = (A2 - B2);
                    }
                    I3 = I3 + (I1 << 1);
                    I4 = I4 + (I1 << 1);
                }
                I1 = I1 >> 1;
                I2 = I2 << 1;
            }
        }


        private double Median(double mag, int z)
        {
            const int len = 4;
            double[] srt = new double[len + 1];

            for (int i = 0; i < len; i++)
            {
                medo[z, i] = medo[z, i + 1];
                srt[i] = medo[z, i];
            }
            medo[z, len] = mag;
            srt[len] = mag;
            Array.Sort(srt);
            return srt[len / 2];
        }


        private void Spectrum()
        {
            try
            {
                int n = 0;
                int z = 0;
                int i = 0;

                for (n = bwl - 1; n <= bwh + 1; n++)
                    signal[n] = 0;

                while (z < nofs)
                {
                    if (z < ovrlp - 1)
                    {
                        int bp = wndw * (ovrlp - z - 1);
                        for (n = 0; n < F2L; n++)
                        {
                            ImagF[n] = 0;
                            if (n < bp)
                                RealF[n] = wd[n] * (short)old1[n + (z * wndw)];
                            else
                                RealF[n] = wd[n] * (short)audio_buffer[n - bp];
                        }
                    }
                    else
                    {
                        for (n = 0; n < F2L; n++)
                        {
                            ImagF[n] = 0;
                            RealF[n] = wd[n] * (short)audio_buffer[i + n];
                        }
                        i += wndw;
                    }

                    MyFFT();

                    for (n = bwl - 1; n <= bwh + 1; n++)
                    {
                        int y = bitrev[n];
                        Mag[n, z] = Math.Sqrt(RealF[y] * RealF[y] + ImagF[y] * ImagF[y]);
                        if (medijan)
                            Mag[n, z] = Median(Mag[n, z], n);
                        if (logmagn)
                        {
                            if (Mag[n, z] > 0.001)
                                Mag[n, z] = Math.Log10(Mag[n, z]);
                        }
                        signal[n] += Mag[n, z] / nofs;
                    }
                    z++;
                }

                for (n = 0; n < (ovrlp - 1) * wndw; n++)  // Save last 3 x  64 samples
                    old1[n] = audio_buffer[i + n];

                for (n = bwl; n <= bwh; n++)
                {
                    prag[n] = (4 * prag[n] + 2 * signal[n] + signal[n - 1] + signal[n + 1]) / 8;
                    if (prag[n] < 2 * Noise[n])
                        prag[n] = 2 * Noise[n];

                    // double v = signal[n] / Noise[n];
                    //if (v > s2nr[n])
                    //    s2nr[n] = v;

                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
            }
        }

        private bool IsCall(string s)
        {
            if (s != "" && Array.BinarySearch(scp, s) >= 0)
                return true;
            else
                return false;
        }


        private bool IsRprt(string s)
        {
            string[] validRst = { "589", "579", "569", "559" };
            rst = Array.Find(validRst, r => s.Contains(r)) ?? "599";

            int i = s.IndexOf(rst);

            if (i < 0)
            {
                int k = s.IndexOf("99");
                int l = s.IndexOf("59");
                int m = s.IndexOf("9");

                if (k > 0)
                    i = k - 1;
                else if (l >= 0)
                    i = l;
                else if (m >= 0 && m < s.Length - 3)
                    s = s.Remove(0, m + 1);
                else
                {
                    while (s != "" && !char.IsDigit(s[s.Length - 1]))
                        s = s.Remove(s.Length - 1, 1);

                    while (s != "" && !char.IsDigit(s[0]))
                        s = s.Remove(0, 1);
                }
            }

            if (i >= 0)
               rip = true;

            int j = s.Length;
            string remainder = "";

            if (i < 0)
                remainder = s;
            else if (j > (i + 3))
            {
                remainder = s.Substring((i + 3), j - i - 3);
            }

            grid = "";
            
            if (raem && remainder.Length > 3)
            {
                string gridPart = ExtractGrid(remainder);
                if (gridPart.Length > 0)
                {
                    grid = gridPart;
                    remainder = remainder.Replace(gridPart, "").Trim();
                }
            }
            
            if (remainder.Length > 3)
                remainder = remainder.Substring(0, 3);

            report = remainder;

            if (report.Length > 1 && !report[0].Equals('5'))
                return IsNmbr(report);
            else
                return false;
        }

        private string ExtractGrid(string s)
        {
            Regex gridRegex = new Regex(@"(\d{2}[NS]\d{2,3}[EOW])", RegexOptions.IgnoreCase);
            Match match = gridRegex.Match(s);
            
            if (match.Success)
            {
                string gridStr = match.Value.ToUpper();
                
                int lat = int.Parse(gridStr.Substring(0, 2));
                char nsDir = gridStr[2];
                
                int lonEndIdx = gridStr.IndexOfAny(new char[] { 'E', 'O', 'W' });
                int lon = int.Parse(gridStr.Substring(3, lonEndIdx - 3));
                char ewDir = gridStr[lonEndIdx];
                
                if (lat >= 0 && lat <= 90 && lon >= 0 && lon <= 180)
                {
                    return gridStr;
                }
            }
            
            return "";
        }


        private bool IsNmbr(string nrs)
        {
            int nr = 0;

            bool rt = Int32.TryParse(nrs, out nr);

            if (rt)
            {
                if (nr > 10000 || nr == 0)
                    rt = false;
            }
            return rt;
        }

        private bool Report_Filter(string stev)
        {
            if (stev.IndexOf("EEEEE") > 3)
                stev = stev.Remove(stev.IndexOf("EEEEE") - 3, 8);

            if (stev.StartsWith("R"))
                stev = stev.Remove(0, 1);
                
            if (stev.StartsWith("TU"))
                stev = stev.Remove(0, 2);
                
            if (stev.StartsWith("5NN"))
                stev = stev.Remove(0, 3);
            else if (stev.StartsWith("ENN"))
                stev = stev.Remove(0, 3);
            else if (stev.StartsWith("NN"))
                stev = stev.Remove(0, 2);
            else if (stev.StartsWith("NTT"))
                stev = stev.Remove(0, 1);

            stev = stev.Replace("E", "5");
            stev = stev.Replace("N", "9");
            stev = stev.Replace("O", "0");
            stev = stev.Replace("T", "0");
            stev = stev.Replace("A", "1");

            if (stev.Length == 12 && Doubled(stev))
                stev = stev.Substring(0, 6);

            return IsRprt(stev);
        }

        private bool regex_check(String testValue)
        {
            Regex _rgx = new Regex("[ETIANSH5]");
            return (_rgx.Matches(testValue).Count == testValue.Length);
        }

        private bool similar(String testValue)
        {
            Regex _rgx = new Regex(call_sent);
            return (_rgx.Matches(testValue).Count >= testValue.Length / 2);
        }

        private bool Call_Filter(string clsn)
        {
            bool cf = false;
            int j = 0;

            if (clsn.StartsWith("DE"))
            {
                crc = true;
                clsn = clsn.Remove(0, 2);
                // Debug.WriteLine("correction");
            }

            if ((((clsn.Length) % 2) == 0) && (clsn.Length > 5) && Doubled(clsn))
                clsn = clsn.Substring(clsn.Length / 2, clsn.Length / 2);

            if (clsn.Length >= 3)
            {
                j = Array.BinarySearch(scp, clsn);

                if (j >= 0)
                {
                    Debug.WriteLine(scp[j]);
                    cf = true;
                }
                else if (clsn.Length > 7)
                {
                    string cl = clsn.Substring(0, clsn.Length / 2);
                    j = Array.BinarySearch(scp, cl);
                    if (j >= 0)
                    {
                        Debug.WriteLine("<" + scp[j]);
                        clsn = cl;
                        cf = true;
                    }
                    else
                    {
                        cl = clsn.Substring(clsn.Length / 2, clsn.Length - clsn.Length / 2);
                        j = Array.BinarySearch(scp, cl);
                        if (j >= 0)
                        {
                            Debug.WriteLine(">" + scp[j]);
                            clsn = cl;
                            cf = true;
                        }
                    }
                }

                if (!cf)
                {
                    while (clsn != "" && seti.IndexOf(clsn[0]) >= 0)
                        clsn = clsn.Remove(0, 1);

                    while (clsn != "" && seti.IndexOf(clsn[clsn.Length - 1]) >= 0)
                        clsn = clsn.Remove(clsn.Length - 1, 1);

                    if (clsn.Length >= 3)
                    {
                        j = Array.BinarySearch(scp, clsn);
                        if (j >= 0)
                        {
                            Debug.WriteLine("!" + scp[j]);
                            cf = true;
                        }
                    }
                }
            }

            if (cf)
            {
                if (Equals(clsn,mycall))
                    cf = false;
                else
                    call = clsn;
            }

            return cf;
        }


        private bool Doubled(string mystr0)
        {
            string s1 = mystr0.Substring(0, mystr0.Length / 2);
            string s2 = mystr0.Substring(mystr0.Length / 2, mystr0.Length / 2);
            if (s1.Equals(s2))
                return true;
            else
                return false;
        }

        private void Analyse()
        {
            for (int z = bwl; z <= bwh; z++)
            {
                if (output[z].Contains(" "))
                {
                    // double v = 0.0;
                    s2nr[z] = prag[z] / Noise[z]; 
                    MainForm.Invoke(new CrossThreadSetText(SetText), "Set text", z, s2nr[z], output[z]);
                    if (output[z].Contains("R?") || output[z].Contains("AGN"))
                        nr_agn = true;
                    // else if (output[z].Contains("CQCQ") || output[z].Contains("TEST") || output[z].Contains("QRL?"))
                    //    lids[z] = true;
                    // else if (output[z].Contains("DE"))
                    // crc = true;
                    else if (valid[z] && output[z].Length > 3)
                    {
                        // s2nr[z] = v;  // (double)prag[z] / Noise[z];
                        string mystr = output[z].Substring(0, output[z].IndexOf(" "));

                        int i = mystr.IndexOf("5NN");

                        if (i < 0)
                            i = mystr.IndexOf("ENN");
                            
                        if (i < 0)
                            i = mystr.IndexOf("NN");
                            
                        if (i < 0)
                            i = mystr.IndexOf("NTT");

                        if (i >= 3)
                        {
                            if (Call_Filter(mystr.Substring(0, i)))
                                calls[z] = call;
                            if (Report_Filter(mystr.Substring(i, mystr.Length - i)))
                                rprts[z] = rst + report + (grid.Length > 0 ? " " + grid : "");
                        }
                        else
                        {
                            if (Report_Filter(mystr))
                                rprts[z] = rst + report + (grid.Length > 0 ? " " + grid : "");
                            if (i < 0 && Call_Filter(mystr))
                                calls[z] = call;
                        }
                    }
                    output[z] = string.Empty;
                    valid[z] = false;
                }
            }
        }


        public int f2len()
        {
            string snr;

            if (serial >= 1000)
                snr = serial.ToString();
            else
                snr = serial.ToString("000");

            snr = snr.Replace('0', 'T');
            snr = snr.Replace('9', 'N');

            return dots(" 5NN" + snr);
        }


        public int dots(String message)
        {
            int[] cwnrs = { 22, 20, 18, 16, 14, 12, 14, 16, 18, 20 };
            int[] cwltr = { 8, 12, 14, 10, 4, 12, 12, 10, 6, 16, 12, 12, 10, 8, 14, 14, 16, 10, 8, 6, 10, 12, 12, 14, 16, 14 };

            int i = 0;
            int tx_len = 0;

            transmit = true;
            rx_timer = ponovi - 1;
            watch_dog = tx_timer / 2;

            while (i < message.Length)
            {
                Char c = message[i];
                if (Char.IsLetter(c))
                    tx_len += cwltr[c.CompareTo('A')];
                else if (Char.IsDigit(c))
                    tx_len += cwnrs[c.CompareTo('0')];
                else if (c.Equals(' ')) 
                    tx_len += 4;
                else if (c.Equals('/'))
                    tx_len += 16;
                else if (c.Equals('?'))
                    tx_len += 18;
                else if (!c.Equals('*'))
                    Debug.Write(".");
                i++;
            }
            return (tx_len * aver / (2 * nofs));
        }


        private void TRtiming()
        {
            try
            {
                bool eot = false;

                if (tx_timer > 0)
                {
                    tx_timer--;
                    if (tx_timer == watch_dog && watch_dog > 5)
                    {
                        if (prag[moni] < 2 * Noise[moni])
                        {
                            Debug.WriteLine(" No monitor? ");
                        }
                    }
                }

                // Check for end of transmission (silence)
                for (int n = 0; n < nofs; n++)
                {
                    if (Mag[moni,n] > 2 * Noise[moni])
                        time_out = 0;
                    else
                    {
                        time_out++;
                    if (time_out > 2 * aver)  // CORRECT - waits for proper silence
                    {
                        eot = true;
                        // Debug.WriteLine($" RX ch={activech} eot={eot} timeout={time_out}");
                        time_out = 0;  // Reset for next TX cycle
                    }
                }
            }

                // Switch to RX when timer expires OR extended silence detected
                if (tx_timer == 0 && eot)  // CORRECT - both conditions required!
                {
                    if (activech > 0)
                    {
                        for (int n = activech - 1; n <= activech + 1; n++)
                        {
                            calls[n] = String.Empty;
                            enable[n] = false;
                        }
                    }

                    for (int n = bwl; n <= bwh; n++)
                    {
                        output[n] = String.Empty;
                        rprts[n] = String.Empty;
                        prag[n] = 2 * Noise[n];
                        valid[n] = false;
                        ave[n] = aver;
                    }
            
                    tx_timer = ponovi;
                    rx_timer = ponovi;
                    transmit = false;
                    time_out = 0;  // Reset for next TX cycle
                    eot = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cqcqcq()
        {
            if (!rx_only)
            {
                tx_timer = dots(mycall) + dots(" TEST");
                MainForm.Invoke(new CrossThreadCallback(CrossThreadCommand), "Send CALL", "");
                Debug.Write(" CQ " + tx_timer.ToString());
            }
            repeat = false;
            qso = false;
            rip = false;
        }

        private void Boundaries()
        {
            if (qso && activech > bwl)
            {
                donja = activech - 1;
                gornja = activech + 1;
            }
            else
            {
                donja = bwl;
                gornja = bwh;
            }
        }

        private bool CallAvail()
        {
            double max = 1;
            bool cf = false;

            Boundaries();

            for (int z = donja; z <= gornja; z++)
            {
                if (enable[z] && calls[z].Length > 2 && s2nr[z] > max)
                {
                    cf = true;
                    call = calls[z];
                    activech = z;
                    max = s2nr[z];
                }
            }
            return cf;
        }

        private bool RprtAvail()
        {
            double max = 1;
            bool rf = false;

            Boundaries();

            for (int z = donja; z <= gornja; z++)
            {
                if (enable[z] && rprts[z].Length > 0 && s2nr[z] > max)
                {
                    freq = z;
                    rf = true;
                    rst = rprts[z].Substring(0, 3);
                    report = rprts[z].Substring(3, rprts[z].Length - 3);  // 9A DX
                    max = s2nr[z];
                }
            }
            return rf;
        }

        private bool Silence()
        {
            bool quiet = true;

            Boundaries();

            for (int n = donja; n <= gornja; n++)
            {
                if (prag[n] > 2 * Noise[n]) { quiet = false; }
            }

            return quiet;
        }

        public void SendExch()
        {
            tx_timer = dots(call_sent) + f2len();
            MainForm.Invoke(new CrossThreadCallback(CrossThreadCommand), "Send F5", "");
            MainForm.Invoke(new CrossThreadCallback(CrossThreadCommand), "Send F2", "");
            Debug.Write(" Exch " + tx_timer.ToString());
        }

        public void SendReport()
        {
            //            tx_timer = f2len();
          
            MainForm.Invoke(new CrossThreadCallback(CrossThreadCommand), "Send F2", "");
            Debug.Write(" Rprt " + tx_timer.ToString());
        }

        public void ClearMR()
        {
            MainForm.Invoke(new CrossThreadCallback(CrossThreadCommand), "Send F11", "");
            Debug.WriteLine(" Clear ");
        }

        public void SendQuest()
        {
            tx_timer = dots("?");
            MainForm.Invoke(new CrossThreadCallback(CrossThreadCommand), "Send F7", "");
            Debug.Write(" ? " + tx_timer.ToString());
        }

        public void SendCall()
        {
            call_sent = call;
            calls[activech] = String.Empty;
            enable[activech] = false;

            if (!rx_only)
            {
                tx_timer = dots(call) + f2len();
                MainForm.Invoke(new CrossThreadCallback(CrossThreadCommand), "Send CALL", call);
                MainForm.Invoke(new CrossThreadCallback(CrossThreadCommand), "Send RST", rst);
                Debug.Write(activech.ToString() + " Call " + tx_timer.ToString());
            }

            MainForm.Invoke(new CrossThreadSetText(SetText), "Set text", activech, prag[activech] / Noise[activech] , call);

            // Send callsign to DXLog (always, even in SWL mode)
            HisCall(call);
        }

        public void SendTU()
        {   
            rprts[activech] = String.Empty;
            enable[activech] = false;

            if (!rx_only)
            {
                MainForm.Invoke(new CrossThreadCallback(CrossThreadCommand), "Send RST", rst);
                MainForm.Invoke(new CrossThreadCallback(CrossThreadCommand), "Send NR", report);
                
                if (qso)
                {
                    serial++;
                    Debug.Write(" Log #" + (serial - 1).ToString() + " " + tx_timer.ToString());
                }
                
                if (swl)
                    DXLogHelper.RPRT(report);
            }
            // SWL mode: send report to DXLog
        }


        private void Respond()
        {
            try
            {
                bool any_call = CallAvail();
                bool report_rcvd = RprtAvail();

                if (rx_timer > 0)
                    rx_timer--;

                if (!qso)
                {
                    /*
                    if (report_rcvd && (freq == activech))
                    {
                        tx_timer = dots("TU");
                        SendTU();
                    }
                    else 
                    */
                    if (any_call)
                    {
                        tx_timer = dots(call) + f2len();
                        SendCall();
                        if (!regex_check(call) && call.Length >= 3)
                            repeat = true;
                        qso = true;
                    }
                    else
                    {
                        if (Silence() && (rx_timer % (ponovi / 4) == 0))
                            cqcqcq(); // MMM
                    }

                }
                else // QSO state
                {
                    if (nr_agn)
                    {
                        nr_agn = false;
                        tx_timer = f2len();
                        SendReport();
                    }
                    else if (report_rcvd)
                    {
                        if (tx_timer == ponovi) tx_timer = dots("TU");
                        SendTU();
                        rip = false;
                        qso = false;
                        repeat = false;
                    }
                    else if (any_call)
                    {
                        if (call_sent.Equals(call) || (!call_sent.Contains(call) && !regex_check(call)))
                        {
                            tx_timer = dots(call);
                            SendCall();
                            if (!report_rcvd)
                            {
                                tx_timer += f2len();
                                SendReport();
                                repeat = true;
                            }

                        }
                    }
                    else if (Silence() && (rx_timer % (ponovi / 4) == 0))
                    {
                        if (repeat && !rip)
                        {
                            SendExch();
                            repeat = false;
                        }
                        else if (rip)
                        {
                            rip = false;
                            SendQuest();
                        }
                        else if (!report_rcvd)
                            qso = false;
                    }
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
