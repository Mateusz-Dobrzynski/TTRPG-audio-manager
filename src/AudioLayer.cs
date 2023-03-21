using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTRPG_Audio_Manager
{
    /// <summary>
    /// This interface describes any layer of the audio hierarchy (Scene, Track, Volume)
    /// </summary>
    internal interface IAudioLayer
    {
        /// <summary>
        /// Volume of an audio layer. Can range from 0 (no sound) to 100 (maximum volume).
        /// </summary>
        public int volume { get; set; }
        /// <summary>
        /// Name of an audio layer created by the user.
        /// </summary>
        public string name { get; set; }
    }
}
