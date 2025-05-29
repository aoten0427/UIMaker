using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ViewUIElement : MonoBehaviour
{
    //İ’u‚³‚ê‚éêŠ
    public Vector2 m_mainPosition { get; set; }

    /// <summary>
    /// ŠeUIView‚Ì‰Šú‰»
    /// </summary>
    public abstract void Initialize();
}
