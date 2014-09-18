using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	    rigidbody.AddForce(new Vector3(Input.acceleration.x, Input.acceleration.y,0 ));
	}
}
