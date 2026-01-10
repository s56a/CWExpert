//=================================================================
// AudioMR.cs
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
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
//=================================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace CWExpert
{
    unsafe class Audio
    {
        [DllImport("msvcrt.dll", EntryPoint = "memcpy")]
        public static extern void memcpy(void* destptr, void* srcptr, int n);

//      public static extern void Copy(Array ulaz, Array izlaz, int n);

        #region variable

        unsafe private static PA19.PaStreamCallback callback = new PA19.PaStreamCallback(Callback);
        unsafe private static void* stream1;
        unsafe private static void* stream2;

        public static int callback_return = 0;
        public static CWExpert MainForm = null;

        #endregion

        #region properties

        private static int host = 0;
        public static int Host
        {
            set { host = value; }
        }

        private static int block_size = 1024;
        public static int BlockSize
        {
            get { return block_size; }
            set { block_size = value; }
        }

        private static int sample_rate = 8000;
        public static int SampleRate
        {
            get { return sample_rate; }
            set { sample_rate = value; }
        }

        private static int input_dev = 0;
        public static int Input
        {
            set { input_dev = value; }
        }

        private static int output_dev = 0;
        public static int Output
        {
            set { output_dev = value; }
        }

        private static int latency = 50;
        public static int Latency
        {
            get { return latency; }
            set { latency = value; }
        }

        private static int num_channels = 2;
        public static int NumChannels
        {
            set { num_channels = value; }
        }

        #endregion

        private static bool paInitialized = false;

        #region PortAudio Initialization/Termination

        /// <summary>
        /// Initialize the PortAudio library. Must be called before any other PortAudio functions.
        /// </summary>
        /// <returns>True if initialization was successful, false otherwise</returns>
        public static bool Initialize()
        {
            if (paInitialized)
                return true;

            try
            {
                int error = PA19.PA_Initialize();
                if (error != 0)
                {
                    MessageBox.Show(PA19.PA_GetErrorText(error), "PortAudio Initialization Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                paInitialized = true;
                Debug.WriteLine("PortAudio initialized successfully");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to initialize PortAudio!\n" + ex.ToString(),
                    "PortAudio Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Terminate the PortAudio library. Should be called when done using audio.
        /// </summary>
        public static void Terminate()
        {
            if (!paInitialized)
                return;

            try
            {
                if (stream1 != null)
                {
                    PA19.PA_AbortStream(stream1);
                    PA19.PA_CloseStream(stream1);
                    stream1 = null;
                }

                if (stream2 != null)
                {
                    PA19.PA_AbortStream(stream2);
                    PA19.PA_CloseStream(stream2);
                    stream2 = null;
                }

                int error = PA19.PA_Terminate();
                if (error != 0)
                {
                    Debug.WriteLine("PortAudio Terminate error: " + PA19.PA_GetErrorText(error));
                }

                paInitialized = false;
                Debug.WriteLine("PortAudio terminated");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error terminating PortAudio: " + ex.ToString());
            }
        }

        #endregion

        #region misc function

        unsafe public static int Callback(void* input, void* output, int frameCount,
            PA19.PaStreamCallbackTimeInfo* timeInfo, int statusFlags, void* userData)
        {
            try
            {
                int* array_ptr = (int*)input;
                ushort* in_l_ptr1 = (ushort*)array_ptr[0];
                ushort* in_r_ptr1 = (ushort*)array_ptr[1];
                array_ptr = (int*)output;
                ushort* out_l_ptr1 = (ushort*)array_ptr[1];
                ushort* out_r_ptr1 = (ushort*)array_ptr[0];

                for (int i = 0; i < frameCount; i++)
                {
                    out_l_ptr1[0] = in_l_ptr1[0];
                    out_r_ptr1[0] = in_r_ptr1[0];
                    out_l_ptr1++;
                    out_r_ptr1++;
                    in_l_ptr1++;
                    in_r_ptr1++;
                }

                array_ptr = (int*)input;
                in_l_ptr1 = (ushort*)array_ptr[0];
                in_r_ptr1 = (ushort*)array_ptr[1];

                ushort[] buffer = new ushort[frameCount * 2];

                for (int i = 0; i < frameCount; i++)
                {
                    buffer[i] = in_l_ptr1[0];
                    buffer[i+frameCount] = in_r_ptr1[0];
                    buffer[frameCount + i] = 0;
                    in_l_ptr1++;
                    in_r_ptr1++;
                }

                if (MainForm.cwDecoder.audio_buffer != null &&
                    MainForm.cwDecoder.audio_buffer.Length == frameCount * 2)
                {

                    Array.Copy(buffer, MainForm.cwDecoder.audio_buffer, frameCount * 2);
                }

                MainForm.cwDecoder.AudioEvent.Set();

                return callback_return;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                return 0;
            }
        }

        public static bool Start()
        {
            try
            {
                if (!paInitialized && !Initialize())
                {
                    return false;
                }

                bool retval = StartAudio(ref callback, (uint)block_size, sample_rate,
                    host, input_dev, output_dev, num_channels, 0, latency);
                return retval;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error starting audio stream!\n" + ex.ToString());
                return false;
            }
        }

        public unsafe static bool StartAudio(ref PA19.PaStreamCallback callback,
            uint block_size, double sample_rate, int host_api_index, int input_dev_index,
            int output_dev_index, int num_channels, int callback_num, int latency_ms)
        {
            try
            {
                Debug.WriteLine("=== StartAudio (MR) Diagnostics ===");
                Debug.WriteLine("Parameters: BlockSize=" + block_size + ", SampleRate=" + sample_rate + 
                              ", Channels=" + num_channels + ", Latency=" + latency_ms + "ms");
                Debug.WriteLine("Host API Index: " + host_api_index);
                Debug.WriteLine("Input Device Index: " + input_dev_index + ", Output Device Index: " + output_dev_index);
                
                int in_dev = PA19.PA_HostApiDeviceIndexToDeviceIndex(host_api_index, input_dev_index);
                int out_dev = PA19.PA_HostApiDeviceIndexToDeviceIndex(host_api_index, output_dev_index);
                
                Debug.WriteLine("Resolved Device IDs: Input=" + in_dev + ", Output=" + out_dev);
                
                // Log device information
                try
                {
                    PA19.PaDeviceInfo inDevInfo = PA19.PA_GetDeviceInfo(in_dev);
                    Debug.WriteLine("Input Device: " + inDevInfo.name + " (Max Channels: " + inDevInfo.maxInputChannels + ")");
                    
                    PA19.PaDeviceInfo outDevInfo = PA19.PA_GetDeviceInfo(out_dev);
                    Debug.WriteLine("Output Device: " + outDevInfo.name + " (Max Channels: " + outDevInfo.maxOutputChannels + ")");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Warning: Could not retrieve device info: " + ex.Message);
                }

                PA19.PaStreamParameters inparam = new PA19.PaStreamParameters();
                PA19.PaStreamParameters outparam = new PA19.PaStreamParameters();

                inparam.device = in_dev;
                inparam.channelCount = num_channels;
                inparam.sampleFormat = PA19.paInt16 | PA19.paNonInterleaved;
                inparam.suggestedLatency = ((float)latency_ms / 1000);

                outparam.device = out_dev;
                outparam.channelCount = num_channels;
                outparam.sampleFormat = PA19.paInt16 | PA19.paNonInterleaved;
                outparam.suggestedLatency = ((float)latency_ms / 1000);

                if (host_api_index == PA19.PA_HostApiTypeIdToHostApiIndex(PA19.PaHostApiTypeId.paWASAPI))
                {
                    Debug.WriteLine("Using WASAPI host API - configuring stream info");
                    PA19.PaWasapiStreamInfo stream_info = new PA19.PaWasapiStreamInfo();
                    stream_info.hostApiType = PA19.PaHostApiTypeId.paWASAPI;
                    stream_info.version = 1;
                    stream_info.size = (UInt32)sizeof(PA19.PaWasapiStreamInfo);
                    inparam.hostApiSpecificStreamInfo = &stream_info;
                    outparam.hostApiSpecificStreamInfo = &stream_info;
                }

                Debug.WriteLine("Opening audio stream (callback #" + callback_num + ")...");
                int error = 0;
                if (callback_num == 0)
                    error = PA19.PA_OpenStream(out stream1, &inparam, &outparam, sample_rate, block_size, 0, callback, 0, 0);
                else
                    error = PA19.PA_OpenStream(out stream2, &inparam, &outparam, sample_rate, block_size, 0, callback, 0, 1);

                if (error != 0)
                {
                    string errorText = PA19.PA_GetErrorText(error);
                    Debug.WriteLine("PA_OpenStream failed with error: " + error + " (" + errorText + ")");
                    
                    // Try to get host error info
                    try
                    {
                        PA19.PaHostErrorInfo hostError = PA19.PA_GetLastHostErrorInfo();
                        Debug.WriteLine("Host API Error - Type: " + hostError.hostApiType + 
                                      ", Code: " + hostError.errorCode + 
                                      ", Text: " + hostError.errorText);
                    }
                    catch
                    {
                        Debug.WriteLine("Could not retrieve host error info");
                    }
                    
                    MessageBox.Show("Failed to open audio stream!\n\n" +
                                  "Error Code: " + error + "\n" +
                                  "Error: " + errorText + "\n\n" +
                                  "Check Debug output for detailed diagnostics.",
                                  "PortAudio Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                Debug.WriteLine("Audio stream opened successfully");
                Debug.WriteLine("Starting audio stream...");
                
                if (callback_num == 0)
                    error = PA19.PA_StartStream(stream1);
                else
                    error = PA19.PA_StartStream(stream2);

                if (error != 0)
                {
                    string errorText = PA19.PA_GetErrorText(error);
                    Debug.WriteLine("PA_StartStream failed with error: " + error + " (" + errorText + ")");
                    
                    MessageBox.Show("Failed to start audio stream!\n\n" +
                                  "Error Code: " + error + "\n" +
                                  "Error: " + errorText + "\n\n" +
                                  "Check Debug output for detailed diagnostics.",
                                  "PortAudio Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                
                Debug.WriteLine("Audio stream started successfully!");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception in StartAudio: " + ex.ToString());
                MessageBox.Show("Error in StartAudio function!\n\n" + 
                              "Exception: " + ex.GetType().Name + "\n" +
                              "Message: " + ex.Message + "\n\n" +
                              "See Debug output for stack trace.",
                              "Audio Start Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public unsafe static void StopAudio()
        {
            PA19.PA_AbortStream(stream1);
            PA19.PA_CloseStream(stream1);
            PA19.PA_AbortStream(stream2);
            PA19.PA_CloseStream(stream2);
            Debug.Write("Audio is stoped!\n");
        }

        public static ArrayList GetPAInputDevices(int hostIndex)
        {
            ArrayList a = new ArrayList();
            PA19.PaHostApiInfo hostInfo = PA19.PA_GetHostApiInfo(hostIndex);
            for (int i = 0; i < hostInfo.deviceCount; i++)
            {
                int devIndex = PA19.PA_HostApiDeviceIndexToDeviceIndex(hostIndex, i);
                PA19.PaDeviceInfo devInfo = PA19.PA_GetDeviceInfo(devIndex);
                if (devInfo.maxInputChannels > 0)
                    a.Add(new PADeviceInfo(devInfo.name, i)/* + " - " + devIndex*/);
            }
            return a;
        }

        public static ArrayList GetPAOutputDevices(int hostIndex)
        {
            ArrayList a = new ArrayList();
            
            if (!paInitialized && !Initialize())
                return a;
            
            PA19.PaHostApiInfo hostInfo = PA19.PA_GetHostApiInfo(hostIndex);
            for (int i = 0; i < hostInfo.deviceCount; i++)
            {
                int devIndex = PA19.PA_HostApiDeviceIndexToDeviceIndex(hostIndex, i);
                PA19.PaDeviceInfo devInfo = PA19.PA_GetDeviceInfo(devIndex);
                if (devInfo.maxOutputChannels > 0)
                    a.Add(new PADeviceInfo(devInfo.name, i));
            }
            return a;
        }

        public static ArrayList GetPAHosts() // returns a text list of driver types
        {
            ArrayList a = new ArrayList();
            
            if (!paInitialized && !Initialize())
                return a;
            
            for (int i = 0; i < PA19.PA_GetHostApiCount(); i++)
            {
                PA19.PaHostApiInfo info = PA19.PA_GetHostApiInfo(i);
                a.Add(info.name);
            }
            return a;
        }

        public unsafe static PA19.PaStreamInfo GetStreamInfo()
        {
            PA19.PaStreamInfo stream_info = new PA19.PaStreamInfo();

            stream_info = PA19.PA_GetStreamInfo(stream1);

            return stream_info;
        }

        #endregion
    }
}
