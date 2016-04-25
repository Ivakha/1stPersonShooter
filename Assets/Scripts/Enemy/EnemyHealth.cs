using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public int healthPoints = 3;
    Animator animator;
    NavMeshAgent navMeshAgent;
    EnemyAttack enemyAttack;
    Rigidbody rigidbody;
    bool dead = false;
    public GameObject blood;
    public Transform bloodPoint;
    //bool damaged = false;

    //public float flashSpeed = 5f;
    //public Color flashColour = new Color(1f, 1f, 0f, 0.1f);
    //Renderer rend;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
            Debug.Log("'PlayerAnimation' is missing 'Animator' component");
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAttack = GetComponent<EnemyAttack>();
        rigidbody = GetComponent<Rigidbody>();
        //rend = GetComponentInChildren<Renderer>();
    }

    /*void Update()
    {
        if (damaged)
        {
            //damageImage.color = flashColour;
            rend.material.color = flashColour;
        }
        else
        {
            //damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            rend.material.color = Color.Lerp(rend.material.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }*/

    public void TakeDamage (int damage)
    {
        //damaged = true;
        healthPoints -= damage;
        if (healthPoints <= 0 && !dead)
        {
            dead = true;
            //Destroy(gameObject);
            StartCoroutine(Die());
        }
        Instantiate(blood, bloodPoint.position, bloodPoint.rotation);
    }

    IEnumerator Die()
    {
        rigidbody.detectCollisions = false;
        enemyAttack.enabled = false;
        navMeshAgent.enabled = false;
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
