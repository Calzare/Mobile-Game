using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject sword;
    public int damage = 20;
    public Rigidbody2D rb;

    void start()
    {
        StartCoroutine(SelfDestruct());
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Ghoul ghoul = hitInfo.GetComponent<Ghoul>();
        if (ghoul != null)
        {
            ghoul.TakeDamage(damage);
        }

        sword.SetActive(false);
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds (1f);
        sword.SetActive(false);
    }
}
