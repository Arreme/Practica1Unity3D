using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : MonoBehaviour
{
    [SerializeField] private float _health;
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealthSysem healthSystem;
        if (other.TryGetComponent(out healthSystem)) {
            if (healthSystem.giveHealth(_health))
            {
                Destroy(gameObject);
            }
        }
    }
}
