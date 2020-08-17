using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float lifespan;
    public Transform spawnPoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletObject = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            Destroy(bulletObject, lifespan);
        }
    }
}
