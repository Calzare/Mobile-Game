using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public GameObject Ghoulie;

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <- 0)
        {
            Die();
        }
    }

    void Die()
    {
        Ghoulie.GetComponent<Renderer>().material.color = new Color(0.2169811f, 0.1646342f, 0.06243321f);
        Destroy(gameObject);
    }
}
