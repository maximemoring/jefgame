using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expidition : MonoBehaviour {
    List<Habitant> expeditionists;
    short leaderID; // Relates to the ID in the List

	// Use this for initialization
	void Start (Habitant[] selectedExpeditionists, short selectedLeaderID) {
        expeditionists = new List<Habitant>(selectedExpeditionists);
        leaderID = selectedLeaderID;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
