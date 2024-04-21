using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerScript : MonoBehaviour
{
    public Transform hitPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hitPoint.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("entered");
    }
}
