using System;
using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class TransitionListener : MonoBehaviour {

	public float targeFarDist = 60f;
	private bool transited = false;

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
		else{
			if(transited)
			{
				DoorMaster.Instance.GoTransition();		
				transited = false;
			}
		}
	}

	public void FadeOut(object sender,EventArgs e)
	{
		targeFarDist = 3f;
		transited = true;
	}
	public void FadeIn(object sender,EventArgs e)
	{
		targeFarDist = 60f;
	}
}
