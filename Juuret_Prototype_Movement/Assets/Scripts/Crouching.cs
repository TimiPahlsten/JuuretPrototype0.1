using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouching : MonoBehaviour
{
    

    CharacterController col;
    float originalHeight;
    public float reducedHeight;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CharacterController>();
        originalHeight = col.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
            Crouch();
        else if (Input.GetKeyUp(KeyCode.LeftAlt))
            GoUp();



    }



    void Crouch()
    {
        col.height = reducedHeight;
    }

    void GoUp()
    {
        col.height = originalHeight;
    }



}
