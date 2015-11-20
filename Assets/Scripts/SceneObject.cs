using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class SceneObject : MonoBehaviour {

	private PlayerInteract playerInteract;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PrepareForInteraction(PlayerInteract player)
	{
		playerInteract = player;
		playerInteract.Interacted += new InteractionHandler (Interact);		
		playerInteract.ChangedPath += new ChangedPathHandler (CancelInteraction);
		DoorMaster.Instance.StartTransition ();
		Debug.Log (gameObject.name + " subscribed to interaction!");
	}

	public void Interact(object sender,System.EventArgs e)
	{
		SendMessage("OnInteraction",e as object);
		Debug.Log (gameObject.name + " interacted!");
		DoorMaster.Instance.EndTransition ();
		playerInteract.Interacted -= new InteractionHandler (Interact);
	}

	public void CancelInteraction(object sender, System.EventArgs e)
	{
		playerInteract.Interacted -= new InteractionHandler (Interact);			
		playerInteract.ChangedPath -= new ChangedPathHandler (CancelInteraction);
		DoorMaster.Instance.EndTransition ();
		Debug.Log (gameObject.name + " unsubscribed to interaction!");
	}
}
