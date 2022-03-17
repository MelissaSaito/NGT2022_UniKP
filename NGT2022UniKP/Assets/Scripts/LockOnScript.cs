//======================================================================================
//�@LockOnScript    �쐬��:����
//  �G�����b�N�I������@�\
//  ��̃I�u�W�F�N�g����肻���AddCompornent
//======================================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnScript : MonoBehaviour
{

    private GameObject[] targets;
    private GameObject target;
    private GameObject player;
    private bool isLockOn = false;
    float closeDist;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // �^�O���g���ĉ�ʏ�̑S�Ă̓G�̏����擾
        targets = GameObject.FindGameObjectsWithTag("Enemy");


    }

    void FixedUpdate()
    {
        lockOnProc();

        //F�L�[���������Ƃ��Ƀ��b�N�I����L���ɂ���
        if (Input.GetKey(KeyCode.F))
        {
            isLockOn = true;
        }
        else
        {
            isLockOn = false;
        }


    }

    //���b�N�I������G��I�ԏ���
    public void lockOnProc()
    {

        closeDist = 10000;
        // �u�����l�v�̐ݒ�
        foreach (GameObject t in targets)
        {

            //�G���Q�[����ʓ��ɂ���ꍇ// isRendered == true
            if (t.GetComponent<EnemyManagementScript>().getIsRendered() == true)
            {
                //�G�Ƃ̊Ԃɏ�Q�������ꍇ
                if (Physics.Linecast(player.transform.position, t.transform.position, LayerMask.GetMask("Stage")) == false)
                {
                    //�������鉻
                    Debug.DrawLine(player.transform.position, t.transform.position, Color.red);

                    // �R���\�[����ʂł̊m�F�p�R�[�h
                    print(Vector3.Distance(player.transform.position, t.transform.position));

                    // ���̃I�u�W�F�N�g�i�C�e�j�ƓG�܂ł̋������v��
                    float tDist = Vector3.Distance(player.transform.position, t.transform.position);

                    // �������u�����l�v�����u�v�������G�܂ł̋����v�̕����߂��Ȃ�΁A
                    if (closeDist > tDist)
                    {
                        // �ucloseDist�v���utDist�i���̓G�܂ł̋����j�v�ɒu��������B
                        // ������J��Ԃ����ƂŁA��ԋ߂��G�������o�����Ƃ��ł���B
                        closeDist = tDist;

                        // ��ԋ߂��G�̏���ϐ��Ɋi�[����i���j
                        target = t;
                    }
                }
            }
        }
        return ;
    }

    //���b�N�I������^�[�Q�b�g�̂֏��Q�b�^�[
    public GameObject getTarget()
    {
        return target;
    }

    //���b�N�I�����Q�b�^�[
    public bool getIsLockOn()
    {
        return isLockOn;
    }
}
