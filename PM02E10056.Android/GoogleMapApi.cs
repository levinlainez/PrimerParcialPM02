﻿using Android.App;
using PM02E10056.Conexiones;
#if DEBUG
using System;
using Android.App;
using Android.Runtime;
using Plugin.CurrentActivity;

[Application(Debuggable = true)]
#else
using System;
using Android.App;
using Android.Runtime;
using Plugin.CurrentActivity;
[Application(Debuggable =false)]
#endif
[MetaData("com.google.android.maps.v2.API_KEY",
    Value = Constantes.GoogleMapsApiKey)]

public class GoogleMapsApi : Application
{
    public GoogleMapsApi(IntPtr handle, JniHandleOwnership transer)
        : base(handle, transer)
    {

    }
    public override void OnCreate()
    {
        base.OnCreate();
        CrossCurrentActivity.Current.Init(this);
    }
}
