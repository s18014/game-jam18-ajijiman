using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_HP : MonoBehaviour
{

    public int nemuHP = 100;
    public int okoHP = 0;


    // Use this for initialization
    void Start()
    {

        if (nemuHP < 0)
            nemuHP = 0;

        if (okoHP < 50)
            okoHP = 50;

    }

    // Update is called once per frame
    void Update()
    {



    }
    public void AddTimer(int amount)
    {
        nemuHP -= amount;

    }
}
