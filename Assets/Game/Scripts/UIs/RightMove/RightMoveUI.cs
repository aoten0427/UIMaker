using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMoveUI : UIElement
{
    RightMoveModel m_rightMoveModel;
    RightMoveView m_rightMoveView;

    public override void SuccessorInitialize()
    {
        gameObject.name = "RightMove";
        m_rightMoveModel = GetModel<RightMoveModel>();
        m_rightMoveView = GetView<RightMoveView>();

        //�����ꂽ�ʒm���Z�b�g������
        m_rightMoveModel.Pushed.DistinctUntilChanged().
            Subscribe(push => m_rightMoveView.Push(push)).
            AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
