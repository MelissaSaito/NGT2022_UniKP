//======================================================================================
//�@PlayerLockScript    �쐬��:����
//  ���b�N�I���@�\�̎g�p���i���b�N�I�����̓���͂����ɒǉ��j
//  Player��AddCompornent
//======================================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLockScript : MonoBehaviour
{
    [SerializeField] GameObject lockOn;
    //[SerializeField] GameObject enemyrayscript;


    private GameObject target;
    public bool flash = false;


    void Update()
    {

        //EnemyRayScript enemyRayScript = enemyrayscript.GetComponent<EnemyRayScript>();

        //���b�N�I���V�X�e�����Q�b�g�R���|�[�l���g
        LockOnScript lockOnSystem = lockOn.GetComponent<LockOnScript>();

        //�ΏۂƂȂ�^�[�Q�b�g�������Ă���
        target = lockOnSystem.getTarget();
 

        //���b�N�I����Ԃ�true�̎�
        if (lockOnSystem.getIsLockOn())
        {
            //�^�[�Q�b�g�I�u�W�F�N�g��ChangeMaterial�֐����g�p
            target.SendMessage("ChangeMaterial");
            Debug.Log("���b�N�I����");
            flash = true;
        }
        else
        {
        }
    }

    //�t���b�V���Ō�����Ȃ��Ȃ���
    public bool getFlash()
    {
        return flash;
    }





}
