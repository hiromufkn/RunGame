using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

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
   public float SpeedMax = 80f;
   public static float NextSpeedUp = 50.0f;


    private Rigidbody rb;
    private bool isGround = true;
    private float startZ;
    private float nextSpeedUp;
    private bool isInvincible = false;
    private Renderer playerRenderer;
    private float move ;
    
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
        move = Input.GetAxis("Horizontal");
        //transform.Translate(move * Speed * Time.deltaTime,0,0);

         Distance = TotalDistance+(transform.position.z-startZ);


        if(Distance>=nextSpeedUp&&Speed<SpeedMax)
        {
            Speed += 1.0f;

            nextSpeedUp += 50.0f;

            NextSpeedUp = nextSpeedUp;
        }

        if(Speed<=0)
        {
            Speed = 0;
            isGameOver = true;
        }


        if (Input.GetKeyDown(KeyCode.Space)&&isGround)
        {
            rb.AddForce(Vector3.up*jumpPower, ForceMode.Impulse);
            isGround = false;
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
            if(Speed<=3)
            {
                Speed = 0;
            }

            StartCoroutine(Invincible());
        }

        

        if(collision.gameObject.CompareTag("Obstacle2"))
        {
            Speed -= 15.0f;

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


