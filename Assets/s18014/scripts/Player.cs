using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 10f;
    Vector2 min;
    Vector2 max;

	// Use this for initialization
	void Start () {
    // bullet = GetComponent<BulletManager>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void FixedUpdate()
    {
        move();
     //   shot();
    }

    void move ()
    {
        min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        max = Camera.main.ViewportToWorldPoint(Vector2.one);
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

    /*
    void shot () {
        if (Input.GetKey(KeyCode.X))
        {
            bullet.equip = 0;
            bullet.shot(transform);
        }
        if (Input.GetKey(KeyCode.Z)) {
            bullet.equip = 1;
            bullet.shot(transform);
        }
        if (Input.GetKey(KeyCode.C))
        {
            bullet.equip = 2;
            bullet.shot(transform);
        }
    }
    */

}
