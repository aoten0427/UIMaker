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
   
    List<IClearMaker> m_ActiveClear = new List<IClearMaker>();

    //�C���X�^���X�擾
    public static ClearCenter GetInstance()
    {
        GameObject clearcenter = GameObject.Find(NAME);
        if(clearcenter == null )
        {
            Debug.LogError("�N���A�Z���^�[�͑��݂��܂���");
        }
        return clearcenter.GetComponent<ClearCenter>();
    }

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
