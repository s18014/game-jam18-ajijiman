using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {

    }

    // Update is called once per frame
    void Update () {

    }
    private void OnTriggerExit2D(Collider2D c)
    {
        string layerName = LayerMask.LayerToName(c.gameObject.layer);
        if (layerName == "DestroyArea")
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(111); 
    }

}
