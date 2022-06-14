using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera camera;
    public float cameraSpeed = 0.001f;

    void Update()
    {
        HandleCameraMovement();
    }

    private void HandleCameraMovement()
    {        
        // move camera up and down        
        if(Input.mouseScrollDelta.y > 0) camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + 1f, camera.transform.position.z);
        if(Input.mouseScrollDelta.y < 0) camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y - 1f, camera.transform.position.z);            
    }   
}
