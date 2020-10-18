using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {

    private AudioSource source;

    void Start () {
        source = GetComponent<AudioSource> ();
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.layer == 8) {
            GameState.P1Score++;
            source.Play ();
            Destroy (other.gameObject);
        }
    }
}