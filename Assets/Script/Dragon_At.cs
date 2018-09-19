using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_At : MonoBehaviour {

    private GameObject target;


	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player");
	 	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(target.transform.position);
		
	}
}
