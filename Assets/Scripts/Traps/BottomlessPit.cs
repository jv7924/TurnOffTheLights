using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomlessPit : TrapBase
{
    protected override void DamagePlayer()
    {
        Debug.Log("Bottomless Pit");
    }
}
