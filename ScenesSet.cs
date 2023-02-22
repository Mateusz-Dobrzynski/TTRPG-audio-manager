using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Un4seen.Bass.AddOn.Mix;
using Un4seen.Bass;
using Newtonsoft.Json;

namespace TTRPG_Audio_Manager
{
    /// <summary>
    /// Contains all the audio scenes
    /// </summary>
    public class ScenesSet : IAudioLayer
    {
        /// <summary>
        /// A list of scenes assigned to this set
        /// </summary>
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

        /// TO-DO: Test this method
        /// <summary>
        /// Saves the file as a .json file.
        /// The file name will be the same as the set name.
        /// </summary>
        /// <param name="directory">Directory in which the file will be saved</param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public void Save(string directory)
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            if (Directory.Exists(directory))
            {
                //TO-DO: Perform a name check to prevent errors caused by illegal characters in file names
                File.WriteAllText($@"{directory}\{name}.json", json);
            }
            else
            {
                throw new DirectoryNotFoundException($"Directory \"{directory}\" doesn't exist");
            }
        }

        /// <summary>
        /// Checks, whether the provided string can be a file name.
        /// </summary>
        /// <returns>Returns true if provide name can be used as a file name. In other case, returns false</returns>
        public bool NameCheck(string name)
        {
            throw new NotImplementedException();
        }
    }
}
