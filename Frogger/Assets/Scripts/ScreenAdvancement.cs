using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenAdvancement : MonoBehaviour {

    public Camera camera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("m_frog"))
        {
            camera.transform.position = new Vector3(camera.transform.position.x, camera.orthographicSize * 2 , camera.transform.position.z);
            Destroy(gameObject);
        }
    }

}
