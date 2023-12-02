using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fila : MonoBehaviour
{
    public Galinha Primeiro;
    public Galinha Ultimo;
    public int Qtd;
    //public GameObject[] Cor1;
    //public GameObject[] Cor2;
    //public GameObject[] Cor3;
    //public GameObject[] Cor4;
    public List<GameObject> Cores;
    public float y;
    player a;


    public class Galinha
    {
        public int cor;
        public GameObject obj;
        public Galinha Next;
    }

    void Update()
    {
        a = FindObjectOfType<player>();
        y = a.y;
    }



    public void cria()
    {
        Primeiro = null;
        Ultimo = null;
        Qtd = 0;
    }


    public bool Vazio()
    {
        return Qtd == 0;
    }

    public bool Cheio()
    {
        return Qtd == 5;
    }

    public void Insere(int cor, out bool ok)
    {
        Galinha g;
        if (Cheio())
        {
            ok = false;
        }
        else
        {
            ok = true;
            g = new Galinha();
            Vector3 position = new Vector3(-5.73f - Qtd * 0.5f, y);
            if(cor == 1)
            {
                g.cor = 1;
                g.obj = Instantiate(Cores[0], position, Quaternion.identity);
            }
            else
            {
                if(cor == 2)
                {
                    g.cor = 2;
                    g.obj = Instantiate(Cores[1], position, Quaternion.identity);
                }
                else
                {
                    if(cor == 3)
                    {
                        g.cor = 3;
                        g.obj = Instantiate(Cores[2], position, Quaternion.identity);
                    }
                    else
                    {
                        g.cor = 4;
                        g.obj = Instantiate(Cores[3], position, Quaternion.identity);
                    }
                }
            }
            
            if (Vazio())
            {
                Primeiro = g;
            }
            else
            {
                Ultimo.Next = g;
            }
            Qtd++;
            Ultimo = g;
            g.Next = null;
        }
    }

    public void Retira(out int cor, out bool ok)
    {
        Galinha g;
        if (Vazio())
        {
            cor = 5;
            ok = false;
        }
        else
        {
            cor = Primeiro.cor;
            Qtd--;
            ok = true;
            g = Primeiro;
            if (Primeiro == Ultimo)
            {
                Primeiro = null;
                Ultimo = null;
            }
            else
            {
                Primeiro = g.Next;
            }
            Destroy(g.obj, 0f);
            g = null;
        }
    }
}
