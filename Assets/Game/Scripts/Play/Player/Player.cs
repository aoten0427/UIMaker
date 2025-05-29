using R3;
using R3.Triggers;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{
    // 入力タイプ
    public enum InputType
    {
        Press, 
        Hold,
        Release 
    }

    //キーと入力タイプとそれに対応したアクション
    private Dictionary<UILocation.ButtonType, Dictionary<InputType, Action<Player>>> m_buttonActions =
        new Dictionary<UILocation.ButtonType, Dictionary<InputType, Action<Player>>>();

    private new void Awake()
    {
        base.Awake();
        InitializeButtonAction();
    }

    /// <summary>
    /// ボタンのアクションの初期化
    /// </summary>
    void InitializeButtonAction()
    {
        // すべてのボタンタイプに対して辞書を初期化
        foreach (UILocation.ButtonType buttonType in Enum.GetValues(typeof(UILocation.ButtonType)))
        {
            if (buttonType == UILocation.ButtonType.None) continue;

            m_buttonActions[buttonType] = new Dictionary<InputType, Action<Player>>
            {
                { InputType.Press, (Player player) => { } },
                { InputType.Hold, (Player player) => { } },
                { InputType.Release, (Player player) => { } }
            };
        }

        // キー入力のサブスクリプション設定
        SetupKeySubscription(KeyCode.UpArrow, UILocation.ButtonType.Up);
        SetupKeySubscription(KeyCode.DownArrow, UILocation.ButtonType.Down);
        SetupKeySubscription(KeyCode.LeftArrow, UILocation.ButtonType.Left);
        SetupKeySubscription(KeyCode.RightArrow, UILocation.ButtonType.Right);
        SetupKeySubscription(KeyCode.Z, UILocation.ButtonType.Z);
        SetupKeySubscription(KeyCode.X, UILocation.ButtonType.X);
        SetupKeySubscription(KeyCode.C, UILocation.ButtonType.C);
    }

    /// <summary>
    /// キー入力のサブスクリプションを設定
    /// </summary>
    /// <param name="keyCode">監視するキーコード</param>
    /// <param name="buttonType">対応するボタンタイプ</param>
    private void SetupKeySubscription(KeyCode keyCode, UILocation.ButtonType buttonType)
    {
        // キーが押された瞬間
        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(keyCode))
            .Subscribe(_ => m_buttonActions[buttonType][InputType.Press](this))
            .AddTo(this);

        // キーが押されている間
        this.UpdateAsObservable()
            .Where(_ => Input.GetKey(keyCode))
            .Subscribe(_ => m_buttonActions[buttonType][InputType.Hold](this))
            .AddTo(this);

        // キーが離された瞬間
        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyUp(keyCode))
            .Subscribe(_ => m_buttonActions[buttonType][InputType.Release](this))
            .AddTo(this);
    }

    /// <summary>
    /// アクションをセット
    /// </summary>
    /// <param name="buttonType">ボタンタイプ</param>
    /// <param name="inputType">入力タイプ（押した瞬間/押している間/離した瞬間）</param>
    /// <param name="action">実行するアクション</param>
    public void SetAction(UILocation.ButtonType buttonType, InputType inputType, Action<Player> action)
    {
        if (buttonType == UILocation.ButtonType.None) return;

        // NULLチェック - アクションがnullの場合は空のアクションを割り当て
        m_buttonActions[buttonType][inputType] = action ?? ((Player player) => { });
    }

    /// <summary>
    /// 後方互換性のために元のSetActionメソッドも維持（Hold状態に割り当て）
    /// </summary>
    /// <param name="buttonType">ボタンタイプ</param>
    /// <param name="action">実行するアクション</param>
    public void SetAction(UILocation.ButtonType buttonType, Action<Player> action)
    {
        SetAction(buttonType, InputType.Hold, action);
    }
}