using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

	public GameObject currentInterObj = null;
	public interactionObject curInterObjScript = null;
	public Inventory inventory;

	void update(){
		if (Input.GetButtonDown ("PickUp") && currentInterObj) {
			if (curInterObjScript.inventory) {
				inventory.addItem (currentInterObj);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("interObject")) {
			Debug.Log (other.name);
			currentInterObj = other.gameObject;
			curInterObjScript = currentInterObj.GetComponent<interactionObject> ();
		}
	}




}
