//instalar: https://www.nuget.org/packages/Plugin.Permissions

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Java.IO;
using System;
using System.Collections.Generic;
using TestDrive.Droid;
using TestDrive.Media;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))]
namespace TestDrive.Droid
{
    [Activity(Label = "TestDrive2", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ICamera
    {
        public static class App
        {   
            public static File _file;
            public static File _dir;
            public static Bitmap bitmap;
        }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = TestDrive2.Droid.Resource.Layout.Tabbar;
            ToolbarResource = TestDrive2.Droid.Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            if (IsThereAnAppToTakePictures())
            {
                CreateDirectoryForPictures();
            }

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new TestDrive.App());
        }

        private void CreateDirectoryForPictures()
        {
            App._dir = new File(
                Android.OS.Environment.GetExternalStoragePublicDirectory(
                    Android.OS.Environment.DirectoryPictures), "CameraAppDemo");
            if (!App._dir.Exists())
            {
                App._dir.Mkdirs();
            }
        }

        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

        public void TirarFoto()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            App._file = new File(App._dir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(App._file));
            ((Activity)Forms.Context).StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            // Make it available in the gallery

            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Android.Net.Uri contentUri = Android.Net.Uri.FromFile(App._file);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);

            // Display in ImageView. We will resize the bitmap to fit the display.
            // Loading the full sized image will consume to much memory
            // and cause the application to crash.

            int height = Resources.DisplayMetrics.HeightPixels;
            int width = Resources.DisplayMetrics.WidthPixels;
            //int width = _imageView.Height;

            var imgFile = new Java.IO.File(App._file.Path);
            var stream = new Java.IO.FileInputStream(imgFile);
            var bytes = new byte[imgFile.Length()];
            stream.Read(bytes);
            MessagingCenter.Send<byte[]>(bytes, "TakePicture");

            // Dispose of the Java side bitmap.
            GC.Collect();
        }
    }
}

