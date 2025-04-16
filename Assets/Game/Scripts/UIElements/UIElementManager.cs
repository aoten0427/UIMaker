using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementManager : Singleton<UIElementManager>
{
    ////登録UIエレメント
    //List<UIElementModel> m_uiElements = new List<UIElementModel>();
    ////現在アクティブのUIエレメント
    //List<UIElementModel> m_activeUIElements = new List<UIElementModel>();

    ////プレイヤー情報を登録
    //public void RegistrationPlayer(Player player)
    //{
    //    m_activeUIElements.ForEach(ui => ui.RegistrationPlayer(player));
    //}

    ////アクティブUIを登録
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
