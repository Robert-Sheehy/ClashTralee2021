using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public GameObject character_prefab_template;
    public GameObject townhall_template;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) Instantiate(character_prefab_template,
                           new Vector3(Random.Range(-10f,10f),0, Random.Range(-10f, 10f)), Quaternion.identity);

        if (Input.GetKeyDown(KeyCode.T)) Instantiate(townhall_template,
                           new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f)), Quaternion.identity);
    }
}
