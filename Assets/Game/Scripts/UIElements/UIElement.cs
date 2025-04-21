using R3;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public abstract class UIElement : MonoBehaviour
{
    
    //���f��
    ModelUIElement m_model;
    //�r���[
    ViewUIElement m_view;

    protected void Initailize(ModelUIElement model,ViewUIElement view)
    {
        m_model = model;
        m_view = view;
    }

    //�{�^���A�N�V����
    public void ButtonAction(Character.Parameter parameter)
    {
        m_model.ButtonAction(parameter);
    }
}
