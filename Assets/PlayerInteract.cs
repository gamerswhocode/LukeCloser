using UnityEngine;
using System.Collections;

public class PlayerInteract : MonoBehaviour {

	private bool isExpectingInteraction = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void WillInteract(SceneObject sceneObject)
	{
		
		Debug.Log("preparing for interaction");
		sceneObject.PrepareForInteraction (this);
		isExpectingInteraction = true;
	}

	public void OnInteracted()
	{
		if(isExpectingInteraction)
		{
			Interacted (this, null);
			isExpectingInteraction = false;
		}
	}

	public event InteractionHandler Interacted;
}
