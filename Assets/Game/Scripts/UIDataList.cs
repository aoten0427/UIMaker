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

        // �v���C���[�A�N�V����
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

        // �v���C���[�X�e�[�^�X
        HP,
        MP,
        Stamina,
        StatusEffect,
        Temperature,
        ExperienceMeter,

        // �Q�[�����[��
        TimeRemaining,
        Score,
        Combo,
        EnemyCount,

        // ���^
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
