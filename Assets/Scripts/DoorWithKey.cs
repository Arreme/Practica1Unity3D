using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithKey : MonoBehaviour
{

    [SerializeField] private Animation _animation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (StData.CurrentKeys >= 1)
            {
                StData.CurrentKeys--;
                _animation.Play("OpenDoor");
            }
        }
    }
}
