using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Un4seen.Bass;

namespace TTRPG_Audio_Manager
{
    public class Track : IAudioLayer
    {
        public string name { get; set; } = "New Track";
        public int volume { get; set; } = 100;
        public List<AudioFile> audioFiles = new List<AudioFile>();

        public void Play()
        {
            for (int i = 0; i < audioFiles.Count; i++)
            {
                int handle = audioFiles[i].GetHandle();
                Bass.BASS_ChannelPlay(handle, false);
            }
        }


        /// <summary>
        /// Creates a new AudioFile and appends it to the audioFiles list.
        /// </summary>
        /// <param name="path">Path of the audio file</param>
        public void AddAudioFile(string path)
        {
            AudioFile newAudioFile = new AudioFile(path);
            this.audioFiles.Add(newAudioFile);
        }
    }
}
