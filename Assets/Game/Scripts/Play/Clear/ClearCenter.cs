using R3;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �N���A�̏�Ԃ��Ǘ�
/// </summary>
public class ClearCenter : MonoBehaviour
{
    //�t���I�u�W�F�N�g��
    public static readonly string NAME = "ClearCenter";
    //�N���A���T�u�W�F�N�g
    private Subject<Unit> stageClearSubject = new Subject<Unit>();
    //�O���p�I�u�U�[�o�[
    public Observable<Unit> OnStageClearAsObservable() => stageClearSubject.AsObservable();
    

    void Awake()
    {
        //��������݂���悤�ɂ���
        if (GameObject.Find(NAME) != null && GameObject.Find(NAME) != gameObject)
        {
            Destroy(gameObject);
            return;
        }
        gameObject.name = NAME;
    }

    /// <summary>
    /// �X�e�[�W���N���A
    /// </summary>
    public void StageClear()
    {
        Debug.Log("StageClear");
        // �C�x���g�̔���
        stageClearSubject.OnNext(Unit.Default);
    }

    /// <summary>
    /// �j��
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
