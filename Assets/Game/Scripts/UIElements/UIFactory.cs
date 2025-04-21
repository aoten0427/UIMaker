using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UIDataList;

public class UIFactory : MonoBehaviour
{
   public static GameObject CreateUI(UIDataList.UIElementType elementType)
    {
        GameObject newObj = new GameObject();
        switch (elementType)
        {
            case UIElementType.None:
                break;
            // プレイヤーアクション
            case UIElementType.Left:
                newObj.AddComponent<LeftMoveUI>();
                break;
            case UIElementType.Right:
                newObj.AddComponent<RightMoveUI>();
                break;
            case UIElementType.Jump:
                break;
            case UIElementType.Attack:
                break;
            case UIElementType.Defense:
                break;
            case UIElementType.Bow:
                break;
            case UIElementType.Magic:
                break;
            case UIElementType.Dodge:
                break;
            case UIElementType.Dash:
                break;
            case UIElementType.Grab:
                break;
            case UIElementType.Throw:
                break;
            case UIElementType.Parry:
                break;
            case UIElementType.Charge:
                break;
            // プレイヤーステータス
            case UIElementType.HP:
                break;
            case UIElementType.MP:
                break;
            case UIElementType.Stamina:
                break;
            case UIElementType.StatusEffect:
                break;
            case UIElementType.Temperature:
                break;
            case UIElementType.ExperienceMeter:
                break;
            // ゲームルール
            case UIElementType.TimeRemaining:
                break;
            case UIElementType.Score:
                break;
            case UIElementType.Combo:
                break;
            case UIElementType.EnemyCount:
                break;
            // メタ
            case UIElementType.Settings:
                break;
            case UIElementType.StageName:
                break;
            case UIElementType.Save:
                break;
            default:
                break;
        }
        return newObj;
    }
}
