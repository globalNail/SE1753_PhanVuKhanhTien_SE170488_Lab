using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public float speed = 5f;
    private float screenWidthInWorldUnits;
    private Camera mainCamera;
    private int direction = 1; // 1 right, -1 left

    void Start()
    {
        mainCamera = Camera.main;

        float objectZ = transform.position.z - mainCamera.transform.position.z;
        Vector3 leftEdgeScreen = new Vector3(0, 0, objectZ);
        Vector3 rightEdgeScreen = new Vector3(Screen.width, 0, objectZ);

        Vector3 leftEdgeWorld = mainCamera.ScreenToWorldPoint(leftEdgeScreen);
        Vector3 rightEdgeWorld = mainCamera.ScreenToWorldPoint(rightEdgeScreen);

        screenWidthInWorldUnits = rightEdgeWorld.x - leftEdgeWorld.x;

    }

    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        //size of GameObject using SpriteRenderer
        float spriteWidth = 0f;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            spriteWidth = sr.bounds.size.x / 2f;
        }

        float camX = mainCamera.transform.position.x;
        float halfScreenWorldWidth = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - camX;


        float currentLeftBoundary = camX - halfScreenWorldWidth + spriteWidth;
        float currentRightBoundary = camX + halfScreenWorldWidth - spriteWidth;


        if (transform.position.x <= currentLeftBoundary)
        {
            direction = 1;
            transform.position = new Vector2(currentLeftBoundary, transform.position.y);
        }
        else if (transform.position.x >= currentRightBoundary)
        {
            direction = -1;
            transform.position = new Vector2(currentRightBoundary, transform.position.y);
        }
    }
}
