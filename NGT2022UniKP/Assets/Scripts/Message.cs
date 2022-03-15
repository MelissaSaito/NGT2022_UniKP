using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;// UI機能を使用するために追記

public class Message : MonoBehaviour
{
    public bool isActive;// Canvasの表示非表示
    public GameObject canvas;// 使用するCanvas
    public Text messageText;// メッセージを表示する文字
    private string message;// 表示するメッセージ
    [SerializeField]
    private int maxTextLength = 90;// 1回のメッセージの最大文字数
    private int textLength = 0;// 1回のメッセージの現在の文字数
    [SerializeField]
    private int maxLine = 3;// メッセージの最大行数
    private int nowLine = 0;// 現在の行
    [SerializeField]
    private float textSpeed = 0.05f;// テキストスピード
    private float elapsedTime = 0f;// 経過時間
    private int nowTextNum = 0;// 今見ている文字番号
    private Image clickIcon;// マウスクリックを促すアイコン
    [SerializeField]
    private float clickFlashTime = 0.2f;// クリックアイコンの点滅秒数
    private bool isOneMessage = false;// 1回分のメッセージを表示したかどうか
    private bool isEndMessage = false;// メッセージをすべて表示したかどうか
    private string[] conversation;// 会話
    private int i = 0;// 文字列の列
    private int stringsCount = 0;// 文字列の総行数

    public bool talkflag = false;//会話フラグ
    public float displayTime = 0.0f;
    public bool eraseFlag = false;
    public bool eraseTimeFlag = false;


    void Start()
    {
        gameObject.SetActive(true);// このオブジェクトを表示する
        //clickIcon = canvas.transform.Find("Panel/Image").GetComponent<Image>();// clickIconをキャンバスの中のPanelの中のImageにする
        //clickIcon.enabled = false;// clickIconのコンポーネントをオフにする
        messageText.text = "";// 文字を空白にする
    }

    void Update()
    {

        //Debug.Log(displayTime);


        if (isEndMessage || message == null)// もし、メッセージが終わっていない、または設定されているなら
        {
            return;// 返す
        }

        if (!isOneMessage)// もし、1回に表示するメッセージを表示していなくて、
        {
            if (elapsedTime >= textSpeed)// テキスト表示時間が経過したら、
            {
                messageText.text += message[nowTextNum];// 次の文字番号にする

                if (message[nowTextNum] == '\n')// もし、改行文字だったら
                {
                    nowLine++;// 行数を足す
                }

                nowTextNum++;// 次の文字番号にする
                textLength++;// 次の文字数にする
                elapsedTime = 0f;// 経過時間を0にする

                if (nowTextNum >= message.Length || textLength >= maxTextLength || nowLine >= maxLine)// もし、メッセージを全部表示、または行数が最大数表示されたなら、
                {
                    isOneMessage = true;// isOneMessageをtrueにする
                }
            }


            elapsedTime += Time.deltaTime;// 経過時間に時間の経過分足す

        }

        else// クリックされていなければ、
        {
            elapsedTime += Time.deltaTime;// 経過時間に時間の経過分足す
            //displayTime += Time.deltaTime;

            if (elapsedTime >= clickFlashTime)// クリックアイコンを点滅する時間を超えたなら、
            {
                //clickIcon.enabled = !clickIcon.enabled;// クリックアイコンを点滅させる
                elapsedTime = 0f;// 経過時間を0にする
            }

            // クリックされたら次の文字を表示する処理
            //if (Input.GetMouseButtonDown(0))// もし、クリックされたら、
            if (talkflag == true)// 
            {
                //messageText.text = "\n";

                //clickIcon.enabled = false;// クリックアイコンをオフにする
                elapsedTime = 0f;// 経過時間を0にする
                textLength = 0;// 文字数を0にする
                isOneMessage = false;// isOneMessageを0にする
                                     //messageText.text = "\n";

                eraseTimeFlag = true;//表示時間計測


                if (nowTextNum >= message.Length)// もし、メッセージが全部表示されていたら、
                {
                    nowTextNum = 0;// 現在の文字番号を0にする

                    if (i == stringsCount - 1)// もし、文字列の総行数に達したら、
                    {
                        isEndMessage = true;// isEndMessageをtrueにする
                        canvas.transform.GetChild(0).gameObject.SetActive(false);// キャンバスの子オブジェクトを非表示にする 
                    }

                    else// もし、文字列の総行数に達していなければ、
                    {
                        i++; //iを1増やす
                        SetMessage(conversation[i]);// SetMessageを実行する
                    }
                }
            }
        }


    }

    void SetMessage(string message)// SetMessage
    {
        this.message = message + "\n";// このオブジェクトのmessageをmessageにする
    }

    public void SetMessagePanel(string[] message)// SetMessagePanel
    {
        i = 0;// iを0にする
        stringsCount = message.Length;// 文字列の総行数をmessageの要素数にする
        conversation = message;// coversationをmessageにする
        canvas.SetActive(true);// キャンバスを表示する
        SetMessage(conversation[0]);// SetMessageを実行する
        canvas.transform.GetChild(1).gameObject.SetActive(true);// キャンバスの子オブジェクトを表示する
        isEndMessage = false;// isEndMessageをfalseにする
    }
}