using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _spawnPoint;
    Transform _sp = default;
    [SerializeField] GameObject _checkPoint;
    [SerializeField] public static int zanki = 3;
    [SerializeField] GameObject _playerPrefab = default;
    public static bool checkpointON = false;
    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        if(checkpointON == true)
        {
            _sp = _checkPoint.transform;//チェックポイント通過したらスポーンポイントをチェックポイントに変更
        }
        if (zanki <= 0)
        {
            GameOver();
        }
    }

    void GameStart()//ゲーム開始とともにプレイヤーｯを生成しゲーム開始
    {
        checkpointON = false;
        _sp = _spawnPoint.transform;//初期スポーンポイント設定
        Instantiate(_playerPrefab, _sp.position, Quaternion.identity);
    }
    void GameOver()//ゲームオーバーの条件（残機数）を満たしたらUIで負けを表示しタイトルをロードする
    {


    }
    void Clear()//ゴールに触れる・ボスを倒したらWinUIを表示して次のシーンに行く
    {

    }

    
}
