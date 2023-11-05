using System.Collections;
using UnityEngine;

public class BulletShooterZombie : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float zombieDamageAmount;

    private Rigidbody2D rb;
    private void Start()//Використовуємо у старті, тому що він стартує при створенні пулі
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyButtonAfter5Sec());
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * force;
    }
   
    IEnumerator DestroyButtonAfter5Sec()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    

    private const string playerTag = "Player";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            var healthControler = collision.gameObject.GetComponent<HealthControler>();
            healthControler.TakeDamage(zombieDamageAmount);
            Destroy(gameObject);
        }
    }
}
