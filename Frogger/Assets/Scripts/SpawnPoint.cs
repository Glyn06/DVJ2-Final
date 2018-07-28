using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject car;
    public bool flip = false;
    public float minTime = 3;
    public float maxTime = 5;

    private float time;
    private float rand;

	void Start () {
        Instanciate();
        rand = Random.Range(minTime, maxTime);
	}

    private void Update()
    {
        InstanciateInSeconds();
    }

    void Instanciate() {
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
    void InstanciateInSeconds() {
        time += Time.deltaTime;
        if (time >= rand)
        {
            Instanciate();
            time = 0;
        }
    }
}
