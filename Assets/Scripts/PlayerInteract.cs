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
		sceneObject.PrepareForInteraction (this);
		isExpectingInteraction = true;
	}

	public void OnInteracted()
	{
		if(isExpectingInteraction)
		{
			Interacted (gameObject, null);
			isExpectingInteraction = false;
		}
	}

	public void OnChangedPath()
	{
		ChangedPath (this, null);
	}

	public event InteractionHandler Interacted;
	public event ChangedPathHandler ChangedPath;
}
