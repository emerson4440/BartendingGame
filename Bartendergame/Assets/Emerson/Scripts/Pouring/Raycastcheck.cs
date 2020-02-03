using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycastcheck : MonoBehaviour
{
    private float m_DistanceGround;

    public bool m_IsGrounded;

    [SerializeField] float m_RaycastLength = 1f;
    void Start()
    {
        m_DistanceGround = GetComponent<Collider>().bounds.extents.y;
    }

    private void Update()
    {
        
    }

    //private void FixedUpdate()
    //{
    //    Debug.DrawRay(transform.position, -Vector3.up, Color.red, m_RaycastLength);
    //    if (Physics.Raycast (transform.position, -Vector3.up, m_DistanceGround + m_RaycastLength))
    //    {
    //        m_IsGrounded = true;
    //        print("in the air");
    //    }
    //    else
    //    {
    //        m_IsGrounded = false;
    //        print("PENIS");
    //    }
    //}
}
