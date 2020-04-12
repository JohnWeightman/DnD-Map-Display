using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float XCameraAxis;
    float ZCameraAxis;
    public float CameraSpeed;

    bool Up;
    bool Down;
    bool Left;
    bool Right;

    void Update()
    {
        CamaraMovement();
    }

    void CamaraMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, CameraSpeed * Time.deltaTime));
            transform.position = new Vector3(transform.position.x, 45f, transform.position.z);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -CameraSpeed * Time.deltaTime));
            transform.position = new Vector3(transform.position.x, 45f, transform.position.z);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-CameraSpeed * Time.deltaTime, 0, 0));
            transform.position = new Vector3(transform.position.x, 45f, transform.position.z);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(CameraSpeed * Time.deltaTime, 0, 0));
            transform.position = new Vector3(transform.position.x, 45f, transform.position.z);
        }
    }
}
