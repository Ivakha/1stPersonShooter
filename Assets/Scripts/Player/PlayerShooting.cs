using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour {

    public GameObject bulletHole;
    public int damage = 1;
    public float timeBetweenShots = 1.5f;
    public int gunCapacity = 2;
    public int ammoLeftInGun = 2;
    public int ammo = 8;
    public Text ammoText;
    public float reloadTime = 1.4f;
    public GameObject gunFlash;
    public Transform shootPoint;
    public GameObject wallHit;

    int shootableMask;
    int enemyMask;
    float time;
    Animator animator;

	void Start () {
        UpdateAmmoText();
        time = timeBetweenShots + 1f;
        animator = GetComponentInChildren<Animator>();
        shootableMask = LayerMask.NameToLayer("Shootable");
        enemyMask = LayerMask.NameToLayer("Enemy");
	}

	void FixedUpdate () {
        if (Input.GetButtonDown("Fire1") && time > timeBetweenShots)
        {
            Shoot();
        }
        time += Time.deltaTime;
	}

    void Shoot()
    {
        if (ammoLeftInGun == 0 && ammo == 0) //TEMP SOLUTION!!!!
        {
            //StartCoroutine(CalculateAmmoAfterReload());
            return;
        }
        StartCoroutine(TempShoot());
        animator.SetTrigger("Shoot");
        time = 0;
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Instantiate(gunFlash, shootPoint.position, shootPoint.rotation);

        if (Physics.Raycast(ray, out hit, 10000f))
        {
            GameObject other = hit.transform.gameObject;
            if (other.layer == shootableMask)
            {
                Instantiate(bulletHole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                Instantiate(wallHit, hit.point, Quaternion.Euler(new Vector3(270, 0, 0)));
            }
            else
                if (other.layer == enemyMask)
                {
                    EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
                    enemyHealth.TakeDamage(damage);
                }
        }
        //StartCoroutine(CalculateAmmoAfterShot());
    }

    IEnumerator TempShoot()
    {
        ammoLeftInGun = 0;
        UpdateAmmoText();
        yield return new WaitForSeconds(reloadTime);
        ammo -= 2;
        if (ammo < 0)
        {
            ammo = 0;
        }
        else
        {
            ammoLeftInGun = 2;
        }
        UpdateAmmoText();
    }

    /*
    IEnumerator CalculateAmmoAfterShot()
    {
        ammoLeftInGun -= 2; //need2fix!!!
        if (ammoLeftInGun == 0)
        {
            StartCoroutine(CalculateAmmoAfterReload());
        }
        else
        {
            UpdateAmmoText();
        }
        yield return new WaitForEndOfFrame();
    }

    IEnumerator CalculateAmmoAfterReload()
    {
        if (ammo == 0)
        {
            yield return new WaitForEndOfFrame();
        }
        else
        {
            yield return new WaitForSeconds(reloadTime);
            if (ammo < gunCapacity)
            {
                ammoLeftInGun = ammo;
                ammo = 0;
            }
            else
            {
                ammoLeftInGun = gunCapacity;
                ammo -= gunCapacity;
            }
            UpdateAmmoText();
        }
    }
    */
    void UpdateAmmoText()
    {
        ammoText.text = ammoLeftInGun.ToString() + " / " + ammo;
    }

    public void AddAmmo (int amount)
    {
        ammo += amount;
        UpdateAmmoText();
    }
}
