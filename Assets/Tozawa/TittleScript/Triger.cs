using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triger : MonoBehaviour
{
    //タイトルのフェードアウト用のアニメーション上のトリガー（爪）のスクリプト
    // Start is called before the first frame update
    public static bool _canFadeOut = false;
    public void Trigers()
    {
        _canFadeOut = true;//このスクリプトはフェードするパネル・イメージのほうに付けておくこれがtrueになって初めてOPFadeのロードシーンが動き出せる
    }
}
