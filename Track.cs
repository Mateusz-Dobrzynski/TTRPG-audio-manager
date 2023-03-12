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
        /// <summary>
        /// Handle of the track mixer channel
        /// </summary>
        int mixerHandle;
        public List<AudioFile> audioFiles = new List<AudioFile>();
        /// <summary>
        /// If true, files in a track will be played in random order.
        /// </summary>
        public bool shuffle { get; set; } = false;

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
                //Queuing audio files in a (pseudo)random order
                if (shuffle)
                {
                    int coprime = GetCoprime(audioFiles.Count);
                    Random rand = new Random();
                    //Creating a random offset (if it wasn't for the offset, the first random index would always be 0)
                    int offset = rand.Next(audioFiles.Count);
                    for (int i = 0; i < audioFiles.Count; i++)
                    {
                        //Selecting a current index in this way ensures that every index is visited exactly once
                        int currentIndex = (i * coprime + offset)  % audioFiles.Count;
                        audioFiles[currentIndex].Queue(mixerHandle);
                    }
                }
                //Queuing audio files in order they were added
                else
                {
                    for (int i = 0; i < audioFiles.Count; i++)
                        audioFiles[i].Queue(mixerHandle);
                }
                //Playing queued audio files
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

        /// <summary>
        /// Finds the greatest common divisor (GCD) of a and b using the Euclidean algorithm.
        /// </summary>
        /// <returns>GCD of a and b.</returns>
        public int GreatestCommonDivisor(int a, int b)
        {
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            if (b > 0)
                return GreatestCommonDivisor(b, a % b);
            else
                return a;
        }

        /// <summary>
        ///Randomly finds coprime of n.
        ///Coprime is a number such that the greatest common divisor
        ///of coprime and n is 1
        /// </summary>
        /// <returns>A coprime of n within a range of [n/2, n)</returns>
        int GetCoprime(int n)
        {
            int coprime = 0;
            do
            {
                Random rand = new Random();
                int coprimeCandidate = rand.Next(n / 2, n);
                if (GreatestCommonDivisor(coprimeCandidate, audioFiles.Count) == 1)
                    coprime = coprimeCandidate;
            }
            while (coprime == 0);
            return coprime;
        }
    }
}
