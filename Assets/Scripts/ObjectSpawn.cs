using UnityEngine;
using System.Collections; // Required for Coroutines

public class SpawnObject : MonoBehaviour
{
    public GameObject objectToSpawn;    // Assign your Prefab in the Inspector
    public float spawnInterval = 0.5f;  // Time in seconds between spawns
    public float objectLifetime = 5f;   // Time in seconds before the spawned object is destroyed
    public float spawnZPosition = 0f;   // The Z position for spawned 2D objects (usually 0 for 2D)

    private float timer;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main; // Cache the main camera for efficiency
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found. Make sure you have a camera tagged 'MainCamera'.");
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            if (mainCamera != null) // Proceed only if camera is found
            {
                SpawnObjectAtMouse();
            }
            timer = 0f; // Reset timer
        }
    }

    void SpawnObjectAtMouse()
    {
        if (objectToSpawn != null)
        {
            // Get mouse position in screen coordinates
            Vector3 mouseScreenPosition = Input.mousePosition;
Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, mainCamera.nearClipPlane + spawnZPosition));

            mouseWorldPosition.z = spawnZPosition;

            // Instantiate the object at the calculated mouse world position and default rotation
GameObject spawnedObject = Instantiate(objectToSpawn, mouseWorldPosition, Quaternion.identity);

            // Start a coroutine to destroy the object after its lifetime
            StartCoroutine(DestroyObjectAfterTime(spawnedObject, objectLifetime));
        }
        else
        {
            Debug.LogError("Object to spawn is not assigned in the Inspector!");
        }
    }

    IEnumerator DestroyObjectAfterTime(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (obj != null) // Check if the object hasn't been destroyed by other means
        {
            Destroy(obj);
        }
    }
}
