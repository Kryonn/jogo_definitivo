using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dead : MonoBehaviour
{

    public float Speed;
    private Rigidbody2D rig;
    public float JumpForce;
    float f;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        rotation();
    }

    void Move()
    {
        Vector3 movement = new Vector3 (-1f, 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
    }

    void rotation()
    {
        f = f + Time.deltaTime * 800;
        transform.rotation = Quaternion.Euler(0, 0, f);
    }

    


}
