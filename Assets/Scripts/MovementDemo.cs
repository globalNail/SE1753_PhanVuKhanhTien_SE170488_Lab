using UnityEngine;

public class MovementDemo : MonoBehaviour
{
    float movementSpeed = 10f;
    float x, y, z;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector3 tempPos = new Vector3(0, 0, 0f);

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        transform.position = transform.position + new Vector3(x * movementSpeed * Time.deltaTime, y * movementSpeed * Time.deltaTime, 0);
        if (x > 0)
        {
            // Face right
            transform.localScale = new Vector3(4, 4, 4);
        }
        else if (x < 0)
        {
            // Face left
            transform.localScale = new Vector3(-4, 4, 4);
        }
        tempPos = new Vector3(x, y, 0f);
        transform.Translate(movementSpeed * Time.deltaTime * tempPos);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Diamond"))
        {
            Destroy(collision.gameObject);
        }
    }
}
