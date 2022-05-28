using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float knockbackP = 1f;
    [SerializeField] public int hp = 5;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            anim.SetTrigger("Death");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 x = collision.transform.position - this.transform.position;
        Vector2 knock = knockbackP * x;
        if (collision.gameObject.tag == "Player")
        {
            var p =collision.gameObject.GetComponent<Rigidbody2D>();
            p.AddForce(knock,ForceMode2D.Impulse);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hp = 0;
    }
    void Death()
    {
        Destroy(this.gameObject);
    }

}
