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
    /// �A�N�e�B�uUI�̍쐬
    /// </summary>
    void LoadUIData()
    {
        UIDataList datas = Resources.Load<UIDataList>("UIDataList");

        foreach (UIDataList.UIData uIData in datas.lists)
        {
            //�f�[�^���A�N�e�B�u�łȂ��Ȃ�p�X
            if (!uIData.m_isActive) continue;
            //UI�G�������g�쐬
            GameObject ui = UIFactory.CreateUI(uIData.Type);
            ui.transform.parent = transform;
            UIElement uiElement = ui.GetComponent<UIElement>();
            m_player.SetAction(uIData.m_button, uiElement.ButtonAction);
        }
    }
}
