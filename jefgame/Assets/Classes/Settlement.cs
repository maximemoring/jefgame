using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settlement : MonoBehaviour {
    List<Habitant> habitants;

	// Use this for initialization
	void Start() {
        habitants = new List<Habitant>();
	}
	
	// Update is called once per frame
	void Update() {
		
	}

    public void addHabitant() {
        habitants.Add(new Habitant());
    }

    public void addHabitant(Habitant theHabitant) {
        habitants.Add(theHabitant);
    }

    public void removeHabitant(int id) {
        habitants.RemoveAt(id);
    }
}
