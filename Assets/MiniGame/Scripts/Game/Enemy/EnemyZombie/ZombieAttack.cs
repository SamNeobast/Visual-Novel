using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField] private float zombieDamageAmount;
    [SerializeField] private float zombieAttackCoolDown;

    private float timerCoolDown;
    private bool canAttack;

    private void Start()
    {
        canAttack = true;
    }
    private void Update()
    {
        CalculatintCoolDown();
    }

    private void CalculatintCoolDown()
    {
        if (timerCoolDown < zombieAttackCoolDown)
        {
            timerCoolDown += Time.deltaTime;

            if (timerCoolDown >= zombieAttackCoolDown)
            {
                canAttack = true;
                timerCoolDown = 0;
            }
        }
    }

    private const string playerTag = "Player";
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == playerTag && canAttack)
        {
            canAttack = false;

            var healthControler = collision.gameObject.GetComponent<HealthControler>();
            healthControler.TakeDamage(zombieDamageAmount);
        }
    }
}
