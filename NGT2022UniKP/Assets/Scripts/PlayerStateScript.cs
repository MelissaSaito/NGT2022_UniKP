//-----------------------------------------------------------------
//  �v���C���[�̏�ԃX�N���v�g
//  �쐬��:����      �쐬��:04/27
//-----------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // Flags�t���鎞�͂��ꂪ�K�v
using UnityEngine.SceneManagement;
using System.Linq;

//�v���C���[�̏��
public enum StateFlags
{
    INITIAL = 0,     // ������� 
    LIVE = 1,     //�@ �������
    DEATH = 2,     // ���S    
}


public class PlayerStateScript : MonoBehaviour
{
    //�v���C���[�̏�ԏ�����
    public StateFlags flag = 0;

    void Start()
    {
        //�X�^�[�g���ɐ������
        flag = StateFlags.LIVE;
    }

    void Update()
    {
        Debug.Log(flag);
    }

}
