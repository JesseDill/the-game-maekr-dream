using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateHandler : MonoBehaviour
{
    PlatformEffector2D platformEffector;
    [SerializeField] private Key.KeyType keyType;
    bool gateOpen = false;
    private void Awake()
    {
        platformEffector = GetComponent<PlatformEffector2D>();
    }

    public void ChangeGateState()
    {
        gateOpen = !gateOpen;
        if (gateOpen) 
        {
            platformEffector.surfaceArc = 0;
        }
        else if (!gateOpen)
        {
            platformEffector.surfaceArc = 360;
        }
    }

    public Key.KeyType GetKeyType()
    {
        return keyType;
    }

}
