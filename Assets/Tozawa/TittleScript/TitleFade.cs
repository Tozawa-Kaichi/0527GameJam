using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleFade : MonoBehaviour
{
    [SerializeField] float _waitsecond;
    string _thisScene;
    void Start()
    {
        _thisScene = SceneManager.GetActiveScene().name;//�g���Ė����Ȃ��H
    }

    public void TitleLoad(string name)
    {
        StartCoroutine(LoadScene(name));
    }
    public IEnumerator LoadScene(string name)
    {
        yield return new WaitUntil(() => Triger._canFadeOut);//�t�F�[�h����摜�̕���Bool��true�ɂȂ�Ȃ����肱���ő҂��Ă����
        yield return new WaitForSeconds(_waitsecond);//�A�j���[�V�������I�������w�肵���b���҂��Ă����i���ꂢ��H�j
        SceneManager.LoadScene(name);
    }
}
