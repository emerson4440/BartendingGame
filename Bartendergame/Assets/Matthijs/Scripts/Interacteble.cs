using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Interacteble : MonoBehaviour
{
    [HideInInspector]
    public Hand m_ActiveHand = null;
}
