using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTRPG_Audio_Manager
{
    /// <summary>
    /// Small dialog where user writes a name of a newly created AudioLayer
    /// </summary>
    /// <seealso cref="IAudioLayer"/>
    public partial class Creator : Form
    {
        public Creator(string audioType)
        {
            if (audioType != null)
            {
                this.audioType = audioType;
            }
            else
            {
                throw new Exception("audioType cannot be null");
            }
            InitializeComponent();
            SetCreated += OnSetCreated;
        }
        //creators purpose is to get an input from user and assign it as the set/scene name
        //public string CreatorName(string name)
        //{
        //    return name;
        //}
        /// <summary>
        /// Defines the type of AudioLayer being created
        /// </summary>
        string audioType;

        #region AudioLayers delegates and events
        public delegate void SetCreatedEventHandler(string name);
        public event SetCreatedEventHandler? SetCreated;
        public delegate void SceneCreatedEventHandler(string name, EventArgs? args);
        public event SceneCreatedEventHandler SceneCreated;
        public delegate void TrackCreatedEventHandler(string name, EventArgs? args);
        public event TrackCreatedEventHandler TrackCreated;
        #endregion
        protected virtual void OnSetCreated(string name)
        {
            MessageBox.Show("Not implemented yet");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Invokes events based on the type of AudioLayer being created
        /// </summary>
        public void submitCreator_Click(object sender, EventArgs e)
        {
            if (textBoxCreator.Modified == true)
            {
                string name = textBoxCreator.Text;
                switch (audioType)
                {
                    case "set":
                        SetCreated?.Invoke(name);
                        break;
                    case "scene":
                        SceneCreated(name, e);
                        break;
                    case "track":
                        TrackCreated(name, e);
                        break;
                    default:
                        throw new Exception("Invalid audioType");
                }
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}