using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunData", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class GunScriptableObject : ScriptableObject
{
    public int _damage;
    public float _attckSpeed;
    public int _clipSize;
}
