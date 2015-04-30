using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class spider : MonoBehaviour {
	private Animator anim;
	private Transform trans;
	private Rigidbody2D body;
	private int timer = 0;
	private bool willRun = true;
	private int direction = -1;

	public int health = 3;
	public float maxSpeed = 10f;
	public int coolDown = 15;
	public int damage = 30;

	public float rotateSpeed = 10f;
	public float moveSensitivity = 0.5f;

	// Use this for initialization
	void Start () {
		//get reference to the animator component
		anim = GetComponent<Animator> ();
		//set the bird moving forward
		body = GetComponent<Rigidbody2D> ();
		trans = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			anim.SetBool ("isDead", true);
		}
		if (willRun) {
			timer += 1;
		    if (body.velocity.magnitude < 0.5) {
				body.velocity = new Vector2 (Random.Range(0f, 1f) * maxSpeed * direction, body.velocity.y);
			}
			if (timer >= coolDown){
				timer = 0;
				willRun = false;
			}
		}
		makeUpright ();
	
	}

	void FixedUpdate(){
		if (body.velocity.magnitude >= moveSensitivity) {
			anim.SetBool ("isMoving", true);
		} else {
			anim.SetBool ("isMoving", false);
		}
	}

	void die() {
		Destroy (gameObject);
	}

	void makeUpright(){

		float z = trans.rotation.z;
		if (z >= 0.5) {
			Debug.Log ("sideways 90 degrees, setting angular velocity");
			body.AddTorque (rotateSpeed);
		}
		else{
			if (z <= -0.5){
					Debug.Log ("sideways the other way, adding tourque");
					body.AddTorque(rotateSpeed * -1);
				}
			}

	}

	//This function controls enemy behavior when the player attacks it.
	void OnTriggerEnter2D(Collider2D other)
	{
		//Get the layer name of the object
		string layerName = LayerMask.LayerToName (other.gameObject.layer);
		if (layerName != "Bullet (Player)") {
			return;
		}
		Debug.Log ("enemy hit");
		health -= 1;
		//...tell the animator about it...
		anim.SetTrigger ("isHit");

		willRun = true;
		direction = 1;
		body.velocity = new Vector2 (Random.Range(0f, 1f) * maxSpeed, body.velocity.y);

	}
}
