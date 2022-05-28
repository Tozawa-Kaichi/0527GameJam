using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _spawnPoint;
    Transform _sp = default;
    [SerializeField] GameObject _checkPoint;
    [SerializeField] public static int zanki = 3;//残機
    [SerializeField] GameObject _playerPrefab = default;//プレイヤーのプレハブ
    [SerializeField] float _loadwaitsecond = 3f;
    public static bool checkpointON = false;
    int _defaultZanki;
    string _nextscenename;//シーン名の補完先
    Scene _thisScene;//現在のシーン
    // Start is called before the first frame update
    void Start()
    {
        _defaultZanki = zanki;
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        if(checkpointON == true)//チェックポイント通過したら
        {
            _sp = _checkPoint.transform;//スポーンポイントをチェックポイントに変更
        }
        if (zanki <= 0)
        {
            GameOver();
        }
    }

    void GameStart()//ゲーム開始とともにプレイヤーｯを生成しゲーム開始
    {
        _thisScene = SceneManager.GetActiveScene();//現在のシーンを取得

        checkpointON = false;
        _sp = _spawnPoint.transform;//初期スポーンポイント設定
        Instantiate(_playerPrefab, _sp.position, Quaternion.identity);//プレイヤー生成
    }
    void GameOver()//ゲームオーバーの条件（残機数）を満たしたらUIで負けを表示しタイトルをロードする
    {
        zanki = _defaultZanki;
        NextStageLoad("Tittle");//タイトルへ戻る
    }
    void Clear()//ゴールに触れる・ボスを倒したらWinUIを表示して次のシーンに行く
    {

    }

    public void NextStageLoad(string name)
    {
        StartCoroutine(InGameLoadScene(name));
    }

    public IEnumerator InGameLoadScene(string name)
    {
        yield return new WaitUntil(() => Triger._canFadeOut);//フェードする画像の方のBoolがtrueにならない限りここで待ってくれる
        yield return new WaitForSeconds(_loadwaitsecond);//アニメーションが終わった後指定した秒数待ってくれる（これいる？）
        SceneManager.LoadScene(name);
    }
}
