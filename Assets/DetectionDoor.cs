using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionDoor : MonoBehaviour
{
    [SerializeField] private Animation _animation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animation.Play("OpenDoor");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        _animation.Play("CloseDoor");
    }
}
