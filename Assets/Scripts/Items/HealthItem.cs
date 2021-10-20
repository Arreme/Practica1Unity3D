using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    [SerializeField] private float _shield;
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealthSysem healthSystem;
        if (other.TryGetComponent(out healthSystem)) {
            if (healthSystem.giveShield(_shield))
            {
                Destroy(gameObject);
            }
        }
    }
}
