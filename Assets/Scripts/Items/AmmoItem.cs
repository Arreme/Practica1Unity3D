using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoItem : MonoBehaviour
{
    [SerializeField] private int _ammo;
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealthSysem shooter;
        if (other.TryGetComponent(out shooter)) {
            if (shooter.bridgeShooter(_ammo))
            {
                Destroy(gameObject);
            }
        }
    }
}
