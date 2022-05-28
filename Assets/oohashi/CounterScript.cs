using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterScript : MonoBehaviour
{
    [SerializeField] float counterTime;
    [SerializeField] float skillHunter;//カウンター時の無敵時間
    [SerializeField] GameObject player;
    [SerializeField] bool _cancounter = true;//後でserializefieldを消す
    [SerializeField] GameObject cAttack;
    bool counterbool = false;
    Playerscript muteki;
    Collider2D atari;
    BoxCollider2D bc;
    float timer = 0;
   // public CapsuleCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        muteki =player.GetComponent<Playerscript>();
        atari = player.GetComponent<CapsuleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire2"))
        {
            counterbool = true;
        }
        if(counterbool == true)
        {
            Counter();
        }
       
    }
    void Counter()
    {
        bc.enabled = true;
        timer += Time.deltaTime;
        if (_cancounter == false)
        {
            Playerscript._canhit = false;
            muteki.Muteki(skillHunter);
            Instantiate(cAttack,this.transform,this.transform);
            _cancounter = true;
        }
        if (counterTime < timer)
        {
            counterbool = false;
            bc.enabled = false;
            timer = 0;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            _cancounter = false;
        }
    }
}
