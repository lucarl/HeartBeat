using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {

    //The speed of the player
    private float playerSpeed = 1.5f;

    //player points
    public static int points = 0;

    //heart rate
    public static double heartRate = 0;

    private float xPos = 0;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        heartRate = (int) GetComponent<Rigidbody2D>().position.y;
        xPos += playerSpeed * Time.deltaTime;
        transform.position = new Vector3(0, 0, 0);
        transform.position = new Vector3(xPos, HeartRateScript.bpm1, transform.position.z);
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.layer == 8) {
            points++;
            Destroy (other.gameObject);
        }
    }
}