using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Hand : MonoBehaviour
{
    public SteamVR_Action_Boolean m_GrabAction = null;

    private SteamVR_Behaviour_Pose m_Pose = null;
    private FixedJoint m_Joint = null;

    private Interacteble m_CurrentInteracteble = null;
    public List<Interacteble> m_ContactInteractebles = new List<Interacteble>();

    private void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
        m_Joint = GetComponent<FixedJoint>();
    }

    void Update()
    {
        // Down
        if(m_GrabAction.GetStateDown(m_Pose.inputSource))
        {
            print(m_Pose.inputSource + "Trigger Down");
            Pickup();
        }

        // Up
        if (m_GrabAction.GetStateUp(m_Pose.inputSource))
        {
            print(m_Pose.inputSource + "Trigger Up");
            Drop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
            return;

        m_ContactInteractebles.Add(other.gameObject.GetComponent<Interacteble>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
            return;

        m_ContactInteractebles.Remove(other.gameObject.GetComponent<Interacteble>());
    }

    public void Pickup()
    {
        // Get nearest
        m_CurrentInteracteble = GetNearestInteractable();

        // Null check
        if (!m_CurrentInteracteble)
            return;

        // Already held, check
        if (m_CurrentInteracteble.m_ActiveHand)
            m_CurrentInteracteble.m_ActiveHand.Drop();

        // Position
        m_CurrentInteracteble.transform.position = transform.position;

        // Attach
        Rigidbody targetBody = m_CurrentInteracteble.GetComponent<Rigidbody>();
        m_Joint.connectedBody = targetBody;

        // Set active hand
        m_CurrentInteracteble.m_ActiveHand = this;

    }

    public void Drop()
    {
        // Null check
        if (!m_CurrentInteracteble)
            return;

        // Aply velocity
        Rigidbody targetBody = m_CurrentInteracteble.GetComponent<Rigidbody>();
        targetBody.velocity = m_Pose.GetVelocity();
        targetBody.angularVelocity = m_Pose.GetAngularVelocity();

        // Detach
        m_Joint.connectedBody = null;

        // Clear
        m_CurrentInteracteble.m_ActiveHand = null;
        m_CurrentInteracteble = null;
    }

    private Interacteble GetNearestInteractable()
    {
        Interacteble nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;

        foreach(Interacteble interactable in m_ContactInteractebles)
        {
            distance = (interactable.transform.position - transform.position).sqrMagnitude;

            if(distance < minDistance)
            {
                minDistance = distance;
                nearest = interactable;
            }
        }

        return nearest;
    }
}
