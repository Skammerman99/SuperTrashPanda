using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusText : MonoBehaviour {
    private Text texter;
    public float HP = 100;
    public float MP = 100;
    private BattleStateMachine BSM;
    private GameObject partyMember;


	// Use this for initialization
	void Start () {
        texter = GetComponent<Text>();
        BSM = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
        partyMember = BSM.Party[0];
    }
	
	// Update is called once per frame
	void Update () {
        HP = partyMember.GetComponent<PlayerStateMachine>().player.CurHP;
        MP = partyMember.GetComponent<PlayerStateMachine>().player.CurMP;
        texter.text = "HP: " + HP + "\nMP: " + MP;

		
	}
}
