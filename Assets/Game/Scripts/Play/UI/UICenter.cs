using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICenter : MonoBehaviour
{
    //�Œ�̖��O
    public static readonly string NAME = "UICenter";
    //�v���C���[
    Player m_player;
    //�L�����o�X
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
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadUIData();
    }

    public void SetPlayer(Player player) {  m_player = player; }
    public void SetCanvas(Canvas canvas) { m_canvas = canvas;}

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

            //�e�ݒ�
            ui.transform.parent = transform;

            //UI�G�������g�̏�����
            UIElement uiElement = ui.GetComponent<UIElement>();
            uiElement.Initalzie(uIData.Type, m_canvas);
    
            //�v���C���[�Ƀ{�^���A�N�V������ݒ�
            m_player.SetAction(uIData.m_button,Player.InputType.Hold,uiElement.ButtonHoldAction);
            m_player.SetAction(uIData.m_button, Player.InputType.Press, uiElement.ButtonPressAction);
            m_player.SetAction(uIData.m_button, Player.InputType.Release, uiElement.ButtonReleaseAction);
        }
    }
}
