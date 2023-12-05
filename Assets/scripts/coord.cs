using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coord : MonoBehaviour
{
    private Rigidbody2D rig;
    public float y;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        y = rig.position.y - 0.03f;
    }
}
