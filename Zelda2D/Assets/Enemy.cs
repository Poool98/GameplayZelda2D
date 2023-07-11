using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public EnemyCounter enemyManager;

    [SerializeField]private GameObject player;
    public int damage = 1;
    public PlayerController playerController;
    [SerializeField]private float speed = 1f;
    private float distance;
    public int maxHealth = 4;
    public int health;
    private bool Death;
    private int life;
    private Animator animator;
    private static int aliveEnemies = 0;

    void Start()
    {  
        animator = GetComponent<Animator>();
        health=maxHealth;
        Death = false;
        aliveEnemies=3;
        enemyManager = FindObjectOfType<EnemyCounter>();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health == 0){
            animator.SetBool("Death", true);
            StartCoroutine(DestroyAfterAnimation());
            aliveEnemies = aliveEnemies - 1;
        }
    }
    private IEnumerator DestroyAfterAnimation()
        {
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + 0.3f);
            Destroy(gameObject);
            
        {
        if (aliveEnemies <= 0)
        {
           SceneManager.LoadScene(3);
        }
    }
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        } 
    }

 public void Die()
    {
        
        enemyManager.EnemyKilled();
    }
}
