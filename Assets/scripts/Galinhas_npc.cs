using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Galinhas_npc : MonoBehaviour
{
    [SerializeField] GameObject[] galinhas;
    private SpriteRenderer sr;
    private CircleCollider2D circle;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }



    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            circle.enabled = false;
            Destroy(gameObject, 0f); 
        }
        
    }
}
