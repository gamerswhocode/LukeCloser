using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LukeBehaviour : MonoBehaviour {

	public float speed = 2f;
	private List<GameObject> currentPath;
	private GameObject nextTile;
	public bool walking = false;


	// Use this for initialization
	void Start () {
		currentPath = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (walking) 
		{
			Walk ();
		}
	
	}

	void Walk ()
	{
		if (Vector3.Distance (transform.position, nextTile.transform.position) < 0.1) 
		{
			Debug.Log ("Arrived in " + nextTile.name);
			if(nextTile != currentPath.Last())
			{
				nextTile = currentPath[currentPath.IndexOf(nextTile)+1];
				SendMessageUpwards("SetPlayerTile", nextTile);
			}
			else
			{
				SendMessageUpwards("SetPlayerTile", nextTile);
				walking = false;
			}
		}
		transform.Translate (Vector3.Normalize(nextTile.transform.position - transform.position) * speed * Time.deltaTime);
	}

	public void StartWalking(List<GameObject> path)
	{
		Debug.Log ("Will walk from " + path [0].name + " to " + path [path.Count - 1]);

		if(currentPath != null)
			currentPath.Clear ();

		currentPath.AddRange (path);
		walking = true;
		nextTile = currentPath [0];
	}
}
