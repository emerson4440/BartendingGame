using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stream : MonoBehaviour
{
    private LineRenderer m_LineRenderer = null;
    private ParticleSystem m_SplashParticle = null;

    private Coroutine m_PourRoutine = null;
    private Vector3 m_targetPosition = Vector3.zero;

    private void Awake()
    {
        m_LineRenderer = GetComponent<LineRenderer>();
        m_SplashParticle = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        MoveToPosition(0, transform.position);
        MoveToPosition(1, transform.position);
    }

    public void Begin()
    {
        StartCoroutine(UpdateParticle());
        m_PourRoutine = StartCoroutine(BeginPour());
    }

    private IEnumerator BeginPour()
    {
        while (gameObject.activeSelf)
        {
            m_targetPosition = FindEndPoint();

            MoveToPosition(0, transform.position);
            MoveToPosition(1, m_targetPosition);

            yield return null;
        }        
    }

    public void End()
    {
        StopCoroutine(m_PourRoutine);
        m_PourRoutine = StartCoroutine(EndPour());
    }

    private IEnumerator EndPour()
    {
        while (!HasReachedPosition(0, m_targetPosition))
        {
            AnimateToPosition(0, m_targetPosition);
            AnimateToPosition(1, m_targetPosition);

            yield return null;
        }
        Destroy(gameObject);
    }

    private Vector3 FindEndPoint()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);

        Physics.Raycast(ray, out hit, 2.0f);
        Vector3 endPoint = hit.collider ? hit.point : ray.GetPoint(2.0f);

        return endPoint;
    }

    private void MoveToPosition(int index, Vector3 targetPosition)
    {
        m_LineRenderer.SetPosition(index, targetPosition);
    }

    private void AnimateToPosition(int index, Vector3 targetPosition)
    {
        Vector3 currentPoint = m_LineRenderer.GetPosition(index);
        Vector3 newPosition = Vector3.MoveTowards(currentPoint, targetPosition, Time.deltaTime * 1.75f);
        m_LineRenderer.SetPosition(index, newPosition);
    }

    private bool HasReachedPosition(int index, Vector3 targetPosition)
    {
        Vector3 currentPosition = m_LineRenderer.GetPosition(index);
        return currentPosition == targetPosition;
    }

    private IEnumerator UpdateParticle()
    {
        while (gameObject.activeSelf)
        {
            m_SplashParticle.gameObject.transform.position = m_targetPosition;

            bool isHitting = HasReachedPosition(1, m_targetPosition);
            m_SplashParticle.gameObject.SetActive(isHitting);

            yield return null;
        }
    }
}