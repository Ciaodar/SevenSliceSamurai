using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0, 0, -10f);
    private float smoothTime = 0.25f;

    private Vector3 velocity = Vector3.zero;
    void Update()
    {
        Vector3 targetPosition = player.transform.position + offset;
        transform.position =
            Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
