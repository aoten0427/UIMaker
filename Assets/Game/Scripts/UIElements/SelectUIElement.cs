using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SelectUIElement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //座標
    RectTransform m_rectTransform;
    //表示画像
    Sprite m_sprite;
    //移動オブジェクト
    MoveSelctUIElement m_moveSelctUIElement;
    //ドロップイベント
    public event Action<MoveSelctUIElement> OnDragEndEvent;

    [SerializeField]
    UIDataList.UIElementType m_type;
    void Awake()
    {
        m_rectTransform = GetComponent<RectTransform>();
        m_sprite = GetComponent<Image>().sprite;
    }

    /// <summary>
    /// クリックされると移動オブジェクトを生成
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        CreateMoveObject();
    }
    /// <summary>
    /// 初回の呼び出し用
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData)
    {
        if(m_moveSelctUIElement)m_moveSelctUIElement.OnPointerUp(eventData);
        m_moveSelctUIElement = null;
    }

    /// <summary>
    /// 移動オブジェクト生成
    /// </summary>
    /// <returns></returns>
    private GameObject CreateMoveObject()
    {
        //オブジェクト生成
        GameObject moveobj = new GameObject("MoveObject");
        moveobj.transform.SetParent(m_rectTransform, false);
        //トランスフォーム生成
        RectTransform rect = moveobj.AddComponent<RectTransform>();
        rect.anchoredPosition = Vector2.zero;
        //画像生成
        Image image = moveobj.AddComponent<Image>();
        image.sprite = m_sprite;
        image.raycastTarget = true; // これが重要
        //移動用オブジェクト生成
        m_moveSelctUIElement = moveobj.AddComponent<MoveSelctUIElement>();
        m_moveSelctUIElement.OnDragEndEvent += this.OnDragEndEvent;
        m_moveSelctUIElement.m_uiData = this;
        m_moveSelctUIElement.m_type = m_type;
        return moveobj;
    }
}


public class MoveSelctUIElement : MonoBehaviour, IPointerDownHandler,  IPointerUpHandler
{
    //UIデータ
    public SelectUIElement m_uiData { get; set; }
    //座標
    private RectTransform rectTransform;
    //移動キャンバス
    private Canvas canvas;
    //ドラッグフラグ
    private bool isDragging = true;
    //ドロップ時イベント
    public event Action<MoveSelctUIElement> OnDragEndEvent;
    //設置場所
    public UILocation m_location{ get; set; }
    public UIDataList.UIElementType m_type{ get; set; }

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        m_location = null;
    }

    /// <summary>
    /// マウスに合わせて移動させる
    /// </summary>
    void Update()
    {
        if (isDragging)
        {
            // キャンバスに対応したマウス位置への変換
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                Input.mousePosition,
                canvas.worldCamera,
                out position);
            // オブジェクトの位置をマウス位置に設定
            rectTransform.position = canvas.transform.TransformPoint(position);
        }
    }

    /// <summary>
    /// ドラッグを開始する
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        // 左クリックの場合のみドラッグを開始
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            isDragging = true;
            m_location = null;
        }
    }

    /// <summary>
    /// ドラッグを終わる
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData)
    {
        // ドラッグ終了イベントを発行
        OnDragEndEvent?.Invoke(this);
        // ドラッグ終了
        isDragging = false;
        ////どこにも設置されていないなら削除する
        if (m_location == null)
        {
            Destroy(gameObject);
        }
    }
}