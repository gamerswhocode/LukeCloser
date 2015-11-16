using UnityEngine;
using System.Collections;

public class PlayerAnimationBehaviour : MonoBehaviour {

	private NavMeshAgent agent;
	private bool moving = false;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
