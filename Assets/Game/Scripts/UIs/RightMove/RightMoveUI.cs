using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMoveUI : UIElement
{
    RightMoveModel m_rightMoveModel;
    RightMoveView m_rightMoveView;

    // Start is called before the first frame update
    void Start()
    {
        m_rightMoveModel = gameObject.AddComponent<RightMoveModel>();
        m_rightMoveView = gameObject.AddComponent<RightMoveView>();
        gameObject.name = "RightMove";
        Initailize(m_rightMoveModel, m_rightMoveView);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
