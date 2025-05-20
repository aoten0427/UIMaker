using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftMoveView : ViewUIElement
{
    //�g�����X�t�H�[��
    RectTransform m_rectTransform;
    //�摜
    Image m_image;
    //���̐F
    Color m_baseColor;
    //������Ă���Ƃ��̐F
    Color m_pushColor;

    public override void Initialize()
    {
        //�|�W�V�������{�^���̏ꏊ�ɔz�u
        m_rectTransform = GetComponent<RectTransform>();
        m_rectTransform.anchoredPosition = m_mainPosition;
        //�摜����e�F��ݒ�
        m_image = GetComponent<Image>();
        m_baseColor = m_image.color;
        m_pushColor = m_baseColor * 0.5f;
        m_pushColor.a = 1.0f;
    }

    //������Ă�����F��ς���
    public void Push(bool ispush)
    {
        if (ispush)
        {
            m_image.color = m_pushColor;
        }
        else
        {
            m_image.color = m_baseColor;
        }
    }
}
