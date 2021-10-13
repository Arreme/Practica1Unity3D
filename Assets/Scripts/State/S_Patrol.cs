using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Patrol : I_State 
{

    StateController enemy;
    [SerializeField] ScriptableObject_Target _targetData;
    

    public void startState(StateController enemy)
    {
        this.enemy = enemy;
        
    }


    public void updateState()
    {
       
    }
}