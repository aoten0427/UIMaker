using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ViewUIElement : MonoBehaviour
{
    //設置される場所
    public Vector2 m_mainPosition { get; set; }

    /// <summary>
    /// 各UIViewの初期化
    /// </summary>
    public abstract void Initialize();
}
