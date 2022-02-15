using UnityEngine;

public class Gun : MonoBehaviour
{
    public float cooldownSpeed;
    public float fireRate;
    public float recoilCooldown;
    public float maxSpreadAngle;
    public float timeTillMaxSpread;
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public GameObject bullet;
    public GameObject shootPoint;
    private float accuracy;
    AudioSource rifle_shootingSound;
    
    void Start()
    {
        rifle_shootingSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        cooldownSpeed += Time.deltaTime * 60f;

        if (Input.GetButton("Fire1"))
        {
            accuracy += Time.deltaTime * 4f;

            if (cooldownSpeed >= fireRate)
            {
            Shoot();
            rifle_shootingSound.Play();
            cooldownSpeed = 0;
            recoilCooldown = 1;
            }
        }
        else
        {
            recoilCooldown -= Time.deltaTime;
            if (recoilCooldown <= 1)
            {
                accuracy = 0.0f;
            }
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        Quaternion fireRotation = Quaternion.LookRotation(transform.forward);

        float currentSpread = Mathf.Lerp(0.0f, maxSpreadAngle, accuracy / timeTillMaxSpread);

        fireRotation = Quaternion.RotateTowards(fireRotation, Random.rotation, Random.Range(0.0f, currentSpread));

        // if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        if (Physics.Raycast(transform.position, fireRotation * Vector3.forward, out hit, Mathf.Infinity))
        {
            Debug.Log(hit.transform.name);
            GameObject tempBullet = Instantiate(bullet, shootPoint.transform.position, fireRotation);
            tempBullet.GetComponent<MoveBullet>().hitPoint = hit.point;

            Target target = hit.transform.GetComponent<Target>();
            
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
