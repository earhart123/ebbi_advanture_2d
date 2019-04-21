using UnityEngine;
using System.Collections;

public class EbbiController : MonoBehaviour
{
    Rigidbody2D rigidbody;
    Animator animator;
    AudioSource audioSource;

    public float maxHeight;
    public float flapVelocity;
    public GameObject sprite;
    public bool Grounded;
    public bool isDead = false;
    
    public AudioClip die;

    

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = sprite.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && transform.position.y < maxHeight && Grounded)
        {
            Flap();
        }
    }

    public void Flap()
    {
        if (isDead) return;
        rigidbody.velocity = new Vector2(0.0f, flapVelocity);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Grounded = true;
        if (sprite.gameObject.tag == "obstacle")
            isDead = true;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Grounded = true;
        animator.SetBool("flap", true);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Grounded = false;
        animator.SetBool("flap", false);
    }

    public void SetSteerActive(bool active)
    {
        rigidbody.isKinematic = !active;
    }
    public bool IsDead()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = die;
            audioSource.Play();
        }
        animator.SetBool("dead", true);
        isDead = true;
        return isDead;
    }
}