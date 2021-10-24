using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateAlert : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMesh;
    [SerializeField] private Transform _player;

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
                    Debug.Log("Found!");
                }
            }
            
        }
    }

    private void OnEnable()
    {
        StartCoroutine(Alerted());
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position,_player.position - transform.position);
    }
    private IEnumerator Alerted()
    {
        //HUH
        yield return new WaitForSeconds(1f);
        _navMesh.destination = _player.position;
    }
}
