using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointLoader : MonoBehaviour
{
    [SerializeField] private int _nCheckPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StData.CurrentCheckpoint = _nCheckPoint;
        }
    }
}
