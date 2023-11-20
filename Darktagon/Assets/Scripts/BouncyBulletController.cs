using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBulletController : MonoBehaviour
{
    [SerializeField] private Rigidbody RgbBullet;
    [SerializeField] public int maxCollisions = 4;
    private Vector3 lastVelocity;
    private float curSpeed;
    private Vector3 direction;
    private int curBounces = 0;

    private void Start()
    {
        curBounces = 0;
        BulletManager.Instance.BulletSpawned();
    }   

    private void OnDestroy()
    {
        BulletManager.Instance.BulletDestroyed();
    }


    void LateUpdate()
    {
        lastVelocity = RgbBullet.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            BounceOffWall(collision.contacts[0].normal);
        }
    }

    private void BounceOffWall(Vector3 surfaceNormal)
    {
        curSpeed = lastVelocity.magnitude;
        direction = Vector3.Reflect(lastVelocity.normalized, surfaceNormal);
        direction.y = 0;

        RgbBullet.velocity = direction * Mathf.Max(curSpeed, 0);
        curBounces++;

        if (curBounces >= maxCollisions+1) {
                DestroyBullet();
        }
    }

     private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
