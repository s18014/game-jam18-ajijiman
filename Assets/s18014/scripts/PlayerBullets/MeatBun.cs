using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatBun : MonoBehaviour {
    public float power;
    public float speed;
    public float coolTime;
    float gravity = 9.81f * 2f;
    Rigidbody2D rig;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        fall();
	}

    public void shot(Vector2 target) {
        rig = GetComponent<Rigidbody2D>();
        Vector2 pos = transform.position;
        Vector2 direction = target - pos;
        direction.Normalize();
        rig.velocity = direction * speed;
    }

    void fall() {
        rig = GetComponent<Rigidbody2D>();
        Vector2 pos = Vector2.zero;
        pos.y = gravity * Time.deltaTime;
        rig.velocity -= pos;
    }

}
