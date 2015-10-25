using UnityEngine;
using System.Collections;

public class LukeMove : MonoBehaviour {
	private RaycastHit hit;
	private Ray ray;	
	private Camera mainCamera;
	// Use this for initialization
	void Start () {	
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera").camera;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonUp(0))
		{
			ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)) {
				Vector3 objectHit = hit.point;
				Debug.Log("Will move i guess");
				GetComponent<NavMeshAgent>().SetDestination(objectHit);

			}
		}
	
	}
}
