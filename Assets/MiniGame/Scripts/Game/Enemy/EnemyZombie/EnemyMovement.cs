using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    private Transform _player;

    private void Awake()
    {
        _player = FindAnyObjectByType<PlayerMovement>().transform;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        RotateEnemy();

       
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    private void RotateEnemy()
    {
        Vector2 direction = _player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

    }
}
