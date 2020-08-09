using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    private ARRaycastManager _raycastManager;
    private GameObject visual;

    private void Start()
    {
        // get components
        _raycastManager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;    
        
        // placement indicator
        visual.SetActive(false);
    }

    private void Update()
    {
        List<ARRaycastHit> _hits = new List<ARRaycastHit>();
        _raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), _hits, TrackableType.Planes);
        
        //Check if we hit AR plane, update position and rotation
        if (_hits.Count > 0)
        {
            transform.position = _hits[0].pose.position;
            transform.rotation = _hits[0].pose.rotation;
            
            if(!visual.activeInHierarchy)
                visual.SetActive(true);
        }
    }
}
