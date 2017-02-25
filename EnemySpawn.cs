using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    monokuma script;
    private int seconds = 1;
    private float time = 0;
    private bool maxEnemy;
    public GameObject prefab;
    public GameObject player;
    public LayerMask layer;
	// Use this for initialization
	void Start () {
        maxEnemy = false;
	}

    // Update is called once per frame
    void Update() {

        if (time >= seconds)
        {
            createEnemy();
            seconds++;
        }
        time += Time.deltaTime;
	}

    void createEnemy()
    {
        GameObject enemy = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
        enemy.GetComponent<monokuma>().player = player.transform;
        enemy.GetComponent<monokuma>().shotLayer = layer;
        Destroy(enemy, 2);
    }
}
