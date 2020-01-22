using UnityEngine;

public class mWebAccess : MonoBehaviour {

    public void OnButtonClicked(string pageToOpen) {

        InAppBrowser.DisplayOptions displayOptions = new InAppBrowser.DisplayOptions();
        displayOptions.displayURLAsPageTitle = false;
        displayOptions.backButtonText = "Back";
        displayOptions.pageTitle = "Lime Crime";
        displayOptions.barBackgroundColor = "#FF479A";
        displayOptions.textColor = "#FFFFFF";

        InAppBrowser.OpenURL(pageToOpen, displayOptions);
    }

    public void callMyPhone() {

        Application.OpenURL("tel:18665283687");
    }

    public void emailMe() {

        Application.OpenURL("mailto:info@limecrimemakeup.com");
    }

    public void downloadMarker() {

        Application.OpenURL("https://firebasestorage.googleapis.com/v0/b/limecrime-ea57a.appspot.com/o/armarker%2FVenusMarker.pdf?alt=media&token=9f4f9cea-625d-48fe-84b3-8bbd2b414e93");
    }

}