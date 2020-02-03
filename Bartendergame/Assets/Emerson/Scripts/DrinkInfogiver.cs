using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DrinkInfogiver : MonoBehaviour
{
    public ListDrinks m_listDrinks;

    public GameObject m_DrinkUI;
    public Text m_NameDrink;
    public Text m_MakingText;
    public Text m_FlavorText;
    public Text m_Money;

    public void OpenQuestWindow()
    {
        m_DrinkUI.SetActive(true);
        m_NameDrink.text = m_listDrinks.m_Title;
        m_MakingText.text = m_listDrinks.m_MakingText;
        m_FlavorText.text = m_listDrinks.m_FlavorText;
        m_Money.text = m_listDrinks.m_Reward.ToString();
    }
}
