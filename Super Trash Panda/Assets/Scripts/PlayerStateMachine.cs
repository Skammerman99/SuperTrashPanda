using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateMachine : MonoBehaviour {

    public PlayerBase player;

    public enum TurnState
    {
        PROCESSING,
        ADDTOLIST,
        WAITING,
        SELECTING,
        ACTION,
        DEAD
    }

    public TurnState currState;

    public float currCool = 0f;
    public float maxCool = 5f;
    public Image progressBar;
    public BattleStateMachine BSM;
    public bool keypress;




	// Use this for initialization
	void Start () {
        currState = TurnState.PROCESSING;
        BSM = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();

    }

    // Update is called once per frame
    void Update () {
        keypress = Input.GetKey(KeyCode.Z);
        switch (currState)
        {
            case (TurnState.PROCESSING):
                UpdateProgressBar();
                break;
            case (TurnState.ADDTOLIST):

                break;
            case (TurnState.WAITING):

                break;
            case (TurnState.SELECTING):
                if (Input.GetKey(KeyCode.Z)){
                    currState = TurnState.ACTION;
                }
                break;
            case (TurnState.ACTION):
                PlayerAttack();
                ResetProgressBar();
                currState = TurnState.PROCESSING;
                

                break;
            case (TurnState.DEAD):

                break;

        }
	}

    void UpdateProgressBar()
    {
        currCool += Time.deltaTime;
        float coolRatio = currCool / maxCool;
        progressBar.transform.localScale = new Vector2(Mathf.Clamp(coolRatio, 0, 1), progressBar.transform.localScale.y);
        if(currCool >= maxCool)
        {
            //currState = TurnState.ADDTOLIST;
            currState = TurnState.SELECTING;
        }
    }

    void PlayerAttack()
    {
        BSM.Enemies[0].GetComponent<EnemyStateMachine>().enemy.CurHP -= 10;
    }

    private void ResetProgressBar()
    {
        currCool = 0;
    }
}
