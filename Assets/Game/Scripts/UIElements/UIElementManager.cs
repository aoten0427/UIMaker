using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementManager : Singleton<UIElementManager>
{
    ////�o�^UI�G�������g
    //List<UIElementModel> m_uiElements = new List<UIElementModel>();
    ////���݃A�N�e�B�u��UI�G�������g
    //List<UIElementModel> m_activeUIElements = new List<UIElementModel>();

    ////�v���C���[����o�^
    //public void RegistrationPlayer(Player player)
    //{
    //    m_activeUIElements.ForEach(ui => ui.RegistrationPlayer(player));
    //}

    ////�A�N�e�B�uUI��o�^
    //public void RegistrationActiveUIElement(int id)
    //{
    //    for (int i = 0; i < m_uiElements.Count; i++)
    //    {
    //        Type type = m_uiElements[i].GetType();
    //        if(UIElementModel.GetTypeID(type) == id)
    //        {
    //            m_activeUIElements.Add(m_uiElements[i]);
    //            break;
    //        }
    //    }
    //}
}
