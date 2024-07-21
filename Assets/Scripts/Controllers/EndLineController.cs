using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLineController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ¿ì½ÂÀÚ
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            IngameManager.Instance.EndGame(player);
        }
    }
}
