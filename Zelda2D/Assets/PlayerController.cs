using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D myRigidbody;
    private Vector2 input;
    public int damage = 1;
    public Enemy enemyController;
    public Enemy enemyController1;
    public Enemy enemyController2;
    public int maxHealth = 4;
    public int currentHealth;
    public HearthCounter hearthCounter;
    private SpriteRenderer spriteRenderer;
    private bool isAttacking;
   

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        hearthCounter.health = currentHealth; 
    }
private void OnCollisionEnter2D(Collision2D collision)
{
    if (isAttacking == true && collision.gameObject.CompareTag("Enemy"))
    {
        enemyController.TakeDamage(damage);
    }
    else if (isAttacking != true && collision.gameObject.CompareTag("Enemy"))
    {
        TakeDamage(damage);
    }
    else if (isAttacking == true && collision.gameObject.CompareTag("Enemy1"))
    {
        enemyController1.TakeDamage(damage);
    }
    else if (isAttacking != true && collision.gameObject.CompareTag("Enemy1"))
    {
        TakeDamage(damage);
    }
    else if (isAttacking == true && collision.gameObject.CompareTag("Enemy2"))
    {
        enemyController2.TakeDamage(damage);
    }
    else if (isAttacking != true && collision.gameObject.CompareTag("Enemy2"))
    {
        TakeDamage(damage);
    }
}

    

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        hearthCounter.TakeDamage(damage);
        if (currentHealth <= 0)
        {
            StartCoroutine(DestroyAfterAnimation());
        }
    }
    private IEnumerator DestroyAfterAnimation()
        {
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + 0.01f);
            SceneManager.LoadScene(2);
        }
    void Update()
    {
        Vector2 velocity = myRigidbody.velocity;
        Vector2 localVelocity = transform.InverseTransformDirection(velocity);
        bool RunnigLeft = localVelocity.x > 0.1f;
        bool RunnigRight = localVelocity.x < -0.1f;
        bool RunnigUp = localVelocity.y > 0.1f;
        bool Runnig = localVelocity.y < -0.1f;
        animator.SetBool("Runnig", Runnig);
        animator.SetBool("RunnigUp", RunnigUp);
        animator.SetBool("RunnigLeft", RunnigLeft);
        animator.SetBool("RunnigRight", RunnigRight);
        FlipFace();
        Run();
        OnFire();
    }

    void OnFire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            animator.SetBool("IsAttacking", isAttacking = true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("IsAttacking", isAttacking = false);
        }
    }
    void Run()
    {
        myRigidbody.velocity = input;
    }

    void FlipFace()
    {
        bool hasMovement = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (hasMovement)
        {
            spriteRenderer.flipX = Mathf.Sign(myRigidbody.velocity.x) < 0f;
        }
    }


    void OnMove(InputValue value)
    {
    
        input = value.Get<Vector2>()*3;
    }

    

}

