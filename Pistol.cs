using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour
{
    RaycastHit hit;//silah bir yere vuracagı için tanımladık 
    public ParticleSystem muzzleFlash;

    AudioSource pistolAS;
    public AudioClip shootAC;
    public AudioClip emptyFire;
    public AudioClip reloadAC;

    Animator anim;

    bool isReloading;

    public int currentAmmo; //tabancadaki mevcut mermi sayısı
    public int maxAmmo; //tabancanın max mermi kapasitesi
    public int carriedAmmo; //taşınan mermi

    [SerializeField]
    float rateOfFire; //ne kadar sürede atış edebilecegini hesaplayabilecek için
    float nextFire = 0;


    [SerializeField]
    float weaponRange;//silah mesafesi

    public float damage = 20f;
   


    public Transform shootPoint;//merminin çıkacagı yer/nokta

    public Text currentAmmoText;
    public Text carriedAmmoText;

    public GameObject metalBulletHole;
    public AudioClip shootMetalAC;

   // public GameObject bloodEffect;


    void Start()
    {

        UpdateAmmoUI();
        anim = GetComponent<Animator>();

        pistolAS = GetComponent<AudioSource>();
        muzzleFlash.Stop();//ateş efekti
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && currentAmmo > 0)//sol tuş mouse 0
        {
            Shoot();
        }
        else if(Input.GetButton("Fire1") && currentAmmo <= 0 && !isReloading)
        {
            EmptyFire();
        }
        else if(Input.GetKeyDown(KeyCode.R)&& currentAmmo <= maxAmmo && !isReloading)
        {
            isReloading = true;
            Reload();
        }
    }

    void Shoot()
    {
        if (Time.time > nextFire)//Time.time oyunda geçen süre demektir.
        {
            nextFire = Time.time + rateOfFire;//mermilerin arasına süre koymak için
            anim.SetTrigger("Shoot");
            StartCoroutine(pistolEffect());
            pistolAS.PlayOneShot(shootAC);//birkez çalmak
            currentAmmo -= 1;
            ShootRay();
            UpdateAmmoUI();
            
        }
    }

    void ShootRay()
    {

        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, weaponRange))
        {
            if (hit.transform.tag == "Enemy")
            {
                EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
                enemy.ReduceHealth(damage);
                //Instantiate(bloodEffect, hit.point, transform.rotation);
            }
            else if (hit.transform.tag == "Metal")
            {
                pistolAS.PlayOneShot(shootMetalAC);
                Instantiate(metalBulletHole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));//ınstantiate yaratmak oluşturmak demek
            }
            else if (hit.transform.tag == "Head")
            {
                EnemyHealth enemy = hit.transform.GetComponentInParent<EnemyHealth>();
                enemy.ReduceHealth(40f);
                hit.transform.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("SOMETHİNG");
            }
          
        }
    }

    void Reload()
    {
        if (carriedAmmo <= 0) return;
        anim.SetTrigger("Reload");
        pistolAS.PlayOneShot(reloadAC);
        StartCoroutine(ReloadCountDown(2f));
        
    }

    void EmptyFire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + rateOfFire;
            pistolAS.PlayOneShot(emptyFire);
            anim.SetTrigger("EmptyFire");
        }
    }

    public void UpdateAmmoUI()
    {
        currentAmmoText.text = currentAmmo.ToString();
        carriedAmmoText.text = carriedAmmo.ToString();
    }

    IEnumerator pistolEffect()
    {
        muzzleFlash.Play();
        yield return new WaitForEndOfFrame();
        muzzleFlash.Stop();
    }
    IEnumerator ReloadCountDown(float timer)
    {
        while (timer > 0f)
        {
            
            timer -= Time.deltaTime;
            yield return null;
        }
        if (timer <= 0)
        {
            isReloading = false;
            int bulletNeeded = maxAmmo - currentAmmo;
            int bulletsToDeduct = (carriedAmmo >= bulletNeeded) ? bulletNeeded : carriedAmmo;
            carriedAmmo -= bulletsToDeduct;
            currentAmmo += bulletsToDeduct;
            UpdateAmmoUI();
        }
    }

}
