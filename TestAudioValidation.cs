using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections;

namespace CWExpert
{
    public static class AudioTestHelper
    {
        public static void ValidateSetup()
        {
            Debug.WriteLine("=== Audio Setup Validation ===");

            try
            {
                if (Audio.Initialize())
                {
                    Debug.WriteLine("PortAudio initialized successfully");

                    int hostCount = PA19.PA_GetHostApiCount();
                    Debug.WriteLine("Found " + hostCount.ToString() + " host APIs");

                    for (int i = 0; i < hostCount; i++)
                    {
                        PA19.PaHostApiInfo info = PA19.PA_GetHostApiInfo(i);
                        Debug.WriteLine("  Host " + i.ToString() + ": " + info.deviceCount.ToString() + " devices");
                    }

                    Audio.Terminate();
                    Debug.WriteLine("PortAudio terminated successfully");
                }
                else
                {
                    Debug.WriteLine("PortAudio initialization failed");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error during validation: " + ex.Message);
            }

            Debug.WriteLine("=== Validation Complete ===");
        }

        public static void TestDeviceEnumeration()
        {
            Debug.WriteLine("=== Device Enumeration Test ===");

            if (!Audio.Initialize())
            {
                Debug.WriteLine("Cannot initialize PortAudio");
                return;
            }

            try
            {
                ArrayList hosts = Audio.GetPAHosts();
                Debug.WriteLine("Found " + hosts.Count.ToString() + " audio hosts");

                for (int i = 0; i < hosts.Count; i++)
                {
                    Debug.WriteLine("--- Host " + i.ToString() + " ---");

                    ArrayList inputs = Audio.GetPAInputDevices(i);
                    Debug.WriteLine("  Input devices: " + inputs.Count.ToString());
                    foreach (object dev in inputs)
                    {
                        Debug.WriteLine("    - " + dev.ToString());
                    }

                    ArrayList outputs = Audio.GetPAOutputDevices(i);
                    Debug.WriteLine("  Output devices: " + outputs.Count.ToString());
                    foreach (object dev in outputs)
                    {
                        Debug.WriteLine("    - " + dev.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error enumerating devices: " + ex.Message);
            }
            finally
            {
                Audio.Terminate();
            }

            Debug.WriteLine("=== Enumeration Test Complete ===");
        }
    }
}