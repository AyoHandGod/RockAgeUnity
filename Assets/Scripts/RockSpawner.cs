using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour {

    #region Fields
    [SerializeField]
    GameObject prefabRock;

    GameObject[] rocksInScene;

    [SerializeField]
    Sprite[] sprites;
    Timer spawnTime;

    // Screen size settings
    int SpawnBorderSize = 100;
    int minSpawnX;
    int maxSpawnX;
    int minSpawnY;
    int maxSpawnY;

    #endregion

    #region Methods
    // Use this for initialization
    void Start () {
        // Set the screen points
        minSpawnX = SpawnBorderSize;
        maxSpawnX = Screen.width - SpawnBorderSize;
        minSpawnY = SpawnBorderSize;
        maxSpawnY = Screen.height - SpawnBorderSize;

        spawnTime = gameObject.AddComponent<Timer>();
        spawnTime.Duration = 3;
        spawnTime.Run();
    }
	
	// Update is called once per frame
	void Update () {
        rocksInScene = GameObject.FindGameObjectsWithTag("rock");
        if (spawnTime.Finished)
        {
            if(rocksInScene.Length < 3)
            {
                spawnRock();
            }
            spawnTime.Run();
        }
	}

    /// <summary>
    /// Spawn Rock GameObject and assigns sprite
    /// </summary>
    void spawnRock()
    {
        // generate random Location for Rock and translate to worldLocation
        Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX),
            Random.Range(minSpawnY, maxSpawnY),
            -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);

        // spawn rock using location
        GameObject rock = Instantiate(prefabRock) as GameObject;
        rock.transform.position = worldLocation;

        // Set the sprite for the rock
        SpriteRenderer spriteRenderer = rock.GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, sprites.Length);
        spriteRenderer.sprite = sprites[spriteNumber];
    }

    #endregion
}
