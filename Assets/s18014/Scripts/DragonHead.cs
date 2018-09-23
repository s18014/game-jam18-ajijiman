using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHead : MonoBehaviour {
    Dragon dragon;

	// Use this for initialization
	void Start () {
        dragon = transform.parent.gameObject.GetComponent<Dragon>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerBullet") {
            dragon.hungryPoint -= other.gameObject.GetComponent<Bullet>().power;
            if (dragon.hungryPoint > dragon.maxHungryPoint) dragon.hungryPoint = dragon.maxHungryPoint;
            if (dragon.hungryPoint < 0f) dragon.hungryPoint = 0f;
            Destroy(other.gameObject);
        }
    }
}
