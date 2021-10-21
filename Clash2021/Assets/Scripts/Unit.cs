using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour, IHealth
{
    internal  Manager theManager;
    internal float Melee_distance;
    internal int DPS;
    internal float attack_time_interval = 0.5f;
    internal float attack_timer;

    bool dead;
    internal Unit current_target;
    internal int MHP = 1000, CHP = 1000, _level = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void takeDamage(int how_much_damage)
    {
        Debug.Log("Im being damaged");
        CHP -= how_much_damage;
        if (CHP <= 0)
        {
            dead = true;
            Debug.Log("Dead");
        }
    }


    public void repair(int v)
    {
        throw new System.NotImplementedException();
    }

    internal abstract void is_destroyed(Unit killed_unit);

}
