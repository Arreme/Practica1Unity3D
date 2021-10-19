using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthSysem : MonoBehaviour
{
    [SerializeField] float _health;
    [SerializeField] float _shield;

    [SerializeField] private UnityEvent<float> _healthEvent;
    [SerializeField] private UnityEvent<float> _shieldEvent;

    public void getHit()
    {
        if (_shield > 0)
        {
            _shield -= 75;
            Debug.Log(_shield);
            _shield = _shield < 0 ? 0 : _shield;
            _shieldEvent.Invoke(_shield);
        } else
        {
            _health -= 25;
            _health = _health < 0 ? 0 : _health;
            _healthEvent.Invoke(_health);
            if (_health <= 0)
            {
                //DeathScreen
            }
        }
    }
}
