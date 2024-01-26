using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    Rigidbody2D rb;

    public bool isFlipped = false; 

    public int maxHealth = 100;
    public int currentHealth;

    
    void Start()
    {
        currentHealth = maxHealth;
        rb = animator.GetComponent<Rigidbody2D>();
    }
    
    
    public void TakeDamage (int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("IsDead", true); 
        StartCoroutine(Dead());
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z*= -1f;

        if(transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f ,180f ,0f );
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public IEnumerator Dead()
    {
        yield return new WaitForSeconds(0.75f);
        Destroy(gameObject);
    }

}
