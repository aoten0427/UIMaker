using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPModel : ModelUIElement
{
    //ç≈ëÂHP
    const int MAX_HP = 100;
    //åªç›ÇÃHP
    float m_currentHP = 100.0f;

    ReactiveProperty<float> m_hpPercent = new ReactiveProperty<float>(1.0f);
    public Observable<float> HPPercent => m_hpPercent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Damage(10);
        }
    }

    void Damage(int damage)
    {
        m_currentHP -= damage;
        if(m_currentHP < 0)
        {

        }
        m_hpPercent.Value = m_currentHP / MAX_HP;
    }
}
