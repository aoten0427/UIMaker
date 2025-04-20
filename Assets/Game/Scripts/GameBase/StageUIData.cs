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

    void PlayStage()
    {

    }
}
