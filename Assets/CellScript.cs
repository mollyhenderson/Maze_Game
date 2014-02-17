using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CellScript : MonoBehaviour {
	
	public List<Transform> Adjacents;
	public Vector3 Position;
	public int Weight;
	public int AdjacentsOpened = 0;
}
