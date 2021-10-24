using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ColliderManager : MonoBehaviour
{
    [SerializeField] private UnityEvent<Collider> _triggerEnter;
    [SerializeField] private UnityEvent<Collider> _triggerExit;
    private void OnTriggerEnter(Collider other)
    {
        if (_triggerEnter != null)
        {
            _triggerEnter.Invoke(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_triggerExit != null)
        {
            _triggerExit.Invoke(other);
        }
    }
}
