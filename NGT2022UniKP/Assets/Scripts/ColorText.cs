using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ColorText : MonoBehaviour
{
    //public
    public float speed = 1.0f;

    //private
    private Text text;
    private Image image;
    private float time;

    private enum ObjType
    {
        TEXT,
        IMAGE
    };
    private ObjType thisObjType = ObjType.TEXT;


    // Inspectorで設定する変数
    public bool IsTokeiMawari = true;
    public int ChangeSpeed = 5;
    // 変換管理変数
    public static int _ChangeCnt = 0;
    public static int _NijiStartId = 0;
    // 変換管理定数
    public const string Df_Tag_Hedder = "<color=#Value>";
    public const string Df_Tag_Footer = "</color>";
    // 虹色の中身　※ 2桁づつで区切って[00 00 00]＝[ R, G, B ]の値になっている
    // 　　　　　　※ この配列の要素を追加・編集したらオリジナルの動く色が作れる
    public static string[] Df_ColorTag = new string[]
    {
        "ff0000",    //赤
        "ffff00",    //黄
        "00ff00",    //緑
        "00ffff", 　 //水
        "0000ff",　　//青
        "ff00ff", 　 //ピンク
    };

    void Start()
    {
        //アタッチしてるオブジェクトを判別
        if (this.gameObject.GetComponent<Image>())
        {
            thisObjType = ObjType.IMAGE;
            image = this.gameObject.GetComponent<Image>();
        }
        else if (this.gameObject.GetComponent<Text>())
        {
            thisObjType = ObjType.TEXT;
            text = this.gameObject.GetComponent<Text>();
        }
    }

    /// <summary>
    /// 毎割り込みイベント
    /// </summary>
    void Update()
    {
        //オブジェクトのAlpha値を更新
        if (thisObjType == ObjType.IMAGE)
        {
            image.color = GetAlphaColor(image.color);
        }
        else if (thisObjType == ObjType.TEXT)
        {
            text.color = GetAlphaColor(text.color);
        }

        //// 設定したスピードに合わせて色変更処理を呼ぶ
        //_ChangeCnt--;
        //if (_ChangeCnt <= 0)
        //{
        //    _ChangeCnt = ChangeSpeed;
        //    SetTextColorChange(IsTokeiMawari, this.GetComponent<Text>());
        //}
    }

    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 3.0f * speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }

    /// <summary>
    /// テキスト色を変える処理（毎割り込み）
    /// </summary>
    /// <param name="TxtSet">変更するテキストオブジェクト</param>
    //public static void SetTextColorChange(bool IsVecLR, Text TxtSet)
    //{
    //    // テキストの文字を取得※Tag文字を取り除く
    //    string textNoTag = TxtSet.text;
    //    textNoTag = textNoTag.Replace(Df_Tag_Footer, "");
    //    for (int i_ColorId = 0; i_ColorId < Df_ColorTag.Length; i_ColorId++)
    //    {
    //        textNoTag = textNoTag.Replace(Df_Tag_Hedder.Replace("Value", Df_ColorTag[i_ColorId]), "");
    //    }
        // 一文字ずつ色を設定
    //    int setColorId = _NijiStartId;
    //    StringBuilder textSet = new StringBuilder();
    //    for (int i_Word = 0; i_Word < textNoTag.Length; i_Word++)
    //    {
    //        textSet.Append(Df_Tag_Hedder.Replace("Value", Df_ColorTag[setColorId]));
    //        textSet.Append(textNoTag.Substring(i_Word, 1));
    //        textSet.Append(Df_Tag_Footer);
    //        if (IsVecLR)
    //        {
    //            setColorId--;
    //            if (setColorId < 0)
    //            {
    //                setColorId = Df_ColorTag.Length - 1;
    //            }
    //        }
    //        else
    //        {
    //            setColorId++;
    //            if (setColorId >= Df_ColorTag.Length)
    //            {
    //                setColorId = 0;
    //            }
    //        }
    //    }
    //    // 次回の開始色を更新
    //    _NijiStartId++;
    //    if (_NijiStartId >= Df_ColorTag.Length)
    //    {
    //        _NijiStartId = 0;
    //    }
    //    // テキスト文字を変更
    //    TxtSet.text = textSet.ToString();
    //}
}
