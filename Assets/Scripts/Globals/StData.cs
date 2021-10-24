using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StData
{
    private static int _currentCheckPoint = 0;
    public static int CurrentCheckpoint
    {
        get { return _currentCheckPoint; }
        set { if (value > _currentCheckPoint) _currentCheckPoint = value; }
    }

    private static int _currentPuntuation = 0;
    public static int CurrentPuntuation
    {
        get { return _currentPuntuation; }
        set { _currentPuntuation = value; }
    }

    public static void ResetData()
    {
        _currentCheckPoint = 0;
    }


    private static int _currentKeys = 0; 
    public static int CurrentKeys
    {
        get { return _currentKeys; }
        set { _currentKeys = value; }
    }
}
