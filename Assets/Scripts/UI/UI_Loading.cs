using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// TODO - ���� sec�θ� ������ ���ϸ� ���� (�ð� �� ������ Scene���� �ε� �ž� �˾� ������ �����ϴ� �� �ڿ��������)
public class UI_Loading : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _loadingText;
    private int _loadingMaxTime;
    private int _curLoadingTime;
    WaitForSeconds _loadingForSeconds = new WaitForSeconds(1);

    // TODO - ����
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
