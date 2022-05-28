using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _spawnPoint;
    Transform _sp = default;
    [SerializeField] GameObject _checkPoint;
    [SerializeField] public static int zanki = 3;//�c�@
    [SerializeField] GameObject _playerPrefab = default;//�v���C���[�̃v���n�u
    [SerializeField] float _loadwaitsecond = 3f;
    ///
    ///////////////////////////////////////////////////////////////
    /// 
    [SerializeField] GameObject startUI = default;
    [SerializeField] GameObject gameOverUI = default;//         UI
    [SerializeField] GameObject clearUI = default;
    /// <summary>
    /// ////////////////////////////////////////
    /// </summary>


    public static bool checkpointON = false;
    public static bool bossDeath = false;
    public static bool playerDeath = false;
    int _defaultZanki;
    int _buildIndexnum = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameManageTrigger._canloadnextStage = false;
        bossDeath = false;
        _sp = _spawnPoint.transform;//�����X�|�[���|�C���g�ݒ�
        checkpointON = false;
        _defaultZanki = zanki;
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        if(checkpointON == true)//�`�F�b�N�|�C���g�ʉ߂�����
        {
            _sp = _checkPoint.transform;//�X�|�[���|�C���g���`�F�b�N�|�C���g�ɕύX
        }
        if (zanki <= 0)
        {
            GameOver();
        }
        if(bossDeath == true)
        {
            Clear();
        }
        if(playerDeath == true)
        {
            GameStart();
        }
        if(GoalChecker.goalcheck == true)
        {
            Stage1Clear();
        }
    }

    void GameStart()//�Q�[���J�n�ƂƂ��Ƀv���C���[��𐶐����Q�[���J�n
    {
        Instantiate(_playerPrefab, _sp.position, Quaternion.identity);//�v���C���[����
        playerDeath = false;
        startUI.SetActive(true);
    }
    void GameOver()//�Q�[���I�[�o�[�̏����i�c�@���j�𖞂�������UI�ŕ�����\�����^�C�g�������[�h����
    {
        zanki = _defaultZanki;
        gameOverUI.SetActive(true);
        NextStageLoad("Tittle");//�^�C�g���֖߂�
    }
    void Clear()//�S�[���ɐG���E�{�X��|������WinUI��\�����Ď��̃V�[���ɍs��
    {
        clearUI.SetActive(true);
        

    }
    void Stage1Clear()
    {
        GoalChecker.goalcheck = false;
        clearUI.SetActive(true);
        NextStageLoad("Stage2");
    }

    public void NextStageLoad(string name)
    {
        StartCoroutine(InGameLoadScene(name));
    }

    public IEnumerator InGameLoadScene(string name)
    {
        yield return new WaitUntil(() => GameManageTrigger._canloadnextStage);//�t�F�[�h����摜�̕���Bool��true�ɂȂ�Ȃ����肱���ő҂��Ă����
        yield return new WaitForSeconds(_loadwaitsecond);//�A�j���[�V�������I�������w�肵���b���҂��Ă����i���ꂢ��H�j
        SceneManager.LoadScene(name);
    }


   
}
