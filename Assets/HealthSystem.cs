using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] float _health;

    public void getHit(float damage)
    {
        _health -= damage;
        if (_health <= 0) Destroy(gameObject);
    }
}
