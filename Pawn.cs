using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{

    [SerializeField] public LaborOrder currentLaborOrder;
    [SerializeField] public string pawnName;
    [SerializeField] public List<LaborTypes>[] queueAnswerPriority;

    // coroutine to complete labor order
    public IEnumerator completeCurrentLaborOrder() {
        
        // print the pawn name and the labor type
        Debug.Log(pawnName + " is completing work order type" + currentLaborOrder.laborType);

        yield return new WaitForSeconds(currentLaborOrder.timeToComplete);
        currentLaborOrder.laborType = null;
        // add the pawn back to the queue
        LaborOrderManager.pawns.Enqueue(this);
    }

    // Start is called before the first frame update
    void Awake()
    {   
        // initialize pawn name and assign to pawn while incrementing pawnCount
        name = "Pawn" + LaborOrderManager.incrementPawnCount();
        pawnName = "Pawn" + LaborOrderManager.incrementPawnCount();

        // initialize queueAnswerPriority to length 4 and randomly assign labor types to each list
        queueAnswerPriority = new List<LaborTypes>[4];
        for (int i = 0; i < 4; i++) {
            queueAnswerPriority[i] = new List<LaborTypes>();
            for (int j = 0; j < 20; j++) {
                queueAnswerPriority[i].Add((LaborTypes)j);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
