using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// クリア状態を生成
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
