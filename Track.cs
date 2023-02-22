using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Mix;

namespace TTRPG_Audio_Manager
{
    public class Track : IAudioLayer
    {
        public string name { get; set; } = "New Track";
        public int volume { get; set; } = 100;
        public List<AudioFile> audioFiles = new List<AudioFile>();

        /// <summary>
        /// Plays all the audio files assigned to the track one by one
        /// </summary>
        public void Play()
        {
            //Creating a mixer stream
			int mixerHandle = BassMix.BASS_Mixer_StreamCreate(44100, 2, BASSFlag.BASS_SAMPLE_FLOAT | BASSFlag.BASS_MIXER_QUEUE);
            if (mixerHandle != 0)
            {
                //TO-DO: The audio files can be added to the queue in random order (depending on the user input)
                foreach (AudioFile file in audioFiles)
                {
                    //Getting a handle of every file in the audio track and adds it to the queue
                    int fileHandle = file.GetHandle();
                    if (BassMix.BASS_Mixer_StreamAddChannel(mixerHandle, fileHandle, BASSFlag.BASS_STREAM_AUTOFREE) == false)
                    {
                        throw new Exception($"Failed to add channel to the mix stream: {Bass.BASS_ErrorGetCode()}");
                    }
                }
                //Beginning of playback
                if (Bass.BASS_ChannelPlay(mixerHandle, true) == false)
                {
                    throw new Exception($"Failed to play track: {Bass.BASS_ErrorGetCode()}");
                }
            }
            else
            {
                throw new Exception($"Failed to create a track mixer: {Bass.BASS_ErrorGetCode()}");
            }
        }


        /// <summary>
        /// Appends na audio file to the audioFiles list.
        /// </summary>
        /// <param name="path">Path of the audio file</param>
        public void AddAudioFile(string path)
        {
            AudioFile newAudioFile = new AudioFile(path);
            this.audioFiles.Add(newAudioFile);
        }

        public void RemoveAudioFile(string path)
        {
            throw new NotImplementedException();
        }
    }
}
