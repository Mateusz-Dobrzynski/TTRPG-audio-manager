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
            fileHandle = Bass.BASS_StreamCreateFile(path, 0, 0, BASSFlag.BASS_SAMPLE_FLOAT | BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_STREAM_AUTOFREE);
            if (fileHandle == 0)
            {
                throw new Exception($"Stream creation error. Error code: {Bass.BASS_ErrorGetCode()}");
            }
            else return fileHandle;
        }
    }
}
