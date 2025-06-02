using Unity.VisualScripting;
using UnityEngine;

public class NinjaGirlMonoBe : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 10f;
    float forceMovement = 10f;
    float horizontalMove = 0f;
    bool isJumping = false;

    private Rigidbody2D rb;
    private float x, y;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
        }
    }

    //private bool isGrounded()
    //{
    //    if ()
    //    {
            
    //    }
    //}

    //private void Jump()
    //{
    //    if (isGrounded())
    //    {
    //        isJumping = true;
    //    }
    //}

    private void FixedUpdate()
    {
        if (isJumping)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, true); // Move with jump
            isJumping = false; // Reset jumping state after applying jump logic
        }
    }
}
