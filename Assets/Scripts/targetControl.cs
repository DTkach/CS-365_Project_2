using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = (GameObject)collision.gameObject;

        if (gameObject.tag == "Missile")
        {
            Destroy(this.gameObject);
        }
    }
}
