using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ViewUIElement : MonoBehaviour
{
    //�ݒu�����ꏊ
    public Vector2 m_mainPosition { get; set; }

    /// <summary>
    /// �eUIView�̏�����
    /// </summary>
    public abstract void Initialize();
}
