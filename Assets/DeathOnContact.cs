using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnContact : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            S_GameManager._gameManager.DeathEvent();
    }
}
