//======================================================================================
//　LockOnScript    作成者:内村
//  敵をロックオンする機能
//  空のオブジェクトを作りそれにAddCompornent
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
        // タグを使って画面上の全ての敵の情報を取得
        targets = GameObject.FindGameObjectsWithTag("Enemy");


    }

    void FixedUpdate()
    {
        lockOnProc();

        //Fキーを押したときにロックオンを有効にする
        if (Input.GetKey(KeyCode.F))
        {
            isLockOn = true;
        }
        else
        {
            isLockOn = false;
        }


    }

    //ロックオンする敵を選ぶ処理
    public void lockOnProc()
    {

        closeDist = 10000;
        // 「初期値」の設定
        foreach (GameObject t in targets)
        {

            //敵がゲーム画面内にいる場合// isRendered == true
            if (t.GetComponent<EnemyManagementScript>().getIsRendered() == true)
            {
                //敵との間に障害物無い場合
                if (Physics.Linecast(player.transform.position, t.transform.position, LayerMask.GetMask("Stage")) == false)
                {
                    //線見える化
                    Debug.DrawLine(player.transform.position, t.transform.position, Color.red);

                    // コンソール画面での確認用コード
                    print(Vector3.Distance(player.transform.position, t.transform.position));

                    // このオブジェクト（砲弾）と敵までの距離を計測
                    float tDist = Vector3.Distance(player.transform.position, t.transform.position);

                    // もしも「初期値」よりも「計測した敵までの距離」の方が近いならば、
                    if (closeDist > tDist)
                    {
                        // 「closeDist」を「tDist（その敵までの距離）」に置き換える。
                        // これを繰り返すことで、一番近い敵を見つけ出すことができる。
                        closeDist = tDist;

                        // 一番近い敵の情報を変数に格納する（★）
                        target = t;
                    }
                }
            }
        }
        return ;
    }

    //ロックオンするターゲットのへ情報ゲッター
    public GameObject getTarget()
    {
        return target;
    }

    //ロックオン情報ゲッター
    public bool getIsLockOn()
    {
        return isLockOn;
    }
}
