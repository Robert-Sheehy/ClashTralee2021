using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    Renderer myRenderer;
    private int MHP = 1000, CHP = 1000, Level = 1;
    private bool destroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();

      
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    internal void takeDamage(int how_much_damage)
    {
        myRenderer.material.color = Color.blue;
        CHP -= how_much_damage;
        if (CHP <= 0)
        {
            destroyed = true;
            myRenderer.material.color = Color.red;
        }
    }

    internal void repair(int how_much_heal)
    {
        CHP += how_much_heal;
        if (CHP > MHP)
        {
            CHP = MHP;
            myRenderer.material.color = Color.white;
        }
    }
}
