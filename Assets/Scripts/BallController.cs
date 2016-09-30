using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

    [Tooltip("The max speed the ball will be able to travil through the physics space")]
    public float maxballspeed;
    Rigidbody2D rb;
    
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void FixUpdate () {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxballspeed);
    }
}
