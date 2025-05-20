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

    //自身のボタンタイプ
    [SerializeField]
    ButtonType m_buttonType;
    //自身の座標
    Vector2 m_position;
    //現在入っているUI
    MoveSelctUIElement m_uiData;
    //追加UI削除時呼び出し
    private ReactiveProperty<MoveSelctUIElement> m_reactiveUIData = new ReactiveProperty<MoveSelctUIElement>();
    //トランスフォーム
    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        // MouseFollowerスクリプトをリスナーとして登録
        RegisterToMouseFollowers();

        m_position = rectTransform.anchoredPosition;
    }

    //持っているUIを返す
    public UIDataList.UIElementType GetSelectUI()
    {
        if (m_uiData) return m_uiData.m_type;
        return UIDataList.UIElementType.None;
    }

    //ボタンの種類を返す
    public ButtonType GetButtonType() { return m_buttonType; }

    //描画位置を返す
    public Vector2 GetPosition() { return m_position; }

    /// <summary>
    /// UIデータにイベントを設定
    /// </summary>
    void RegisterToMouseFollowers()
    {
        // シーン内のすべてのMouseFollowerを検索
        SelectUIElement[] allFollowers = FindObjectsOfType<SelectUIElement>();

        foreach (SelectUIElement follower in allFollowers)
        {
            follower.OnDragEndEvent += OnDragEndHandler;
        }
    }

    // ドラッグ終了時のイベントハンドラー
    private void OnDragEndHandler(MoveSelctUIElement follower)
    {
        // 移動オブジェクトが固定オブジェクトの範囲内にあるか確認
        if (IsWithinAcceptanceRange(follower.GetComponent<RectTransform>()))
        {
            // 移動オブジェクトを固定オブジェクトの位置に移動
            follower.transform.position = transform.position;
            follower.transform.SetParent(transform, true);
            follower.m_location = this;
            //UIデータに設定
            //削除時にnullにする
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

    // 指定されたRectTransformが受け入れ範囲内にあるかチェック
    private bool IsWithinAcceptanceRange(RectTransform otherRect)
    {
        if (m_uiData) return false;

        // 両方のRectTransformの中心位置をワールド座標で取得
        Vector3 thisCenter = rectTransform.position;
        Vector3 otherCenter = otherRect.position;

        // 固定オブジェクトの幅と高さの半分（受け入れ範囲）
        Vector2 thisSize = rectTransform.rect.size * rectTransform.localScale;
        float halfWidth = thisSize.x * 0.5f;
        float halfHeight = thisSize.y * 0.5f;

        // X軸とY軸の距離を計算
        float distanceX = Mathf.Abs(thisCenter.x - otherCenter.x);
        float distanceY = Mathf.Abs(thisCenter.y - otherCenter.y);

        // 両方の距離が受け入れ範囲内にあるかチェック
        return distanceX <= halfWidth && distanceY <= halfHeight;
    }
}
