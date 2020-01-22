using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BottleType : ScriptableObject
{
    public string m_Type;
    public float m_Amount;

    private void OnEnable()
    {
        m_Amount = 0f;
    }

    public void EmptyBottle()
    {
        m_Amount = 0f;
    }
}
