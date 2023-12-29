using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public bool on;
    public bool on1;
    public bool go_pause;
    player a;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        on = false;
        a = FindObjectOfType<player>();
    }

    // Update is called once per frame
    void Update()
    {
        go_pause = a.go_pause;
        if(Input.GetKeyDown(KeyCode.Escape) || a.freeze == true)
        {
            pausar();
        }
        
        if(go_pause == true)
        {
            go_pausar();
        }
    }

    private void pausar()
    {
        if(on == false)
        {
            Time.timeScale = 0f;
            on = true;
        }
        else
        {
            Time.timeScale = 1f;
            on = false;
        }
    }

    private void go_pausar()
    {
        Time.timeScale = 0f;
        on1 = true;
    }
}
