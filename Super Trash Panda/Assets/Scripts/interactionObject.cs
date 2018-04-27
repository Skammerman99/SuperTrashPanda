using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionObject : MonoBehaviour {

	public bool inventory; // if true this object can be stored in the inventory

	public void doInteraction(){
		gameObject.SetActive (false);
	}
}
