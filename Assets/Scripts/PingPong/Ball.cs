using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 35f;
    public float acceleration = 0.5f;

    AudioSource audioSource;

    [SerializeField]
    AudioClip hitSound; 

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        speed += acceleration * Time.deltaTime;
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlaySound();
        if (collision.gameObject.name == "RacketLeft")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                collision.transform.position,
                                collision.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        // Hit the right Racket?
        if (collision.gameObject.name == "RacketRight")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                collision.transform.position,
                                collision.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }

    void PlaySound()
    {
        audioSource.clip = hitSound;
        audioSource.Play();
    }
}
