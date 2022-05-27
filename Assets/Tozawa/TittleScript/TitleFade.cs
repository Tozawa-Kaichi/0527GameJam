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
        _thisScene = SceneManager.GetActiveScene().name;//使って無くない？
    }

    public void TitleLoad(string name)
    {
        StartCoroutine(LoadScene(name));
    }
    public IEnumerator LoadScene(string name)
    {
        yield return new WaitUntil(() => Triger._canFadeOut);//フェードする画像の方のBoolがtrueにならない限りここで待ってくれる
        yield return new WaitForSeconds(_waitsecond);//アニメーションが終わった後指定した秒数待ってくれる（これいる？）
        SceneManager.LoadScene(name);
    }
}
