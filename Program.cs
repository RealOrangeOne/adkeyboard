using System;
using System.Diagnostics;

namespace adkeyboard {
	class MainClass	{
    public static Process sendText(string cmd) {
      string parsedCommand = String.Format("adb shell input text {0}", cmd.Replace(" ", "%s"));
      ProcessStartInfo procInfo = new ProcessStartInfo("/usr/bin/env", parsedCommand);
      procInfo.CreateNoWindow = true;
      procInfo.UseShellExecute = false;
      procInfo.RedirectStandardOutput = true;
      procInfo.RedirectStandardError = true;
      procInfo.RedirectStandardInput = true;
      Process proc = new Process();
      proc.StartInfo = procInfo;
      proc.Start();
      return proc;
    }

		public static void Main (string[] args) {
      while (true) {
        Console.Write("Prompt: ");
        string inputText = Console.ReadLine();
        Process proc = sendText(inputText);
        Console.Write("Sending '{0}'... ", inputText);
        proc.WaitForExit();
        if (proc.ExitCode == 0) {
          Console.WriteLine("Success!");
        } else {
          Console.WriteLine("Error!");
          Console.WriteLine(proc.StandardError.ReadToEnd());
        }
      }
		}
	}
}
