﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed;
    public int hp;
    Vector2 min;
    Vector2 max;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void FixedUpdate()
    {
        move();
    }

    void move ()
    {
        float diffY = 96f / 720f;
        min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        max = Camera.main.ViewportToWorldPoint(Vector2.one);
        min.y -= min.y * diffY * 2f;
        Vector2 size = GetComponent<SpriteRenderer>().bounds.size / 2f;
        Vector2 pos = transform.position;
        Vector2 rot = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
            );
        rot.Normalize();
        pos += rot * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, min.x + size.x, max.x - size.x);
        pos.y = Mathf.Clamp(pos.y, min.y + size.y, max.y - size.y);
        transform.position = pos;
    }
}