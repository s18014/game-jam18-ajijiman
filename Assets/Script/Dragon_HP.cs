using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dragon_HP : MonoBehaviour
{
    public nemuHP nemuHp;

    public int nemuHP ;
    public int okoHP = 0;

    public int DangoDM;
    public int PizzaDM;
    public int NikumanDM;

    public int NEAT;

    Slider _slider;


    // Use this for initialization
    void Start()
    {
        _slider = GameObject.Find("nemu_Gauge").GetComponent<Slider>();

        _slider.value = nemuHP;

        if (nemuHP < 100)
            nemuHP = 0;

        if (okoHP < 70)
            okoHP = 0;

    }

    // Update is called once per frame
    void Update()
    {

        nemuHp.Addnemuhp(NEAT);




    }


    void OnTriggerStay2D(Collider2D other)
    { 
   
        if (other.gameObject.tag == "Dango")
        {

            nemuHP += DangoDM;
                      
            Destroy(other.gameObject);
        }


        if (other.gameObject.tag == "Pizza")
        {
            nemuHP += PizzaDM;
            
            Destroy(other.gameObject);
        }


        if (other.gameObject.tag == "Nikuman")
        {
            nemuHP += NikumanDM;
            
            Destroy(other.gameObject);
        }

    }


    /*
        public void dango ()
        {
            nemuHp.AddDangoo(DangoDM);
        }

        public void pizza ()
        {
            nemuHp.AddPizza(PizzaDM);
        }

        public void nikuman ()
        {
            nemuHp.AddNikuman(NikumanDM);
        }*/
}
