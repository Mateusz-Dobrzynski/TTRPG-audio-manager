using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Mix;
using System;

namespace TTRPG_Audio_Manager
{
    public class AudioFile : IAudioLayer
    {
        public string name { get; set; }
        public int volume { get; set; } = 100;
        public string path { get; set; }
        public Track parentTrack { get; set; }
        public AudioFile(string path)
        {
            this.path = path;
            this.name = Path.GetFileNameWithoutExtension(path);
        }
        public int fileHandle;

        /// <summary>
        /// Creates a new stream from a file path
        /// </summary>
        /// <returns>Returns the stream handle</returns>
        public int GetHandle()
        {
            fileHandle = Bass.BASS_StreamCreateFile(path, 0, 0, BASSFlag.BASS_SAMPLE_FLOAT | BASSFlag.BASS_STREAM_DECODE);
            if (fileHandle == 0)
            {
                throw new Exception($"Stream creation error. Error code: {Bass.BASS_ErrorGetCode()}");
            }
            else return fileHandle;
        }

        /// <summary>
        /// Adds the file stream to a mixer with a given handle.
        /// </summary>
        /// <param name="mixerHandle">Handle of the parent mixer channel</param>
        public void Queue(int mixerHandle)
        {
            int fileHandle = GetHandle();
            if (BassMix.BASS_Mixer_StreamAddChannel(mixerHandle, fileHandle, BASSFlag.BASS_STREAM_AUTOFREE) == false)
            {
                throw new Exception($"Failed to add channel to the mix stream: {Bass.BASS_ErrorGetCode()}");
            }
        }
        /// <summary>
        /// Removes the AudioFile from the parent Track
        /// </summary>
        public void RemoveSelf()
        {
            parentTrack.RemoveAudioFile(this);
        }
    }
}
