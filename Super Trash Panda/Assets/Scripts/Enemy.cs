﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    int HP;
    // Use this for initialization
    void Start () {

        HP = 10;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (HP == 0)
        {
            Destroy(gameObject);
        }


	}
}
