using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ViewUIElement : MonoBehaviour
{
    public Vector2 m_mainPosition { get; set; }

    public abstract void Initialize();
}
