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

    }
}