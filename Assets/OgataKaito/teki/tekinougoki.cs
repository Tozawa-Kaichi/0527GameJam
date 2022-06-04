using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tekinougoki : Enemy
{
    [SerializeField] float speed = 2.0f;
    Rigidbody2D _rd2D;
    // Start is called before the first frame update
    void Start()
    {
        _rd2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void move()
    {
        _rd2D.velocity = new Vector2(speed, _rd2D.velocity.y);   
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "side" )
        {
            speed = speed * -1;
        }
    }
}
