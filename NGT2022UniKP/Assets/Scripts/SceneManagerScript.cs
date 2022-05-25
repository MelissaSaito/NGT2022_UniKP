//---------------------------------------------------------------------------------------------
// �V�[���ڍs�Ɋւ���v���O����  �쐬:�L�e�C�@���S����Ƃ�:����
//
//---------------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] GameObject player; //�v���C���[�̓��ꕨ
    [SerializeField] PlayerStateScript playerState;//PlayerStateScript�̓��ꕨ


    void Start()
    {
        //�v���C���[��PlayerStateScript�����Ă���
        player = GameObject.Find("Player");
        playerState = player.GetComponent<PlayerStateScript>();
    }

    void FixedUpdate()
    {

        if (SceneManager.GetActiveScene().name == "Title")
        {
            // �������s
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetButton("ControllerY"))
            {
                //�V�[����ς���
                SceneManager.LoadScene("SampleScene");
            }
        }

        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            //�v���C���[�X�e�[�^�X�̏�Ԃ�DEATH�̎�
            if (playerState.flag == StateFlags.DEATH)
            {
                Debug.Log("���S");
                //���̃Q�[���V�[���ׂ̈ɐ����Ԃ点��
                playerState.flag = StateFlags.LIVE;
                //�V�[����ς���
                SceneManager.LoadScene("GameOver");

            }

        }

        if (SceneManager.GetActiveScene().name == "Stage2")
        {
            //�v���C���[�X�e�[�^�X�̏�Ԃ�DEATH�̎�
            if (playerState.flag == StateFlags.DEATH)
            {
                Debug.Log("���S");
                //���̃Q�[���V�[���ׂ̈ɐ����Ԃ点��
                playerState.flag = StateFlags.LIVE;
                //�V�[����ς���
                SceneManager.LoadScene("GameOver");

            }

        }

        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            // �������s
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetButton("ControllerY"))
            {
                //�V�[����ς���
                SceneManager.LoadScene("Title");
            }
        }

    }
}
