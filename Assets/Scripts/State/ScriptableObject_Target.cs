using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TargetData", menuName = "ScriptableObjects/ScriptableObjectTarget", order = 2)]
public class ScriptableObject_Target : ScriptableObject
{
    [SerializeField] private Transform[] _targets; 
}
