using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;   //UniRxから書き換え
using R3.Triggers;
using System;

public interface IClearCondition
{
    //クリア
    void Clear();
    //タイプを取得
    ClearCondition.ClearType GetClearType();
}

/// <summary>
/// クリア状態
/// </summary>
public abstract class ClearCondition : MonoBehaviour, IClearCondition
{
    //クリアタイプ
    public enum ClearType
    {
        None,
        Goal
    }

    //自身のクリアタイプ
    [SerializeField] private ClearType clearType = ClearType.None;
    //クリア時呼び出し
    protected Subject<bool> m_clearSubject = new Subject<bool>();
    //クリアフラグ
    protected bool isCleared = false;

    protected virtual void Start()
    {
        ClearCenter clearCenter = FindObjectOfType<ClearCenter>();
        //クリア時の呼び出しを設定
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
    /// クリア
    /// </summary>
    public void Clear()
    {
        if (isCleared) return;

        isCleared = true;
        m_clearSubject.OnNext(true);
    }

    /// <summary>
    /// クリアタイプ取得
    /// </summary>
    /// <returns></returns>
    public ClearType GetClearType()
    {
        return clearType;
    }

    /// <summary>
    /// 破壊時
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
