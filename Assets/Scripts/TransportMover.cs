using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TransportMover : MonoBehaviour
{
    private List<GameObject> m_transportPoints;
    private Rigidbody2D m_rigidbody;
    private bool m_plotting = false;

    [SerializeField]
    private float m_plotRate;
    private float m_plotCooldown;
    [SerializeField]
    private float m_forceFactor;

    [SerializeField]
    GameObject m_pointer = null;

    void Start ()
    {
        m_transportPoints = new List<GameObject>();
        m_rigidbody = gameObject.GetComponent<Rigidbody2D>();        
    }
	

	void Update ()
    {
        PlotCourse();
        AddMomentum();
    }


    void PlotCourse()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("pressing mouse 0");
            m_plotting = true;
        }
        else
        {
            m_plotting = false;
        }
        if (m_plotting && m_plotCooldown >= m_plotRate)
        {
            m_plotCooldown = 0;

            GameObject point = new GameObject();
            point.transform.position = m_pointer.transform.position;

            m_transportPoints.Add(point);
        }

        m_plotCooldown += Time.deltaTime;
    }

    void AddMomentum()
    {
        if (m_transportPoints.Count > 0)
        {
            Debug.Log("\npointer x: " + Input.mousePosition.x + " and pointer y: " + Input.mousePosition.y);

            Debug.Log("\nprickball x: " + gameObject.transform.position.x + " and y: " + gameObject.transform.position.y);

            m_rigidbody.AddForce((m_transportPoints[0].transform.position - gameObject.transform.position) * m_forceFactor * Time.deltaTime);

            if (m_transportPoints.Count > 1)
            {
                if (Vector3.Distance(m_transportPoints[0].transform.position, this.transform.position) < 1)
                {
                    GameObject toRemove = m_transportPoints[0];
                    m_transportPoints.RemoveAt(0);
                    GameObject.Destroy(toRemove);
                }
            }
        }
    }
}


