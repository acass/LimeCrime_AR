using UnityEngine;
using Vuforia;
using UnityEngine.Video;
using DG.Tweening;

public class DefaultTrackableEventHandler : MonoBehaviour, ITrackableEventHandler {

    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;

    public VideoPlayer mVideoPlayer;
    public GameObject mVideoHolder;
    public Vector3 myNewVector3, myBackVector3;
    public GameObject myHandTarget;

    protected virtual void Start() {

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);

        myHandTarget.SetActive(true);
    }

    protected virtual void OnDestroy() {

        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
        }
        else
        {
            OnTrackingLost();
        }
    }

    protected virtual void OnTrackingFound()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        foreach (var component in rendererComponents)
            component.enabled = true;
            
        foreach (var component in colliderComponents)
            component.enabled = true;
            
        foreach (var component in canvasComponents)
            component.enabled = true;

        mVideoPlayer.Play();

        myNewVector3 = new Vector3(0, 0.298f, 0);

        mVideoHolder.transform.DOLocalMove(myNewVector3, 3f, false);
        myHandTarget.SetActive(false);
    }

    protected virtual void OnTrackingLost()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        foreach (var component in rendererComponents)
            component.enabled = false;
            
        foreach (var component in colliderComponents)
            component.enabled = false;
            
        foreach (var component in canvasComponents)
            component.enabled = false;

        mVideoPlayer.Stop();

        myBackVector3 = new Vector3(0, -0.7f, -0.4f);

        mVideoHolder.transform.DOLocalMove(myBackVector3, 3f, false);

        myHandTarget.SetActive(true);
    }

}
