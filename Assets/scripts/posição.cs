using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posição : MonoBehaviour
{

    public float y;
    coord a;
    // Start is called before the first frame update
    void Start()
    {
        a = FindObjectOfType<coord>();
        transform.eulerAngles = new Vector3(0f, 180f, 0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 novo_position = transform.position;
        novo_position.y = a.y;
        transform.position = novo_position;
    }
}
