using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    public static readonly string NAME = "PlayManager";

    //プレイヤー
    [SerializeField]
    Player m_player;
    //UIセンター
    GameObject m_UICenter;
    //クリアセンター
    GameObject m_ClearCenter;
    //キャンバス
    [SerializeField]
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

        if (m_player == null) Debug.LogError("プレイヤーが存在しません");

        //UIセンターを生成
        m_UICenter = new GameObject();
        m_UICenter.transform.parent = transform;
        var uicenter = m_UICenter.AddComponent<UICenter>();
        uicenter.SetPlayer(m_player);
        uicenter.SetCanvas(m_canvas);

        //クリアセンターを生成
        m_ClearCenter = new GameObject();
        m_ClearCenter.transform.parent = transform;
        m_ClearCenter.AddComponent<ClearCenter>();


    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
