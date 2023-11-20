using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float normalMoveSpeed = 5f;
    public float slowedMoveSpeed = 2f;
    public float rotationSpeed = 100f; // Adjust the rotation speed as needed
    public float shiftCooldownDuration = 10f;
    public float shiftDuration = 4f;

    private float rotation = 50f;
    public Transform spawnPoint;
    public float bulletSpeed = 100f;

    public float shootCooldown = 0.5f;

    private float shootCooldownTimer = 0f;
    private bool isShiftPressed = false;
    private float shiftCooldownTimer = 5f;
    private float shiftTimer = 0f;

    void Update()
    {
        shiftCooldownTimer -= Time.deltaTime;

        if (isShiftPressed)
        {
            shiftTimer += Time.deltaTime;
            if (shiftTimer >= shiftDuration)
            {
                isShiftPressed = false;
                shiftCooldownTimer = shiftCooldownDuration;
                shiftTimer = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            if (!isShiftPressed && shiftCooldownTimer <= 0f)
            {
                isShiftPressed = true;
                shiftCooldownTimer = shiftCooldownDuration;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            isShiftPressed = false;
            shiftTimer = 0f;
        }

        float moveSpeed = isShiftPressed ? slowedMoveSpeed : normalMoveSpeed;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        rotation = Input.GetAxis("HorizontalRotation") *rotationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && shootCooldownTimer <= 0f)
        {
            Shoot();
            shootCooldownTimer = shootCooldown;
        }

        // Update the shoot cooldown timer
        shootCooldownTimer -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);

        newBullet.GetComponent<Rigidbody>().velocity = transform.forward * 100;
    }
}
