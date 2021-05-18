using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disarm : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Spearfield_1;
    public GameObject Spearfield_2;
    public GameObject Spearfield_3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void disarmTrap(){
        Spearfield_1.GetComponent<disarmField>().disarmTrap();
        Spearfield_2.GetComponent<disarmField>().disarmTrap();
        Spearfield_3.GetComponent<disarmField>().disarmTrap();
    }
    public void armTrap(){
        Spearfield_1.GetComponent<disarmField>().armTrap();
        Spearfield_2.GetComponent<disarmField>().armTrap();
        Spearfield_3.GetComponent<disarmField>().armTrap();
    }
}
