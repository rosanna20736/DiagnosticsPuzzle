using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Controller2 : MonoBehaviour {

	public List<List<int>> ColorAssignments, LightAssignments;
	public List<int> LeverAssignments;

	// Use this for initialization
	void Awake () {
		
		ColorAssignments = MakeColorAssignments ();
		LightAssignments = MakeLightAssignments ();
		LeverAssignments = MakeLeverAssignments ();

	}

	// Update is called once per frame
	void Update () {

	}

	List<List<int>> MakeColorAssignments () {
		int possibleNextAssignment = 0;
		List<List<int>> ColorsArray = new List<List<int>>(8);
		for (int i = 0; i <= 7; i++)
		{
			ColorsArray.Add(new List<int>(9));
			for (int j = 0; j <= 7; j++)
			{
				possibleNextAssignment = Random.Range(1,5);
				while (ColorsArray[i].Count (x => x==possibleNextAssignment)==2) {
					possibleNextAssignment = Random.Range(1,5);
				}
				ColorsArray[i].Add(possibleNextAssignment);
			}

			ColorsArray[i].Add(Random.Range(1,5));
		}
		return ColorsArray;
	}

	List<List<int>> MakeLightAssignments () {
		int possibleNextAssignment = new int();
		List<List<int>> LightsArray = new List<List<int>>(8);
		for (int i = 0; i <= 7; i++)
		{
			LightsArray.Add(new List<int>(5));
			for (int j = 0; j <= 4; j++)
			{
				possibleNextAssignment = Random.Range(0,9);
				while (LightsArray[i].Count (x => x==possibleNextAssignment)==1) {
					possibleNextAssignment = Random.Range(0,9);
				}
				LightsArray[i].Add(possibleNextAssignment);
			}
			LightsArray [i].Sort ();
		}
		return LightsArray;
	}
		
	List<int> MakeLeverAssignments () {
		int possibleNextAssignment = new int();
		List<int> LeverArray = new List<int>(8);
		for (int i = 0; i <= 7; i++)
		{
				possibleNextAssignment = Random.Range(0,8);
				while (LeverArray.Count (x => x==possibleNextAssignment)==1) {
					possibleNextAssignment = Random.Range(0,8);
				}
				LeverArray.Add(possibleNextAssignment);
		}
		return LeverArray;
	}

}