using UnityEngine;
using System.Collections;

public class LukeMove : MonoBehaviour {
	private RaycastHit hit;
	private Ray ray;	
	private Camera mainCamera;
	private NavMeshAgent agent;
	private bool isMoving = false;
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
				if(hit.transform.gameObject.GetComponent<SceneObject>()!= null)
				{	
					Debug.Log("Found scene object");
					SendMessage("WillInteract",hit.transform.gameObject.GetComponent<SceneObject>());
				}
				Debug.Log("Will move i guess");
				agent.SetDestination(objectHit);
				isMoving = true;
			}
		}

		if (!agent.pathPending && isMoving)
		{
			if (agent.remainingDistance <= agent.stoppingDistance)
			{
				if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
				{
					SendMessage("OnInteracted");
					isMoving = false;
				}
			}
		}	
	}
}
