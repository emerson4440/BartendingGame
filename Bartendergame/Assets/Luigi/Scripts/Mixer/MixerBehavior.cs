using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixerBehavior : MonoBehaviour
{
    public float m_CurrentFill;
    
    [SerializeField] private List<BottleType> m_BottleTypes;

    private float m_MaximumFill = 100f;
    private float m_Fill;

    public bool m_Vodka = false;
    public bool m_Cola = false;
    public bool m_Bier = false;

    private void Start()
    {
        m_CurrentFill = 0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MixIngredients();
        }

        //FillIgredient();
    }

    private void FillIgredient()
    {
        Debug.Log(m_BottleTypes.Count);

        foreach (var Amount in m_BottleTypes)
        {
            Debug.Log(Amount.m_Amount);
        }

        //m_CurrentFill
    }

    public void MixIngredients()
    {
        Debug.Log("Pressig space");

        foreach (BottleType bottleType in m_BottleTypes)
        {
            if (bottleType.m_Type == "Vodka")
            {
                m_Vodka = true;
            }
            if (bottleType.m_Type == "Cola")
            {
                m_Cola = true;
            }
            if (bottleType.m_Type == "Bier")
            {
                m_Bier = true;
            }
            if (m_Vodka && m_Cola)
            {
                Debug.Log("You made vodkaCola");
                RemoveIngredients();
            }
            bottleType.EmptyBottle();            
        }
    }

    private void RemoveIngredients()
    {
        m_Vodka = false;
        m_Cola = false;
        m_Bier = false;
    }

    private void AddNewIngredient(BottleType bottleType)
    {
        if (m_BottleTypes.Contains(bottleType))
            return;
            m_BottleTypes.Add(bottleType);
    }

    private void PourIngredient(BottleType bottleType)
    {
        bottleType.m_Amount += Time.deltaTime * 10f;

        for (int i = 0; i < m_BottleTypes.Count; i++)
        {
            //Debug.Log(m_BottleTypes[i].m_Type + ": " + m_BottleTypes[i].m_Amount);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        PourIngredient(other.GetComponent<BottleBehavior>().m_BottleType);
    }

    private void OnTriggerEnter(Collider other)
    {
        AddNewIngredient(other.GetComponent<BottleBehavior>().m_BottleType);
    }
}
