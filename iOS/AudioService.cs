using System;
using Xamarin.Forms;
using AudioPlayEx;
using AudioPlayEx.iOS;
using System.IO;
using Foundation;
using AVFoundation;
using CadmusDND;
using MediaPlayer;

[assembly: Dependency (typeof (AudioService))]
namespace AudioPlayEx.iOS
{
    public class AudioService : i_audio
    {
        

        public AudioService ()
        {
        }

        public void PlayAudioFile(string fileName)
        {
			/*string sFilePath = NSBundle.MainBundle.PathForResource
                                       (Path.GetFileNameWithoutExtension(fileName), Path.GetExtension(fileName));
            var url = NSUrl.FromString(sFilePath);
            var _player = AVAudioPlayer.FromUrl(url);
            _player.FinishedPlaying += (object sender, AVStatusEventArgs e) =>
            {
                _player = null;
            };
            _player.Play();*/

			                      
            string sFilePath = NSBundle.MainBundle.PathForResource
            (Path.GetFileNameWithoutExtension(fileName), Path.GetExtension(fileName));
            var url = NSUrl.FromString (sFilePath);
            var _player = AVAudioPlayer.FromUrl(url);
            _player.FinishedPlaying += (object sender, AVStatusEventArgs e) => {
                _player = null;
            };
            _player.Play();
        }
    }
}