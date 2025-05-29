using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageUIData : MonoBehaviour
{
    //�V�[����
    [SerializeField]
    string m_sceneName;
    public string SceneName { get { return m_sceneName; } }
    //UI�̐ݒu�ꏊ
     List<UILocation> m_uis = new List<UILocation>();

    void Start()
    {
        //UI�̐ݒu�ꏊ���擾
        foreach (Transform child in transform)
        {
            UILocation ui = child.GetComponent<UILocation>();
            if (ui != null)
            {
                m_uis.Add(ui);
            }
        }
    }

    /// <summary>
    /// �v���C�J�n�O��UI�̃f�[�^���Z�b�g����
    /// </summary>
    public void PlayStage()
    {
       UIDataList datas = Resources.Load<UIDataList>("UIDataList");

       //��x�A�N�e�B�u���I�t��
       for(int i = 0;i < datas.lists.Count;i++)
       {
            datas.lists[i].m_isActive = false;
       }

       //�A�N�e�B�u�ɂȂ�UI��I��
       foreach (UILocation uiLocation in m_uis)
       {
           foreach (UIDataList.UIData data in datas.lists)
           {
                if (uiLocation.GetSelectUI() != data.Type) continue;
                data.m_isActive = true;
                //�ݒ肳��Ă���{�^����ݒ�
                data.m_button = uiLocation.GetButtonType();
                //UI�̃|�W�V������ݒ�
                data.Position = uiLocation.GetPosition();
                break;
           }
       }
    }
}
