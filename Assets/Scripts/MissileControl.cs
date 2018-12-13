using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControl : MonoBehaviour {

    public float timerCommand = 0;
    public float fractDist = .01f;

    public Transform boomObj;

    // Use this for initialization
    void Start()
    {
        SceneManage.targetPosition = SceneManage.objectPosition;
        GetComponent<Transform>().eulerAngles = new Vector3(0, 0, -15);
    }

    // Update is called once per frame
    void Update()
    {

        timerCommand += Time.deltaTime;
        if (timerCommand > 0.5)
        {
            fractDist += .02f;
            timerCommand = 0;
        }
        transform.position = Vector2.Lerp(transform.position, SceneManage.targetPosition, fractDist);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = (GameObject)collision.gameObject;

        if (gameObject.tag == "enemyMissile" || gameObject.tag == "Crosshair")
        {
            Destroy(this.gameObject);
            Instantiate (boomObj, transform.position, boomObj.rotation);
        }
    }
}
