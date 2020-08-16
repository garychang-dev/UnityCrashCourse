using UnityEngine;

public class PlayerSpawnPrefab : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform spawnPoint;

    public float timeToLive;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && prefabToSpawn != null && spawnPoint != null)
        {
            // Spawn the prefab on the spawn point
            GameObject obj = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);

            // Destroy after some time
            if (timeToLive > 0)
            {
                Destroy(obj, 5f);
            }
        }
    }
}
