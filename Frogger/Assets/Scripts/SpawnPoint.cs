using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject car;

	void Start () {
        Instantiate(car, transform);
	}
	
}
