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

    void GameStart()//�Q�[���J�n�ƂƂ��Ƀv���C���[��𐶐����Q�[���J�n
    {

    }
    void GameOver()//�Q�[���I�[�o�[�̏����i�c�@���j�𖞂�������UI�ŕ�����\�����^�C�g�������[�h����
    {


    }
    void Clear()//�S�[���ɐG���E�{�X��|������WinUI��\�����Ď��̃V�[���ɍs��
    {

    }

    
}
