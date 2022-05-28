using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tekinougoki : Enemy
{
    public float speed = 2.0f;
    private Rigidbody2D rd;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void move()
    {
        rd.velocity = new Vector2(speed, rd.velocity.y);   
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if("side" == collision.gameObject.tag)
        {
            speed = speed * -1;
        }
    }
}