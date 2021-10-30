using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DrawOnSurface : MonoBehaviour
{

    public TrackableType surfaceToDetect;

    private ARRaycastManager arOrigin;

    // Start is called before the first frame update
    void Start()
    {
        arOrigin = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 centerPoint = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));

        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        arOrigin.Raycast(centerPoint, hits, surfaceToDetect);
        gameObject.transform.position = hits[0].pose.position;
        gameObject.transform.rotation = hits[0].pose.rotation;
        
    }
}


//sends out a ray from center of frame into AR space
//test if hit detected space
//update pen point to be where ray collides on surface