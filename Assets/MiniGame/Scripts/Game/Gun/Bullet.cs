using System;
using System.Collections;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private GameObject bloodPrefab;
    [SerializeField] private GameObject healthPoiton;
    [SerializeField] private int chanceDropHealthPoiton;

    private Rigidbody2D rb;
    private Camera mainCam;
    private Vector3 mousePos;

    private void Start()//Використовуємо у старті, тому що він стартує при створенні пулі
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();

        LetsTheBulletFly();

        StartCoroutine(DestroyButtonAfter5Sec());

    }

    IEnumerator DestroyButtonAfter5Sec()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    private void DropPotionAfterKill(Collider2D collision)
    {
        int randomDrop = UnityEngine.Random.Range(1, 101);
        if (randomDrop <= chanceDropHealthPoiton)
        {
            Instantiate(healthPoiton, collision.transform.position, healthPoiton.transform.rotation);
        }
    }

    private void LetsTheBulletFly()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    private const string enemyTag = "Enemy";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == enemyTag)
        {
            Instantiate(bloodPrefab, collision.transform.position, collision.transform.rotation);
            DropPotionAfterKill(collision);
            Destroy(collision.gameObject);
            Destroy(gameObject);

            Events.OnKilledEnemy?.Invoke();
        }
    }


}
