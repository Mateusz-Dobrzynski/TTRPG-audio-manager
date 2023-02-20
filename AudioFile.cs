using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Un4seen.Bass;
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

        /// <summary>
        /// Creates a new stream from a file path
        /// </summary>
        /// <returns>Returns the stream handle</returns>
        public int GetHandle()
        {
            int fileHandle = Bass.BASS_StreamCreateFile(path, 0, 0, new BASSFlag());
            return fileHandle;
        }
    }
}
