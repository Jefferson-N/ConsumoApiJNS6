using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ConsumoApiJNS6.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly:Xamarin.Forms.Dependency(typeof(MensajeAndroid))]
namespace ConsumoApiJNS6.Droid
{
    public class MensajeAndroid : IMensaje
    {
        public void longAlert(string msg)
        {
            Toast.MakeText(Application.Context, msg, ToastLength.Long).Show();
        }   

        public void shortAlert(string msg)
        {
            Toast.MakeText(Application.Context, msg, ToastLength.Short).Show();

        }
    }
}