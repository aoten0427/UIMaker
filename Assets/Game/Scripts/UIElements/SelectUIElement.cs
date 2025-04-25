using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SelectUIElement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //���W
    RectTransform m_rectTransform;
    //�\���摜
    Sprite m_sprite;
    //�ړ��I�u�W�F�N�g
    MoveSelctUIElement m_moveSelctUIElement;
    //�h���b�v�C�x���g
    public event Action<MoveSelctUIElement> OnDragEndEvent;

    [SerializeField]
    UIDataList.UIElementType m_type;
    void Awake()
    {
        m_rectTransform = GetComponent<RectTransform>();
        m_sprite = GetComponent<Image>().sprite;
    }

    /// <summary>
    /// �N���b�N�����ƈړ��I�u�W�F�N�g�𐶐�
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        CreateMoveObject();
    }
    /// <summary>
    /// ����̌Ăяo���p
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData)
    {
        if(m_moveSelctUIElement)m_moveSelctUIElement.OnPointerUp(eventData);
        m_moveSelctUIElement = null;
    }

    /// <summary>
    /// �ړ��I�u�W�F�N�g����
    /// </summary>
    /// <returns></returns>
    private GameObject CreateMoveObject()
    {
        //�I�u�W�F�N�g����
        GameObject moveobj = new GameObject("MoveObject");
        moveobj.transform.SetParent(m_rectTransform, false);
        //�g�����X�t�H�[������
        RectTransform rect = moveobj.AddComponent<RectTransform>();
        rect.anchoredPosition = Vector2.zero;
        //�摜����
        Image image = moveobj.AddComponent<Image>();
        image.sprite = m_sprite;
        image.raycastTarget = true; // ���ꂪ�d�v
        //�ړ��p�I�u�W�F�N�g����
        m_moveSelctUIElement = moveobj.AddComponent<MoveSelctUIElement>();
        m_moveSelctUIElement.OnDragEndEvent += this.OnDragEndEvent;
        m_moveSelctUIElement.m_uiData = this;
        m_moveSelctUIElement.m_type = m_type;
        return moveobj;
    }
}


public class MoveSelctUIElement : MonoBehaviour, IPointerDownHandler,  IPointerUpHandler
{
    //UI�f�[�^
    public SelectUIElement m_uiData { get; set; }
    //���W
    private RectTransform rectTransform;
    //�ړ��L�����o�X
    private Canvas canvas;
    //�h���b�O�t���O
    private bool isDragging = true;
    //�h���b�v���C�x���g
    public event Action<MoveSelctUIElement> OnDragEndEvent;
    //�ݒu�ꏊ
    public UILocation m_location{ get; set; }
    public UIDataList.UIElementType m_type{ get; set; }

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        m_location = null;
    }

    /// <summary>
    /// �}�E�X�ɍ��킹�Ĉړ�������
    /// </summary>
    void Update()
    {
        if (isDragging)
        {
            // �L�����o�X�ɑΉ������}�E�X�ʒu�ւ̕ϊ�
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                Input.mousePosition,
                canvas.worldCamera,
                out position);
            // �I�u�W�F�N�g�̈ʒu���}�E�X�ʒu�ɐݒ�
            rectTransform.position = canvas.transform.TransformPoint(position);
        }
    }

    /// <summary>
    /// �h���b�O���J�n����
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        // ���N���b�N�̏ꍇ�̂݃h���b�O���J�n
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            isDragging = true;
            m_location = null;
        }
    }

    /// <summary>
    /// �h���b�O���I���
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData)
    {
        // �h���b�O�I���C�x���g�𔭍s
        OnDragEndEvent?.Invoke(this);
        // �h���b�O�I��
        isDragging = false;
        ////�ǂ��ɂ��ݒu����Ă��Ȃ��Ȃ�폜����
        if (m_location == null)
        {
            Destroy(gameObject);
        }
    }
}