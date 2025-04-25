using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICenter : MonoBehaviour
{
    public static readonly string NAME = "UICenter";
    Player m_player;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = NAME;
        LoadUIData();
    }

    public void SetPlayer(Player player) {  m_player = player; }

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
            ui.transform.parent = transform;
            UIElement uiElement = ui.GetComponent<UIElement>();
            m_player.SetAction(uIData.m_button, uiElement.ButtonAction);
        }
    }
}
