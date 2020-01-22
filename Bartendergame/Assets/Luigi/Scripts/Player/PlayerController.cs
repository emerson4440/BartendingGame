using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float m_Range = 2500f;
    private Camera m_Camera;

    [SerializeField] private GameObject m_Hand;
    [SerializeField] private GameObject m_AttachedObject;

    private void Start()
    {
        m_Camera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootRay();
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (m_AttachedObject == null)
                return;
                DetachFromHand(m_AttachedObject);  
        }
    }

    private void ShootRay()
    {
        RaycastHit hit;

        if (Physics.Raycast(m_Camera.transform.position, m_Camera.ScreenPointToRay(Input.mousePosition).direction, out hit, m_Range))
        {
            if (!hit.transform.GetComponent<BottleBehavior>())
                return;
            AttachToHand(hit.transform.gameObject);
        }       
    }

    private void AttachToHand(GameObject gameObjectToAttach)
    {
        gameObjectToAttach.transform.position = m_Hand.transform.position;
        gameObjectToAttach.transform.rotation = m_Hand.transform.rotation;

        m_AttachedObject = gameObjectToAttach;
        gameObjectToAttach.transform.SetParent(m_Hand.transform);
    }

    private void DetachFromHand(GameObject gameObjectToDetach)
    {
        gameObjectToDetach.transform.SetParent(null);
        m_AttachedObject = null;       
    }
}
