
using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMoveUI : UIElement
{
    LeftMoveModel m_leftMoveModel;
    LeftMoveView m_leftMoveView;

    public override void SuccessorInitialize()
    {
        gameObject.name = "LeftMove";
        m_leftMoveModel = GetModel<LeftMoveModel>();
        m_leftMoveView = GetView<LeftMoveView>();

        //押された通知をセットさせる
        m_leftMoveModel.Pushed.DistinctUntilChanged().
            Subscribe(push => m_leftMoveView.Push(push)).
            AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        Disposable.Dispose();
    }
}
