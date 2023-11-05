using UnityEngine;

public class ShooterZombieMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float distanceToShoot;

    public bool normalDistanceForAttack;
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
        MoveEnemyShooterZombie();
    }

    private void MoveEnemyShooterZombie()
    {
        if (Vector2.Distance(_player.position, transform.position) >= distanceToShoot)
        {
            rb.velocity = transform.up * speed;
            normalDistanceForAttack = false;
        }
        else
        {
            rb.velocity = Vector2.zero;
            normalDistanceForAttack = true;
        }
    }

    private void RotateEnemy()
    {
        Vector2 direction = _player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

    }
}
