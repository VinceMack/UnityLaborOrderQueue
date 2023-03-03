using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LaborTypes { FireFight, Patient, Doctor, Sleep, Basic, Warden, Handle, Cook, Hunt, Construct, Grow, Mine, Farm, Woodcut, Smith, Tailor, Art, Craft, Haul, Clean, Research };

public struct LaborOrder
{
    public LaborTypes? laborType;
    public float timeToComplete;
    public int orderNumber;
    public static int orderCount = 0;

    public const int numberOfLaborTypes = 21;
    const float maxTimeToComplete = 0.2f;
    const float maxMinTimeToComplete = 0.1f;

    public LaborOrder(LaborTypes laborType, float timeToComplete)
    {
        this.laborType = laborType;
        this.timeToComplete = timeToComplete;
        orderNumber = ++orderCount;
    }

    // default constructor for testing struct
    public LaborOrder(bool isRandom){
        laborType = (LaborTypes)UnityEngine.Random.Range(0, numberOfLaborTypes);
        timeToComplete = UnityEngine.Random.Range(maxMinTimeToComplete, maxTimeToComplete);
        orderNumber = ++orderCount;
    }

}
