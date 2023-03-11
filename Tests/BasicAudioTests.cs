using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System;
using Un4seen.Bass;
using TTRPG_Audio_Manager;

namespace Tests
{
    [TestClass]
    public class BasicAudioTests
    {
        /// <summary>
        /// Local audio file for testing needs
        /// </summary>
        string audioFilePath = @"";

        /// <summary>
        /// Audio files have their names without extensions
        /// </summary>
        [TestMethod]
        public void AudioFilesNames()
        {
            string audioFileName = Path.GetFileNameWithoutExtension(audioFilePath);
            AudioFile newAudioFile = new AudioFile(audioFilePath);
            Assert.AreEqual(audioFileName, newAudioFile.name);
        }

        /// <summary>
        /// Audio files are added to tracks
        /// </summary>
        [TestMethod]
        public void AddAudioFiles()
        {
            Track track = new Track("name");
            string audioFileName = Path.GetFileNameWithoutExtension(audioFilePath);

            track.AddAudioFile(audioFilePath);
            Assert.AreEqual(1, track.audioFiles.Count);
        }

        /// <summary>
        /// Streams from audio files can be created
        /// </summary>
        [TestMethod]
        public void CreateStreamFromFile()
        {
            Registration reg = new Registration();
            AudioFile newAudioFile = new AudioFile(audioFilePath);
            Assert.AreNotEqual(0, newAudioFile.GetHandle());
        }

        /// <summary>
        /// Tracks can be played
        /// </summary>
        [TestMethod]
        public void PlayTracks()
        {
            Registration reg = new Registration();
            Scene scene = new Scene();
            scene.AddTrack("name");
            scene.tracks[0].AddAudioFile(audioFilePath);
            scene.tracks[0].Play();
        }

        /// <summary>
        /// Scenes can be created and tracks can be added
        /// </summary>
        [TestMethod]
        public void CreatingScenes()
        {
            Scene scene = new Scene();
            scene.AddTrack("name");
            Assert.AreEqual(1, scene.tracks.Count);
        }

        /// <summary>
        /// Scenes with single tracks can be played
        /// </summary>
        [TestMethod]
        public void PlayingScene()
        {
            Registration reg = new Registration();
            Scene scene = new Scene();
            scene.AddTrack("name");
            scene.tracks[0].AddAudioFile(audioFilePath);
            scene.Play();
        }

        /// <summary>
        /// Scenes can be added to sets
        /// </summary>
        [TestMethod]
        public void AddScenes()
        {
            ScenesSet set = new ScenesSet();
            set.AddScene("name");
            Assert.AreEqual(1, set.scenes.Count);
            Assert.AreEqual("name", set.scenes[0].name);
        }
    }
}