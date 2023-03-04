using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum LaborType { FireFight, Patient, Doctor, Sleep, Basic, Warden, Handle, Cook, Hunt, Construct, Grow, Mine, Farm, Woodcut, Smith, Tailor, Art, Craft, Haul, Clean, Research };

[System.Serializable]
public struct LaborOrder
{
    public LaborType? laborType;
    public float timeToComplete;
    public int orderNumber;
    public static int orderCount = 0;

    public const int numberOfLaborTypes = 21;
    const float maxTimeToComplete = 3.0f;
    const float maxMinTimeToComplete = 5.0f;

    public LaborOrder(LaborType laborType, float timeToComplete)
    {
        this.laborType = laborType;
        this.timeToComplete = timeToComplete;
        orderNumber = ++orderCount;
    }

    // default constructor for testing struct
    public LaborOrder(bool isRandom){
        laborType = (LaborType)UnityEngine.Random.Range(0, numberOfLaborTypes);
        timeToComplete = UnityEngine.Random.Range(maxMinTimeToComplete, maxTimeToComplete);
        orderNumber = ++orderCount;
    }

    public LaborType getLaborType() {
        return (LaborType)laborType;
    }

}
