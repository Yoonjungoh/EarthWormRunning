using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumManager : MonoBehaviour
{

    #region »ý¼ºÀÚ
    public static EnumManager _instance = null;

    public static EnumManager Instance
    {
        get 
        { 
            if (_instance == null)
            {
                _instance = new EnumManager();
            }
            return _instance; 
        }
    }
    #endregion
}

public enum PlayerState
{
    None = 0,
    Idle = 1,
    Move = 2,
}