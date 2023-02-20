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
        public int volume { get; set; }
        public string name { get; set; }
    }
}
