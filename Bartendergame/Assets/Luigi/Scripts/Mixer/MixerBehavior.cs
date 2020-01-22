using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixerBehavior : MonoBehaviour
{
    private List<BottleType> m_BottleTypes;
    private float m_MaximumFill = 100f;
    private float m_Fill;
    private List<string> m_IngredientList;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MixIngredients();
        }
    }

    public void MixIngredients()
    {
        for (int i = 0; i < m_BottleTypes.Count; i++)
        {
            m_Fill += m_BottleTypes[i].m_Amount;
        }
        foreach (BottleType bottleType in m_BottleTypes)
        {
            bottleType.EmptyBottle();
        }
        m_BottleTypes.Clear();
        //Set The Possile Combinations here
        if (m_IngredientList.Contains("Cola") && m_IngredientList.Contains("Vodka"))
        {
            SetMixedIngredient("VodkaCola");
        }
        if (m_IngredientList.Contains("Whiskey") && m_IngredientList.Contains("Lemon Juice") && m_IngredientList.Contains("Sugar"))
        {
            SetMixedIngredient("Whiskey Sour");
        }
        if (m_IngredientList.Contains("White Rum") && m_IngredientList.Contains("Lime Juice") && m_IngredientList.Contains("Syrop"))
        {
            SetMixedIngredient("Mojito");
        }
        if (m_IngredientList.Contains("Vodka") && m_IngredientList.Contains("Ginger") && m_IngredientList.Contains("Beer") && m_IngredientList.Contains("Lime Juice"))
        {
            SetMixedIngredient("Moscow Mule");
        }
        if (m_IngredientList.Contains("Citrus") && m_IngredientList.Contains("Vodka") && m_IngredientList.Contains("Limme Juice") && m_IngredientList.Contains("Crannberry Juice") && m_IngredientList.Contains("Cointreau"))
        {
            SetMixedIngredient("Cosmopolitan");
        }
        if (m_IngredientList.Contains("Silver Tequila") && m_IngredientList.Contains("Cointreau") && m_IngredientList.Contains("Lime Juice") && m_IngredientList.Contains("Salt"))
        {
            SetMixedIngredient("Margarite");
        }

        m_Fill = 0f;
        m_IngredientList.Clear();
    }

    private void SetMixedIngredient(string mixedIgredient)
    {
        BottleType MixedIngredient = BottleType.CreateInstance<BottleType>();
        m_BottleTypes.Add(MixedIngredient);
        MixedIngredient.name = mixedIgredient;
        MixedIngredient.m_Type = mixedIgredient;
        MixedIngredient.m_Amount = m_Fill;
    }

    private void AddNewIngredient(BottleType bottleType)
    {
        if (m_BottleTypes.Contains(bottleType))
            return;
        m_BottleTypes.Add(bottleType);
        m_IngredientList.Add(bottleType.m_Type);
    }

    private void PourIngredient(BottleType bottleType)
    {
        bottleType.m_Amount += Time.deltaTime * 10f;
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