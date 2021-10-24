using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithPuntuation : MonoBehaviour
{
    private void Update()
    {
        if (StData.CurrentPuntuation >= 50)
        {
            Destroy(gameObject, 4);
            gameObject.SetActive(false);
        }
    }
}
