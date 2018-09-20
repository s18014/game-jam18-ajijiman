using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dango : MonoBehaviour {
    public float power;
    public float speed;
    public float chageTime;
    Rigidbody2D rig;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void shot(Vector2 target)
    {
        rig = GetComponent<Rigidbody2D>();
        Vector2 pos = transform.position;
        Vector2 direction = target - pos;
        direction.Normalize();
        rig.velocity = direction * speed;
    }
}