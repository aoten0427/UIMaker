using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageUIData : MonoBehaviour
{
    //�V�[����
    [SerializeField]
    string m_sceneName;
    public string SceneName { get { return m_sceneName; } }

    //�K�p�����UI
    public List<UIElement> m_activeElements { get; set; }
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
