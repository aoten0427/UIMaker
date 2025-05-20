using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public struct Parameter
    {
        public Character character;
        public Rigidbody2D m_rigidbody { get; set; }
        public Vector2 m_direction { get; set; }
    }

    //自身のデータ
    Parameter m_parameter;
    public Parameter GetParameter() { return m_parameter; }

    protected void Awake()
    {
        m_parameter.character = this;
        m_parameter.m_rigidbody = GetComponent<Rigidbody2D>();
        m_parameter.m_direction = new Vector2(1, 0);
    }

    public virtual void Move() { }

    public virtual void Damage(IReadDamageBox damage) { }

    public void SuitedTo(Vector2 direction)
    {
        m_parameter.m_direction = direction;
    }
}
