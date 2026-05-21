using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public  float Speed=5.0f;
   public float jumpPower = 5.0f;

    private Rigidbody rb;
    private bool isGround = true;
    
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        float move = Input.GetAxis("Horizontal");
        transform.Translate(move * Speed * Time.deltaTime,0,0);

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
    }



}
