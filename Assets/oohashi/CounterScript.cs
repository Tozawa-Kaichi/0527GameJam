using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterScript : MonoBehaviour
{
    [SerializeField] float counterTime;
    BoxCollider2D bc;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            bc.enabled = true;
        }
        if(bc.enabled == true)
        {
            timer += Time.deltaTime;
            if(counterTime < timer)
            {
                bc.enabled = false;
                timer = 0;
            }
        }
    }
}
