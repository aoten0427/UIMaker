using R3;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// クリアの状態を管理
/// </summary>
public class ClearCenter : MonoBehaviour
{
    //付属オブジェクト名
    public static readonly string NAME = "ClearCenter";
   
    List<IClearMaker> m_ActiveClear = new List<IClearMaker>();

    //インスタンス取得
    public static ClearCenter GetInstance()
    {
        GameObject clearcenter = GameObject.Find(NAME);
        if(clearcenter == null )
        {
            Debug.LogError("クリアセンターは存在しません");
        }
        return clearcenter.GetComponent<ClearCenter>();
    }

    void Awake()
    {
        //一つだけ存在するようにする
        if (GameObject.Find(NAME) != null && GameObject.Find(NAME) != gameObject)
        {
            Destroy(gameObject);
            return;
        }
        gameObject.name = NAME;
    }

    /// <summary>
    /// ステージをクリア
    /// </summary>
    public void StageClear()
    {
        Debug.Log("StageClear");
       
    }

    public void RegistrationClear(IClearMaker clearMaker)
    {
        m_ActiveClear.Add(clearMaker);
    }

    bool IsClear()
    {
        foreach(IClearMaker clear in m_ActiveClear)
        {
            if(clear.IsClear())return true;
        }
        return false;
    }
}
