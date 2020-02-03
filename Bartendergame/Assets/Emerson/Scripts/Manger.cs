using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manger : MonoBehaviour
{
    public GameObject m_Ball;
    public float m_radius;
    public float m_Mass;
    public float m_RestDensity;
    public float m_Viscosity;
    public float m_Drag;

    public bool m_Wallsup;
    public int m_Amount;
    public int m_PerRow;
    public List<GameObject> m_Walls = new List<GameObject>();

    private float m_Smoothingradius = 1.0f;
    private Vector3 m_Gravity = new Vector3(0.0f, -9.81f, 0.0f);
    private float m_GravirtMultiplicator = 2000.0f;
    private float m_Gas = 2000.0f;
    private float m_DeltaTime = 0.0008f;
    private float m_Damping = -0.5f;

    private Particle[] m_Particles;
    private ParticleCollider[] m_Colliders;
    private bool m_Clearing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
