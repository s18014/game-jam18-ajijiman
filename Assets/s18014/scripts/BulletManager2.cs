using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager2 : MonoBehaviour {
    public GameObject dangoPrefab;
    public GameObject pizzaPrefab;
    public GameObject meatBunPrefab;
    int equip = 0;
    Vector2 target;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        changeFoods();
        shot();
		
	}

    void shot () {
        if (Input.GetMouseButtonDown(0)) {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(target);
        }
        if (Input.GetMouseButtonUp(0))  {
            if (equip == 0) {
                GameObject dango = Instantiate(dangoPrefab, transform.position, Quaternion.identity);
                dango.GetComponent<Dango>().shot(target);
            }
            if (equip == 1) {
                GameObject pizza = Instantiate(pizzaPrefab, transform.position, Quaternion.identity);
                pizza.GetComponent<Pizza>().shot(target);
            }
            if (equip == 2)
            {
                GameObject meatBun = Instantiate(meatBunPrefab, transform.position, Quaternion.identity);
                meatBun.GetComponent<MeatBun>().shot(target);
            }
        }
    }

    void changeFoods() {
        if (Input.GetMouseButtonDown(1)) {
            equip += 1;
            if (equip > 2) equip = 0;
        }
    }
}