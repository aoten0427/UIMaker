using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    [SerializeField]
    Player m_player;
    List<UIElement> m_activeUiElement = new List<UIElement>();

    // Start is called before the first frame update
    void Start()
    {
       LoadUIData();
       //foreach(UIElement uiElement in m_activeUiElement)
       //{

       //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// アクティブUIの作成
    /// </summary>
    void LoadUIData()
    {
        UIDataList datas = Resources.Load<UIDataList>("UIDataList");

        foreach(UIDataList.UIData uIData in datas.lists)
        {
            //データがアクティブでないならパス
            if (!uIData.m_isActive) continue;
            //UIエレメント作成
            GameObject ui = UIFactory.CreateUI(uIData.m_type);
            ui.transform.parent = transform;
            UIElement uiElement = ui.GetComponent<UIElement>();
            m_activeUiElement.Add(uiElement);
            m_player.SetAction(uIData.m_button, uiElement.ButtonAction);
        }
    }
}
