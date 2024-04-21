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
    public Animator[] heartAnimator;
    public float range=15;
    public enemyscript myEnemy;
    public GameObject hitParticle;
    public GameObject heartContainer;
    public int start = 0;
    public Transform hitEnterPoint;
    public AudioSource mySource;
    public AudioSource deadAudioSource;

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
            if (IsBetween(myAngle, degri-range, degri+range)) 
            {
                if (CheckIfItIntersects())
                {
                    Destroyer();
                }            
            }
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
        if (myEnemy.health > 1)
        {
            myEnemy.health -= 1;
            enemyAnimator.SetTrigger("isHit");

            heartAnimator[start].SetTrigger("isHit");
            mySource.Play();
            start += 1;
            Instantiate(hitParticle, hitEnterPoint.position,transform.rotation);
        }
        else
        {

            if (enemyAnimator.GetBool("isDead")==false)
            {
                deadAudioSource.Play();
                heartAnimator[start].SetTrigger("isHit");
                heartAnimator[start].GetComponent<heartShake>().shakeDuration = 0.2f;
                start += 1;
                Instantiate(hitParticle, hitEnterPoint.position, transform.rotation);
                enemyAnimator.SetBool("isDead", true);
            }
            
        }
    }


    public bool CheckIfItIntersects()
    {

        Vector3 startVector = new Vector3(atack.StartPos.x, atack.StartPos.y, -5f);

        Vector3 stopVector = new Vector3(atack.StopPos.x, atack.StopPos.y, -5f);

        RaycastHit2D hit = Physics2D.Raycast(startVector,(stopVector-startVector).normalized*Vector3.Distance(stopVector,startVector));
        Debug.DrawRay(startVector, (stopVector - startVector).normalized * 5f, Color.green);

        // If it hits something...
        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
