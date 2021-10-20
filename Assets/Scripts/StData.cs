using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StData
{
    public static int _currentCheckPoint = 0;

    public static void tryUpdateCheckPoint(int nCheckPoint)
    {
        if (nCheckPoint > _currentCheckPoint) _currentCheckPoint = nCheckPoint;
    }

    public static void ResetData()
    {
        _currentCheckPoint = 0;
    }
}
