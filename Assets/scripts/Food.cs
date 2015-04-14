using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

	public int points = 100;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D (Collider2D c){
		//Get item's layer name
		string layerName = LayerMask.LayerToName (c.gameObject.layer);
		//If the ship did not collide with a player's bullet, ignore it
		if (layerName != "Player") 
			return;
		Debug.Log ("collision with player");
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}