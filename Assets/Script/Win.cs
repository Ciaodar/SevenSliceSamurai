using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public CompasSpin compasspin;
    public Atack atack;
    public float Randomcuk;
    public Text text;
    public float degri;
    GameObject enemy;
    public Animator enemyAnimator;
    public float range=15;
    void Start()
    {
        Randomcuk = Random.Range(10, 350);
        Randomcuk = Mathf.CeilToInt(Randomcuk / 10f) * 10;

    }

    void Update()
    {
        float myAngle = atack.myAngle;
        degri = atack.degri;
        if (degri < 0)
        {
            degri += 360;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (IsBetween(myAngle, degri-range, degri+range)) { Destroyer();}
            else
            {
                compasspin.getRandomRotation();
            }
        }



        /*text.GetComponent<Text>().text = Randomcuk.ToString();

        if (Input.GetKeyDown(KeyCode.Space))

        {
            if (degri < Randomcuk + 40 && degri > Randomcuk - 40)
            {
               myAngel=(myAngel+ 180) % 360
        if (myAngle < Randomcuk + 40 && myAngle > Randomcuk - 40) 
                { 
                    Destroyer(); 
                }
        
            }
        }*/
    }




    public bool IsBetween(float testValue, float bound1, float bound2)
    {
        return (testValue >= Mathf.Min(bound1, bound2) && testValue <= Mathf.Max(bound1, bound2));
    }

    public void Destroyer()
    {
        Debug.Log("deneme");
        enemyAnimator.SetBool("isDead",true);
    }
}
