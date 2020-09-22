using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator animator;
    public Transform AttackPoint;
    public float attackRange=0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40; 
    public float attackRate =2f;
    float nextAttackTime =0f;
    public float wait = 1f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                StartCoroutine(Attack());
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    public IEnumerator Attack()
    {
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.5f);
       Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange,enemyLayers);
       foreach(Collider2D enemy in hitEnemies)
       {
          
           GameObject.Find("Ennemy_Frog").GetComponent<enemy>().TakeDamage(attackDamage);
           
       }
    
    }
    void OnDrawGizmosSelected() 
    {
        if(AttackPoint == null)
        return;
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }
}

