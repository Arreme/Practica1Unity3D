using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateAttackChase : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMesh;
    [SerializeField] private Transform _target;

    private bool _inRange = false;
    private void Update()
    {
        _navMesh.destination = _target.position;
    }

    public void TriggerEnterEvent(Collider other)
    {
        
    }
}
