using UnityEngine;

public class MovementRigidBody : MonoBehaviour
{
    float forceMovement = 10f;
    private Rigidbody2D rb;
    private float x, y;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        Vector2 movementDirection = new Vector2(x, y);
        rb.AddForce(movementDirection.normalized * forceMovement);
    }
}
