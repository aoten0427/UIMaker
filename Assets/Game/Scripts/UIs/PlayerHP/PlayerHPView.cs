using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPView : ViewUIElement
{
    //�g�����X�t�H�[��
    RectTransform m_rectTransform;
    //HP�o�[
    [SerializeField]
    Image m_hpBar;
    // Start is called before the first frame update
    public override void Initialize()
    {
        m_rectTransform = GetComponent<RectTransform>();
        m_rectTransform.anchoredPosition = m_mainPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeDamage(float par)
    {
        m_hpBar.fillAmount = par;
    }

   
}
