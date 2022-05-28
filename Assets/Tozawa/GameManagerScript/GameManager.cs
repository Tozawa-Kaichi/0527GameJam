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
    public static bool checkpointON = false;
    int _defaultZanki;
    string _nextscenename;//�V�[�����̕⊮��
    Scene _thisScene;//���݂̃V�[��
    // Start is called before the first frame update
    void Start()
    {
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
    }

    void GameStart()//�Q�[���J�n�ƂƂ��Ƀv���C���[��𐶐����Q�[���J�n
    {
        _thisScene = SceneManager.GetActiveScene();//���݂̃V�[�����擾

        checkpointON = false;
        _sp = _spawnPoint.transform;//�����X�|�[���|�C���g�ݒ�
        Instantiate(_playerPrefab, _sp.position, Quaternion.identity);//�v���C���[����
    }
    void GameOver()//�Q�[���I�[�o�[�̏����i�c�@���j�𖞂�������UI�ŕ�����\�����^�C�g�������[�h����
    {
        zanki = _defaultZanki;
        NextStageLoad("Tittle");//�^�C�g���֖߂�
    }
    void Clear()//�S�[���ɐG���E�{�X��|������WinUI��\�����Ď��̃V�[���ɍs��
    {

    }

    public void NextStageLoad(string name)
    {
        StartCoroutine(InGameLoadScene(name));
    }

    public IEnumerator InGameLoadScene(string name)
    {
        yield return new WaitUntil(() => Triger._canFadeOut);//�t�F�[�h����摜�̕���Bool��true�ɂȂ�Ȃ����肱���ő҂��Ă����
        yield return new WaitForSeconds(_loadwaitsecond);//�A�j���[�V�������I�������w�肵���b���҂��Ă����i���ꂢ��H�j
        SceneManager.LoadScene(name);
    }
}
