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

    GameObject SelObj;

    void Update()
    {
        CamaraMovement();
        Raycasts();
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

    public void Raycasts()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit Hit;
            Ray Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(Ray, out Hit, 1000f))
            {
                if (Hit.transform.tag == "NPC" || Hit.transform.tag == "PC")
                {
                    SelObj = Hit.transform.gameObject;
                }
                else
                {
                    SelObj = null;
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            RaycastHit Hit;
            Ray Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(Ray, out Hit, 1000f))
            {
                Debug.Log(Hit.transform.name);
                Debug.Log(SelObj.transform.name);
                if (Hit.transform.tag == "Walkable" && SelObj != null)
                {
                    SelObj.transform.position = new Vector3(Hit.transform.position.x, SelObj.transform.position.y, Hit.transform.position.z);
                }
            }
        }
    }
}
