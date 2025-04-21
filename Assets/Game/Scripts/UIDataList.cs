using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Scriptable/UIData")]
public class UIDataList : ScriptableObject
{

    public enum UIElementType
    {
        None,

        // プレイヤーアクション
        Left,
        Right,
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

    public List<UIData> lists = new List<UIData>();

    [System.Serializable]
    public class UIData
    {
        public UIElementType m_type;
        public Sprite m_image;
        public bool m_isActive = false;
        public UILocation.ButtonType m_button;
    }

   
}
