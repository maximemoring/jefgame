using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habitant : MonoBehaviour {
    private int maxHealth = 10;
    private int currentHealth = 10;
    private short illness = 0;

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
        if (currentHealth <= 0) Object.Destroy(this);
	}

    void loseHealth(int amount) {
        currentHealth -= amount;
    }

    void gainHealth(int amount) {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }
}
