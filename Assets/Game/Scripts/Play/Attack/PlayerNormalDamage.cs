using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalDamage : DamageBox
{
    // Start is called before the first frame update
    protected override void  Start()
    {
        base.Start();
        SetLifeTime(5.0f);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    
}
