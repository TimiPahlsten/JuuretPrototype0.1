using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    
    private float range = 500f;
    public GameObject _HandImage;
    public GameObject _EyeImage;
    public GameObject _CrossHairImage;
    public Camera cam;
    public bool canHover = false;


    void Start()
    {
        _HandImage.SetActive(false);
        _CrossHairImage.SetActive(true);
    }
    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ViewportPointToRay(new Vector2(.5f, .5f));


        if (Physics.Raycast(ray, out hit, range))
        {
            float iconRange = 1.5f;

            Debug.DrawRay(ray.origin, ray.direction * 2, Color.green);
            if (canHover == true)
            {

                if ((hit.collider.tag == "Examine") && (hit.distance < iconRange))
                {
                    _EyeImage.SetActive(true);
                    _CrossHairImage.SetActive(false);

                    if (Input.GetMouseButton(0))
                    {
                        _EyeImage.SetActive(false);
                    }
                }


                else if ((hit.collider.tag == "Object") && (hit.distance < iconRange))
                {
                    _HandImage.SetActive(true);
                    _CrossHairImage.SetActive(false);

                    if (Input.GetMouseButton(0))
                    {
                        _HandImage.SetActive(false);
                    }
                }

                else
                {
                    _EyeImage.SetActive(false);
                    _HandImage.SetActive(false);
                    _CrossHairImage.SetActive(true);
                }


            }
        }
    }
}
