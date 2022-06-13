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
        // Rotate the camera left and right
        if(Input.GetKey("a"))
        {
            camera.transform.eulerAngles += new Vector3(camera.transform.position.x - cameraSpeed, camera.transform.position.y, camera.transform.position.z);
        }
        if(Input.GetKey("d"))
        {
            camera.transform.eulerAngles += new Vector3(camera.transform.position.x + cameraSpeed, camera.transform.position.y, camera.transform.position.z);
        }


        if(Input.GetKey("w"))
        {
            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z + cameraSpeed);
        }

        if(Input.GetKey("s"))
        {
            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z - cameraSpeed);
        }

        
        if(Input.mouseScrollDelta.y > 0) camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + 1f, camera.transform.position.z);
        if(Input.mouseScrollDelta.y < 0) camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y - 1f, camera.transform.position.z);            
    }   
}
// x is up
// y left and right