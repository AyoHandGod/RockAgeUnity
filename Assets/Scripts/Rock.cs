using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour { 

    public float speed = .75f;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Awake()
    {

        const float MinImpulseForce = 1f;
        const float MaxImpulseForce = 3f;

        float angle = Random.Range(0, 2 * Mathf.PI);

        Vector2 direction = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));

        float magnitude = Random.Range(MinImpulseForce,
            MaxImpulseForce);

        GetComponent<Rigidbody2D>().AddForce(direction * magnitude,
            ForceMode2D.Impulse);
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}