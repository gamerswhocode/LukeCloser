using UnityEngine;
using System.Collections.Generic;
using AssemblyCSharp;
using System;

public class DialogueBehaviour : MonoBehaviour, IObjectInteraction{

	public List<String> dialog;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DialogEndedListener(object sender, List<String> dialogs)
	{
		DialogMaster.Instance.DialogEnded -= new DialogEndedHandler (DialogEndedListener);
	}

	#region IObjectInteraction implementation

	public void OnInteraction (object sender)
	{
		DialogMaster.Instance.StartDialog (gameObject, dialog);
		DialogMaster.Instance.DialogEnded += new DialogEndedHandler (DialogEndedListener);
	}
	#endregion
}
