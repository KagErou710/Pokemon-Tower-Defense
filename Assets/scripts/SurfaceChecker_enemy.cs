using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;

public class SurfaceChecker_enemy : MonoBehaviour
{
    [SerializeField] ARRaycastManager arRayCastMng;

    [SerializeField] bool canPlace;

    private Pose placementPose;
    [SerializeField] GameObject placementIndicator;
    [SerializeField] GameObject character;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpadatePlacementPose();
        UpadatePlacementIndicator();
    }

    public void SpawnCharacter()
    {
        if (canPlace)
        {
            Instantiate(character, placementPose.position, placementPose.rotation);
        }
    }

    private void UpadatePlacementPose()
    {
        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0f));

        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        arRayCastMng.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        canPlace = hits.Count > 0;

        if (canPlace)
        {
            placementPose = hits[0].pose;
            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0f, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }


    private void UpadatePlacementIndicator()
    {
        if (canPlace)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }
}
