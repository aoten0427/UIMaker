using R3;
using R3.Triggers;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{
    Dictionary<UILocation.ButtonType, Action<Character.Parameter>> m_buttonAction = new Dictionary<UILocation.ButtonType, Action<Character.Parameter>>();

    private new void Awake()
    {
        base.Awake();
        InitializeButtonAction();
    }

  

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// ボタンのアクションの初期化
    /// </summary>
    void InitializeButtonAction()
    {
        m_buttonAction.Add(UILocation.ButtonType.Up, (Character.Parameter parameter) => { });
        m_buttonAction.Add(UILocation.ButtonType.Down, (Character.Parameter parameter) => { });
        m_buttonAction.Add(UILocation.ButtonType.Left, (Character.Parameter parameter) => { });
        m_buttonAction.Add(UILocation.ButtonType.Right, (Character.Parameter parameter) => { });
        m_buttonAction.Add(UILocation.ButtonType.Z, (Character.Parameter parameter) => { });
        m_buttonAction.Add(UILocation.ButtonType.X, (Character.Parameter parameter) => { });
        m_buttonAction.Add(UILocation.ButtonType.C, (Character.Parameter parameter) => { });

        this.UpdateAsObservable()
          .Where(_ => Input.GetKey(KeyCode.UpArrow))
          .Subscribe(_ => m_buttonAction[UILocation.ButtonType.Up](GetParameter()))
          .AddTo(this);

        this.UpdateAsObservable()
          .Where(_ => Input.GetKey(KeyCode.DownArrow))
          .Subscribe(_ => m_buttonAction[UILocation.ButtonType.Down](GetParameter()))
          .AddTo(this);

        this.UpdateAsObservable()
          .Where(_ => Input.GetKey(KeyCode.LeftArrow))
          .Subscribe(_ => m_buttonAction[UILocation.ButtonType.Left](GetParameter()))
          .AddTo(this);

        this.UpdateAsObservable()
          .Where(_ => Input.GetKey(KeyCode.RightArrow))
          .Subscribe(_ => m_buttonAction[UILocation.ButtonType.Right](GetParameter()))
          .AddTo(this);

        this.UpdateAsObservable()
          .Where(_ => Input.GetKey(KeyCode.Z))
          .Subscribe(_ => m_buttonAction[UILocation.ButtonType.Z](GetParameter()))
          .AddTo(this);

        this.UpdateAsObservable()
          .Where(_ => Input.GetKey(KeyCode.X))
          .Subscribe(_ => m_buttonAction[UILocation.ButtonType.X](GetParameter()))
          .AddTo(this);

        this.UpdateAsObservable()
          .Where(_ => Input.GetKey(KeyCode.C))
          .Subscribe(_ => m_buttonAction[UILocation.ButtonType.C](GetParameter()))
          .AddTo(this);
    }

    public void SetAction(UILocation.ButtonType buttonType, Action<Character.Parameter> action)
    {
        if (buttonType == UILocation.ButtonType.None) return;
        m_buttonAction[buttonType] = action;
    }
}
