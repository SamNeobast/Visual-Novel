using UnityEngine;

public class ShootingPistol : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float timeRechange;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float shakeIntensivity = 5f;
    [SerializeField] private float timeShake = 2f;


    private bool canShoot;
    private float timer;

    private void Awake()
    {
        canShoot = true;
    }

    private void Update()
    {
        OnFire();
        CalculatintCoolDown();
    }

    private void OnFire()
    {
        if (Input.GetMouseButton(0) && canShoot)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            ShakeCinemashine.Instance.ShakeCamera(shakeIntensivity, timeShake);
            canShoot = false;
        }
    }

    private void CalculatintCoolDown()
    {
        if (timer <= timeRechange)
        {
            timer += Time.deltaTime;
            if (timer >= timeRechange)
            {
            canShoot = true;
            timer = 0;
            }
        }
    }
}
