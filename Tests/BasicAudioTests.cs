using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System;
using Un4seen.Bass;

namespace Tests
{
    [TestClass]
    public class BasicAudioTests
    {
        //Audio files have their names without extensions
        [TestMethod]
        public void AudioFilesNames()
        {
            string audioFilePath = @"C:\Users\gryzo\Music\Frames Pyrosion (No Copyright Music).mp3";
            string audioFileName = Path.GetFileNameWithoutExtension(audioFilePath);
            AudioFile newAudioFile = new AudioFile(audioFilePath);
            Assert.AreEqual(audioFileName, newAudioFile.name);
        }

        //Audio files are added to tracks
        [TestMethod]
        public void AddAudioFiles()
        {
            Track track = new Track();
            string audioFilePath = @"C:\Users\gryzo\Music\Frames Pyrosion (No Copyright Music).mp3";
            string audioFileName = Path.GetFileNameWithoutExtension(audioFilePath);

            track.AddAudioFile(audioFilePath);
            Assert.AreEqual(1, track.audioFiles.Count);
        }

        //Streams from audio files can be created
        [TestMethod]
        public void CreateStreamFromFile()
        {
            //Registration. E-mail address and registration key must be provided to register successfully
            Un4seen.Bass.BassNet.Registration("", "");
            //Initializing BASS library
            Bass.BASS_Init(1, 48000, BASSInit.BASS_DEVICE_FREQ, new IntPtr(0));
            string audioFilePath = @"C:\Users\gryzo\Music\Frames Pyrosion (No Copyright Music).mp3";
            AudioFile newAudioFile = new AudioFile(audioFilePath);
            Assert.AreNotEqual(0, newAudioFile.GetHandle());
        }

        //Tracks can be played
        [TestMethod]
        public void PlayTracks()
        {
            string audioFilePath = @"C:\Users\gryzo\Music\Frames Pyrosion (No Copyright Music).mp3";
            Track track = new Track();
            track.AddAudioFile(audioFilePath);
            track.Play();
        }

        //Scenes can be created

        //Scenes can be played (multiple tracks can be played at once)

    }
}