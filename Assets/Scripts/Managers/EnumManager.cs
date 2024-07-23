using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumManager : MonoBehaviour
{

    // TODO - 따로 래핑한 매니저 사용
    #region 생성자
    public static EnumManager _instance = null;

    public static EnumManager Instance
    {
        get 
        { 
            if (_instance == null)
            {
                _instance = new EnumManager();
                GameObject singleton = new GameObject();
                _instance = singleton.AddComponent<EnumManager>();
                singleton.name = typeof(EnumManager).ToString();
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