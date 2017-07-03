using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour {

    public GameObject[] punts = new GameObject[2];
    public GameObject yo;
    GameObject actual;
    int i = 0;
    public float velo;
	// Use this for initialization
	void Start () {
        actual = punts[0];
	}

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x == punts[punts.Length-1].transform.position.x)
            if (transform.position.z == punts[punts.Length-1].transform.position.z)
            {
                Debug.LogWarning("ODAAAAAAA");
                Destroy(yo);
            }
                

        if (transform.position == actual.transform.position)
        {
            actual = punts[i];
            if (i + 1 != punts.Length)
            {
                i++;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, actual.transform.position, velo);
        }
    }
}
