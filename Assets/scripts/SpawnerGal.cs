using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGal : MonoBehaviour
{
    [SerializeField] GameObject[] obstpre;
    [SerializeField] float t1, t2;
    [SerializeField] float temp;
    [SerializeField] int t3, t4, plat;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ObsSpawn());
    }

    // Update is called once per frame
    //void Update()
    //{
    //   
    //}

    IEnumerator ObsSpawn()
    {
        float y;
        while(true)
        {
            plat = Random.Range(t3, t4);
            if(plat == 1)
            {
                y = -3.154f;
            }
            else
            {
                if(plat == 2)
                {
                    y = 0.25f;
                }
                else
                {
                    y = 3.27f;
                }
            }
            var wanted = Random.Range(t1, t2);
            var position = new Vector3(wanted, y);
            GameObject gameObject = Instantiate(obstpre[Random.Range(0, obstpre.Length)], position, Quaternion.identity); 
            yield return new WaitForSeconds(temp);
            Destroy(gameObject, 7f);
        }
    }
}