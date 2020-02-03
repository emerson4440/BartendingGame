using System.Collections;
using UnityEngine;

public class PourDetector : MonoBehaviour
{
    public int m_PourThreshold = 45;
    public Transform m_Origin = null;
    public GameObject m_StreamPrefab = null;

    private bool m_IsPouring = false;
    private Stream m_CurrentStream = null;

    private void Update()
    {
        bool pourCheck = CalculatePourAngle() < m_PourThreshold;

        if (m_IsPouring != pourCheck)
        {
            m_IsPouring = pourCheck;

            if (m_IsPouring)
            {
                StartPour();
            }
            else
            {
                EndPour();
            }
        }
    }

    private void StartPour()
    {
        print("Start");
        m_CurrentStream = CreateStream();
        m_CurrentStream.Begin();
    }

    private void EndPour()
    {
        print("End");
        m_CurrentStream.End();
        m_CurrentStream = null;
    }

    private float CalculatePourAngle()
    {
        return transform.forward.y * Mathf.Rad2Deg;
    }

    private Stream CreateStream()
    {
        GameObject streamObject = Instantiate(m_StreamPrefab, m_Origin.position, Quaternion.identity, transform);
        return streamObject.GetComponent<Stream>();
    }
}