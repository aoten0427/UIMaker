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
                newObj.AddComponent<NormalAttackUI>();
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
                newObj.AddComponent<PlayerHPUI>();
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

    public static ModelUIElement CreateUIModel(UIDataList.UIElementType elementType,GameObject holder)
    {
        ModelUIElement newModelUI = null;
        switch (elementType)
        {
            case UIElementType.None:
                break;
            // プレイヤーアクション
            case UIElementType.Left:
                newModelUI = holder.AddComponent<LeftMoveModel>();
                break;
            case UIElementType.Right:
                newModelUI = holder.AddComponent<RightMoveModel>();
                break;
            case UIElementType.Jump:
                break;
            case UIElementType.Attack:
                newModelUI = holder.AddComponent<NormalAttackModel>();
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
                newModelUI = holder.AddComponent<PlayerHPModel>();
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
        return newModelUI;
    }
}
