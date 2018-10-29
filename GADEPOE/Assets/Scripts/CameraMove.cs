using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    bool isCamMoving = false;
    public float zoomSize;
    // Use this for initialization
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {

        Zoom();
        MoveCam();
        

    }
    public void Zoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel")>0)
        {
            if (zoomSize>2)
            {
                zoomSize -= 1;
            }
            
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (zoomSize<30)
            {
                zoomSize += 1;
            }
            
        }
        GetComponent<Camera>().orthographicSize = zoomSize;
    }
    public void MoveCam()
    {
        
        var speed = 5;
     

        Vector3 camPos = transform.position;
        if (Input.GetKey(KeyCode.D))
        {
            isCamMoving = true;
            camPos.x += speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            isCamMoving = true;
            camPos.x -= speed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.W))
        {
            isCamMoving = true;
            camPos.y += speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            isCamMoving = true;
            camPos.y -= speed * Time.deltaTime;
        }
        else
        {
            isCamMoving = false;
        }
        transform.position = camPos;
    }
}
