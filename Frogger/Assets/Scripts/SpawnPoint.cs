using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject car;
    public bool flip = false;

	void Start () {
        if (flip)
        {
            car.GetComponent<SpriteRenderer>().flipX = true;
            car.GetComponent<Car>().direction = Vector2.left;
            Instantiate(car, transform.position, Quaternion.identity);
        }
        else
        {
            car.GetComponent<SpriteRenderer>().flipX = false;
            car.GetComponent<Car>().direction = Vector2.right;
            Instantiate(car, transform.position, Quaternion.identity);
        }
        
	}
	
}
