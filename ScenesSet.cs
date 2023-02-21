using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Un4seen.Bass.AddOn.Mix;
using Un4seen.Bass;

namespace TTRPG_Audio_Manager
{
    /// <summary>
    /// Contains all the audio scenes
    /// </summary>
    public class ScenesSet : IAudioLayer
    {
        public List<Scene> scenes = new List<Scene>();

        public int volume { get; set; }
        public string name { get; set; } = "New Set";

        /// <summary>
        /// Stops all the audio scenes
        /// </summary
        public void SetStop()
        {
            if (Bass.BASS_Stop() != true) throw new Exception($"Failed to stop the set: {Bass.BASS_ErrorGetCode()}");
        }

        /// <summary>
        /// Creates a new scene and adds it to the set
        /// </summary>
        public void AddScene()
        {
            Scene scene = new Scene();
            scenes.Add(scene);
        }
    }
}
