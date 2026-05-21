using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public  float Speed=5.0f;
   public float jumpPower = 5.0f;
   public float Distance { get; private set; }
    public bool isGameOver = false;

    private Rigidbody rb;
    private bool isGround = true;
    private float startZ;
    private float nextSpeedUp = 50.0f;
    
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        startZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;

        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        float move = Input.GetAxis("Horizontal");
        transform.Translate(move * Speed * Time.deltaTime,0,0);

         Distance =  transform.position.z-startZ;

        if(Distance>=nextSpeedUp)
        {
            Speed += 1.0f;

            nextSpeedUp += 50.0f;
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
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }

        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Speed -= 3.0f;
        }
 
    }

    

}
