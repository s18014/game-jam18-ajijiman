using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Futon : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector2(4, 10);
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 pos = transform.position;
        if (transform.position.y > -1f) {
            pos.y -= 3f * Time.deltaTime;
            transform.position = pos;
        } else {
            pos = new Vector2(4, -1);
            transform.position = pos;
        }
    }
}
