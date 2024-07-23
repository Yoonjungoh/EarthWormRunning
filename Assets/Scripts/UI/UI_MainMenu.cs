using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class UI_MainMenu : MonoBehaviour
{
    // TODO - 데이터화
    private const int MIN_TIME = 3;
    private const int MAX_TIME = 15;

    void Start()
    {
        Init();
    }

    private void Init()
    {

    }

    // TODO
    public void OnClickMatchButton()
    {
        Random random = new Random();
        int randomTime = random.Next(MIN_TIME, MAX_TIME + 1);
        StartCoroutine(CoEnterIngame(randomTime));
    }

    // TODO
    private IEnumerator CoEnterIngame(int randomTime)
    {
        // TODO - UI 매니저 사용
        GameObject loadingUIPrefab = Resources.Load<GameObject>("Prefabs/UI/UI_Loading");
        GameObject loadingUIObj = Instantiate(loadingUIPrefab);
        UI_Loading loadingUI = loadingUIObj.GetComponent<UI_Loading>();

        loadingUI.Show(randomTime);

        yield return new WaitForSeconds(randomTime);

        SceneManager.LoadScene("Ingame");
    }
}
