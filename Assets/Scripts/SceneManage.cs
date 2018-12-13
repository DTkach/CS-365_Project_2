using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManage : MonoBehaviour {

    public Texture2D crosshairTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public Vector2 mousePosition;
    public static Vector2 objectPosition;
    public static Vector2 targetPosition;

    public KeyCode launchMissile;
    public Transform playerMissile;
    public Transform lockOnTarget;
    public Transform enemyMissile;

    public static int missilesRemaining=15;

    public float missileSpawnTimer = 0f;
    public int enemySpawnPosition;
    // Use this for initialization
    public static int playerScore;
    public Vector2 city1, city2, city3, city4, city5, city6;
    public Vector2[] targetGrid;

    public GameObject[] cityGrid;
   

    void Start()
    {
        Cursor.SetCursor(crosshairTexture, hotSpot, cursorMode);
        city1 = new Vector2(-7.67f, -4.38f);
        city2 = new Vector2(-5.41f, -4.38f);
        city3 = new Vector2(-2.77f, -4.38f);
        city4 = new Vector2(2.263f, -4.38f);
        city5 = new Vector2(4.8f, -4.38f);
        city6 = new Vector2(7.36f, -4.38f);
        targetGrid[1] = city1;
        targetGrid[2] = city2;
        targetGrid[3] = city3;
        targetGrid[4] = city4;
        targetGrid[5] = city5;
        targetGrid[6] = city6;
    }

    // Update is called once per frame
    void Update()
    {
        enemySpawn();
        mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //transform.position = objectPosition;

        if (Input.GetKeyDown(launchMissile))
        {
            Instantiate(playerMissile, new Vector2(0, -4), playerMissile.rotation);
            Instantiate(lockOnTarget, objectPosition, lockOnTarget.rotation);
        }

    }

    void enemySpawn()
    {
        missileSpawnTimer += Time.deltaTime;

        if (missileSpawnTimer > 2)
        {
            enemySpawnPosition = Random.Range(-7, 7);
            missileSpawnTimer = 0;
            Instantiate(enemyMissile, new Vector2 (enemySpawnPosition, 6), enemyMissile.rotation);
        }

    }
}
