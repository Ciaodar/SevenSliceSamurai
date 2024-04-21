using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using FixedUpdate = UnityEngine.PlayerLoop.FixedUpdate;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class movementScript : MonoBehaviour
{
    public enum Direction
    {
        Left,
        Right
    }


    public float offset = 1.5f;
    public float speed = 5f;
    public float totalLerpTime = 0.2f;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;
    public KeyCode jumpKey;
    public KeyCode dashKey;
    public float kaymaX;
    public float kaymaY;
    public GameObject colA;
    public GameObject colB;
    

    public CameraShake camShake;
    private Direction _direction;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;
    private Vector2 mevcutPos;
    private float inputX;
    private bool isMoving = false;
    private bool isJumping = false;
    private float landingDis;
    private Vector2 landingPos;
    private bool canDash = true;
    private bool isDashing;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _direction = Direction.Right;
        rb.velocity = new Vector2(kaymaX, -kaymaY) * speed;
    }

    IEnumerator MoveSide(Vector3 goal)
    {
        Vector3 currentPos = transform.position;
        Vector3 goalPos = transform.position + goal;

        float timeElapsed = 0f;

        while (timeElapsed < totalLerpTime)
        {
            transform.position = Vector3.Lerp(currentPos, goalPos, (timeElapsed) / (totalLerpTime));

            isMoving = true;
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            isMoving = false;
        }
    }
    
    void MoveMethod()
    {
        if (inputX >= 0.95f)
        {
            if (_direction != Direction.Right && !isMoving)
            {
                StartCoroutine(MoveSide(new Vector3(offset,offset,0f)));

                if (_direction == Direction.Left)
                {
                    _direction = Direction.Right;
                }

                ;
            }
        }
        if (inputX <= -0.95f)
        {
            if (_direction != Direction.Left && !isMoving)
            {
                StartCoroutine(MoveSide(new Vector3(-offset,-offset,0f)));

                if (_direction == Direction.Right)
                {
                    _direction = Direction.Left;
                }
            }
        }
    }

    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        anim.SetTrigger("Dash");
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f).magnitude * new Vector2(kaymaX, -kaymaY).normalized;
        camShake.shakeDuration = 0.4f;
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        rb.velocity = new Vector2(kaymaX,-kaymaY) * speed;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        isJumping = Input.GetKeyDown(jumpKey);

        PlayerPrefs.SetFloat("x",transform.position.x);
        PlayerPrefs.SetFloat("y",transform.position.x);
        PlayerPrefs.SetFloat("z",transform.position.x);
        
        //Debug.Log(guncelPos);

        //isJumping = anim.GetCurrentAnimatorStateInfo(0).IsName("jumpAnim");
        if (isJumping  && !isDashing )
        {
            anim.SetTrigger("Jump");
        }

        if (Input.GetKeyDown(dashKey) && canDash && (!isJumping && !isMoving))
        {
            StartCoroutine(Dash());
        }
        
        
        if (_direction == Direction.Left)
        {
            colB.GetComponent<TilemapCollider2D>().enabled = false;
            colA.GetComponent<TilemapCollider2D>().enabled = true;
        }
        else
        {
            colB.GetComponent<TilemapCollider2D>().enabled = true;
            colA.GetComponent<TilemapCollider2D>().enabled = false;
        }
    }

    private void FixedUpdate()
    {
        MoveMethod();
    }
    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("collider1"))
        {
            if (!(anim.GetCurrentAnimatorStateInfo(0).IsName("jumpAnim") || isDashing))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (other.CompareTag("collider2"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (other.CompareTag("enemy"))
        {
            SceneManager.LoadScene("AttackScene");
        }
    }
}
