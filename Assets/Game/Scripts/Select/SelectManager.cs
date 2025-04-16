using R3;
using R3.Triggers;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    //�X�e�[�W�f�[�^
    [SerializeField]
    List<Object> m_stages;
    //�I�𒆂̃X�e�[�W
    StageUIData m_selectStage;
    //�ő�X�e�[�W��
    int m_maxStage;
    //�I���X�e�[�W�ԍ�
    int m_selectNumber;

    //�X�e�[�W�ݒu�ꏊ
    readonly Vector2 STAGE_POSITION = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        //�q����StageData���擾
        for(int i = 0;i < transform.childCount;i++)
        {
            m_stages.Add(transform.GetChild(i).gameObject);
        }
        //�X�e�[�W���擾
        m_maxStage = transform.childCount + 1;

        SelectStage(0);
      
        //�V�[���J�ڐݒ�
        this.UpdateAsObservable()
         .Where(_ => Input.GetKeyDown(KeyCode.Space))
         .Subscribe(_ => StageSelect())
         .AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        PickStage();
    }

    /// <summary>
    /// �X�e�[�W�I��
    /// </summary>
    void PickStage()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            SelectStage(m_selectNumber - 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SelectStage(m_selectNumber + 1);
        }
    }

    /// <summary>
    /// �X�e�[�W�I��
    /// </summary>
    private void SelectStage(int n)
    {
        //�X�e�[�W�ԍ����͈͓����`�F�b�N
        if (n < 0 || n > m_maxStage) return;
        //���݂̃X�e�[�W�̃A�N�e�B�u���I�t��
        if (m_selectStage)m_selectStage.gameObject.SetActive(false);
        //�X�e�[�W�f�[�^�擾
        m_selectStage = m_stages[n].GetComponent<StageUIData>();
        //�Ȃ��ꍇ�G���[�\��
        if (!m_selectStage) Debug.LogError("StageData������܂���");
        //�X�e�[�W�̃A�N�e�B�u���I����
        m_selectStage.gameObject.SetActive(true);
        //�|�W�V�������Z�b�g
        m_selectStage.GetComponent<RectTransform>().anchoredPosition = STAGE_POSITION;
        //�X�e�[�W�ԍ��X�V
        m_selectNumber = n;
    }

    void StageSelect()
    {
        SceneManager.LoadScene(m_selectStage.SceneName);
    }
}
