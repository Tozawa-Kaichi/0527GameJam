using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CF : MonoBehaviour
{
    GameObject player;
    GameObject mcamera;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        mcamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("player");
        mcamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 10);
        this.transform.position = player.transform.position;
    }
}
