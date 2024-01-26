using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireballPrefab;
    public bool CD = false;
    public GameObject Sword;
    public bool CDSword;

    // Update is called once per frame
    void Update()
    {
        if (CD == false)
     {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            CD = true;
            StartCoroutine(CoolDown());
        }
     }
     if (CDSword == false)
     {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Sword.SetActive(true);
            StartCoroutine(SwordCD());
        }
     }
    }

    void Shoot()
    {
        Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
    }
    
    private IEnumerator SwordCD()
    {
        yield return new WaitForSeconds (0.1f);
        CDSword = false;
    }
    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds (2f);
        CD = false;
    }
}
