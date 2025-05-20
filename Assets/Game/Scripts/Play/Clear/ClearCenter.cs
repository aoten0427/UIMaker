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
    //クリア時サブジェクト
    private Subject<Unit> stageClearSubject = new Subject<Unit>();
    //外部用オブザーバー
    public Observable<Unit> OnStageClearAsObservable() => stageClearSubject.AsObservable();
    

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
        // イベントの発火
        stageClearSubject.OnNext(Unit.Default);
    }

    /// <summary>
    /// 破壊時
    /// </summary>
    private void OnDestroy()
    {
       
         if (stageClearSubject != null)
         {
              stageClearSubject.OnCompleted();
              stageClearSubject.Dispose();
              stageClearSubject = null;
         }
    }
}
