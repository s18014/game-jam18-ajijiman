using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour {
    public float power;
    public float speed;
    public float chageTime;
    float gravity = 9.81f;
    SpriteRenderer sprinteRenderer;
    Rigidbody2D rig;
    Vector2 target = Vector2.zero;
    Vector2 Target
    {
        set { target = value; }
    }


	// Use this for initialization
	void Start () {
        sprinteRenderer = GetComponent<SpriteRenderer>();
        rig = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        fall();
	}

    IEnumerator move ()
    {
        firstMove();
        yield return new WaitForSeconds(1f);
        secondMove();
    }

    void firstMove()
    {
        float angle = 75f;
        Vector2 dirction = Vector2.zero; 
        dirction.x = Mathf.Cos(Mathf.Deg2Rad * angle); 
        dirction.y = Mathf.Sin(Mathf.Deg2Rad * angle);
        dirction.Normalize();
        rig.velocity = dirction * speed / 2f;
    }

    void secondMove()
    {
        gravity = 0f;
        rig.velocity = Vector2.zero;
        Vector2 pos = transform.position;
        Vector2 direction = target - pos;
        direction.Normalize();
        rig.velocity = direction * speed;
    }

    public void shot(Vector2 target)
    {
        this.target = target;
        StartCoroutine("move");
    }

    void fall ()
    {
        Vector2 pos = new Vector2(0f, 0f);
        pos.y = gravity * Time.deltaTime;
        rig.velocity -= pos;
        Debug.Log(gravity);
    }
}