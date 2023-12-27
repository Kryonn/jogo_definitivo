using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fila : MonoBehaviour
{
    public Galinha Primeiro;
    public Galinha Ultimo;
    public int Qtd;
    public List<GameObject> Cores;
    public List<int> pontuacoes;
    public List<GameObject> colisao;
    private GameObject dead;
    public float y;
    public float y2;
    player a;


    public class Galinha
    {
        public int cor;
        public GameObject obj;
        public Galinha Next;
        public float coord;
    }

    void Update()
    {
        a = FindObjectOfType<player>();
        y = a.y;
        y2 = a.y2;
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
                score.instance.score_total += pontuacoes[0];
            }
            else
            {
                if(cor == 2)
                {
                    g.cor = 2;
                    g.obj = Instantiate(Cores[1], position, Quaternion.identity);
                    score.instance.score_total += pontuacoes[1];
                }
                else
                {
                    if(cor == 3)
                    {
                        g.cor = 3;
                        g.obj = Instantiate(Cores[2], position, Quaternion.identity);
                        score.instance.score_total += pontuacoes[2];
                    }
                    else
                    {
                        g.cor = 4;
                        g.obj = Instantiate(Cores[3], position, Quaternion.identity);
                        score.instance.score_total += pontuacoes[3];
                    }
                }
            }
            g.coord = -5.73f - Qtd * 0.5f;
            
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
        int cont = 0;
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
            score.instance.score_total -= pontuacoes[g.cor - 1];
            Destroy(g.obj, 0f);
            Vector3 pos = new Vector3(-5.73f, y2);
            dead = Instantiate(colisao[g.cor - 1], pos, Quaternion.identity);
            Destroy(dead, 2f);
            g = Primeiro;
            while(g != null)
            {
                Vector3 position = new Vector3(-5.73f - cont * 0.5f, y);
                Destroy(g.obj, 0f);
                g.obj = Instantiate(Cores[g.cor - 1], position, Quaternion.identity);
                g = g.Next;
                cont++;
            }
        }
    }
}
