using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackModel : ModelUIElement
{
    GameObject m_weapon;
    PlayerNormalDamage m_normalDamage;
    float m_interval;
    float m_intervalTimer;

    // Start is called before the first frame update
    void Start()
    {
        PlayerItems playeritems = Resources.Load<PlayerItems>(PlayerItems.NAME);
        m_weapon = playeritems.GetItem(PlayerItems.PlayerItem.ItemType.NormalAttack);

        m_interval = m_weapon.GetComponent<PlayerNormalDamage>().GetInterval();
    }

    // Update is called once per frame
    void Update()
    {
        m_intervalTimer -= Time.deltaTime;
    }

    public override void ButtonHoldAction(Player player)
    {
        if (m_intervalTimer > 0) return;
        m_intervalTimer = m_interval;

        Vector2 pos = player.GetParameter().character.transform.position;
        pos += player.GetParameter().m_direction * 2;

        Instantiate(m_weapon,pos,Quaternion.identity);
    }
}
