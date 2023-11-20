using UnityEngine;

public class MirrorBulletController : MonoBehaviour
{
    public string wallTag = "Wall";
    public int maxCollisions = 4; 
    private int collisionCount = 0;

    private void Start()
    {

        BulletManager.Instance.BulletSpawned();
    }

    private void OnDestroy()
    {

        BulletManager.Instance.BulletDestroyed();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(wallTag))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = -rb.velocity;

            collisionCount++;
            if (collisionCount >= maxCollisions+1)
            {
                DestroyBullet();
            }
        }
    }

    private void DestroyBullet()
    {

        Destroy(gameObject);
    }
}