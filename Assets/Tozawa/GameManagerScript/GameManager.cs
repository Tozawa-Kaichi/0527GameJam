using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _spawnPoint;
    [SerializeField] public static int zanki = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {

        if (zanki <= 0)
        {
            GameOver();
        }
    }

    void GameStart()//ゲーム開始とともにプレイヤーｯを生成しゲーム開始
    {

    }
    void GameOver()//ゲームオーバーの条件（残機数）を満たしたらUIで負けを表示しタイトルをロードする
    {


    }
    void Clear()//ゴールに触れる・ボスを倒したらWinUIを表示して次のシーンに行く
    {

    }

    
}
