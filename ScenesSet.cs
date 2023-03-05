using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Un4seen.Bass.AddOn.Mix;
using Un4seen.Bass;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Resources;

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
        public void AddScene(string? name)
        {
            Scene scene = new Scene();
            scene.name = name;
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
        /// Loads a scene set from a provided .json file.
        /// </summary>
        /// <param name="path">Path of the json file</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="FileFormatException"></exception>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public ScenesSet(string? path = null)
        {
            if (path != null)
            {
                if (File.Exists(path))
                {
                    if (Path.GetExtension(path) == ".json")
                    {
                        // Deserializes the file and checks whether it's a valid Set file
                        string fileContent = File.ReadAllText(path);
                        if (this.ContentCheck() == false)
                            throw new Exception($"The loaded file {path} is not a set file or the loaded set file is corrupted.");
                        else
                        {
                            this.name = JsonConvert.DeserializeObject<ScenesSet>(fileContent).name;
                            this.scenes = JsonConvert.DeserializeObject<ScenesSet>(fileContent).scenes;
                            this.volume = JsonConvert.DeserializeObject<ScenesSet>(fileContent).volume;
                        }
                    }
                    else
                    {
                        throw new FileFormatException("Only .json files are accepted");
                    }
                }
                else
                {
                    throw new DirectoryNotFoundException();
                }
            }
        }

        /// <summary>
        /// Checks, whether the provided string can be a file name.
        /// </summary>
        /// <returns>Returns true if provided name can be used as a file name. In other case, returns false</returns>
        public bool NameCheck(string name)
        {
            Regex pattern = new Regex(@"[<>:\""\/\\\|\?\*]");
            if (pattern.IsMatch(name)) return false;
            else return true;
        }

        /// <summary>
        /// Checks whether the object contains valid attributes.
        /// </summary>
        /// <returns>Returns true if file contents are valid. In other case returns false.</returns>
        public bool ContentCheck()
        {
            if (name.GetType() != typeof(string))  return false;
            if (volume < 0 || volume > 100) return false;
            if (volume < 0 || volume > 100) return false;
            if (scenes.GetType() != typeof(List<Scene>)) return false;
            else return true;
        }
    }
}
