//======================================================================================
//　PlayerLockScript    作成者:内村
//  ロックオン機能の使用等（ロックオン時の動作はここに追加）
//  PlayerにAddCompornent
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

        //ロックオンシステムをゲットコンポーネント
        LockOnScript lockOnSystem = lockOn.GetComponent<LockOnScript>();

        //対象となるターゲットを持ってくる
        target = lockOnSystem.getTarget();
 

        //ロックオン状態がtrueの時
        if (lockOnSystem.getIsLockOn())
        {
            //ターゲットオブジェクトのChangeMaterial関数を使用
            target.SendMessage("ChangeMaterial");
            Debug.Log("ロックオン中");
            flash = true;
        }
        else
        {
        }
    }

    //フラッシュで見つからなくなるやつ
    public bool getFlash()
    {
        return flash;
    }





}
