using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Galinhas_npc : MonoBehaviour
{
    [SerializeField] GameObject[] galinhas;
    private SpriteRenderer sr;
    private CircleCollider2D circle;
    private int cont;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
        cont = 0;
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
            Destroy(gameObject, 1f);
            
        }
        if(collider.gameObject.tag == "Player")
        {
            var position = new Vector3(-5.73f - cont, transform.position.y);
            GameObject gameObject = Instantiate(galinhas[Random.Range(0, galinhas.Length)], position, Quaternion.identity);
            cont++;
            
        }
    }
}
