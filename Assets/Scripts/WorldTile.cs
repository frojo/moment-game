using UnityEngine;
using System.Collections;

// TODO(frojo): This would probably be cleaner as just a Tile class I think
/** Holds info for the tile used to build endless runner world */
public class WorldTile : MonoBehaviour {

	public GameObject background_wall;
	public GameObject world_maintainer;

	public bool is_refresh_tile;

	/** Step size for tiling */
	public float step_size {
		get;
		private set;
	}

	public float ComputeandGetStepSize() {
		return background_wall.GetComponent<Renderer> ().bounds.size.x;
	}


	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player" && is_refresh_tile) {
			// Call for a refresh of the tiles
		}

	}

	// Use this for initialization
	void Start () {
		step_size = background_wall.GetComponent<Renderer> ().bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
