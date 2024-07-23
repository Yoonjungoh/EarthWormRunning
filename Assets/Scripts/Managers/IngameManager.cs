using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    public Dictionary<int, PlayerController> PlayerDictionary = new Dictionary<int, PlayerController>();    // (key, value) = (id, �÷��̾� ����)

    public MyPlayerController MyPlayer;

    private PlayerController _winner;

    private int _id;

    private List<Vector3> _playerSpawnPosList = new List<Vector3>();

    private Queue<Vector3> _playerSpawnPosQueue = new Queue<Vector3>();

    public void Init(List<Vector3> playerSpawnPositionList)
    {
        _playerSpawnPosList = playerSpawnPositionList;

        _playerSpawnPosList.Shuffle();    // ���� ������ ������
        _playerSpawnPosQueue = new Queue<Vector3>(_playerSpawnPosList);

        SpawnMyPlayer();
        SpawnOtherPlayers();

        _playerSpawnPosQueue.Clear();
    }

    private void SpawnMyPlayer()
    {
        if (_playerSpawnPosQueue.Count == 0)
            return;

        Vector3 spawnPos = _playerSpawnPosQueue.Dequeue();
        // TODO - ���� ������ ���ҽ� �Ŵ��� ���
        GameObject myPlayerPrefab = Resources.Load<GameObject>("Prefabs/Creatures/MyPlayer");
        GameObject myPlayerObj = Instantiate(myPlayerPrefab, spawnPos, Quaternion.identity);
        MyPlayerController myPlayer = myPlayerObj.GetComponent<MyPlayerController>();

        int id = GenerateId();
        myPlayer.Init(id);
        MyPlayer = myPlayer;

        PlayerDictionary.TryAdd(id, MyPlayer);
    }

    private void SpawnOtherPlayers()
    {
        // TODO - ���� ������ ���ҽ� �Ŵ��� ���
        GameObject otherPlayerPrefab = Resources.Load<GameObject>("Prefabs/Creatures/OtherPlayer");
        for (int i = 0; i < 4; i++)
        {
            if (_playerSpawnPosQueue.Count == 0)
                return;

            Vector3 spawnPos = _playerSpawnPosQueue.Dequeue();
            GameObject otherPlayerObj = Instantiate(otherPlayerPrefab, spawnPos, Quaternion.identity);
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

    public void EndGame(PlayerController winner)
    {
        // �ߺ� ����� ����
        if (_winner != null)
            return;

        if (winner == null)
            return;

        _winner = winner;

        // TODO - UI �Ŵ��� ���
        GameObject winnerUIPrefab = Resources.Load<GameObject>("Prefabs/UI/UI_Win");
        GameObject winnerUIObj = Instantiate(winnerUIPrefab);
        UI_Win winnerUI = winnerUIObj.GetComponent<UI_Win>();
        winnerUI.ShowPop(winner);
    }


    // TODO - ���� ������ �Ŵ��� ���
    #region ������
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