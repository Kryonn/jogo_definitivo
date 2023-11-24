using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    private float length, StartPos;
    private Transform cam;

    public float ParEff;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float Distance = cam.transform.position.x * ParEff;

        transform.position = new Vector3(StartPos + Distance, transform.position.y, transform.position.z);
    }
}
