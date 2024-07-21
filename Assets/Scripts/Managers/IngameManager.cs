using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    public Dictionary<int, PlayerController> PlayerDictionary = new Dictionary<int, PlayerController>();    // (key, value) = (id, 플레이어 정보)

    public MyPlayerController MyPlayer;

    private int _id;

    public void StartGame()
    {
        SpawnMyPlayer();
        SpawnOtherPlayers();
    }

    public void EndGame(PlayerController winPlayer)
    {
        // TODO - UI 매니저 사용
        GameObject winnerUIPrefab = Resources.Load<GameObject>("Prefabs/UI/UI_Win");
        GameObject winnerUIObj = Instantiate(winnerUIPrefab);
        UI_Win winnerUI = winnerUIObj.GetComponent<UI_Win>();
        winnerUI.ShowPop(winPlayer);
    }

    private void SpawnMyPlayer()
    {
        GameObject myPlayerPrefab = Resources.Load<GameObject>("Prefabs/Creatures/MyPlayer");
        GameObject myPlayerObj = Instantiate(myPlayerPrefab, new Vector3(-8.0f, 3.3f, 0.0f), Quaternion.identity);
        MyPlayerController myPlayer = myPlayerObj.GetComponent<MyPlayerController>();

        int id = GenerateId();
        myPlayer.Init(id);
        MyPlayer = myPlayer;

        PlayerDictionary.TryAdd(id, MyPlayer);
    }

    private void SpawnOtherPlayers()
    {
        GameObject otherPlayerPrefab = Resources.Load<GameObject>("Prefabs/Creatures/OtherPlayer");
        for (int i = 0; i < 4; i++)
        {
            GameObject otherPlayerObj = Instantiate(otherPlayerPrefab, new Vector3(-8.0f, (3.3f - (i + 1) * 1.7f), 0.0f), Quaternion.identity);
            OtherPlayerController otherPlayer = otherPlayerObj.GetComponent<OtherPlayerController>();

            int id = GenerateId();
            otherPlayer.Init(id);

            PlayerDictionary.TryAdd(id, otherPlayer);
        }
    }

    private int GenerateId()
    {
        return _id++;
    }

    #region 생성자
    public static IngameManager _instance = null;

    public static IngameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new IngameManager();
                GameObject singleton = new GameObject();
                _instance = singleton.AddComponent<IngameManager>();
                singleton.name = typeof(IngameManager).ToString();
            }

            return _instance;
        }
    }
    #endregion
}