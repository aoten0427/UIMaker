using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageUIData : MonoBehaviour
{
    //シーン名
    [SerializeField]
    string m_sceneName;
    public string SceneName { get { return m_sceneName; } }
    //UIの設置場所
     List<UILocation> m_uis = new List<UILocation>();

    void Start()
    {
        //UIの設置場所を取得
        foreach (Transform child in transform)
        {
            UILocation ui = child.GetComponent<UILocation>();
            if (ui != null)
            {
                m_uis.Add(ui);
            }
        }
    }

    /// <summary>
    /// プレイ開始前にUIのデータをセットする
    /// </summary>
    public void PlayStage()
    {
       UIDataList datas = Resources.Load<UIDataList>("UIDataList");

       //一度アクティブをオフに
       for(int i = 0;i < datas.lists.Count;i++)
       {
            datas.lists[i].m_isActive = false;
       }

       //アクティブになるUIを選択
       foreach (UILocation uiLocation in m_uis)
       {
           foreach (UIDataList.UIData data in datas.lists)
           {
                if (uiLocation.GetSelectUI() != data.Type) continue;
                data.m_isActive = true;
                //設定されているボタンを設定
                data.m_button = uiLocation.GetButtonType();
                //UIのポジションを設定
                data.Position = uiLocation.GetPosition();
                break;
           }
       }
    }
}
