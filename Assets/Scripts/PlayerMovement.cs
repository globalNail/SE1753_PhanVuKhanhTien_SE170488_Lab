using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 10f; 

    float horizontalMove = 0f;
    bool isJumping = false;
    
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, true); // Move with jump
            isJumping = false; // Reset jumping state after applying jump logic
        }
    }
}
