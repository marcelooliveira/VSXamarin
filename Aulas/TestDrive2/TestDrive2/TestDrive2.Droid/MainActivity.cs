﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using TestDrive;
using TestDrive.Media;
using TestDrive2.Droid;
using Java.IO;
using Android.Graphics;
using Android.Content;
using System.Collections.Generic;
using Android.Provider;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))]
namespace TestDrive2.Droid
{
    [Activity(Label = "TestDrive2", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : 
        global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
        , ICamera
    {
        public static class ImageData
        {
            public static File Arquivo;
            public static File Diretorio;
            public static Bitmap Imagem;
        }

        public void TirarFoto()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            ImageData.Arquivo = new File(ImageData.Diretorio,
                String.Format("MinhaFoto_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(ImageData.Arquivo));
            ((Activity)Forms.Context).StartActivityForResult(intent, 0);
        }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            if (AppPodeTirarFotos())
                CriaDiretorioParaImagens();

            LoadApplication(new App());
        }

        private void CriaDiretorioParaImagens()
        {
            ImageData.Diretorio = new File(
                Android.OS.Environment.GetExternalStoragePublicDirectory(
                    Android.OS.Environment.DirectoryPictures), "Imagens");
            if (!ImageData.Diretorio.Exists())
            {
                ImageData.Diretorio.Mkdirs();
            }
        }

        private bool AppPodeTirarFotos()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

        protected override void OnActivityResult(int requestCode,
        [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            // Deixa a imagem disponível na galeria de imagens
            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Android.Net.Uri contentUri = Android.Net.Uri.FromFile(ImageData.Arquivo);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);

            //Define o tamanho da imagem
            int height = Resources.DisplayMetrics.HeightPixels;
            int width = Resources.DisplayMetrics.WidthPixels;

            //Obtendo dados da imagem
            var imgFile = new Java.IO.File(ImageData.Arquivo.Path);
            var stream = new Java.IO.FileInputStream(imgFile);
            var bytes = new byte[imgFile.Length()];
            stream.Read(bytes);
            MessagingCenter.Send<byte[]>(bytes, "TirarFoto");

            // Fazendo dispose da imagem no Java
            GC.Collect();
        }
    }
}

