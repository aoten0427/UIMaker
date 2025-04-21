using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public struct Parameter
    {
        public Character character;
        public Rigidbody2D m_rigidbody;
    }

    //自身のデータ
    Parameter m_parameter;
    public Parameter GetParameter() { return m_parameter; }

    protected void Awake()
    {
        m_parameter.character = this;
        m_parameter.m_rigidbody = GetComponent<Rigidbody2D>();
    }

    public virtual void Move() { }
}
