using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fila : MonoBehaviour
{
    public Galinha Primeiro;
    public Galinha Ultimo;
    public int Qtd;
    public GameObject[] Cor1;
    public GameObject[] Cor2;
    public GameObject[] Cor3;
    public GameObject[] Cor4;
    public float y;
    player a;


    public class Galinha
    {
        public int cor;
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
                GameObject gameObject = Instantiate(Cor1[Random.Range(0, Cor1.Length)], position, Quaternion.identity);
            }
            else
            {
                if(cor == 2)
                {
                    g.cor = 2;
                    GameObject gameObject = Instantiate(Cor2[Random.Range(0, Cor2.Length)], position, Quaternion.identity);
                }
                else
                {
                    if(cor == 3)
                    {
                        g.cor = 3;
                        GameObject gameObject = Instantiate(Cor3[Random.Range(0, Cor3.Length)], position, Quaternion.identity);
                    }
                    else
                    {
                        g.cor = 4;
                        GameObject gameObject = Instantiate(Cor4[Random.Range(0, Cor4.Length)], position, Quaternion.identity);
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
            cor = 0; // ou algum valor padrão
            ok = false;
        }
        else
        {
            cor = Primeiro.cor;
            Qtd--;
            ok = true;
            if (Primeiro == Ultimo)
            {
                Primeiro = null;
                Ultimo = null;
            }
            else
            {
                g = Primeiro;
                Primeiro = g.Next;
            }
        }
    }
}
