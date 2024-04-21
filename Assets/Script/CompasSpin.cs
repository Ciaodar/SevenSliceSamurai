using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompasSpin : MonoBehaviour
{
    [SerializeField]
    public float secondsMultiplier = 25f;
    private int inGameSeconds;
    public bool stop;
    private void Start()
    {
        getRandomRotation();
    }
   /* private void Update()
    {
        if (!stop)
        {
            inGameSeconds = Mathf.RoundToInt(Time.time * secondsMultiplier);
            secondsHandle.transform.localRotation = Quaternion.Euler(-180, 0, inGameSeconds);
        }
    }
   */
    public void getRandomRotation()
    {
        transform.localRotation = Quaternion.Euler(-180, 0, Random.Range(0, 360));
    }

    public void RotateStop()
    {
        stop = true;
    }

}
