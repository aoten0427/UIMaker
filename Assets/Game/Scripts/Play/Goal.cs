using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    IClearCondition m_clera;
    // Start is called before the first frame update
    void Start()
    {
        GameObject goalClear = ClearFactory.CreateClearCondition(ClearCondition.ClearType.Goal);
        goalClear.transform.parent = transform;
        m_clera = goalClear.GetComponent<IClearCondition>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) m_clera.Clear();
    }
}
