using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]Transform front;
    Rigidbody2D rb;
    [SerializeField]float speed = 5f;
    Vector2 shot;
    [SerializeField] float knockbackP = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector2 x = front.transform.position - this.transform.position;
        shot = speed * x;
        rb = GetComponent< Rigidbody2D>();
        rb.AddForce(shot, ForceMode2D.Impulse);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Vector2 x = collision.transform.position - this.transform.position;
        Vector2 knock = knockbackP * x;
        if (collision.gameObject.tag == "Player")
        {
            var p = collision.gameObject.GetComponent<Rigidbody2D>();
            p.AddForce(knock, ForceMode2D.Force);
        }
        Destroy(this.gameObject);

    }
}
