using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftMoveView : ViewUIElement
{
    //トランスフォーム
    RectTransform m_rectTransform;
    //画像
    Image m_image;
    //元の色
    Color m_baseColor;
    //押されているときの色
    Color m_pushColor;

    public override void Initialize()
    {
        //ポジションをボタンの場所に配置
        m_rectTransform = GetComponent<RectTransform>();
        m_rectTransform.anchoredPosition = m_mainPosition;
        //画像から各色を設定
        m_image = GetComponent<Image>();
        m_baseColor = m_image.color;
        m_pushColor = m_baseColor * 0.5f;
        m_pushColor.a = 1.0f;
    }

    //押されていたら色を変える
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
