using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController : PlayerController
{
    void Update()
    {
        OnUpdate();

        if (Input.GetKeyDown(KeyCode.A))
        {
            IngameManager.Instance.MyPlayer._playerStat.SetStat(1.0f);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            IngameManager.Instance.MyPlayer._playerStat.SetStat(0.5f);
        }
    }
}
