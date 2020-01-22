using UnityEngine;
using System.Collections;

public class BrowserOpener : MonoBehaviour {

	//public string pageToOpen = "http://www.google.com";

	public void OnButtonClicked(string pageToOpen) {

		InAppBrowser.DisplayOptions displayOptions = new InAppBrowser.DisplayOptions();
		displayOptions.displayURLAsPageTitle = false;
		displayOptions.backButtonText = "My back text";  // put your text for Back button here
		displayOptions.pageTitle = "Your title";  // put your text for top bar here
		displayOptions.barBackgroundColor = "#FF0000"; // this is #RRGGBB format so that represents red color
		displayOptions.textColor = "#00FF00";  // this is green
		InAppBrowser.OpenURL(pageToOpen, displayOptions);

	}

}