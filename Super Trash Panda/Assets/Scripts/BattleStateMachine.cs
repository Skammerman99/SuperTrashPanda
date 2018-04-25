using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateMachine : MonoBehaviour
{

    public enum PerformAction
    {
        WAITING,
        SELECTACTION,
        PERFORMACTION
    }

    public PerformAction battleState;

    public List<HandleTurn> PerformList = new List<HandleTurn>();
    public List<GameObject> Party = new List<GameObject>();
    public List<GameObject> Enemies = new List<GameObject>();

    // Use this for initialization 
    void Start()
    {
        battleState = PerformAction.WAITING;
        Enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        Party.AddRange(GameObject.FindGameObjectsWithTag("Player"));
    }

    // Update is called once per frame
    void Update()
    {
        switch (battleState)
        {
            case (PerformAction.WAITING):
                break;
            case (PerformAction.SELECTACTION):
                break;
            case (PerformAction.PERFORMACTION):
                break;
        }
    }

    public void CollectActions(HandleTurn input)
    {
        PerformList.Add(input);
    }
}
