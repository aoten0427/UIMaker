using R3;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class UIElement : MonoBehaviour
{
    public enum UIElementType
    {
        None,

        // プレイヤーアクション
        MoveLeftRight,
        Jump,
        Attack,
        Defense,
        Bow,
        Magic,
        Dodge,
        Dash,
        Grab,
        Throw,
        Parry,
        Charge,

        // プレイヤーステータス
        HP,
        MP,
        Stamina,
        StatusEffect,
        Temperature,
        ExperienceMeter,

        // ゲームルール
        TimeRemaining,
        Score,
        Combo,
        EnemyCount,

        // メタ
        Settings,
        StageName,
        Save
    }
    ModelUIElement m_model;
    ViewUIElement m_view;

    void SetModel(ModelUIElement model)
    {
        m_model = model;
    }

    void SetView(ViewUIElement view)
    {
        m_view = view;
    }
}
