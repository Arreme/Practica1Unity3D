using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Patrol : I_State 
{

    StateController enemy;
 
    

    public void startState(StateController enemy)
    {
        this.enemy = enemy;
        
    }


    public void updateState()
    {
       
    }
}