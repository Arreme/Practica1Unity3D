using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateAlert : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMesh;
    [SerializeField] private Transform _player;
    [SerializeField] private MonoBehaviour _nextState;
    [SerializeField] private MonoBehaviour _patrolState;

    [SerializeField] private float _distance = 10;
    [SerializeField] private LayerMask _layerMask;
    private void Update()
    {
        RaycastHit info;
        if (Physics.Raycast(transform.position, _player.position - transform.position,out info,_distance,_layerMask))
        {
            if (info.transform.CompareTag("Player"))
            {
                Vector3 _direction = _player.position - transform.position;
                _direction.Normalize();
                float angle = Vector3.Angle(transform.forward, _direction);
                if (angle <= 80)
                {
                    StopCoroutine(Alerted());
                    _nextState.enabled = true;
                    enabled = false;
                }
            }
            
        }
    }

    private void OnEnable()
    {
        StartCoroutine(Alerted());
    }
    private IEnumerator Alerted()
    {
        yield return new WaitForSeconds(1f);
        _navMesh.destination = _player.position;
        yield return new WaitForSeconds(7f);
        _patrolState.enabled = true;
        enabled = false;
    }
}
