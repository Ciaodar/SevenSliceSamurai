using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class Atack : MonoBehaviour
{
    public CompasSpin compasSpin;
    public Vector2 mousePos;
    public  Vector2 StartPos;
    public  Vector2 StopPos;
    public Vector2 myDir;
    public float myAngle;
    public Sprite Hit;
    public Sprite Empty;
    public GameObject HitSpace;
    public Transform compassBase;
    public Transform compassEnd;
    Vector2 myEndCompass;
    public float degri;
    void Start()
    {
//
    }

    void Update()
    {
        myEndCompass = new Vector2(compassEnd.position.x, compassEnd.position.y).normalized;

        degri = Vector2.Angle(transform.up,myEndCompass);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(0))
        {
            StartPos = mousePos;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopPos = mousePos;
            GetAngle();
        }
       /* if (Input.GetKey(KeyCode.Space))
        {
           // HitSpace.GetComponent<SpriteRenderer>().sprite = Hit;
            compasSpin.RotateStop();
   
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
           // HitSpace.GetComponent<SpriteRenderer>().sprite = Empty;
        }

       */
    }

    public void GetAngle()
    {
        myDir = (StopPos - StartPos).normalized;
        myAngle = Vector2.Angle(transform.up, myDir);
    }
}
