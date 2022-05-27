using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerscript : MonoBehaviour
{
    [SerializeField] float horizontalSpeed;
    [SerializeField] int jumpForce;
    Rigidbody2D rb;
    int jumpcount = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent < Rigidbody2D >();
    }

    void FixedUpdate()
    {
        float horizontalky = Input.GetAxisRaw("Horizontal");
        if(horizontalky > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            rb.velocity = new Vector2(horizontalSpeed, rb.velocity.y);//右移動
        }
        if(horizontalky < 0)
        {
            transform.rotation = new Quaternion(0, 1f, 0, 0);//反転
            rb.velocity = new Vector2(-horizontalSpeed, rb.velocity.y);//左移動
        }

    }
    // Update is called once per frame
    void Update()
    {
        bool jumpky = Input.GetButtonDown("Jump");
        if (jumpky && jumpcount < 1) 
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);//ジャンプ計算
            jumpcount++;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            jumpcount = 0;//カウントリセット
        }
    }
}
