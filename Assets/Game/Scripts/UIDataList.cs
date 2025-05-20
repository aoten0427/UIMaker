using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Scriptable/UIData")]
public class UIDataList : ScriptableObject
{
    public static readonly string NAME = "UIDataList";

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

    //対応UIを返す
    public UIData SearchData(UIElementType type)
    {
        foreach(UIData uIData in lists)
        {
            if(uIData.Type == type)return uIData;
        }
        return null;
    }

    [System.Serializable]
    public class UIData
    {
        //自身のタイプ
        [SerializeField]
        private UIElementType m_type;
        //コスト
        [SerializeField]
        public int m_cost;
        //アクティブフラグ
        public bool m_isActive = false;
        //設定ボタン
        public UILocation.ButtonType m_button;
        //描画位置
        [SerializeField]
        public Vector2 m_position;
        //ビュー
        [SerializeField]
        GameObject m_viewObject;


        public UIElementType Type => m_type;
        public int Cost => m_cost;
        public bool isActive { get { return m_isActive; } set { isActive = value; } }
        public UILocation.ButtonType Button { get { return m_button; } set { m_button = value; } }
        public Vector2 Position { get { return m_position; } set { m_position = value; } }
        public GameObject ViewObject => m_viewObject;
    }

   
}
