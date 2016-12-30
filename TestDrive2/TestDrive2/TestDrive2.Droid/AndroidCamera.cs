////instalar: https://www.nuget.org/packages/Plugin.Permissions

//using System;
//using Android.App;
//using Android.Content.PM;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using Android.OS;
//using TestDrive.Droid;
//using TestDrive2;
//using TestDrive2.Droid;
//using Android.Content;
//using TestDrive.Media;
//using Android.Support.V4.Content;
//using Android;
//using Android.Support.V4.App;
//using Plugin.Permissions;
//using Plugin.Permissions.Abstractions;
//using Android.Provider;
//using Java.IO;
//using Android.Graphics;

//[assembly: Xamarin.Forms.Dependency(typeof(AndroidCamera))]
//namespace TestDrive.Droid
//{
//    [Activity]
//    public class AndroidCamera : Activity, ICamera, ActivityCompat.IOnRequestPermissionsResultCallback
//    {
//        private File _file;
//        private Bitmap _bitmap;

//        public async void TirarFoto()
//        {
//            //try
//            //{
//            //    pickIntent = new Intent("ACTION_IMAGE_CAPTURE");

//            //    if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.Camera) != Permission.Granted)
//            //    {
//            //        ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.Camera }, 1);
//            //    }
//            //    //StartActivityForResult(pickIntent, _id);
//            //}
//            //finally
//            //{
//            //    if (pickIntent != null)
//            //        pickIntent.Dispose();
//            //}

//            try
//            {
//                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Camera);
//                if (status != PermissionStatus.Granted)
//                {
//                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Plugin.Permissions.Abstractions.Permission.Camera))
//                    {
//                        //await DisplayAlert("Need Camera", "Gunna need that Camera", "OK");
//                    }

//                    var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Plugin.Permissions.Abstractions.Permission.Camera });
//                    status = results[Plugin.Permissions.Abstractions.Permission.Camera];
//                }

//                if (status == PermissionStatus.Granted)
//                {
//                    //intent = new Intent(MediaStore.ActionImageCapture);
//                    //documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
//                    //_file = new File(documentsPath, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
//                    //intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(_file));
//                    //this.Parent.StartActivityForResult(intent, 0);

//                    string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
//                    _file = new File(documentsPath, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));

//                    Intent intent = new Intent(MediaStore.ActionImageCapture);
//                    intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(_file));

//                    this.Parent.StartActivityForResult(intent, 0);


//                    //var results = await CrossGeolocator.Current.GetPositionAsync(10000);
//                    //LabelGeolocation.Text = "Lat: " + results.Latitude + " Long: " + results.Longitude;
//                }
//                else if (status != PermissionStatus.Unknown)
//                {
//                    //await DisplayAlert("Camera Denied", "Can not continue, try again.", "OK");
//                }
//            }
//            catch (Exception ex)
//            {
//                //LabelGeolocation.Text = "Error: " + ex;
//            }
//        }

//        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
//        {
//            base.OnActivityResult(requestCode, resultCode, data);

//            // Make it available in the gallery

//            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
//            var contentUri = Android.Net.Uri.FromFile(_file);
//            mediaScanIntent.SetData(contentUri);
//            SendBroadcast(mediaScanIntent);

//            // Display in ImageView. We will resize the bitmap to fit the display.
//            // Loading the full sized image will consume to much memory
//            // and cause the application to crash.

//            int height = Resources.DisplayMetrics.HeightPixels;
//            int width = Resources.DisplayMetrics.WidthPixels;

//            _bitmap = _file.Path.LoadAndResizeBitmap(width, height);
//            if (_bitmap != null)
//            {
//                ImageView imageView = new ImageView(this.ApplicationContext);
//                imageView.SetImageBitmap(_bitmap);
//                _bitmap = null;
//            }

//            // Dispose of the Java side bitmap.
//            GC.Collect();
//        }
//    }
//}



