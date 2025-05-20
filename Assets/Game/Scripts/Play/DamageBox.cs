using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReadDamageBox
{
    Character GetAttacker();
    int GetDamage();
}

public class DamageBox : MonoBehaviour,IReadDamageBox
{
    Character.Parameter m_attacker;

    [Header("�_���[�W�ݒ�")]
    [SerializeField] int m_damage = 10;

    [Header("�_���[�W�{�b�N�X�ݒ�")]
    [SerializeField]  float m_lifeTime = 0.2f;
    [SerializeField] float m_interval = 1.0f;
    [SerializeField]  bool m_destroyOnHit = false;
    [SerializeField]  LayerMask m_targetLayers;

    float m_lifeTimer;

    List<Collider2D> hitColliders = new List<Collider2D>();


    //getter,setter
    public void SetDamage(int dmage) {  m_damage = dmage; }
    public void SetLifeTime(float lifeTime) {  m_lifeTime = lifeTime; }
    public void SetInterval(float interval) {  m_interval = interval; }
    public void SetDestroyOhHit(bool onhit) {  m_destroyOnHit = onhit; }

    public Character GetAttacker() { return m_attacker.character; }
    public int GetDamage() { return m_damage; }
    public float GetInterval() { return m_interval; }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        m_targetLayers += 1 << LayerMask.NameToLayer("Character");
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        m_lifeTimer += Time.deltaTime;
        if(m_lifeTimer > m_lifeTime)
        {
            Destroy(gameObject);
        }
    }
    
    public void Attack(Character.Parameter parameter)
    {
        m_attacker = parameter;
    }


    protected void OnTriggerEnter2D(Collider2D collision)
    {
        // �Ώۃ��C���[�łȂ���Ζ���
        if (((1 << collision.gameObject.layer) & m_targetLayers) == 0) return;
        //���łɓ������Ă���Ȃ疳��
        if (hitColliders.Contains(collision)) return;

        hitColliders.Add(collision);

        // ���肪�L�����N�^�[�Ȃ�_���[�W��^����
        Character targetCharacter = collision.GetComponent<Character>();
        if (targetCharacter != null && targetCharacter != m_attacker.character)
        {
            targetCharacter.Damage(this);

            if (m_destroyOnHit) Destroy(gameObject);
        }
    }
}
