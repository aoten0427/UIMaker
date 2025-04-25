using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;   //UniRxÇ©ÇÁèëÇ´ä∑Ç¶
using R3.Triggers;
using System;

public interface IClearCondition
{
    void Clear();
}

public class ClearCondition : MonoBehaviour, IClearCondition
{
    public enum ClearType
    {
        None,
        Goal
    }

    protected Subject<bool> m_clearSubject = new Subject<bool>();

    protected void Start()
    {
        ClearCenter clearCenter = GameObject.Find(ClearCenter.NAME).GetComponent<ClearCenter>();
        m_clearSubject.AsObservable().Subscribe(IsClear => clearCenter.StageClear()).AddTo(this);
    }


    public void Clear()
    {
        m_clearSubject.OnNext(true);
    }

    private void OnDestroy()
    {
        m_clearSubject?.Dispose();
    }
}
