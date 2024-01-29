using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject Player;
void OnTriggerEnter2D( Collider2D collider)
{
    Player.transform.position = teleportTarget.transform.position;
}
}
