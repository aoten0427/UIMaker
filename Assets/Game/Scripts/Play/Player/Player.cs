using R3;
using R3.Triggers;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{
    // ���̓^�C�v
    public enum InputType
    {
        Press, 
        Hold,
        Release 
    }

    //�L�[�Ɠ��̓^�C�v�Ƃ���ɑΉ������A�N�V����
    private Dictionary<UILocation.ButtonType, Dictionary<InputType, Action<Player>>> m_buttonActions =
        new Dictionary<UILocation.ButtonType, Dictionary<InputType, Action<Player>>>();

    private new void Awake()
    {
        base.Awake();
        InitializeButtonAction();
    }

    /// <summary>
    /// �{�^���̃A�N�V�����̏�����
    /// </summary>
    void InitializeButtonAction()
    {
        // ���ׂẴ{�^���^�C�v�ɑ΂��Ď�����������
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

        // �L�[���͂̃T�u�X�N���v�V�����ݒ�
        SetupKeySubscription(KeyCode.UpArrow, UILocation.ButtonType.Up);
        SetupKeySubscription(KeyCode.DownArrow, UILocation.ButtonType.Down);
        SetupKeySubscription(KeyCode.LeftArrow, UILocation.ButtonType.Left);
        SetupKeySubscription(KeyCode.RightArrow, UILocation.ButtonType.Right);
        SetupKeySubscription(KeyCode.Z, UILocation.ButtonType.Z);
        SetupKeySubscription(KeyCode.X, UILocation.ButtonType.X);
        SetupKeySubscription(KeyCode.C, UILocation.ButtonType.C);
    }

    /// <summary>
    /// �L�[���͂̃T�u�X�N���v�V������ݒ�
    /// </summary>
    /// <param name="keyCode">�Ď�����L�[�R�[�h</param>
    /// <param name="buttonType">�Ή�����{�^���^�C�v</param>
    private void SetupKeySubscription(KeyCode keyCode, UILocation.ButtonType buttonType)
    {
        // �L�[�������ꂽ�u��
        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(keyCode))
            .Subscribe(_ => m_buttonActions[buttonType][InputType.Press](this))
            .AddTo(this);

        // �L�[��������Ă����
        this.UpdateAsObservable()
            .Where(_ => Input.GetKey(keyCode))
            .Subscribe(_ => m_buttonActions[buttonType][InputType.Hold](this))
            .AddTo(this);

        // �L�[�������ꂽ�u��
        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyUp(keyCode))
            .Subscribe(_ => m_buttonActions[buttonType][InputType.Release](this))
            .AddTo(this);
    }

    /// <summary>
    /// �A�N�V�������Z�b�g
    /// </summary>
    /// <param name="buttonType">�{�^���^�C�v</param>
    /// <param name="inputType">���̓^�C�v�i�������u��/�����Ă����/�������u�ԁj</param>
    /// <param name="action">���s����A�N�V����</param>
    public void SetAction(UILocation.ButtonType buttonType, InputType inputType, Action<Player> action)
    {
        if (buttonType == UILocation.ButtonType.None) return;

        // NULL�`�F�b�N - �A�N�V������null�̏ꍇ�͋�̃A�N�V���������蓖��
        m_buttonActions[buttonType][inputType] = action ?? ((Player player) => { });
    }

    /// <summary>
    /// ����݊����̂��߂Ɍ���SetAction���\�b�h���ێ��iHold��ԂɊ��蓖�āj
    /// </summary>
    /// <param name="buttonType">�{�^���^�C�v</param>
    /// <param name="action">���s����A�N�V����</param>
    public void SetAction(UILocation.ButtonType buttonType, Action<Player> action)
    {
        SetAction(buttonType, InputType.Hold, action);
    }
}