﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AnimationAngleSelector))]
public class Surfer : MonoBehaviour {

	// Island that the surfer is approaching
	private GameObject island;
	Vector2 island_position;

	// How fast the surfer approaches the island
	public float surf_speed;

	Vector2 end_point;
	float speed;

	float push_speed;

	// Use this for initialization
	void Start () {
        island = GameObject.FindGameObjectWithTag("Island");
        Debug.Assert(island != null, "no island found!", this);
        island_position = island.transform.position;
		end_point = island_position;
		speed = surf_speed;

        var dir = end_point - new Vector2(transform.position.x, transform.position.y);
        GetComponent<AnimationAngleSelector>().SetDirection(dir);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = 
			Vector2.MoveTowards (transform.position, end_point, speed * Time.deltaTime);
	}

	// Pushers/weapons call this to push the surfer away
	public void InitiatePush (Vector2 push_destination, float push_speed) {
		end_point = push_destination;
		speed = push_speed;
	}

	// Pushers/weapons call this to end the push
	public void EndPush () {
		end_point = island_position;
		speed = surf_speed;
	}
}
