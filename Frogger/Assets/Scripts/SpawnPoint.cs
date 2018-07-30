using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public new GameObject gameObject;
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
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.GetComponent<MovingObject>().direction = Vector2.left;
            Instantiate(gameObject, transform.position, Quaternion.identity);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.GetComponent<MovingObject>().direction = Vector2.right;
            Instantiate(gameObject, transform.position, Quaternion.identity);
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
