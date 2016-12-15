using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/** This maintains the state of the world.
 *  Currently used to autogenerate endless world to run
 */
public class WorldGenerator : MonoBehaviour {

	public GameObject main_character;
	public GameObject ground;
	public GameObject background_wall;

	public GameObject world_tile;

	// TODO(frojo): Probably don't need this and next_world_tile_pos. but maybe keep for clarity
	/** Starting position for generation world */
	public Vector2 start_pos;

	/** Number of starting world tiles */
	public int num_starting_world_tiles;

	/** Size of step for tiling with the runner world tiles */
	public float world_tile_step_size;
	public Vector2 next_world_tile_pos;

	// TODO(frojo): Should probably write this thing its own class
	/** Stores the currently instantiated world tiles */
	private LinkedList<GameObject> world_tiles_buffer;
	private GameObject refresh_trigger_tile;

	/** Extends world by one tile 
	 *  is_refresh_trigger: Whether or not new tile should be a trigger
	 *  for a refresh of the world
	 */
	private void ExtendWorldTiles(bool is_refresh_trigger) {
		// TODO(frojo): Well what do I do here then?
//		if (!world_tiles_buffer) {
//			print ("Error! Called RefreshWorldTiles() before initing world_tiles_buffer");
//			return;
//		}
//
		print ("Instantiating world tile at " + next_world_tile_pos);
		GameObject new_world_tile = 
			(GameObject) Instantiate (world_tile, next_world_tile_pos, Quaternion.identity);
		if (is_refresh_trigger) {
			refresh_trigger_tile = new_world_tile;
		}

		world_tiles_buffer.AddFirst(new_world_tile);
		next_world_tile_pos.Set (
			next_world_tile_pos.x + world_tile_step_size, 
			next_world_tile_pos.y);
	}

	// TODO(frojo): Either refactor this into WorldTileBuffer class, or delete it. Maybe?
	/** Appends a world tile to the world tile buffer */
	private void AppendWorldTile(GameObject world_tile) {
		// TODO(frojo): Well what do I do here then?
		//		if (!world_tiles_buffer) {
		//			print ("Error! Called RefreshWorldTiles() before initing world_tiles_buffer");
		//			return;
		//		}
		//
		world_tiles_buffer.AddFirst(world_tile);
	}

	/** Cleans up world by one tile */
	private void RemoveWorldTiles() {
		// TODO(frojo): Well what do I do here then?
		//		if (!world_tiles_buffer) {
		//			print ("Error! Called RefreshWorldTiles() before initing world_tiles_buffer");
		//			return;
		//		}
		//

		GameObject oldest_world_tile = world_tiles_buffer.Last.Value;
		print ("Removing world tile at " + oldest_world_tile.transform.position.x);
		Destroy (oldest_world_tile);
		world_tiles_buffer.RemoveLast ();
	}

	private void CycleWorldTileBuffer(bool is_refresh_trigger) {
		ExtendWorldTiles (is_refresh_trigger);
		RemoveWorldTiles ();
	}

	private void InitializeWorld () {
		// Initialize a wall and platform prefab and copy it a couple of times
		// Assume we start at (0,0)

		world_tiles_buffer = new LinkedList<GameObject> ();

		world_tile_step_size = 
			world_tile.GetComponent<WorldTile> ().ComputeandGetStepSize ();
		// Create world tile at (0,0). Tile it a few times (we can do 3 to start)

		next_world_tile_pos.Set (start_pos.x, start_pos.y);

		// TODO(frojo): Probably pull this out into a "Tiler" class or something
		for (int i = 0; i < num_starting_world_tiles; i++) {
			if (i == num_starting_world_tiles / 2) {
				ExtendWorldTiles (true);
			} else {
				ExtendWorldTiles (false);
			}
		}
			
		// Starting at (0, 0), for 3 times
		// Create platform right under runner

	}

	// Use this for initialization
	void Start () {
		InitializeWorld ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}