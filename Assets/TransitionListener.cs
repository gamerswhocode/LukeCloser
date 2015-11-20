using System;
using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class TransitionListener : MonoBehaviour {

	public float targeFarDist = 100f;

	// Use this for initialization
	void Start () {
		DoorMaster.Instance.TransitionStarted += new TransitionStartedHandler (FadeOut);
		DoorMaster.Instance.TransitionEnded += new TransitionEndedHandler (FadeIn);
	}
	
	// Update is called once per frame
	void Update () {
		if (camera.farClipPlane>targeFarDist) 
		{
			camera.farClipPlane -= 3f;
		}
		else if (camera.farClipPlane<targeFarDist) 
		{
			camera.farClipPlane += 3f;
		}
	}

	public void FadeOut(object sender,EventArgs e)
	{
		targeFarDist = 4f;
		Debug.Log("will fade out");
	}
	public void FadeIn(object sender,EventArgs e)
	{
		targeFarDist = 100f;
		Debug.Log("will fade in");
	}
}
