using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //The speed of the player
    public int speed = 12;

    //player points
    public static int points = 0;

    //heart rate
    public static int heartRate = 0;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        heartRate = (int) GetComponent<Rigidbody2D>().position.y;
        transform.position += Vector3.right * 0.8f * Time.deltaTime;
        if (Input.GetKey (KeyCode.UpArrow)) {
            GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, speed);
        } else if (Input.GetKey (KeyCode.DownArrow)) {
            GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, speed * -1);
        } else {
            GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
        }
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.layer == 8) {
            points++;
            Destroy (other.gameObject);
        }
    }
}