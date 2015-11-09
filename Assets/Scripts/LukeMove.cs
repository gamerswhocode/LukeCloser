using UnityEngine;
using System.Collections;

public class LukeMove : MonoBehaviour {
	private RaycastHit hit;
	private Ray ray;	
	private Camera mainCamera;
	private NavMeshAgent agent;
	public bool moving = false;
	// Use this for initialization
	void Start () {	
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera").camera;
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonUp(0))
		{
			ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)) {
				Vector3 objectHit = hit.point;
				Debug.Log("Will move i guess");
				agent.SetDestination(objectHit);
			}
		}

		if (agent.velocity.magnitude > 0) 
		{
			if(!moving){
				GetComponent<Animator> ().SetBool ("Moving", true);
				moving = true;
			}
		} 
		else
		{
			if(moving)
			{
				GetComponent<Animator> ().SetBool ("Moving", false);
				moving = false;
			}
		}
	
	}
}
