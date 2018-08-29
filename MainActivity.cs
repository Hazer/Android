using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Webkit;
using Android.Support.V4.App;
using Android;
using Android.Content.PM;
using Android.Util;

namespace LittleWeebAndroid
{

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true, ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class MainActivity : AppCompatActivity
    {
        private View rootLayout;
        private WebView webView;
        private LittleWeebLibrary.LittleWeeb LittleWeeb = null;
        private int permissionLevel = 0;



        public override async void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            if (requestCode == 1)
            {
               

                if (Android.Support.V4.Content.ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadExternalStorage) != (int)Permission.Granted && Android.Support.V4.Content.ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) != (int)Permission.Granted)
                {
                    // Permission has never been accepted
                    // So, I ask the user for permission
                    ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.WriteExternalStorage, Manifest.Permission.ReadExternalStorage }, 1);
                }
                else
                {


                    Log.Debug("PERMISSION", "Got storage permission! Starting littleweeb!");
                    LittleWeeb = new LittleWeebLibrary.LittleWeeb();

                    webView.LoadUrl("file:///android_asset/index.html");
                    // Permission has already been accepted previously
                }

            }
            else
            {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            RequestWindowFeature(WindowFeatures.NoTitle);

            SetContentView(Resource.Layout.activity_main);

            rootLayout = FindViewById(Resource.Id.root_layout);
            webView = FindViewById<WebView>(Resource.Id.webView);
            webView.Settings.JavaScriptEnabled = true;
            webView.Settings.CacheMode = CacheModes.Normal;
            webView.Settings.DatabaseEnabled = true;
            webView.Settings.DomStorageEnabled = true;
            webView.Settings.AllowFileAccess = true;
            webView.Settings.AllowFileAccessFromFileURLs = true;
            webView.Settings.AllowUniversalAccessFromFileURLs = true;
            webView.Settings.SetRenderPriority(WebSettings.RenderPriority.High);
            webView.Settings.SetSupportZoom(true);
            webView.Settings.UseWideViewPort = true;
            webView.Settings.SetEnableSmoothTransition(true);
            webView.Settings.SetLayoutAlgorithm(WebSettings.LayoutAlgorithm.NarrowColumns);
            webView.SetLayerType(LayerType.Hardware, null);



            webView.SetWebChromeClient(new MyWebChromeClient());


            webView.SetWebViewClient(new MyWebViewClient(this));


            Console.WriteLine("Requesting permission");

            if (Android.Support.V4.Content.ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadExternalStorage) != (int)Permission.Granted && Android.Support.V4.Content.ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) != (int)Permission.Granted)
            {
                // Permission has never been accepted
                // So, I ask the user for permission
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.WriteExternalStorage, Manifest.Permission.ReadExternalStorage }, 1);
            }
            else
            {


                Log.Debug("PERMISSION", "Got storage permission! Starting littleweeb!");
                LittleWeeb = new LittleWeebLibrary.LittleWeeb();

                webView.LoadUrl("file:///android_asset/index.html");
                // Permission has already been accepted previously
            }


        }

        private class MyWebViewClient : WebViewClient
        {
            public Activity mActivity;
            public MyWebViewClient(Activity activity)
            {
                mActivity = activity;
            }

            public override void OnPageFinished(WebView view, string url)
            {
                base.OnPageFinished(view, url);

                var icon = mActivity.FindViewById<RelativeLayout>(Resource.Id.imgIcon);

                icon.Visibility = ViewStates.Gone;
            }
        }

        private class MyWebChromeClient : WebChromeClient
        {
            public override void OnConsoleMessage(string message, int lineNumber, string sourceID)
            {
                base.OnConsoleMessage(message, lineNumber, sourceID);
                Log.Debug("CHROMEWEBVIEW", "MESSAGE: " + message + ", at: " + lineNumber + ", from:" + sourceID);
            }
        }


    }
}

