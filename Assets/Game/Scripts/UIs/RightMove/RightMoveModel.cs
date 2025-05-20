using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMoveModel : ModelUIElement
{
    //�ړ��X�s�[�h
    float m_speed = 10;

    //�������̂�View�ɓ`���邽�߂̕ϐ�
    ReactiveProperty<bool> m_isPush = new ReactiveProperty<bool>(false);
    public Observable<bool> Pushed => m_isPush;//�O���p

    // Start is called before the first frame update
    void Start()
    {
       
    }

    /// <summary>
    /// �{�^����������Ă���Ƃ�
    /// </summary>
    /// <param name="player"></param>
    public override void ButtonHoldAction(Player player)
    {
        //�{�^����������Ă���Ƃ��͉E�Ɉړ�������
        player.GetParameter().m_rigidbody.AddForce(new Vector2(m_speed, 0));
        player.SuitedTo(new Vector2(-1, 0));
    }

    /// <summary>
    /// �{�^���������ꂽ�Ƃ�
    /// </summary>
    /// <param name="player"></param>
    public override void ButtonPressAction(Player player)
    {
        //�ʒm
        m_isPush.Value = true;
    }

    /// <summary>
    /// �{�^���������ꂽ�Ƃ�
    /// </summary>
    /// <param name="player"></param>
    public override void ButtonReleaseAction(Player player)
    {
        //�ʒm
        m_isPush.Value = false;
    }
}
