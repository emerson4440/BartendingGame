using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleBehavior : MonoBehaviour
{
    public BottleType m_BottleType;

    private GameObject m_parent;

    private void Start()
    {
        m_BottleType.m_Type = gameObject.name;
    }
}
