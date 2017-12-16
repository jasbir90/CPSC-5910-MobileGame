﻿using System;
using Xamarin.Forms;
using AudioPlayEx.Droid;
using Android.Media;
using Android.Content.Res;
using CadmusDND;


[assembly: Dependency(typeof(AudioService))]
namespace AudioPlayEx.Droid
{
    public class AudioService : i_audio
	{
		public AudioService()
		{
		}

		public void PlayAudioFile(string fileName)
		{
			var player = new MediaPlayer();
			var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);
            player.Prepared += (s, e) =>
            {
                player.Start();
            };

			player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
			player.Prepare();
		}
	}
}
