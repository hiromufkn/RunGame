using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
   public  float Speed=5.0f;
   public float moveSpeed = 5.0f;
   public float jumpPower = 5.0f;
   public float Distance { get; private set; }
   public bool isGameOver = false;
   public float invincibleTime = 2.0f;
   public float limitX = 5.0f;
   public static float TotalDistance=0f;
   public static float TotalSpeed = 7f;
   public static float Totalhit = 0f;
   public float SpeedMax = 80f;
   public static float NextSpeedUp = 50.0f;
   public int Maxhit = 5;
    public Image[] hearts;


    private Rigidbody rb;
    private bool isGround = true;
    private float startZ;
    private float nextSpeedUp;
    private bool isInvincible = false;
    private Renderer playerRenderer;
    private float move ;
    private Vector2 StartTouchPos;
    private Vector2 EndTouchPos;
    private float SwipeMoveTime=0f;
    
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        startZ = transform.position.z;

        playerRenderer = GetComponent<Renderer>();

        Speed = TotalSpeed;

        nextSpeedUp = NextSpeedUp;

        UpdateHearts();

        //hearts[0].gameObject.SetActive(false);
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(i<(Maxhit - Totalhit));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Speed <= 0)
        {
            Debug.Log("’âŽ~");
        }

        if (isGameOver) return;


        //transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        //if (Input.touchCount > 0)
        if (Input.GetMouseButtonDown(0))
        {
            //Touch touch = Input.GetTouch(0);
            StartTouchPos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            EndTouchPos = Input.mousePosition;
            float SwipeX = EndTouchPos.x - StartTouchPos.x;

            //switch (touch.phase)
            //{
            //case TouchPhase.Began:

            //StartTouchPos = touch.position;

            //break;

            //case TouchPhase.Ended:

            // EndTouchPos = touch.position;

            //float SwipeX = EndTouchPos.x - StartTouchPos.x;

            if (SwipeX > 50f)
            {
                move = 1f;
                //SwipeMoveTime = 0.2f;
            }

            else if (SwipeX < -50f)
            {
                move = -1f;
               // SwipeMoveTime = 0.2f;
            }

            else
            {
                move = 0f;
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            move = 0f;
        }

            // break;
            //}
            //}
            //move = Input.GetAxis("Horizontal");
            //transform.Translate(move * Speed * Time.deltaTime,0,0);

            Distance = TotalDistance + (transform.position.z - startZ);


            if (Distance >= nextSpeedUp)
            {
                nextSpeedUp += 50.0f;

                if (Speed < SpeedMax)
                {

                    Speed += 1.0f;
                }

                NextSpeedUp = nextSpeedUp;
            }

            if (Speed <= 0)
            {
                Speed = 0;
                isGameOver = true;
            }

            if (Totalhit >= Maxhit)
            {
                isGameOver = true;
            }

            if (Input.GetMouseButtonDown(1) && isGround)
            {
                rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
                isGround = false;
            }

            if (SwipeMoveTime > 0)
            {
                SwipeMoveTime -= Time.deltaTime;

                if (SwipeMoveTime <= 0)
                {
                    move = 0f;
                }
            }
        }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 velocity = rb.velocity;

        velocity.y = 0f;

        rb.velocity = velocity;

        if(collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }

        if (isInvincible) return;

        if(collision.gameObject.CompareTag("Obstacle1"))
        {
            Speed -= 5.0f;

            Totalhit++;

            UpdateHearts();

            if(Speed<=3)
            {
                Speed = 0;
            }

            StartCoroutine(Invincible());
        }

        

        if(collision.gameObject.CompareTag("Obstacle2"))
        {
            Speed -= 15.0f;

            Totalhit++;

            UpdateHearts();

            StartCoroutine(Invincible());
        }
 
        if(collision.gameObject.CompareTag("Obstacle3"))
        {
            Speed = 0f;
        }

    }


    IEnumerator Invincible()
    {
        isInvincible = true;

        SetLayerRecursively(gameObject, LayerMask.NameToLayer("invinciblePlayer"));

        for (int i=0; i <= 10; i++)
        {
            playerRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);

            playerRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }

        SetLayerRecursively(gameObject, LayerMask.NameToLayer("player"));

        isInvincible = false;
    }

    void SetLayerRecursively(GameObject obj,int newLayer)
    {
        obj.layer = newLayer;

        foreach(Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }

    private void FixedUpdate()
    {
        if (isGameOver) return;

        Vector3 velocity = rb.velocity;

        velocity.x = move * moveSpeed;
        velocity.z = Speed;

        if(velocity.y>14f)
        {
            velocity.y = 14f;
        }

        if(transform.position.x<=-limitX&&velocity.x<0)
        {
            velocity.x = 0;
        }

        if(transform.position.x>=limitX&&velocity.x>0)
        {
            velocity.x = 0;
        }

        rb.velocity = velocity;

        //Vector3 pos = transform.position;

        //pos.x = Mathf.Clamp(pos.x, -limitX, limitX);

        //transform.position = pos;

    }

}


