using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireballPrefab;
    public bool CD = false;

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
    }

    void Shoot()
    {
        Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
    }
    
    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds (2f);
        CD = false;
    }
}
