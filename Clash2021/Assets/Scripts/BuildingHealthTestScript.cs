using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHealthTestScript : MonoBehaviour
{

    Building ourBuilding;
    // Start is called before the first frame update
    void Start()
    {
        ourBuilding = FindObjectOfType<Building>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.getKeyDown(KeyCode.D)) ourBuilding.takeDamage(70);
        if (Input.getKeyDown("H")) ourBuilding.repair(100);
    }
}
