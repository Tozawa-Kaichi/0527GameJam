using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triger : MonoBehaviour
{
    //�^�C�g���̃t�F�[�h�A�E�g�p�̃A�j���[�V������̃g���K�[�i�܁j�̃X�N���v�g
    // Start is called before the first frame update
    public static bool _canFadeOut = false;
    public void Trigers()
    {
        _canFadeOut = true;//���̃X�N���v�g�̓t�F�[�h����p�l���E�C���[�W�̂ق��ɕt���Ă������ꂪtrue�ɂȂ��ď��߂�OPFade�̃��[�h�V�[���������o����
    }
}
