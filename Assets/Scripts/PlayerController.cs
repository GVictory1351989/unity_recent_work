using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireCooldown = 0.3f;
    public float rotationSpeed = 5f; // Smooth turning
    public float aimTolerance = 5f;  // Angle threshold to start firing

    private float nextFireTime = 0f;
    private Camera mainCam;
    private Vector3 targetDirection;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        UpdateMouseDirection();
        RotateTowardsMouse();

        // Check if facing the direction (within aimTolerance degrees)
        float angle = Vector3.Angle(transform.forward, targetDirection);
        bool isAimed = angle <= aimTolerance;

        if (Input.GetMouseButton(0) && Time.time >= nextFireTime && isAimed)
        {
            Fire();
            nextFireTime = Time.time + fireCooldown;
        }
    }

    void UpdateMouseDirection()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        if (groundPlane.Raycast(ray, out float distance))
        {
            Vector3 hitPoint = ray.GetPoint(distance);
            targetDirection = (hitPoint - transform.position);
            targetDirection.y = 0f;
            targetDirection.Normalize();
        }
    }

    void RotateTowardsMouse()
    {
        if (targetDirection.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void Fire()
    {
        var spawnedBullet= Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        spawnedBullet.SetActive(true);
    }
}
