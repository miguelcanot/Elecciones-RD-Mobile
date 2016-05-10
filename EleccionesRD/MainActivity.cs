using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Android.OS;

namespace EleccionesRD
{
	[Activity (Label = "Elecciones RD", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@android:style/Theme.NoTitleBar")]
	public class MainActivity : Activity
	{
		WebView web_view;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			web_view = FindViewById<WebView> (Resource.Id.webview);
			web_view.Settings.JavaScriptEnabled = true;
			web_view.LoadUrl ("http://eleccionesrd.dominicancode.com");

			web_view.SetWebViewClient (new HelloWebViewClient ());
		}

		public class HelloWebViewClient : WebViewClient
		{
			public override bool ShouldOverrideUrlLoading (WebView view, string url)
			{
				view.LoadUrl (url);
				return true;
			}
		}

		public override bool OnKeyDown (Android.Views.Keycode keyCode, Android.Views.KeyEvent e)
		{
			if (keyCode == Keycode.Back && web_view.CanGoBack ()) {
				web_view.GoBack ();
				return true;
			}

			return base.OnKeyDown (keyCode, e);
		}
	}
}

