using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// TODO - 현재 sec로만 받으니 원하면 수정 (시간 다 지나고 Scene까지 로딩 돼야 팝업 꺼지게 수정하는 게 자연스러울듯)
public class UI_Loading : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _loadingText;
    private int _loadingMaxTime;
    private int _curLoadingTime;
    WaitForSeconds _loadingForSeconds = new WaitForSeconds(1);

    // TODO - 수정
    public void Show(int loadingTime)
    {
        _loadingMaxTime = loadingTime;
        StartCoroutine(CoCountLoadingTime());
    }

    private IEnumerator CoCountLoadingTime()
    {
        _loadingText.text = $"Loading... {_curLoadingTime} sec";
        _curLoadingTime++;

        yield return _loadingForSeconds;

        if (_curLoadingTime < _loadingMaxTime)
        {
            StartCoroutine(CoCountLoadingTime());
        }
        else
        {
            yield return null;
        }
    }
}
