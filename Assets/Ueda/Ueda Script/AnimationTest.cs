using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalky = Input.GetAxisRaw("Horizontal");
        if (horizontalky == 0.0)
        {
            anim.SetBool("isRun", false);
        }
        else
        {
            anim.SetBool("isRun", true);
        }
        bool jumpky = Input.GetButtonDown("Jump");
        if (jumpky) //ÉWÉÉÉìÉvÇÃâÒêîêßå¿
        {
            anim.SetBool("isJump",true);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("isAttack");
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            anim.SetBool("isJump",false);
        }
    }
    
}
