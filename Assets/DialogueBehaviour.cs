using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class DialogueBehaviour : MonoBehaviour, IObjectInteraction{

	public string dialogue;

	// Use this for initialization
	void Start () {
		dialogue = "Hey luke!";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	#region IObjectInteraction implementation

	public void OnInteraction (object sender)
	{
		throw new System.NotImplementedException ();
	}

	#endregion
}
