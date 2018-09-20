using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Western_PlayerController : PlayerController {

    public WesternManager wm;

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(PlayerData.playerKeys[slot]))
        {
            wm.RecordShot(this);
        }
    }

}
