using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System;

public class DoorBehaviour : MonoBehaviour, IObjectInteraction {

	public GameObject otherSide;
	public Transform standPoint;
	private GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void WarpPlayer(object sender, EventArgs e)
	{
			player.GetComponent<NavMeshAgent> ().Warp (otherSide.GetComponent<DoorBehaviour>().standPoint.position);
			DoorMaster.Instance.EndTransition();
	}

	#region IObjectInteraction implementation


	public void OnInteraction (object sender)
	{
		player = sender as GameObject;
		DoorMaster.Instance.TransitionGoing += new TransitionGoingHandler (WarpPlayer);
		DoorMaster.Instance.StartTransition();
	}

	#endregion
}
