using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public TrailRenderer thisTrail;
    public CameraShake1 camShake;

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            thisTrail.Clear();
            Vector3 mypoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mypoint.x, mypoint.y, -5f);
            thisTrail.Clear();
            camShake.shakeDuration = 0.5f;
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 mypoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mypoint.x, mypoint.y, -5f);
            camShake.shakeDuration = 0.5f;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Vector3 mypoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = new Vector3(mypoint.x, mypoint.y, -5f);
            camShake.shakeDuration = 0.02f;
        }
    }

}
