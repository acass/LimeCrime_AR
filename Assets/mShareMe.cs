using UnityEngine;
using SA.Android.App;
using SA.Android.Content;
using SA.iOS.Social;

public class mShareMe : MonoBehaviour {

   public void ShareWithMe() {

        #if UNITY_ANDROID
            AN_Intent sendIntent = new AN_Intent();
            sendIntent.SetAction(AN_Intent.ACTION_SEND);
            sendIntent.PutExtra(AN_Intent.EXTRA_TEXT, "Welcome to Lime Crime https://www.limecrime.com");
            sendIntent.SetType("text/plain");
            AN_MainActivity.Instance.StartActivity(AN_Intent.CreateChooser(sendIntent, "Hello Lime Crime!"));

        #endif

        #if UNITY_IOS
            ISN_UIActivityViewController controller = new ISN_UIActivityViewController();
            controller.SetText("Welcome to Lime Crime https://www.limecrime.com");
            controller.Present((result) => { });
        #endif
    }

    public void DownloadMarker() {

            ISN_UIActivityViewController controller = new ISN_UIActivityViewController();
            controller.SetText("Try it for yourself, download the Lime Crime augmented reality marker here: https://bit.ly/2rSt012");
            controller.Present((result) => { });
        }
}