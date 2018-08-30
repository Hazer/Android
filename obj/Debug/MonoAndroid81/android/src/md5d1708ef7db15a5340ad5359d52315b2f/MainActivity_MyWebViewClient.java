package md5d1708ef7db15a5340ad5359d52315b2f;


public class MainActivity_MyWebViewClient
	extends android.webkit.WebViewClient
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPageFinished:(Landroid/webkit/WebView;Ljava/lang/String;)V:GetOnPageFinished_Landroid_webkit_WebView_Ljava_lang_String_Handler\n" +
			"";
		mono.android.Runtime.register ("LittleWeebAndroid.MainActivity+MyWebViewClient, LittleWeeb", MainActivity_MyWebViewClient.class, __md_methods);
	}


	public MainActivity_MyWebViewClient ()
	{
		super ();
		if (getClass () == MainActivity_MyWebViewClient.class)
			mono.android.TypeManager.Activate ("LittleWeebAndroid.MainActivity+MyWebViewClient, LittleWeeb", "", this, new java.lang.Object[] {  });
	}

	public MainActivity_MyWebViewClient (android.app.Activity p0)
	{
		super ();
		if (getClass () == MainActivity_MyWebViewClient.class)
			mono.android.TypeManager.Activate ("LittleWeebAndroid.MainActivity+MyWebViewClient, LittleWeeb", "Android.App.Activity, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public void onPageFinished (android.webkit.WebView p0, java.lang.String p1)
	{
		n_onPageFinished (p0, p1);
	}

	private native void n_onPageFinished (android.webkit.WebView p0, java.lang.String p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
