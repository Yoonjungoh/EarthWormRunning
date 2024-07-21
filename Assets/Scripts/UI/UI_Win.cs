using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Win : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _winText;
    [SerializeField] private Image _winnerImage;

    // TODO - ¼öÁ¤
    public void ShowPop(PlayerController player)
    {
        _winText.text = $"Winner Id: {player.Id}";
        _winnerImage.sprite = player.GetComponent<SpriteRenderer>().sprite;
        _winnerImage.color = player.GetComponent<SpriteRenderer>().color;
        Time.timeScale = 0f;
    }
}
