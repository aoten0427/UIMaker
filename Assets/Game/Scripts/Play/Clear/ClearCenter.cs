using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCenter : MonoBehaviour
{
    public static readonly string NAME = "ClearCenter";
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = NAME;
    }

    public void StageClear()
    {
        Debug.Log("StageClear");
    }
}
