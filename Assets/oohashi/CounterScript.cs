using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterScript : MonoBehaviour
{
    [SerializeField] float counterTime;
    [SerializeField] float skillHunter;//カウンター時の無敵時間
    [SerializeField] GameObject player;
    bool counterbool = false;
    Playerscript muteki;
    BoxCollider2D bc;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        muteki =player.GetComponent<Playerscript>();
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
        timer += Time.deltaTime;
        muteki.Muteki(skillHunter);
        bc.enabled = true;
        if (counterTime < timer)
        {
            counterbool = false;
            bc.enabled = false;
            timer = 0;
        }
    }
}
