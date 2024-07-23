using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLineController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ¿ì½ÂÀÚ
        PlayerController winner = collision.GetComponent<PlayerController>();
        if (winner != null)
        {
            IngameManager.Instance.EndGame(winner);
        }
    }
}
