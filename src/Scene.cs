﻿using System;
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

		public Scene(string name = "New Scene")
		{
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
			throw new NotImplementedException();
		}

		/// <summary>
		/// Creates a new audio track and appends it to the tracks list
		/// </summary>
		public void AddTrack(string name)
		{
			Track track = new Track(name);
			tracks.Add(track);
		}

		public void RemoveTrack(int index)
		{
			throw new NotImplementedException();
		}
	}
}
