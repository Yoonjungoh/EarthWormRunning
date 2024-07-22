using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameScene : MonoBehaviour
{
    [SerializeField] private List<Transform> _playerSpawnPositionList = new List<Transform>();

    void Awake()
    {
        Init();
    }

    private void Init()
    {
        List<Vector3> playerSpawnPositionList = new List<Vector3>();

        foreach (Transform transform in _playerSpawnPositionList)
        {
            playerSpawnPositionList.Add(transform.position);
        }

        IngameManager.Instance.Init(playerSpawnPositionList);
    }
}
