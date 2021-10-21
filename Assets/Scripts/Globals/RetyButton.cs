using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetyButton : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            S_GameManager._gameManager.RestartGame();
        }
    }
}
