using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{

	public int heal = 10;
	public int dp = 2;


    public GameObject[] punts = new GameObject[15];
    public GameObject yo;
    GameObject actual;
    int i = 0;
    public float velo;
    private bool first = true;

    void Start()
    {
        actual = punts[0];
        yo.transform.Rotate(new Vector3(0, 90, 0));
    }

    // Update is called once per frame
    void Update()
    {

		if (heal <= 0)
			Destroy (yo);

        if (yo.transform.position == actual.transform.position)
        {
            if (actual == punts[14])
                Destroy(yo);
            if(!first)
                yo.transform.Rotate(new Vector3(0, 90, 0));
            actual = punts[i];
            if (i + 1 != punts.Length)
            {
                i++;
            }
            first = false;
        }
        else
        {
            yo.transform.position = Vector3.MoveTowards(yo.transform.position, actual.transform.position, velo);
        }
			
    }

	void OnTriggerEnter(Collider col){
		if (col.tag == "bala") {
			heal = 0;
		}

	}

}