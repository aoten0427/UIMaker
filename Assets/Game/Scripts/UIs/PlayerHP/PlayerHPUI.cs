using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using R3.Triggers;

public class PlayerHPUI : UIElement
{
    PlayerHPModel m_playerHPModel;
    PlayerHPView m_playerHPView;

    public override void SuccessorInitialize()
    {
        gameObject.name = "PlayerHP";
        m_playerHPModel = GetModel<PlayerHPModel>();
        m_playerHPView = GetView<PlayerHPView>();

        m_playerHPModel.HPPercent.
            Subscribe(par => m_playerHPView.ChangeDamage(par)).
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
