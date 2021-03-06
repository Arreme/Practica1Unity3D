using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyStatePatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _tr;
    [SerializeField] private NavMeshAgent _navMesh;

    [SerializeField] private MonoBehaviour _nextState;

    private int _currTarget = 0;
    void Start()
    {
        _navMesh.destination = _tr[0].position;
    }

    private void Update()
    {
        if (_navMesh.remainingDistance <= 0.1f)
        {
            nextTarget();
            _navMesh.destination = _tr[_currTarget].position;
        }
    }

    private void nextTarget()
    {
        _currTarget++;
        if (_currTarget == _tr.Length) _currTarget = 0;
    }

    public void PatrolHearEvent(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _nextState.enabled = true;
            enabled = false;
        }
    }
}
