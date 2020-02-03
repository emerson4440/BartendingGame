using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slidertest : MonoBehaviour
{

    [SerializeField] Slider m_MainSlider;
    [SerializeField] BoxCollider m_collider;

    private bool m_Canpour;

    private int m_Glasses;
    public Transform[] m_Drinks;

    // Start is called before the first frame update
    void Start()
    {
        m_Canpour = false;
        m_MainSlider.value = 0f;
        m_Glasses = m_Drinks.Length;
    }

    private void Update()
    {
        //if (m_Drinks[m_Glasses].localRotation >= 100f && )
    }

    private void OnTriggerStay(Collider other)
    {

        if(other == m_collider)
        {
            Debug.Log("pour");
            m_MainSlider.value += 0.01f;
        }
    }

}
