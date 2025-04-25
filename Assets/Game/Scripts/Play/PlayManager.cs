using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    public static readonly string NAME = "PlayManager";

    [SerializeField]
    Player m_player;
    GameObject m_UICenter;
    GameObject m_ClearCenter;
    // Start is called before the first frame update

    private void Awake()
    {
        gameObject.name = NAME;

        if (m_player == null) Debug.LogError("ÉvÉåÉCÉÑÅ[Ç™ë∂ç›ÇµÇ‹ÇπÇÒ");

        m_UICenter = new GameObject("UICenter");
        m_UICenter.transform.parent = transform;
        var uicenter = m_UICenter.AddComponent<UICenter>();
        uicenter.SetPlayer(m_player);

        m_ClearCenter = new GameObject("ClearCenter");
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
