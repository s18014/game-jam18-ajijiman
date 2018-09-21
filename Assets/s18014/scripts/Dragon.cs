using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour {
    public GameObject[] bulletPrefabs;
    float time = 3f;

	// Use this for initialization
	void Start () {
        StartCoroutine("shot");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator shot ()
    {
        yield return new WaitForSeconds(2f);
        while(true)
        {
            Instantiate(bulletPrefabs[Random.Range(0, 2)]);
            yield return new WaitForSeconds(time);
        }
    }
}
