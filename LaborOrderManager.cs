using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LaborOrderManager : MonoBehaviour
{
    [SerializeField] public GameObject pawn_prefab;
    public static Queue<Pawn> pawns;
    public static List<Queue<LaborOrder>> laborQueues = new List<Queue<LaborOrder>>();
    public int totalLaborOrders;
    public static int pawnCount;

    public static int incrementPawnCount() {
        return ++pawnCount;
    }

    public static int decrementPawnCount() {
        return --pawnCount;
    }

    // get the total number of labor orders in the list of labor queues
    public int getTotalLaborOrders() {
        int total = 0;
        for (int i = 0; i < 20; i++) {
            total += laborQueues[i].Count;
        }
        return total;
    }

    void assignPawn(){
        // iterate through the list of labor queues and find the first one with a labor order and dequeue it
        for (int i = 0; i < LaborOrder.numberOfLaborTypes; i++) {
            if (laborQueues[i].Count > 0) {
                // assign the pawn to the labor order
                pawns.Peek().currentLaborOrder = laborQueues[i].Dequeue();
                // start the coroutine to complete the labor order
                StartCoroutine(pawns.Peek().completeCurrentLaborOrder());
                // dequeue the pawn
                pawns.Dequeue();
                decrementPawnCount();
                // break out of the loop
                break;
            }
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        // initialize and populate pawn queue (Instantiate them as the children of this object)
        pawns = new Queue<Pawn>();
        for (int i = 0; i < 10; i++) {
            pawns.Enqueue(Instantiate(pawn_prefab, transform).GetComponent<Pawn>());
        }

        // iterate through the list of labor queues and initialize them
        for (int i = 0; i < 20; i++) {
            laborQueues.Add(new Queue<LaborOrder>());
        }

        // iterate through the list of labor queues and populate them with random labor orders that match the labor type
        int laborOrderToAdd = 5;
        for (int i = 0; i < 20; i++) {
            for (int j = 0; j < laborOrderToAdd; j++) {
                laborQueues[i].Enqueue(new LaborOrder((LaborTypes)i, UnityEngine.Random.Range(3, 10)));
            }
        }

        // initialize totalLaborOrders to 0
        totalLaborOrders = 0;

        // initialize pawnCount to 0
        pawnCount = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // assure there are pawns and labor orders to assign
        if (pawns.Count > 0 && getTotalLaborOrders() > 0) {

            // print the number of pawns and labor orders
            //Debug.Log("Pawns: " + pawns.Count + " Labor Orders: " + laborQueues.Sum(x => x.Count));

            // assign a pawn to a labor order
            assignPawn();
        }
    }
}
