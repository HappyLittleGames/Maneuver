using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TransportMover : MonoBehaviour
{
    private List<GameObject> m_transportPoints;
    private Rigidbody2D m_rigidbody;
    private bool m_plotting = true;

    [SerializeField]
    private float m_plotRate;
    private float m_plotCooldown;
    [SerializeField]
    private float m_forceFactor;


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
        if (m_plotting && m_plotCooldown >= m_plotRate)
        {
            m_plotCooldown = 0;

            GameObject point = new GameObject();
            point.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.x, 0);
            

            m_transportPoints.Add(point);
        }
        m_plotCooldown += Time.deltaTime;
    }

    void AddMomentum()
    {
        if (m_transportPoints.Count > 0)
        {
            m_rigidbody.AddForce((gameObject.transform.position - m_transportPoints[0].transform.position) * m_forceFactor * Time.deltaTime);
        }
    }
}


