using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICenter : MonoBehaviour
{
    //固定の名前
    public static readonly string NAME = "UICenter";
    //プレイヤー
    Player m_player;
    //キャンバス
    Canvas m_canvas;

    void Awake()
    {
        //一つだけ存在するようにする
        if (GameObject.Find(NAME) != null && GameObject.Find(NAME) != gameObject)
        {
            Destroy(gameObject);
            return;
        }
        gameObject.name = NAME;
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadUIData();
    }

    public void SetPlayer(Player player) {  m_player = player; }
    public void SetCanvas(Canvas canvas) { m_canvas = canvas;}

    /// <summary>
    /// アクティブUIの作成
    /// </summary>
    void LoadUIData()
    {
        UIDataList datas = Resources.Load<UIDataList>("UIDataList");

        foreach (UIDataList.UIData uIData in datas.lists)
        {
            //データがアクティブでないならパス
            if (!uIData.m_isActive) continue;

            //UIエレメント作成
            GameObject ui = UIFactory.CreateUI(uIData.Type);

            //親設定
            ui.transform.parent = transform;

            //UIエレメントの初期化
            UIElement uiElement = ui.GetComponent<UIElement>();
            uiElement.Initalzie(uIData.Type, m_canvas);
    
            //プレイヤーにボタンアクションを設定
            m_player.SetAction(uIData.m_button,Player.InputType.Hold,uiElement.ButtonHoldAction);
            m_player.SetAction(uIData.m_button, Player.InputType.Press, uiElement.ButtonPressAction);
            m_player.SetAction(uIData.m_button, Player.InputType.Release, uiElement.ButtonReleaseAction);
        }
    }
}
