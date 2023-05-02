using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float jumpForce = 8f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){


        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        rb.velocity = new Vector3(horizontalInput*movementSpeed, rb.velocity.y ,verticalInput*movementSpeed);
            
        if(Input.GetButtonDown("Jump") && AtGround()){
            rb.velocity = new Vector3(rb.velocity.x ,jumpForce ,rb.velocity.z);
        }

        if(Input.GetKeyDown("q") || Input.GetKeyDown("escape")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    bool AtGround(){
        return Physics.CheckSphere(groundCheck.position, 0.8f, ground);
    }

}
