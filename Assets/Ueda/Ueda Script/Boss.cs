using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{   
    [SerializeField]float tackleTime = 20;
    float timer = 0;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform barrel;
    [SerializeField] float cooltime = 2f;
    float count = 0;
    Animator bossAnim;
    // Start is called before the first frame update
    void Start()
    {
        bossAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if(count > cooltime )
        {
            Instantiate(bullet, barrel.position,barrel.rotation);
            count = 0;
        }
        timer += Time.deltaTime;
        if (timer >tackleTime)
        {
            bossAnim.SetTrigger("Tackle");
            timer = 0;
        }
        if (hp <= 0)
        {
            bossAnim.SetTrigger("Death");
            GameManager.bossDeath = true;
        }
    }

}
