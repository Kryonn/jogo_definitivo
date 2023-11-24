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

    private Rigidbody2D rig;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();


        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(current != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
    }

    void Move()
    {
        Vector3 movement = new Vector3 (Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        if(Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if(Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if(Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("walk", false);
        }
            
    }


    void Jump()
    {
        if((Input.GetButtonDown("Jump") && isjumping == false && plat3 == false && rig.velocity.y == 0))
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            


            if(isjumping == true)
            {
                anim.SetBool("jump", true);
            }
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
                plat3 = true;
                current = collision.gameObject;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8  || collision.gameObject.layer == 9 || collision.gameObject.layer == 10)
        {
            isjumping = true;
            current = null;
            plat3 = false;
        }
    }

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = current.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }


}
