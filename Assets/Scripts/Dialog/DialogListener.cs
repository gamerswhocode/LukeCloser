using UnityEngine;
using System.Collections.Generic;
using AssemblyCSharp;
using System;

public class DialogListener : MonoBehaviour {


	// Use this for initialization
	void Start () 
	{
		DialogMaster.Instance.DialogStarted += new DialogStartedHandler (DialogStartedListener);
		DialogMaster.Instance.DialogEnded += new DialogEndedHandler (DialogEndedListener);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void DialogStartedListener(object sender, List<String> e)
	{
		SendMessage ("DialogStarted", e);
	}

	void DialogEndedListener(object sender, List<String> e)
	{
		SendMessage ("DialogEnded");
	}
}
