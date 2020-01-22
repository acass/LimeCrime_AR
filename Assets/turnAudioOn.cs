using SA.iOS.AVFoundation;
using UnityEngine;

public class turnAudioOn : MonoBehaviour {

	void Start () {

        ISN_AVAudioSession.SetActive(true);
        ISN_AVAudioSession.SetCategory(ISN_AVAudioSessionCategory.Playback);
    }
}