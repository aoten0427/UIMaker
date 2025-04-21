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
  

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        
    }

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
                if (uiLocation.GetSelectUI() != data.m_type) continue;
                data.m_isActive = true;
                data.m_button = uiLocation.GetButtonType();
                break;
           }
       }
    }
}
