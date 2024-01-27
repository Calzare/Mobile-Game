using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject Sword;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Sword.SetActive(false);
        }
    }
}
