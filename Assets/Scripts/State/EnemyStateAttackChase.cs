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

    public void TriggerEnterExitEvent(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inRange = !_inRange;
            _navMesh.isStopped = _inRange;
        }
        
        //run animation
        //activate colliderobj
    }

    public void TriggerEnterAttackEvent(Collider other)
    {
        other.GetComponent<PlayerHealthSysem>()?.getHit();
    }
}
