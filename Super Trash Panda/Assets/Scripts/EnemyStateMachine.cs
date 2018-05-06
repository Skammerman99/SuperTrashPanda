using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour {

    public EnemyBase enemy;
    private BattleStateMachine BSM;

    public enum TurnState
    {
        PROCESSING,
        CHOOSEACTION,
        WAITING,
        ACTION,
        DEAD
    }

    public TurnState currState;

    public float currCool = 0f;
    public float maxCool = 5f;
    public float coolRatio;

    // Use this for initialization
    void Start () {
        currState = TurnState.PROCESSING;
        BSM = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();

    }

    // Update is called once per frame
    void Update () {

        switch (currState)
        {
            case (TurnState.PROCESSING):
                UpdateProgressBar();
                break;
            case (TurnState.CHOOSEACTION):
                ChooseAction();
                currState = TurnState.WAITING;
                break;
            case (TurnState.WAITING):
                ResetProgressBar();
                currState = TurnState.PROCESSING;
                break;

            case (TurnState.ACTION):

                break;
            case (TurnState.DEAD):

                break;

        }

    }

    void UpdateProgressBar()
    {
        currCool += Time.deltaTime;
        coolRatio = currCool / maxCool;
        if (currCool >= maxCool)
        {
            currState = TurnState.CHOOSEACTION;
        }
    }

    private void ResetProgressBar()
    {
        currCool = 0;
    }

    void ChooseAction()
    {
        HandleTurn attackerino = new HandleTurn();
        attackerino.attackerName = enemy.Name;
        attackerino.Attacker = this.gameObject;
        attackerino.Target = BSM.Party[0];
        BSM.CollectActions(attackerino);
        attackerino.Target.GetComponent<PlayerStateMachine>().player.CurHP -= 10;
        //attackerino.Target = BSM.Party[Random.Range(0, BSM.Party.Count)];
        //this is for random attacks eventually ^
    }
}
