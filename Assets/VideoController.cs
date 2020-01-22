using SA.iOS.Foundation;
using SA.iOS.AVFoundation;
using SA.iOS.AVKit;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour {

    public VideoPlayer mVideoPlayer;

    void Start () {

        mVideoPlayer.loopPointReached += EndReached;

        ISN_AVAudioSession.SetActive(true);
        ISN_AVAudioSession.SetCategory(ISN_AVAudioSessionCategory.Playback);
    }

    void EndReached(VideoPlayer vp)  {

        startMyVideo();
        Debug.Log("VideoEnded");
    }

    public void startMyVideo () {

        var url = ISN_NSURL.StreamingAssetsURLWithPath("VenusVideo.mp4");
        var player = new ISN_AVPlayer(url);
        player.Volume = 0.8f;

        var viewController = new ISN_AVPlayerViewController();
        viewController.Player = player;

        viewController.ShowsPlaybackControls = true;
        viewController.AllowsPictureInPicturePlayback = false;
        viewController.ShoudCloseWhenFinished = false;

        viewController.Show();
    }
}