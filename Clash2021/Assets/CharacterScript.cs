using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour,IHealth
{

    private int MHP = 1000, CHP = 1000, _level = 0;
    Building current_target;

    Vector3 velocity;
    private float character_speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            current_target = FindObjectOfType<Building>();
            if (current_target)
            {
                Vector3 from_me_to_building = current_target.transform.position - transform.position;
                Vector3 direction = from_me_to_building.normalized;
                velocity = direction * character_speed;

            }


            if (Input.GetKeyDown(KeyCode.DownArrow)) velocity = Vector3.down;
            if (Input.GetKeyDown(KeyCode.LeftArrow)) velocity = Vector3.left;
            if (Input.GetKeyDown(KeyCode.RightArrow)) velocity = Vector3.right;
            if (Input.GetKeyDown(KeyCode.UpArrow)) velocity = Vector3.up;
        }
    }




    public void repair(int v)
    {
        throw new System.NotImplementedException();
    }

    public void takeDamage(int v)
    {
        throw new System.NotImplementedException();
    }
}
