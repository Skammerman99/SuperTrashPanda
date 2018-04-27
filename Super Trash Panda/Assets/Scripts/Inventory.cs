using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public GameObject[] inventory = new GameObject[10];

	public void addItem(GameObject item){
		bool itemAdded = false;
		for (int i = 0; i < 10; i++) {
			if (inventory [i] == null) {
				inventory [i] = item;
				Debug.Log (item.name + "was added.");
				itemAdded = true;
				item.SendMessage ("doInteraction");
				break;
			}
		}
		if (!itemAdded) {
			Debug.Log ("Inventory is full - Item is not added.");
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
