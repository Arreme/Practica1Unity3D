using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDummies : MonoBehaviour
{
    [SerializeField] private GameObject[] _dummies;

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject dummy in _dummies)
        {
            dummy.SetActive(true);
        }
    }
}
