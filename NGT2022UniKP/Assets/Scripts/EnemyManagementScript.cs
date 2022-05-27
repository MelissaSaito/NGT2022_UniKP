//======================================================================================
//�@EnemyManagementScript    �쐬��:����
//  �G�l�~�[�����C���J�����Ɏʂ��Ă��邩�̔���ƃG�l�~�[�̃}�e���A����ύX���鏈��
//  Enemy��AddCompornent
//======================================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagementScript : MonoBehaviour
{
    //���C���J�����ɕt���Ă���^�O��
    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";
    //�J�����ɕ\������Ă��邩
    private bool isRendered = false;

    //���点��֌W-------------------------------
    // ��������True�ɂ����HDR�J���[�p�l���ɂȂ�
    [ColorUsage(false, true)] public Color color1;
    private MeshRenderer enemyMesh;
    //-------------------------------------------

    //���̃X�N���v�g�C���X�^���X������Ă�
    public static EnemyManagementScript instance;

    // Start is called before the first frame update
    void Start()
    {

        enemyMesh = GetComponent<MeshRenderer>();

        //// �}�e���A���̕ύX����p�����[�^�����O�ɒm�点��
        //enemyMesh.material.EnableKeyword("_EMISSION");


    }

    // Update is called once per frame
    void Update()
    {
        //�J�����Ɏʂ��ĂȂ��Ƃ���false
        isRendered = false;

        //��̃C���X�^���X�ɂ��̃X�N���v�g�����Ă�
        if (instance == null)
        {
            instance = this;
        }

    }

    //�J�����ɉf���Ă�ԂɌĂ΂��
    private void OnWillRenderObject()
    {
        //���C���J�����ɉf����������_isRendered��L����
        if (Camera.current.tag == MAIN_CAMERA_TAG_NAME)
        {

            isRendered = true;
        }
    }

    //�J�����Ɏʂ��Ă邩�̏��Q�b�^�[
    public bool getIsRendered()
    {
        return isRendered;
    }


    //�}�e���A����ύX����֐�
    public void ChangeMaterial()
    {
        enemyMesh.material.SetColor("_EmissionColor", color1);

    }

}
