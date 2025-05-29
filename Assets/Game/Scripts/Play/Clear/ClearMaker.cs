using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearMaker : MonoBehaviour,IClearMaker
{
    ClearMaker()
    {
        ClearCenter.GetInstance().RegistrationClear(this);
    }

    public bool IsClear()
    {
        throw new System.NotImplementedException();
    }
}
