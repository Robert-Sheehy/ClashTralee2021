using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : MonoBehaviour, IHealth
{
    enum Character_states { Idle, Move_to_Target, Attack, Death }
    int DPS = 100;
    float attack_time_interval = 0.7f;
    float attack_timer;
    /*float spawn_timer;
    float spawn_timer_interval = 6f;*/
    Character_states my_state = Character_states.Idle;
    private int MHP = 300, CHP = 300, level=0;
    Building current_target;
    Vector3 velocity;
    private float character_speed = 12f;
    public float attack_distance { get { return 12.0f; } }
    private Manager theManager;
    bool dead;
    
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        switch (my_state)
        {
            case Character_states.Idle:
                if (current_target)
                {
                    my_state = Character_states.Move_to_Target;
                }
                else
                {
                    current_target = theManager.whats_my_target(this);
                    if (current_target != null)
                    {
                        Vector3 from_me_to_target = current_target.transform.position - transform.position;
                        velocity = character_speed * from_me_to_target.normalized;
                        transform.LookAt(current_target.transform);
                        my_state = Character_states.Move_to_Target;
                    }
                }

                break;

            case Character_states.Move_to_Target:
                if (current_target != null)
                    if (within_attack_range(current_target))
                    {
                        my_state = Character_states.Attack;
                        attack_timer = 0;
                        velocity = Vector3.zero;
                    }
                    else
                    {
                        my_state = Character_states.Idle;
                    }

                transform.position += velocity * Time.deltaTime;
                break;

            case Character_states.Attack:

                if (current_target)
                    if (attack_timer <= 0f)
                    {
                        current_target.takeDamage((int)((float)DPS * attack_time_interval));
                        attack_timer = attack_time_interval;
                    }

                    else
                        my_state = Character_states.Idle;

                attack_timer -= Time.deltaTime;

                break;


            case Character_states.Death:
                if (dead == true)
                {
                    Destroy(gameObject);
                }

                break;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            current_target = FindObjectOfType<Building>();
            if (current_target)
            {
                assign_target(current_target);

            }
        }
    }

    public void assign_target(Building current_target)
    {
        if ((my_state == Character_states.Idle) || (my_state == Character_states.Move_to_Target))
        {
            Vector3 from_me_to_building = current_target.transform.position - transform.position;
            Vector3 direction = from_me_to_building.normalized;
            velocity = direction * character_speed;
            my_state = Character_states.Move_to_Target;
        }
    }

    internal void is_destroyed(Building building)
    {
        if (current_target == building)
            my_state = Character_states.Idle;
    }

    internal void ImtheMan(Manager manager)
    {
        theManager = manager;
    }
    private bool within_attack_range(Building current_target)
    {
        return (Vector3.Distance(transform.position, current_target.transform.position) < current_target.attack_distance);
    }

    public void takeDamage(int how_much_damage)
    {
        Debug.Log("Im being damaged");
        CHP -= how_much_damage;
        if (CHP <= 0)
        {
            dead= true;
            Debug.Log("Dead");
        }
    }
    public void repair(int v)
    {
        throw new NotImplementedException();
    }

    internal void levelUp()
    { 
        level++;
        MHP += 40;
        DPS += 20;
    }
}
