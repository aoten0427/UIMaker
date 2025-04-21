
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMoveUI : UIElement
{
    LeftMoveModel m_leftMoveModel;
    LeftMoveView m_leftMoveView;

    // Start is called before the first frame update
    void Start()
    {
        m_leftMoveModel = gameObject.AddComponent<LeftMoveModel>();
        m_leftMoveView = gameObject.AddComponent<LeftMoveView>();
        gameObject.name = "LeftMove";
        Initailize(m_leftMoveModel, m_leftMoveView);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
