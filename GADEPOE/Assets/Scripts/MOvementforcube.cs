using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOvementforcube : MonoBehaviour {
    
    public float turnrate;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        

        transform.Rotate(Vector3.up, turnrate * Time.deltaTime);
    }
}
