using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Testing : MonoBehaviour
{
    public GameObject Player;
    public bool LeftClick = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { if (LeftClick == true)
        {
            Player.transform.Translate(Vector2.right * Time.deltaTime);
        }
    }
}
