using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scriptcamera : MonoBehaviour {

    public Transform player;
    public float smoothrate = 0.05f;
    private Transform thisTransform;
    private Vector2 velocity;
	// Use this for initialization
	void Start () {
        thisTransform = transform;
        velocity = new Vector2(0.5f, 8.5f);
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 newPos2d = Vector2.zero;
        newPos2d.x = Mathf.SmoothDamp(thisTransform.position.x, player.position.x, ref velocity.x, smoothrate);
        newPos2d.y = Mathf.SmoothDamp(thisTransform.position.y, player.position.y, ref velocity.y, smoothrate);
        Vector3 newPos = new Vector3(newPos2d.x, newPos2d.y, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, newPos, Time.time);
    }
}
