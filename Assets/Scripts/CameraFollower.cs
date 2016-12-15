using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {

	public GameObject followee;
	public float zoom_distance = 10f;
	public float vertical_offset = 20f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		// VERY simple/naive following algo (just lock on to the followee)
		transform.position = followee.transform.position + Vector3.back * zoom_distance +
			Vector3.up * vertical_offset;


	}
}
