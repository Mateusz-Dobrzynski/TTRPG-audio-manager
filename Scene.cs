using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTRPG_Audio_Manager
{
	public class Scene : IAudioLayer
	{
		public string name { get; set; }
		public int volume { get; set; } = 100;
		List<Track> tracks = new List<Track>();
		public Scene(string name)
		{
			this.name = name;
		}
		public void Play()
		{
            throw new NotImplementedException();
		}
		/// <summary>
		/// Creates a new audio track and appends it to the tracks list
		/// </summary>
		private void AddTrack()
		{
			int tracksCount = this.tracks.Count;
			Track newAudioTrack = new Track();
		}
	}
}
