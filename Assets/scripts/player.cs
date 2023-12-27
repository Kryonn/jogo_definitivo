using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private GameObject current;
    [SerializeField] private BoxCollider2D playerCollider;

    public bool isjumping;
    public bool plat3;
    public bool start;
    public bool allow;
    public int cor;
    public bool ok;
    public fila f;
    public float y;
    public float y2;
    public bool hit;
    public List<int> pontuacoes;
    


    private Rigidbody2D rig;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        start = true;
        f.cria();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();

        y = rig.position.y;
        y2 = rig.position.y;
        if(rig.position.y >= 2)
        {
            y = 2.933118f;
        }
        else
        {
            if(rig.position.y < 2 && rig.position.y > -1)
            {
                y = -0.1473702f;
            }
            else
            {
                y = -3.042978f;
            }
        }
        


        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(current != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
        
        if(allow == true)
        {
            f.Insere(cor, out ok);
            allow = false;
        }

        if(hit == true)
        {
            f.Retira(out cor, out ok);
            StartCoroutine(hit_anim());
            hit = false;
        }

        
    }

    void Move()
    {

        if(start == true)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
            
    }


    void Jump()
    {
        if((Input.GetButtonDown("Jump") && isjumping == false && plat3 == false && rig.velocity.y == 0))
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            
        }
        
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            isjumping = false;
            current = collision.gameObject;
        }
        else
        {
            if(collision.gameObject.layer == 10)
            {
                isjumping = false;
                plat3 = true;
                current = collision.gameObject;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            isjumping = true;
            current = null;
        }
        else
        {
            if(collision.gameObject.layer == 10)
            {
                isjumping = true;
                plat3 = false;
                current = null;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 15)
        {
            allow = true;
            cor = 1;
        }
        else
        {
            if(collider.gameObject.layer == 16)
            {
                allow = true;
                cor = 2;
            }
            else
            {
                if(collider.gameObject.layer == 17)
                {
                    allow = true;
                    cor = 3;
                }      
                else
                {
                    if(collider.gameObject.layer == 18)
                {
                    allow = true;
                    cor = 4;
                }
                }
            }
        }
        if(collider.gameObject.layer == 4)
        {
            hit = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 15 || collider.gameObject.layer == 16 || collider.gameObject.layer == 17 || collider.gameObject.layer == 18)
        {
            allow = false;
            cor = 0;
        }
        if(collider.gameObject.layer == 4)
        {
            hit = false;
        }
    }


    

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = current.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }

    private IEnumerator hit_anim()
    {
        anim.SetBool("hit", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("hit", false);
    }
    

}
