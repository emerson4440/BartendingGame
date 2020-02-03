using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pouring : MonoBehaviour
{
    
    
    [SerializeField] GameObject m_Drink;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Drink.transform.rotation.z >= -110f && m_Drink.transform.rotation.z <= -245)
        {

        }
    }
}
