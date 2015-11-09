using UnityEngine;
using System.Collections;

public class TileClick : MonoBehaviour {

	public GameObject sparks;
	private RaycastHit hit;
	private Ray ray;
	private Camera mainCamera;
	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera").camera;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0)) 
		{
			ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)) {
				Transform objectHit = hit.transform;
				if(objectHit.GetComponent<TileBehaviour>() != null)
				{
					SendMessage("StartFlood",objectHit.gameObject);
				}
			}
		}

	}
	
}
