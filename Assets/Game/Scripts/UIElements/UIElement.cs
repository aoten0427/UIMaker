using R3;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public abstract class UIElement : MonoBehaviour
{
    
    //モデル
    ModelUIElement m_model;
    //ビュー
    ViewUIElement m_view;

    protected void Initailize(ModelUIElement model,ViewUIElement view)
    {
        m_model = model;
        m_view = view;
    }

    //ボタンアクション
    public void ButtonAction(Character.Parameter parameter)
    {
        m_model.ButtonAction(parameter);
    }
}
