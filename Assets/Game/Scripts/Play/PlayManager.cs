using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    public static readonly string NAME = "PlayManager";

    //�v���C���[
    [SerializeField]
    Player m_player;
    //UI�Z���^�[
    GameObject m_UICenter;
    //�N���A�Z���^�[
    GameObject m_ClearCenter;
    //�L�����o�X
    [SerializeField]
    Canvas m_canvas;

    void Awake()
    {
        //��������݂���悤�ɂ���
        if (GameObject.Find(NAME) != null && GameObject.Find(NAME) != gameObject)
        {
            Destroy(gameObject);
            return;
        }
        gameObject.name = NAME;

        if (m_player == null) Debug.LogError("�v���C���[�����݂��܂���");

        //UI�Z���^�[�𐶐�
        m_UICenter = new GameObject();
        m_UICenter.transform.parent = transform;
        var uicenter = m_UICenter.AddComponent<UICenter>();
        uicenter.SetPlayer(m_player);
        uicenter.SetCanvas(m_canvas);

        //�N���A�Z���^�[�𐶐�
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
