using R3;
using R3.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILocation : MonoBehaviour
{
    public enum ButtonType
    { 
        None,
        Up,
        Down,
        Left,
        Right,
        Z,
        X,
        C
    }

    //���g�̃{�^���^�C�v
    [SerializeField]
    ButtonType m_buttonType;
    //���g�̍��W
    Vector2 m_position;
    //���ݓ����Ă���UI
    MoveSelctUIElement m_uiData;
    //�ǉ�UI�폜���Ăяo��
    private ReactiveProperty<MoveSelctUIElement> m_reactiveUIData = new ReactiveProperty<MoveSelctUIElement>();
    //�g�����X�t�H�[��
    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        // MouseFollower�X�N���v�g�����X�i�[�Ƃ��ēo�^
        RegisterToMouseFollowers();

        m_position = rectTransform.anchoredPosition;
    }

    //�����Ă���UI��Ԃ�
    public UIDataList.UIElementType GetSelectUI()
    {
        if (m_uiData) return m_uiData.m_type;
        return UIDataList.UIElementType.None;
    }

    //�{�^���̎�ނ�Ԃ�
    public ButtonType GetButtonType() { return m_buttonType; }

    //�`��ʒu��Ԃ�
    public Vector2 GetPosition() { return m_position; }

    /// <summary>
    /// UI�f�[�^�ɃC�x���g��ݒ�
    /// </summary>
    void RegisterToMouseFollowers()
    {
        // �V�[�����̂��ׂĂ�MouseFollower������
        SelectUIElement[] allFollowers = FindObjectsOfType<SelectUIElement>();

        foreach (SelectUIElement follower in allFollowers)
        {
            follower.OnDragEndEvent += OnDragEndHandler;
        }
    }

    // �h���b�O�I�����̃C�x���g�n���h���[
    private void OnDragEndHandler(MoveSelctUIElement follower)
    {
        // �ړ��I�u�W�F�N�g���Œ�I�u�W�F�N�g�͈͓̔��ɂ��邩�m�F
        if (IsWithinAcceptanceRange(follower.GetComponent<RectTransform>()))
        {
            // �ړ��I�u�W�F�N�g���Œ�I�u�W�F�N�g�̈ʒu�Ɉړ�
            follower.transform.position = transform.position;
            follower.transform.SetParent(transform, true);
            follower.m_location = this;
            //UI�f�[�^�ɐݒ�
            //�폜����null�ɂ���
            m_uiData = follower;
            m_uiData.OnDestroyAsObservable()
                .Subscribe(_ =>
                {
                    m_uiData = null;
                    m_reactiveUIData.Value = null;
                })
                .AddTo(this);
        }
    }

    // �w�肳�ꂽRectTransform���󂯓���͈͓��ɂ��邩�`�F�b�N
    private bool IsWithinAcceptanceRange(RectTransform otherRect)
    {
        if (m_uiData) return false;

        // ������RectTransform�̒��S�ʒu�����[���h���W�Ŏ擾
        Vector3 thisCenter = rectTransform.position;
        Vector3 otherCenter = otherRect.position;

        // �Œ�I�u�W�F�N�g�̕��ƍ����̔����i�󂯓���͈́j
        Vector2 thisSize = rectTransform.rect.size * rectTransform.localScale;
        float halfWidth = thisSize.x * 0.5f;
        float halfHeight = thisSize.y * 0.5f;

        // X����Y���̋������v�Z
        float distanceX = Mathf.Abs(thisCenter.x - otherCenter.x);
        float distanceY = Mathf.Abs(thisCenter.y - otherCenter.y);

        // �����̋������󂯓���͈͓��ɂ��邩�`�F�b�N
        return distanceX <= halfWidth && distanceY <= halfHeight;
    }
}
