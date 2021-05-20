using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disarmField : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spear_1;
    public GameObject spear_2;
    public GameObject spear_3;
    public GameObject spear_4;
    public GameObject spear_5;
    public GameObject spear_6;
    public GameObject spear_7;
    public GameObject spear_8;
    public GameObject spear_9;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void disarmTrap(){
        spear_1.GetComponent<spearRelease>().disarmTrap();
        spear_2.GetComponent<spearRelease>().disarmTrap();
        spear_3.GetComponent<spearRelease>().disarmTrap();
        spear_4.GetComponent<spearRelease>().disarmTrap();
        spear_5.GetComponent<spearRelease>().disarmTrap();
        spear_6.GetComponent<spearRelease>().disarmTrap();
        spear_7.GetComponent<spearRelease>().disarmTrap();
        spear_8.GetComponent<spearRelease>().disarmTrap();
        spear_9.GetComponent<spearRelease>().disarmTrap();
    }
    public void armTrap(){
        spear_1.GetComponent<spearRelease>().armTrap();
        spear_2.GetComponent<spearRelease>().armTrap();
        spear_3.GetComponent<spearRelease>().armTrap();
        spear_4.GetComponent<spearRelease>().armTrap();
        spear_5.GetComponent<spearRelease>().armTrap();
        spear_6.GetComponent<spearRelease>().armTrap();
        spear_7.GetComponent<spearRelease>().armTrap();
        spear_8.GetComponent<spearRelease>().armTrap();
        spear_9.GetComponent<spearRelease>().armTrap();
    }
}
