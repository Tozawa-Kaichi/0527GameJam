using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerscript : MonoBehaviour
{
    [SerializeField] float horizontalSpeed;
    [SerializeField] int jumpForce;
    [SerializeField] float emperorTime;//くらった時の無敵時間
    [SerializeField] private BoxCollider2D attack;
    [SerializeField] float hp = 5;
    float defaultHp = 0;
    Rigidbody2D rb;
    int jumpcount = 0;
   [SerializeField]public static bool _canhit = true;//後でserializefieldを消す
   public CapsuleCollider2D collider;
    float timer = 0;
  // public CounterScript counterscript;

    void Start()
    {
        defaultHp = hp;
        rb = GetComponent < Rigidbody2D >();
        collider = GetComponent<CapsuleCollider2D>();
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

    void Update()
    {
        bool jumpky = Input.GetButtonDown("Jump");
        if (jumpky && jumpcount < 1) //ジャンプの回数制限
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpcount++;
        }
        if(_canhit == false)//無敵時間が始まる
        {
            Muteki(emperorTime);
        }
        if(hp == 0)//hpが0になったとき残機を減らす
        {
            GameManager.zanki--;
            hp = defaultHp;
        }
    }
    public  void Muteki(float second)
    {
        collider.enabled = false;
        timer += Time.deltaTime;
        if (second < timer)//無敵時間が終わる
        {
            _canhit = true;
            collider.enabled = true;
            timer = 0;
        }
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            jumpcount = 0;//カウントリセット
        }
        if(collision.gameObject.tag == "enemy")
        {
            hp--;//エネミーの攻撃が当たるとhpを減らす
            _canhit = false;
            GameManager.playerDeath = true;
        }
    }
   
    private void IsAttack()
    {
        attack.enabled = true;
    }
    private void IsAttack2()
    {
        attack.enabled = false;
    }
}
