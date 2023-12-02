using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galinha_roxa : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;
    public bool ok;
    public int cor;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ok == true)
        {
            cor = 1;
            ok = false;
        }

        if(ok == false)
        {
            cor = 5;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            circle.enabled = false;
            Destroy(gameObject, 1f); 
            ok = true;
        }
    }
}
