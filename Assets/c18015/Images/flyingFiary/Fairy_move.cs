﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy_move : MonoBehaviour {

    Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0))
        {
            animator.Play("Throw");
        }
        

    }
}
