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
        public string name { get; set; }
        public int volume { get; set; } = 100;
        int mixerHandle;
        public List<AudioFile> audioFiles = new List<AudioFile>();

        public Track(string name)
        {
            this.name = name;
			mixerHandle = BassMix.BASS_Mixer_StreamCreate(44100, 2, BASSFlag.BASS_SAMPLE_FLOAT | BASSFlag.BASS_MIXER_QUEUE);
            if (mixerHandle == 0) throw new Exception($"Failed to create a track mixer: {Bass.BASS_ErrorGetCode()}"); 
        }

        /// <summary>
        /// Plays all the audio files assigned to the track one by one
        /// </summary>
        public void Play()
        {
            if (GetChannelStatus() != BASSActive.BASS_ACTIVE_PLAYING)
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
        }

        /// <summary>
        /// Pauses playback of the current track. If the current track is not playing, nothing happens.
        /// </summary>
        /// <remarks>
        /// If this method is used, the Play() method will resume the playback instead of starting it anew.
        /// </remarks>
        /// <seealso cref="Play"/>
        public void Pause()
        {
            if (GetChannelStatus() == BASSActive.BASS_ACTIVE_PLAYING)
            {
                Bass.BASS_ChannelStop(mixerHandle);
            }
        }

        /// <summary>
        /// Stops playback of the current track. If the current track is not playing, nothing happens.
        /// </summary>
        public void Stop()
        {
            if (GetChannelStatus() == BASSActive.BASS_ACTIVE_PLAYING)
            {
                //Stopping all the file streams
                for (int i = 0; i < audioFiles.Count; i++)
                {
                    if (Bass.BASS_ChannelStop(audioFiles[i].fileHandle) == false)
                        throw new Exception($"Failed to stop a file stream: {Bass.BASS_ErrorGetCode()}");
                }
                //Stopping the main track channel
                if (Bass.BASS_ChannelStop(mixerHandle) == false)
                    throw new Exception($"Failed to stop a track mixer: {Bass.BASS_ErrorGetCode()}");
            }
        }

        /// <summary>
        /// Checks current status of the track mixer
        /// </summary>
        /// <returns>Status of the track mixer</returns>
        BASSActive GetChannelStatus()
        {
            return Bass.BASS_ChannelIsActive(mixerHandle);
        }

        /// <summary>
        /// Changes volume of a track
        /// </summary>
        /// <param name="newVolume">New volume value</param>
        public void ChangeVolume(int newVolume)
        {
            if (newVolume >= 0 && newVolume <= 100)
            {
                float newVolumeFloat = (float)newVolume * (float)0.01;
                if (Bass.BASS_ChannelSetAttribute(mixerHandle, BASSAttribute.BASS_ATTRIB_VOL, newVolume) == false)
                    throw new Exception($"Failed to change track volume: {Bass.BASS_ErrorGetCode()}");
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
