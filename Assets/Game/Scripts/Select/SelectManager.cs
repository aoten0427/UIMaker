using R3;
using R3.Triggers;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    //ステージデータ
    [SerializeField]
    List<Object> m_stages;
    //選択中のステージ
    StageUIData m_selectStage;
    //最大ステージ数
    int m_maxStage;
    //選択ステージ番号
    int m_selectNumber;

    //ステージ設置場所
    readonly Vector2 STAGE_POSITION = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        //子からStageDataを取得
        for(int i = 0;i < transform.childCount;i++)
        {
            m_stages.Add(transform.GetChild(i).gameObject);
        }
        //ステージ数取得
        m_maxStage = transform.childCount + 1;

        SelectStage(0);
      
        //シーン遷移設定
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
    /// ステージ選択
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
    /// ステージ選択
    /// </summary>
    private void SelectStage(int n)
    {
        //ステージ番号が範囲内かチェック
        if (n < 0 || n > m_maxStage) return;
        //現在のステージのアクティブをオフに
        if (m_selectStage)m_selectStage.gameObject.SetActive(false);
        //ステージデータ取得
        m_selectStage = m_stages[n].GetComponent<StageUIData>();
        //ない場合エラー表示
        if (!m_selectStage) Debug.LogError("StageDataがありません");
        //ステージのアクティブをオンに
        m_selectStage.gameObject.SetActive(true);
        //ポジションをセット
        m_selectStage.GetComponent<RectTransform>().anchoredPosition = STAGE_POSITION;
        //ステージ番号更新
        m_selectNumber = n;
    }

    void StageSelect()
    {
        SceneManager.LoadScene(m_selectStage.SceneName);
    }
}
