using UnityEngine;
using System.Collections;

public class TrackMouse : MonoBehaviour
{
	

	void Update ()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
	}
}
