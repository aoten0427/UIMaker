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
        //���g�̃^�C�v
        [SerializeField]
        private UIElementType m_type;
        //�R�X�g
        [SerializeField]
        public int m_cost;
        //�A�N�e�B�u�t���O
        public bool m_isActive = false;
        //�ݒ�{�^��
        public UILocation.ButtonType m_button;

        public UIElementType Type => m_type;
        public int Cost => m_cost;
        public bool isActive { get { return m_isActive; } set { isActive = value; } }
        public UILocation.ButtonType Button { get { return m_button; } set { m_button = value; } }
    }

   
}
