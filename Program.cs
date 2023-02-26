using System;
using System.Windows.Forms.VisualStyles;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Mix;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Bson;
using System.Security.Cryptography.X509Certificates;

namespace TTRPG_Audio_Manager
{
    public class Program
    {
        /// <summary>
        /// Currently used set
        /// </summary>
        /// <remarks>Possibly can be moved to SceneSelector</remarks>
        /// <seealso cref="SceneSelector"/>
        ScenesSet currentSet = new ScenesSet(); 
        
        /// <summary>
        /// Renames currentSet
        /// </summary>
        /// <param name="name"></param>
        public void RenameCurrentSet(string name)
        {
            currentSet.name = name;
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Bass registration and initialization
            Registration reg = new Registration();

            //Initializing GUI
            ApplicationConfiguration.Initialize();
            Application.Run(new Index());
        }

        /// <summary>
        /// Loads a scene set from a provided .json file.
        /// </summary>
        /// <param name="path">Path of the json file</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="FileFormatException"></exception>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public ScenesSet LoadFile(string path)
        {
            if (File.Exists(path))
            {
                if (Path.GetExtension(path) == ".json")
                {
                    // Deserializes the file and checks whether it's a valid Set file
                    string fileContent = File.ReadAllText(path);
                    ScenesSet loadedSet = JsonConvert.DeserializeObject<ScenesSet>(fileContent);
                    if (loadedSet.ContentCheck() == true && loadedSet != null) return loadedSet;
                    else throw new Exception($"The loaded file {path} is not a set file or the loaded set file is corrupted.");
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
}