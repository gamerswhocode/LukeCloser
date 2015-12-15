using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class DialogBoxBehaviour : MonoBehaviour, IDialogObject{

	public float targetHeight = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.localScale.y != targetHeight) 
		{
			transform.localScale += deltaScale();
		}

	}

	Vector3 deltaScale ()
	{
		Vector3 delta = new Vector3 (transform.localScale.x, targetHeight, transform.localScale.z);
		delta -= transform.localScale;
		return delta.normalized/5;
	}


	#region IDialogObject implementation

	public void DialogStarted (System.Collections.Generic.List<string> dialoges)
	{
		targetHeight = 4f;
	}

	public void DialogEnded ()
	{
		targetHeight = 0f;
	}

	#endregion
}
