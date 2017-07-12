package md5fae0ccda195e1d3f56ca76c99cca19a1;


public class LocalNotification
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("BenchTest.Droid.LocalNotification, BenchTest.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", LocalNotification.class, __md_methods);
	}


	public LocalNotification () throws java.lang.Throwable
	{
		super ();
		if (getClass () == LocalNotification.class)
			mono.android.TypeManager.Activate ("BenchTest.Droid.LocalNotification, BenchTest.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
