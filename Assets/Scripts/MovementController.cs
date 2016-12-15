using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

	public float run_velocity = 0.5f;

	public bool isGrounded = true;

	public float jumpStrength = 10000f;
	private float jumpBuffer = 0;
	private bool jumpPressed = false;

	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		jumpBuffer = jumpStrength * 0.1f;
		rb = GetComponent<Rigidbody2D> ();
	}


	void FixedUpdate () {
		// TODO(frojo): Not sure if this is the best way to habe a 
		transform.position += Vector3.right * run_velocity;

		if (jumpPressed) {
			jumpPressed = false;
			rb.AddForce (transform.up * jumpStrength);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space") && isGrounded) {
			jumpPressed = true;
			print("Jump!");
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		/* If any of the collisions are on the bottom, we are grounded */
		foreach (ContactPoint2D contact_point in coll.contacts) {
			if (Vector2.Equals (contact_point.normal, Vector2.up)) {
				isGrounded = true;
				print ("Collided from the bottom. Grounded!");
				break;
			}
		}
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		/* If any of the collisions are on the bottom, we are grounded */
		foreach (ContactPoint2D contact_point in coll.contacts) {
			if (Vector2.Equals (contact_point.normal, Vector2.up)) {
				isGrounded = false;
				print ("Lift off! Ungrounded! Normal is:");
				print (contact_point.normal);
				break;
			}
		}
	}
}
