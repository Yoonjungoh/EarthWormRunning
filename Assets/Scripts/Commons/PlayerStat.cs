using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    private float _moveSpeed = 0.5f;

    public float MoveSpeed { get { return _moveSpeed; } }

    public void SetStat(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }
}
