using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_State
{
    void startState(StateController enemy);
    void updateState(); 
}
