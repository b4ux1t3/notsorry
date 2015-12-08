using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.IO;

namespace notsorry
{
    class main
    {
        #region Globals
        private static SpeechSynthesizer synth = new SpeechSynthesizer();
        private static bool exit = false;
        private static string whatToSay;
        #endregion

        // Entry point
        static void Main(string[] args)
        {
            int mode;
            
            Console.WriteLine("Select a mode:\n1. Manual Input\n2. Read from a file\n3. Settings");

            bool parsed = int.TryParse(Console.ReadLine(), out mode);
            try
            {
                if (parsed && (mode < 4 && mode > 0))
                {
                    if (mode == 1) // Mode 1 (Manual imput)
                    {
                        
                        while (!exit)
                        {
                            ReadInput();
                        }
                        Console.WriteLine("Program terminated. Press any key to continue. Have a nice day!");
                        Console.Read();
                    } // End of Mode 1
                    else if (mode == 2)// Mode 2 (Read from File)
                    {
                        ReadFile();
                        Console.WriteLine("End of file. Have a nice day!");
                        Console.Read();            
                    } // End of Mode 2
                    else // Mode 3 (Settings)
                    {
                        throw new NotImplementedException();
                    }
                }
                else
                {
                    Console.WriteLine("Could not recognize input. Try running the program again.");
                    Console.Read();
                }
            }
            catch (NotImplementedException e)
            {
                Console.WriteLine("That feature has not yet been implemented. Try running the program again in a different mode.");
                Console.Read();
            }
        }
        
        // Reads from console
        private static void ReadInput()
        {
            Console.WriteLine("What would you like to say? To exit, enter an empty string.");
            whatToSay = Console.ReadLine();
            Console.WriteLine();
            if (String.IsNullOrEmpty(whatToSay) || String.IsNullOrWhiteSpace(whatToSay))
            {
                exit = true;
            }
            else
            {
                synth.SpeakAsync(whatToSay);
            }
        }
        
        // Reads from a file
        private static void ReadFile()
        {
            Console.WriteLine("Which file would you like to read?");
            whatToSay = Console.ReadLine();
            try
            {
                string text = File.ReadAllText(whatToSay);
                synth.Speak(text);
            }
            catch
            {
                Console.WriteLine("Something went wrong. That file either does not exist, or the File class could not read it. Make sure you only enter plaintext files, like .txt, and not binary files, like images or executables.\n");
                Console.WriteLine("Remember that the file must either be in the same folder as this program, or you must provide a full file path to the file.");
                Console.Read();
            }
        }
        
        // Shows the settings menu
        private static void ChangeSettings()
        {
            int choice;
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Change voice\n2. Change Speed");
            bool parsed = int.TryParse(Console.ReadLine(), out choice);
            try
            {
                if (parsed && (choice < 3 && choice > 0))
                {
                    if (choice == 1)
                    {
                        throw new NotImplementedException();
                    }
                    else
                    {
                        ChangeSpeed();
                    }
                }
            }
            catch (NotImplementedException e)
            {
                Console.WriteLine("That feature has not yet been implemented.");
                Console.Read();
            }
        }
        
        // Changed the system voice
        private static void ChangeVoice()
        {
            int count = 0;
            int choice;
            string chosenVoice;
            ReadOnlyCollection<InstalledVoice> voices = synth.GetInstalledVoices();

            Console.WriteLine("Which voice would you like?");
            foreach (InstalledVoice voice in voices)
            {
                Console.WriteLine("{0}. {1}", ++count, voice.VoiceInfo.Name);
            }

            bool parsed = int.TryParse(Console.ReadLine(), out choice);

            //if 
        }
        
        // Changes the rate of playback
        private static void ChangeSpeed()
        {

        }
    }
}