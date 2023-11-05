using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    [SerializeField] private float potionHealthAmount = 20f;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            var healthControler = collision.gameObject.GetComponent<HealthControler>();
            healthControler.AddHealth(potionHealthAmount);

            Destroy(gameObject);
        }
    }
}
