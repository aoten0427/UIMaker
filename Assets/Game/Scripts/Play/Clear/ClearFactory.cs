using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �N���A��Ԃ𐶐�
/// </summary>
public class ClearFactory : MonoBehaviour
{
    public static GameObject CreateClearCondition(ClearCondition.ClearType cleartype)
    {
        GameObject clearCondition = new GameObject();
        switch (cleartype)
        {
            case ClearCondition.ClearType.Goal:
                clearCondition.AddComponent<GoalClear>();
                break;
        }
        return clearCondition;
    }
}
