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

        //ImageView _imageView = null;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = TestDrive2.Droid.Resource.Layout.Tabbar;
            ToolbarResource = TestDrive2.Droid.Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            if (IsThereAnAppToTakePictures())
            {
                CreateDirectoryForPictures();

                //Button button = FindViewById<Button>(TestDrive2.Droid.Resource.Id.myButton);
                //_imageView = FindViewById<ImageView>(TestDrive2.Droid.Resource.Id.imageView1);
                //button.Click += TakeAPicture;
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

        //private void TakeAPicture(object sender, EventArgs eventArgs)
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

            //App.bitmap = App._file.Path.LoadAndResizeBitmap(width, height);
            //if (App.bitmap != null)
            //{
            //    ImageSource imgSrc = null;
            //    //_imageView.SetImageBitmap(App.bitmap);
            //    imgSrc = ImageSource.FromStream(() =>
            //    {
            //        System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //        App.bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, ms);
            //        byte[] bitmapData = ms.ToArray();
            //        ms.Seek(0L, System.IO.SeekOrigin.Begin);
            //        return ms;
            //    });
            //    App.bitmap = null;
            //}

            // Dispose of the Java side bitmap.
            GC.Collect();
        }
    }

    public static class BitmapHelpers
    {
        public static Bitmap LoadAndResizeBitmap(this string fileName, int width, int height)
        {
            // First we get the the dimensions of the file on disk
            BitmapFactory.Options options = new BitmapFactory.Options { InJustDecodeBounds = true };
            BitmapFactory.DecodeFile(fileName, options);

            // Next we calculate the ratio that we need to resize the image by
            // in order to fit the requested dimensions.
            int outHeight = options.OutHeight;
            int outWidth = options.OutWidth;
            int inSampleSize = 1;

            if (outHeight > height || outWidth > width)
            {
                inSampleSize = outWidth > outHeight
                                   ? outHeight / height
                                   : outWidth / width;
            }

            // Now we will load the image and have BitmapFactory resize it for us.
            options.InSampleSize = inSampleSize;
            options.InJustDecodeBounds = false;
            Bitmap resizedBitmap = BitmapFactory.DecodeFile(fileName, options);

            return resizedBitmap;
        }
    }
}

