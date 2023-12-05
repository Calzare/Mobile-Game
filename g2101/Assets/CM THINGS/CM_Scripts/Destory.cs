using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(deathEffectStop());
    }

        public IEnumerator deathEffectStop()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
