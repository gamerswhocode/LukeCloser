using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TileMapBehaviour : MonoBehaviour {
	private List<GameObject> nextFloodLevel;
	private List<GameObject> oldFloodLevel;
	public List<List<GameObject>> TileGrid;
	public GameObject PlayerTile;
	public GameObject TargetTile;
	public List<GameObject> Path;
	public bool floodEnded = false;
	public bool pathFound = false;
	public LukeBehaviour Luke;

	// Use this for initialization
	void Start () {
		nextFloodLevel = new List<GameObject>();
		oldFloodLevel = new List<GameObject>();
		Path = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetPlayerTile(GameObject tile)
	{
		PlayerTile = tile;
		Debug.Log ("Tile is now " + PlayerTile.name);
	}

	void SpawnPlayer()
	{		
		TileGrid = GetComponent<CreateTileMap> ().tileGrid;
		Luke = GameObject.FindGameObjectWithTag ("Player").GetComponent<LukeBehaviour>();
		try
		{
			Luke.transform.position = TileGrid [0] [0].transform.position;
			PlayerTile = TileGrid[0][0];
		}
		catch(UnityException u)
		{
			Debug.LogException(u);
		}
	}

	void StartFlood(GameObject target)
	{
		Path.Clear ();
		nextFloodLevel.Clear ();
		oldFloodLevel.Clear ();

		TargetTile = target;
		Debug.Log("Began flood at "+target.name);
		target.GetComponent<TileBehaviour> ().isFlooded = true;
		oldFloodLevel.Add(target);
		int step = 0;
		while (!floodEnded && PlayerTile != null) 
		{
			Debug.Log("On step " + step);
			foreach(GameObject g in oldFloodLevel)
			{
				TileBehaviour tile = g.GetComponent<TileBehaviour>();
				tile.floodCount = step;
				tile.isFlooded = true;
				if(g == PlayerTile)
				{
					floodEnded = true;
				}
				else
				{
					if(tile.NorthTile != null 
					   && tile.NorthTile.GetComponent<TileBehaviour>().isEmpty 
					   && !tile.NorthTile.GetComponent<TileBehaviour>().isFlooded)
					{
						nextFloodLevel.Add(tile.NorthTile);
					}
					if(tile.EastTile != null 
					   && tile.EastTile.GetComponent<TileBehaviour>().isEmpty 
					   && !tile.EastTile.GetComponent<TileBehaviour>().isFlooded)
					{
						nextFloodLevel.Add(tile.EastTile);
					}
					if(tile.SouthTile != null 
					   && tile.SouthTile.GetComponent<TileBehaviour>().isEmpty 
					   && !tile.SouthTile.GetComponent<TileBehaviour>().isFlooded)
					{
						nextFloodLevel.Add(tile.SouthTile);
					}
					if(tile.WestTile != null 
					   && tile.WestTile.GetComponent<TileBehaviour>().isEmpty 
					   && !tile.WestTile.GetComponent<TileBehaviour>().isFlooded)
					{
						nextFloodLevel.Add(tile.WestTile);
					}
				}

			}
			step++;
			oldFloodLevel.Clear();
			oldFloodLevel.AddRange(nextFloodLevel);
			nextFloodLevel.Clear();
		}
		floodEnded = false;
		Debug.Log("Flood ended");
		FindPath ();
	}

	void FindPath()
	{
		Debug.Log("Finding path");
		Path.Add (PlayerTile);
		GameObject lastTile;
		GameObject nextTile;
		TileBehaviour tb;
		int lowestStep = PlayerTile.GetComponent<TileBehaviour> ().floodCount;
		nextTile = PlayerTile;
		int x = 0;
		while (!pathFound) 
		{
			lastTile = Path[Path.Count-1];
			tb = lastTile.GetComponent<TileBehaviour>();


			if(tb.NorthTile != null 
			   && tb.NorthTile.GetComponent<TileBehaviour>().isFlooded
			   && tb.NorthTile.GetComponent<TileBehaviour>().floodCount < lowestStep)
			{
				nextTile = tb.NorthTile;
				lowestStep = tb.NorthTile.GetComponent<TileBehaviour>().floodCount;
				Debug.Log("Chose North");
			}
			if(tb.EastTile != null 
			   && tb.EastTile.GetComponent<TileBehaviour>().isFlooded
			   && tb.EastTile.GetComponent<TileBehaviour>().floodCount < lowestStep)
			{
				nextTile = tb.EastTile;
				lowestStep = tb.EastTile.GetComponent<TileBehaviour>().floodCount;
				Debug.Log("Chose East");
			}
			if(tb.SouthTile != null 
			   && tb.SouthTile.GetComponent<TileBehaviour>().isFlooded
			   && tb.SouthTile.GetComponent<TileBehaviour>().floodCount < lowestStep)
			{
				nextTile = tb.SouthTile;
				lowestStep = tb.SouthTile.GetComponent<TileBehaviour>().floodCount;
				Debug.Log("Chose South");
			}
			if(tb.WestTile != null 
			   && tb.WestTile.GetComponent<TileBehaviour>().isFlooded
			   && tb.WestTile.GetComponent<TileBehaviour>().floodCount < lowestStep)
			{
				nextTile = tb.WestTile;
				lowestStep = tb.WestTile.GetComponent<TileBehaviour>().floodCount;
				Debug.Log("Chose West");
			}

			Path.Add(nextTile);
			Debug.Log("Added " + nextTile.name);
			x++;
			Debug.Log ("Counted " + x + "times");

			if(nextTile == TargetTile || x>100)
			{
				pathFound = true;
			}
		}
		Debug.Log("Path found");
		pathFound = false;

		BroadcastMessage ("EndFlood");
		Luke.StartWalking (Path);
	}


}
