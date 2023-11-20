using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void Start()
    {
        BulletManager.Instance.BulletSpawned();
        DestroyAfterDelay(10f);
    }

    private void OnDestroy()
    {
        BulletManager.Instance.BulletDestroyed();
    }

    private void HandleTrigger()
    {
        Debug.Log("Bullet triggered with the player");
        BulletManager.Instance.BulletDestroyed();
    }

    private void DestroyAfterDelay(float delay)
    {
        Invoke("DestroyBullet", delay);
    }

    private void DestroyBullet()
    {
        // Destroy the bullet GameObject
        Destroy(gameObject);
    }
}