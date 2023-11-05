using UnityEngine;

public class ShooterZombieAttack : MonoBehaviour
{
    [SerializeField] private float zombieDamageAmount;
    [SerializeField] private float zombieAttackCoolDown;
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private Transform firePoint;


    private bool normalDistanceForAttack;
    private bool canAttackZombieShooter;
    private float timerCoolDown;

    private void Start()
    {
        canAttackZombieShooter = true;
    }
    private void Update()
    {
        CalculatingCoolDown();
        CheckCanAttack();
    }

    private void CheckCanAttack()
    {
        normalDistanceForAttack = GetComponent<ShooterZombieMove>().normalDistanceForAttack;
        if (canAttackZombieShooter && normalDistanceForAttack)
        {
            Instantiate(enemyBullet, firePoint.position, firePoint.rotation);
            timerCoolDown = 0;
        }
    }

    private void CalculatingCoolDown()
    {
        if (timerCoolDown < zombieAttackCoolDown)
        {
            timerCoolDown += Time.deltaTime;
            canAttackZombieShooter = timerCoolDown >= zombieAttackCoolDown;
        }
    }
}
