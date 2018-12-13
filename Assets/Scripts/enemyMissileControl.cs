using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMissileControl : MonoBehaviour {

    public int enemyTrajectory;
	// Use this for initialization
	void Start () {
        enemyTrajectory = Random.Range(1, 3);

        if (enemyTrajectory == 1)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(2, -2);
        }

        if (enemyTrajectory > 1)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-2, -2);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D missile)
    {
        if (missile.gameObject.name == "boom(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
