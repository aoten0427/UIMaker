using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMoveModel : ModelUIElement
{
    [SerializeField]
    float m_speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ButtonAction(Character.Parameter parameter)
    {
        parameter.m_rigidbody.AddForce(new Vector3(m_speed, 0, 0));
    }
}
