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
		public List<Track> tracks = new List<Track>();
		public int handle;
		public ScenesSet parentSet;

		public Scene(ScenesSet parentSet, string name = "New Scene")
		{
			this.parentSet = parentSet;
			this.name = name;
		}

        /// <summary>
        /// Simultaneously plays all the tracks within the scene
        /// </summary>
        public void Play()
		{
			foreach (Track track in tracks) track.Play();
		}

		public void Stop()
		{
            foreach (Track track in tracks) track.Stop();
        }

		/// <summary>
		/// Removes the scene from the parent scene set
		/// </summary>
		public void RemoveSelf()
		{
			parentSet.RemoveScene(this);
		}

		/// <summary>
		/// Creates a new audio track and appends it to the tracks list
		/// </summary>
		public void AddTrack(string name)
		{
			Track track = new Track(this, name);
			tracks.Add(track);
		}

        /// <summary>
        /// Removes a track from tracks list.
        /// This method is always called by one of the tracks
        /// included in the scene
        /// </summary>
        /// <param name="track">Parameter provided by the <see cref="Track.Remove"/> method</param>
        /// <seealso cref="Track.Remove"/>
		public void RemoveTrack(Track track)
		{
			tracks.Remove(track);
		}
	}
}
