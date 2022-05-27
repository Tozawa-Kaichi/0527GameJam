using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerscript : MonoBehaviour
{
    [SerializeField] float horizontalSpeed;
    [SerializeField] int jumpForce;
    [SerializeField] float emperorTime;
    [SerializeField] float hp = 5;
    float defaultHp = 0;
    Rigidbody2D rb;
    int jumpcount = 0;
   [SerializeField] bool _canhit = true;
    CapsuleCollider2D collider;
    float timer = 0;
    // Start is called before the first frame update
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
            rb.velocity = new Vector2(horizontalSpeed, rb.velocity.y);//�E�ړ�
        }
        if(horizontalky < 0)
        {
            transform.rotation = new Quaternion(0, 1f, 0, 0);//���]
            rb.velocity = new Vector2(-horizontalSpeed, rb.velocity.y);//���ړ�
        }

    }
    // Update is called once per frame
    void Update()
    {
        bool jumpky = Input.GetButtonDown("Jump");
        if (jumpky && jumpcount < 1) //�W�����v�̉񐔐���
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpcount++;
        }
        if(_canhit == false)//���G���Ԃ��n�܂�
        {
            collider.enabled = false;
            timer += Time.deltaTime;
            if(emperorTime < timer)//���G���Ԃ��I���
            {
                _canhit = true;
                collider.enabled = true;
                timer = 0;
            }
        }
        if(hp == 0)//hp��0�ɂȂ����Ƃ��c�@�����炷
        {
            GameManager.zanki--;
            hp = defaultHp;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            jumpcount = 0;//�J�E���g���Z�b�g
        }
        if(collision.gameObject.tag == "enemy")
        {
            hp--;//�G�l�~�[�̍U�����������hp�����炷
            _canhit = false;
        }
    }
}
