using UnityEngine;
using System.Collections;

public class Prick : MonoBehaviour {

    private MeshCollider m_collider;

    void Start ()
    {
        m_collider = GetComponent<MeshCollider>();
	}
	
	void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "PrickBall")
        {
            Destroy(gameObject);
        }
    }

}
