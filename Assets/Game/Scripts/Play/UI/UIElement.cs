using R3;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIElement : MonoBehaviour
{
    //自身のタイプ
    UIDataList.UIElementType m_type;
    //モデル
    ModelUIElement m_model;
    //ビュー
    GameObject m_viewObj;
    ViewUIElement m_view;
    //キャンバス
    Canvas m_canvas;

    //初期化
    public void Initalzie(UIDataList.UIElementType type,Canvas canvas)
    {
        //タイプ設定
        m_type = type;
        //キャンバス設定
        m_canvas = canvas;

        //データリストを検索
        UIDataList datas = Resources.Load<UIDataList>("UIDataList");
        UIDataList.UIData data = datas.SearchData(m_type);
        if (data == null)
        {
            Debug.LogError("データが存在しません");
        }

        //モデルを作成
        m_model = UIFactory.CreateUIModel(m_type, gameObject);

        //ビューを生成
        GameObject view = data.ViewObject;
        m_viewObj = Instantiate(view, m_canvas.GetComponent<RectTransform>());
        m_view = m_viewObj.GetComponent<ViewUIElement>();
        //ビューの位置を設定
        m_view.m_mainPosition = data.Position;
        //ビューの初期化
        m_view.Initialize();

        //継承先の初期化
        SuccessorInitialize();
    }

    /// <summary>
    /// 各UI要素の初期化を記述
    /// </summary>
    public abstract void SuccessorInitialize();

    //モデルを取得する
    public T GetModel<T>()
    {
        T model = GetComponent<T>();
        if (model == null)
        {
            Debug.Log("指定されたモデルを持っていません");
        }
        return model;
    }

    //ビューを取得する
    public T GetView<T>()
    {
        T view = m_viewObj.GetComponent<T>();
        if(view == null)
        {
            Debug.Log("指定されたビューを持っていません");
        }
        return view;
    }

    /// <summary>
    /// ボタンプレスアクション
    /// </summary>
    /// <param name="player"></param>
    public void ButtonHoldAction(Player player)
    {
        m_model.ButtonHoldAction(player);
    }

    /// <summary>
    /// ボタンプレスアクション
    /// </summary>
    /// <param name="player"></param>
    public void ButtonPressAction(Player player)
    {
        m_model.ButtonPressAction(player);
    }

    /// <summary>
    /// ボタンリリースアクション
    /// </summary>
    /// <param name="player"></param>
    public void ButtonReleaseAction(Player player)
    {
        m_model.ButtonReleaseAction(player);
    }
}
