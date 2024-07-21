using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameScene : MonoBehaviour
{
    void Awake()
    {
        Init();
    }

    private void Init()
    {
        IngameManager.Instance.StartGame();
    }
}
