using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterAttack : MonoBehaviour
{
    [SerializeField] CounterScript counterscript;
    public BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
