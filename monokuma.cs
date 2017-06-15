using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monokuma : MonoBehaviour {

    private float veloFollow = 3.0f;
    public Transform player;
    private float x;
    private float y;
    public LayerMask shotLayer;
    private bool destroyed;
	// Use this for initialization
	void Start () {
        destroyed = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (!destroyed) {
            if (player.position.x > transform.position.x)
                transform.position -= Vector3.left * veloFollow * Time.deltaTime;
            else if (player.position.x < transform.position.x)
                transform.position -= Vector3.right * veloFollow * Time.deltaTime;

            if (player.position.y > transform.position.y)
                transform.position -= Vector3.down * veloFollow * Time.deltaTime;
            else if (player.position.y < transform.position.y)
                transform.position -= Vector3.up * veloFollow * Time.deltaTime;

            if (Physics2D.OverlapCircle(transform.position, 0.2f, shotLayer)){
                this.GetComponent<SpriteRenderer>().sprite = null;
                Destroy(this);
                destroyed = true;
            }
        }
        
    }
}
