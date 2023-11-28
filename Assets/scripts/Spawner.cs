using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstpre;
    [SerializeField] float t1, t2;
    [SerializeField] float temp;

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
        while(true)
        {
            var wanted = Random.Range(t1, t2);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(obstpre[Random.Range(0, obstpre.Length)], position, Quaternion.identity); 
            yield return new WaitForSeconds(temp);
            Destroy(gameObject, 7f);
        }
    }
}
