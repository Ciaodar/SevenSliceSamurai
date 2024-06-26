using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public Camera myCam;
    public TrailRenderer thisTrail;
    public CameraShake1 camShake;
    public ParticleSystem particleSystem;
    public AudioSource mySource;

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            thisTrail.Clear();
            Vector3 mypoint = myCam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mypoint.x, mypoint.y, -5f);
            thisTrail.Clear();
            camShake.shakeDuration = 0.5f;
           

        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 mypoint = myCam.ScreenToWorldPoint(Input.mousePosition);
            particleSystem.Emit(2);
            transform.position = new Vector3(mypoint.x, mypoint.y, -5f);
            camShake.shakeDuration = 0.5f;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Vector3 mypoint = myCam.ScreenToWorldPoint(Input.mousePosition);

            transform.position = new Vector3(mypoint.x, mypoint.y, -5f);
            camShake.shakeDuration = 0.02f;
        }
    }

}
