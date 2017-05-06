using UnityEngine;

public class DetectedBehaviour : MonoBehaviour, Vuforia.ITrackableEventHandler
{

    private Vuforia.TrackableBehaviour mTrackableBehaviour;
    public Shooter shooter;

    void Start()
    {
        mTrackableBehaviour = GetComponent<Vuforia.TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(Vuforia.TrackableBehaviour.Status previousStatus, Vuforia.TrackableBehaviour.Status newStatus)
    {
        if (newStatus == Vuforia.TrackableBehaviour.Status.DETECTED ||
            newStatus == Vuforia.TrackableBehaviour.Status.TRACKED ||
            newStatus == Vuforia.TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }

    private void OnTrackingFound()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

        // Enable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = true;
        }

        // Enable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = true;
        }

        shooter.enabled = true; //TODO: change for s_enabled (bug that solves the problem to test in a pc without a cam)

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
    }


    private void OnTrackingLost()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

        // Disable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = false;
        }

        // Disable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = false;
        }
        shooter.enabled = false;
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
    }

}

