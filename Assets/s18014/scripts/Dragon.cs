using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour {
    public float maxHungryPoint;
    public float hungryPoint;
    public float maxAngryPoint;
    public float angryPoint;

	// Use this for initialization
	void Start () {
        hungryPoint = maxHungryPoint;
        angryPoint = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
