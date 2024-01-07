using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public GameObject start1_screen;
    public GameObject start2_screen;
    public GameObject start3_screen;
    public GameObject start4_screen;
    public GameObject start5_screen;
    // Start is called before the first frame update
    void Start()
    {
        start1_screen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void main_menu()
    {
        start1_screen.SetActive(false);
        start2_screen.SetActive(true);
    }

    public void star()
    {
        SceneManager.LoadScene("Jogo");
    }

    public void options()
    {
        start2_screen.SetActive(false);
        start3_screen.SetActive(true);
    }

    public void control()
    {
        start4_screen.SetActive(true);
        start3_screen.SetActive(false);
    }

    public void back_to_main()
    {
        start3_screen.SetActive(false);
        start2_screen.SetActive(true);
        start5_screen.SetActive(false);
    }

    public void back_to_option()
    {
        start4_screen.SetActive(false);
        start3_screen.SetActive(true);
    }

    public void credits()
    {
        start5_screen.SetActive(true);
        start2_screen.SetActive(false);
    }
}
