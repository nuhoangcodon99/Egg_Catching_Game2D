using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;
    public float boundary = 10f;
    private Animator anim;
    private bool isFacingRight = true;
    public GameObject egg;

    // Get the ScoreManager from the scene
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private AudioManager audioManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
        HandleAnimationStates();
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        HandlePhysics();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("egg"))
        {
            // Destroy the egg
            Destroy(other.gameObject);
            // Debug.Log("Egg collected!", gameObject);
            // Increase the score using the ScoreManager
            scoreManager.IncreaseScore();
            // Play a sound effect
            audioManager.PlaySFX(audioManager.SFXClip);

        }
    }

    private void HandleMovementInput()
    {
        float moveInput = Input.GetAxis("Horizontal");
        // Flip the player sprite using quaternion rotation
        if (moveInput > 0 && !isFacingRight)
        {
            isFacingRight = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveInput < 0 && isFacingRight)
        {
            isFacingRight = false;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void HandlePhysics()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxis("Horizontal"), 0);
        rb.velocity = moveDirection * speed;

        // Clamp the player position within boundaries
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, -boundary, boundary);
        transform.position = currentPosition;
    }

    private void HandleAnimationStates()
    {
        // Check if the player is moving horizontally
        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }
    }
}