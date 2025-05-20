using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;   //UniRx���珑������
using R3.Triggers;
using System;

public interface IClearCondition
{
    //�N���A
    void Clear();
    //�^�C�v���擾
    ClearCondition.ClearType GetClearType();
}

/// <summary>
/// �N���A���
/// </summary>
public abstract class ClearCondition : MonoBehaviour, IClearCondition
{
    //�N���A�^�C�v
    public enum ClearType
    {
        None,
        Goal
    }

    //���g�̃N���A�^�C�v
    [SerializeField] private ClearType clearType = ClearType.None;
    //�N���A���Ăяo��
    protected Subject<bool> m_clearSubject = new Subject<bool>();
    //�N���A�t���O
    protected bool isCleared = false;

    protected virtual void Start()
    {
        ClearCenter clearCenter = FindObjectOfType<ClearCenter>();
        //�N���A���̌Ăяo����ݒ�
        m_clearSubject.AsObservable()
            .TakeUntil(this.OnDestroyAsObservable())
            .Subscribe(
                IsClear => {
                    if (clearCenter != null)
                    {
                        clearCenter.StageClear();
                    }
                }
            )
            .AddTo(this);
    }

    /// <summary>
    /// �N���A
    /// </summary>
    public void Clear()
    {
        if (isCleared) return;

        isCleared = true;
        m_clearSubject.OnNext(true);
    }

    /// <summary>
    /// �N���A�^�C�v�擾
    /// </summary>
    /// <returns></returns>
    public ClearType GetClearType()
    {
        return clearType;
    }

    /// <summary>
    /// �j��
    /// </summary>
    protected virtual void OnDestroy()
    {
        if (m_clearSubject != null)
        {
            m_clearSubject.OnCompleted();
            m_clearSubject.Dispose();
            m_clearSubject = null;
        }
    }
}
