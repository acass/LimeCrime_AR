using UnityEngine;

public class detectLayout : MonoBehaviour {

    public GameObject PortraitPanel, LandscapePanel;

    void Update() {

        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight) {

            PortraitPanel.SetActive(false);
            LandscapePanel.SetActive(true);
        }
        else if (Input.deviceOrientation == DeviceOrientation.Portrait) {

            PortraitPanel.SetActive(true);
            LandscapePanel.SetActive(false);
        }
        else if (Input.deviceOrientation == DeviceOrientation.FaceUp) {

            PortraitPanel.SetActive(true);
            LandscapePanel.SetActive(false);
        }
    }
}