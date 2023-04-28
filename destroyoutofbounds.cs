using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private Transform mainCamera;
    public float topBound = 30f;
    public float bottomBound = -10f;
    public float leftBound = -22f;
    public float rightBound = 22f;

    void Start()
    {
        mainCamera = Camera.main.transform;
    }

    void Update()
    {
        if (transform.position.z > mainCamera.position.z + topBound ||
            transform.position.z < mainCamera.position.z + bottomBound ||
            transform.position.x < mainCamera.position.x + leftBound ||
            transform.position.x > mainCamera.position.x + rightBound)
        {
            Destroy(gameObject);
        }
    }
}
