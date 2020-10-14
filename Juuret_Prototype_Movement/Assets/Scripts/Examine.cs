using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examine : MonoBehaviour
{


    public bool canHover = false;

    Camera mainCam;//Camera Object Will Be Placed In Front Of
    GameObject clickedObject;//Currently Clicked Object


    //Holds Original Postion And Rotation So The Object Can Be Replaced Correctly
    Vector3 originaPosition;
    Vector3 originalRotation;

    //If True Allow Rotation Of Object
    bool examineMode;

    void Start()
    {
        mainCam = Camera.main;
        examineMode = false;
    }

    private void Update()
    {

        ClickObject();//Decide What Object To Examine

        TurnObject();//Allows Object To Be Rotated

        ExitExamineMode();//Returns Object To Original Postion
    }


    void ClickObject()
    {
        

        if (Input.GetMouseButtonDown(0) && examineMode == false)
        {

            RaycastHit hit;
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 1.5f) && hit.collider.tag == "Examine")
                {
                    //ClickedObject Will Be The Object Hit By The Raycast
                    clickedObject = hit.transform.gameObject;

                    //Save The Original Postion And Rotation
                    originaPosition = clickedObject.transform.position;
                    originalRotation = clickedObject.transform.rotation.eulerAngles;

                    //Now Move Object In Front Of Camera
                    clickedObject.transform.position = mainCam.transform.position + (transform.forward);                  
                    //clickedObject.transform.rotation = mainCam.transform.rotation;

                //Pause The Game
                Time.timeScale = 0;

                    //Turn Examine Mode To True
                    examineMode = true;
                }
            
        }
    }

    void TurnObject()
    {


        if (Input.GetMouseButton(0) && examineMode)
        {
            float rotationSpeed = 10;

            float xAxis = Input.GetAxis("Mouse X") * rotationSpeed;
            float yAxis = Input.GetAxis("Mouse Y") * rotationSpeed;

            clickedObject.transform.Rotate(transform.up, -xAxis, Space.World);
            clickedObject.transform.Rotate(transform.right, yAxis, Space.World);
        }
    }

    void ExitExamineMode()
    {
        if (Input.GetMouseButtonUp(0) && examineMode)
        {
            //Reset Object To Original Position
            clickedObject.transform.position = originaPosition;
            clickedObject.transform.eulerAngles = originalRotation;


            //Unpause Game
            Time.timeScale = 1;

            //Return To Normal State
            examineMode = false;
        }
    }
}
