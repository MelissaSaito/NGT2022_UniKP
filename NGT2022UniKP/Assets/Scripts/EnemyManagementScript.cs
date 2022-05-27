//======================================================================================
//　EnemyManagementScript    作成者:内村
//  エネミーがメインカメラに写っているかの判定とエネミーのマテリアルを変更する処理
//  EnemyにAddCompornent
//======================================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagementScript : MonoBehaviour
{
    //メインカメラに付いているタグ名
    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";
    //カメラに表示されているか
    private bool isRendered = false;

    //光らせる関係-------------------------------
    // 第二引数をTrueにするとHDRカラーパネルになる
    [ColorUsage(false, true)] public Color color1;
    private MeshRenderer enemyMesh;
    //-------------------------------------------

    //このスクリプトインスタンスを作ってる
    public static EnemyManagementScript instance;

    // Start is called before the first frame update
    void Start()
    {

        enemyMesh = GetComponent<MeshRenderer>();

        //// マテリアルの変更するパラメータを事前に知らせる
        //enemyMesh.material.EnableKeyword("_EMISSION");


    }

    // Update is called once per frame
    void Update()
    {
        //カメラに写ってないときはfalse
        isRendered = false;

        //空のインスタンスにこのスクリプトを入れてる
        if (instance == null)
        {
            instance = this;
        }

    }

    //カメラに映ってる間に呼ばれる
    private void OnWillRenderObject()
    {
        //メインカメラに映った時だけ_isRenderedを有効に
        if (Camera.current.tag == MAIN_CAMERA_TAG_NAME)
        {

            isRendered = true;
        }
    }

    //カメラに写ってるかの情報ゲッター
    public bool getIsRendered()
    {
        return isRendered;
    }


    //マテリアルを変更する関数
    public void ChangeMaterial()
    {
        enemyMesh.material.SetColor("_EmissionColor", color1);

    }

}
