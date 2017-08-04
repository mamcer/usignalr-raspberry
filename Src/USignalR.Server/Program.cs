
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using System.Diagnostics;

class Program
{
	static void Main (string[] args)
	{
		string url = System.Configuration.ConfigurationManager.AppSettings ["HostUrl"];
		using (WebApp.Start (url)) {
			Console.WriteLine ("Server running on {0}", url);
			Console.ReadLine ();
			Console.WriteLine ("Server Stopped");
		}
	}

	public class ChatHub:Hub
	{
		private static Process _process;
		private static string _musicPath = System.Configuration.ConfigurationManager.AppSettings ["MusicDirectory"];
		private static string _playerName = System.Configuration.ConfigurationManager.AppSettings ["PlayerName"];
		private static string _playerParameters = System.Configuration.ConfigurationManager.AppSettings ["PlayerParameters"];
		private static string _welcomeMessage = System.Configuration.ConfigurationManager.AppSettings ["WelcomeMessage"];
		private static int _volumeLevel = 100;

		public void Welcome ()
		{
			Clients.All.send (_welcomeMessage);
		}

		public void Play (string fileName)
		{
			if (System.IO.File.Exists (System.IO.Path.Combine (_musicPath, fileName))) {
				Clients.All.send (fileName);
				Console.WriteLine (fileName);

				KillProcess ();

				var processStart = new System.Diagnostics.ProcessStartInfo (_playerName, string.Format (@"{0} ""{1}{2}""", _playerParameters, _musicPath, fileName));
				_process = Process.Start (processStart);
			} else {
				Clients.All.send (fileName + " does not exists");
				Console.WriteLine (fileName + " does not exists");			
			}
		}

		public void Stop ()
		{
			KillProcess ();
		}

		public void VolumeUp ()
		{
			if (_volumeLevel < 100) {
				_volumeLevel += 5;
			}

			UpdateVolume ();
		}

		public void VolumeDown ()
		{
			if (_volumeLevel > 0) {
				_volumeLevel -= 5;
			}

			UpdateVolume ();
		}

		private void UpdateVolume()
		{
			var processStart = new System.Diagnostics.ProcessStartInfo ("amixer", string.Format(" sset PCM,0 {0}%", _volumeLevel));
			Process.Start (processStart);

			Clients.All.send (string.Format("volume level: {0}%", _volumeLevel));
			Console.WriteLine (string.Format("volume level: {0}%", _volumeLevel));
		}

		private void KillProcess ()
		{
			if (_process != null && !_process.HasExited) {
				var proc = Process.GetProcessById (_process.Id);
				proc.Kill ();
			}
		}
	}
}