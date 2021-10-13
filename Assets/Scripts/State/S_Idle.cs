using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Idle : I_State 
{

    StateController enemy;
    float _idleCD; 

    public void startState(StateController enemy)
    {
        this.enemy = enemy;
        _idleCD = 5;
    }


    public void updateState()
    {
        _idleCD -= Time.deltaTime;
        if (_idleCD <= 0)
            enemy.changeState(enemy._patrolState);
    }
}
