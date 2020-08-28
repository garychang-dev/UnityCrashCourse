using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint;

    public float bulletLifespan = 3f;
    public bool isFlipped;

    public void Fire()
    {
        var bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        bullet.transform.right = isFlipped ? Vector2.left : Vector2.right;
        Destroy(bullet, bulletLifespan);
    }
}
