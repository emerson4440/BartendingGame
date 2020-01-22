using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleBehavior : MonoBehaviour
{
    public BottleType m_BottleType;
    //ProtoType
    public Vector3 m_originalPosition { get; set; }
    public Quaternion m_originalRotation { get; set; }

    private GameObject m_parent;

    private void Start()
    {
        m_BottleType.m_Type = gameObject.name;
        //ProtoType
        m_originalPosition = gameObject.transform.position;
        m_originalRotation = gameObject.transform.rotation;
    }
}
