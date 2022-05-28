using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{   float moveCount = 0;
    [SerializeField]float tackleTime = 20;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
