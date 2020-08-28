using UnityEngine;

public class FlyingOctopus : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    public float agroDistance;

    [SerializeField]
    private GameObject explosionPrefab;
    private Transform m_PlayerTransform;

    [SerializeField]
    private float speed;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        m_PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector2 direction = m_PlayerTransform.position - transform.position;
        float distance = direction.magnitude;
        if (distance < agroDistance)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }
}
