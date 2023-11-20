using UnityEngine;

public class FollowBoss : MonoBehaviour
{
    public GameObject boss;  // Reference to the boss GameObject
    public float bulletSpeed = 10f;  // Adjust the bullet speed as needed

    void Start()
    {
        if (boss == null)
        {
            Debug.LogError("Boss GameObject not assigned to the bullet!");
            // Disable the script to avoid runtime errors
            enabled = false;
        }

        // Point the bullet toward the boss
        if (boss != null)
        {
            transform.LookAt(boss.transform);
        }
    }

    void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the bullet collides with the boss
        if (other.gameObject == boss)
        {
            // Handle the collision with the boss (deal damage, etc.)
            // For now, let's just destroy the bullet
            Destroy(gameObject);
        }
    }
}