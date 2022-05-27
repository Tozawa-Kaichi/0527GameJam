using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterScript : MonoBehaviour
{
    public Playerscript playerscript;
   public BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
