using System;
using System.Windows.Forms.VisualStyles;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Mix;

namespace TTRPG_Audio_Manager
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Initializing GUI
            ApplicationConfiguration.Initialize();
            Application.Run(new Index());
        }
    }
}