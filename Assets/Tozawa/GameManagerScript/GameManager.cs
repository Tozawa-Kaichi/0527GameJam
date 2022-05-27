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
            _sp = _checkPoint.transform;//�`�F�b�N�|�C���g�ʉ߂�����X�|�[���|�C���g���`�F�b�N�|�C���g�ɕύX
        }
        if (zanki <= 0)
        {
            GameOver();
        }
    }

    void GameStart()//�Q�[���J�n�ƂƂ��Ƀv���C���[��𐶐����Q�[���J�n
    {
        checkpointON = false;
        _sp = _spawnPoint.transform;//�����X�|�[���|�C���g�ݒ�
        Instantiate(_playerPrefab, _sp.position, Quaternion.identity);
    }
    void GameOver()//�Q�[���I�[�o�[�̏����i�c�@���j�𖞂�������UI�ŕ�����\�����^�C�g�������[�h����
    {


    }
    void Clear()//�S�[���ɐG���E�{�X��|������WinUI��\�����Ď��̃V�[���ɍs��
    {

    }

    
}
