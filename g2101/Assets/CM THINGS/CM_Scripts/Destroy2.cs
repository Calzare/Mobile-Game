using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy2 : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(deathEffectStop());
    }

        public IEnumerator deathEffectStop()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
