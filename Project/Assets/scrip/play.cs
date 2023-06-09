using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play : MonoBehaviour
{
    public float bulletspeed = 100;
    public Transform bulletspawn;
    public GameObject bulletprefab;

    public float cooldownspeed;
    public float firerate;
    public float recordcooldown;
    public float accurary;
    public float maxSpred;
    public float Timetill;

    public int startmagSize;
    public int magSize;
    public float reloadtime;
    public bool Reloading;
    public Animator animator;

    public AudioSource gun;
    public AudioClip singleshot;
    public AudioSource gunreload;
    public AudioClip reload;

    public bool AR;
    public bool SMG;
    public bool SR;
    // Start is called before the first frame update
    void Start()
    {
        magSize = startmagSize;
    }
    void OnEnable()
    {
        Reloading = false;
        if (AR == true)
        {
            animator.SetBool("Reloading", false);
        }
        
        if (SMG == true)
        {
            animator.SetBool("SmgReloading", false);
        }

        if (SR == true)
        {
            animator.SetBool("SRreloading", false);
        }


    }
    void Shoot()
    {
        magSize--;
        RaycastHit hit;
        Quaternion fireRotation = Quaternion.LookRotation(transform.forward);
        float currentSpread = Mathf.Lerp(0.0f,maxSpred, accurary/Timetill);
        fireRotation = Quaternion.RotateTowards(fireRotation, Random.rotation, Random.Range(0.0f, currentSpread));
        if(Physics.Raycast(transform.position, fireRotation * Vector3.forward, out hit, Mathf.Infinity))
        {
            var bullet = Instantiate(bulletprefab, bulletspawn.transform.position, bulletspawn.transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletspawn.forward * bulletspeed;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        cooldownspeed += Time.deltaTime *60f;
        if (Reloading == true)
        {
            return;
        }

        
        if (Input.GetMouseButton(0))
        {
            accurary += Time.deltaTime * 4f;
            if(cooldownspeed > firerate)
            {
                Shoot();
                gun.PlayOneShot(singleshot);
                cooldownspeed = 0;
                recordcooldown = 1;
            }
                              
        }
        if(magSize <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        else
        {
            recordcooldown = -Time.deltaTime;
            if(recordcooldown <= 1)
            {
                accurary = 0.0f;
            }
        }
        if (Input.GetKey("r"))
        {
            StartCoroutine(Reload());
            return;

        }
    }
    IEnumerator Reload()
    {
        Reloading = true;
        if (AR == true)
        {
            animator.SetBool("Reloading", true);
        }

        if (SMG == true)
        {
            animator.SetBool("SmgReloading", true);
        }

        if (SR == true)
        {
            animator.SetBool("SRreloading", true);
        }
        yield return new WaitForSeconds(reloadtime);
        gunreload.PlayOneShot(reload);
        if (AR == true)
        {
            animator.SetBool("Reloading", false);
        }

        if (SMG == true)
        {
            animator.SetBool("SmgReloading", false);
        }

        if (SR == true)
        {
            animator.SetBool("SRreloading", false);
        }
        yield return new WaitForSeconds(.45f);
        magSize = startmagSize;
        Reloading = false;
    }

}
