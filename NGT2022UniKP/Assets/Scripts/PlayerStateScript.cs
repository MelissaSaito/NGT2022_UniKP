//-----------------------------------------------------------------
//  プレイヤーの状態スクリプト
//  作成者:内村      作成日:04/27
//-----------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // Flags付ける時はこれが必要
using UnityEngine.SceneManagement;
using System.Linq;

//プレイヤーの状態
public enum StateFlags
{
    INITIAL = 0,     // 初期状態 
    LIVE = 1,     //　 生存状態
    DEATH = 2,     // 死亡    
}


public class PlayerStateScript : MonoBehaviour
{
    //プレイヤーの状態初期化
    public StateFlags flag = 0;

    void Start()
    {
        //スタート時に生存状態
        flag = StateFlags.LIVE;
    }

    void Update()
    {
        Debug.Log(flag);
    }

}
