using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateTileMap : MonoBehaviour {

	public GameObject Tile;
	public List<List<GameObject>> tileGrid;

	public int xTiles;
	public int yTiles;

	// Use this for initialization
	void Start () {
		tileGrid = new List<List<GameObject>> ();

		for (int x=0; x<xTiles; x++) 
		{
			tileGrid.Add (new List<GameObject>());
			for (int y=0; y<yTiles; y++) 
			{
				GameObject newTile = (GameObject)Instantiate(Tile, new Vector3(x-xTiles/2, 0, y-yTiles/2), new Quaternion());
				newTile.transform.parent = gameObject.transform;								
				newTile.GetComponent<TileBehaviour>().TileMap = gameObject;
				newTile.name = "Tile ["+x+"]["+y+"]";
				tileGrid[x].Add(newTile);

			}
		}

		for (int x=0; x<xTiles; x++) 
		{
			for (int y=0; y<yTiles; y++) 
			{
				if(y>0)
				tileGrid[x][y].GetComponent<TileBehaviour>().WestTile 	= tileGrid[x][y-1]!= null? tileGrid[x][y-1]:null;

				if(x<xTiles-1)
				tileGrid[x][y].GetComponent<TileBehaviour>().SouthTile 	= tileGrid[x+1][y]!= null? tileGrid[x+1][y]:null;

				if(y<yTiles-1)
				tileGrid[x][y].GetComponent<TileBehaviour>().EastTile 	= tileGrid[x][y+1]!= null? tileGrid[x][y+1]:null;

				if(x>0)
				tileGrid[x][y].GetComponent<TileBehaviour>().NorthTile 	= tileGrid[x-1][y]!= null? tileGrid[x-1][y]:null;
			}
		}

		//GetComponent<TileMapBehaviour> ().TileGrid = tileGrid;
		SendMessage ("SpawnPlayer");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
