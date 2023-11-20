using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletManager : MonoBehaviour
{
    public TextMeshPro   totalBulletText;
    private int totalBulletCount = 0; 

    public static BulletManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void BulletSpawned()
    {
        totalBulletCount++;
        UpdateTotalBulletCounter();
    }

    public void BulletDestroyed()
    {
        totalBulletCount--;
        UpdateTotalBulletCounter();
    }

    private void UpdateTotalBulletCounter()
    {
        if (totalBulletText != null)
        {
            totalBulletText.text = "Balas en pantalla: " + totalBulletCount.ToString();
        }
    }
}
