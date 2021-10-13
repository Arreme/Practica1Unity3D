using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeshAgentTarget : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMesh;
    [SerializeField] private Transform _target;

    private void Update()
    {
        _navMesh.destination = _target.position;
    }
}
