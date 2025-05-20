using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMoveModel : ModelUIElement
{
    //移動スピード
    float m_speed = 10;

    //押したのをViewに伝えるための変数
    ReactiveProperty<bool> m_isPush = new ReactiveProperty<bool>(false);
    public Observable<bool> Pushed => m_isPush;//外部用

    // Start is called before the first frame update
    void Start()
    {
       
    }

    /// <summary>
    /// ボタンが押されているとき
    /// </summary>
    /// <param name="player"></param>
    public override void ButtonHoldAction(Player player)
    {
        //ボタンを押されているときは右に移動させる
        player.GetParameter().m_rigidbody.AddForce(new Vector2(m_speed, 0));
        player.SuitedTo(new Vector2(-1, 0));
    }

    /// <summary>
    /// ボタンが押されたとき
    /// </summary>
    /// <param name="player"></param>
    public override void ButtonPressAction(Player player)
    {
        //通知
        m_isPush.Value = true;
    }

    /// <summary>
    /// ボタンが離されたとき
    /// </summary>
    /// <param name="player"></param>
    public override void ButtonReleaseAction(Player player)
    {
        //通知
        m_isPush.Value = false;
    }
}
