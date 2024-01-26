using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Animator animator;
    [SerializeField] SpriteRenderer PlayerSprite;

    [SerializeField] 
    private float maxSpeed = 2, acceleration = 50, deacceleration = 100;
    [SerializeField] 
    private float currentSpeed = 0;
    public float dashSpeed;
    public bool canDash = true;

    public float dashLength = 0.5f, dashCooldown = 1f;

    [SerializeField] bool isDashing;
    private float dashTimer;

    public float currentExperience;
    public float maxExperience;
    public int currentLevel;

    private Vector2 oldMovementInput;
    public Vector2 playerInput { get; set; }

    [SerializeField] Health health;
    public HealthBar healthBar;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnDisable()
    {
        ExperienceManager.Instance.OnExperienceChange -= HandleExperiencChange;
    }

    private void Start()
    {
        playerInput = transform.position;
        healthBar.SetMaxHealth(health.maxHealth);
        ExperienceManager.Instance.OnExperienceChange += HandleExperiencChange;
    }

    private void FixedUpdate()
    {

        animator.SetBool("IsDashing", isDashing);
        animator.SetFloat("Speed", currentSpeed);
        animator.SetBool("CanDash", canDash);
        if (!isDashing)
        {
            if (playerInput.magnitude > 0 && currentSpeed >= 0)
            {
                oldMovementInput = playerInput;
                currentSpeed += acceleration * maxSpeed * Time.fixedDeltaTime;
            }
            else
            {
                currentSpeed -= deacceleration * maxSpeed * Time.fixedDeltaTime;
            }
            currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
            rb2d.velocity = oldMovementInput * currentSpeed;
        }
        else
        {
            Dash();
        }
    }
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (PlayerSprite != null)
            {
                PlayerSprite.flipX = true;
            }
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            if (PlayerSprite != null)
            {
                PlayerSprite.flipX = false;
            }
        }
    }
    private void HandleExperiencChange(int newExperience)
    {
        currentExperience += newExperience;
        if (currentExperience >= maxExperience)
        {
            LevelUp();
            currentExperience -= maxExperience;
            currentLevel++;
        }
    }
    public void PerformDash()
    {
        isDashing = true;

        //Set the length of the dash to the how fair the dash would go
        dashTimer = dashLength;
    }
    private void Dash()
    {
        if (canDash)
        {
            rb2d.velocity = oldMovementInput.normalized * dashSpeed;
            dashTimer -= Time.deltaTime;
            canDash = false;
        }
        else
        {
            return;
        }
    }


    public void DashReset()
    {
        Debug.Log("why?");
        isDashing = false;
    }

    public void CanDashReset()
    {
        if (!canDash)
        {
            canDash = true;
        }
    }

    private void LevelUp()
    {
        health.maxHealth += 25;
        health.currentHealth = health.maxHealth;
        maxExperience += 100f;
        healthBar.SetHealth(health.currentHealth);
    }

    public void OnTakeDamage() 
    { 
        healthBar.SetHealth(health.currentHealth);
    }
}
