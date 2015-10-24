using UnityEngine;
using System.Collections;

public class TileBehaviour : MonoBehaviour {

	private GameObject mainCamera;
	public GameObject TileMap;

	public GameObject NorthTile;
	public GameObject WestTile;
	public GameObject SouthTile;
	public GameObject EastTile;
	
	public int floodCount = 0;
	public bool isFlooded = false;
	public bool isEmpty = true;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void EndFlood()
	{
		floodCount = 0;
		isFlooded = false;
	}
}
