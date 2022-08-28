using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


 public class EnemyAI : MonoBehaviour
 {
   NavMeshAgent agent;
   Animator anim;
   Transform target;


   public bool isDead = false;
   public float trunSpeed;

   public float damage = 25f;
   public bool canAttack;//düşman saldırıp saldırmadığına bakılacak

   [SerializeField] //inspector ekranında da görmek için ekleniyor
   float attackTimer = 2f;//can düşmesinin 2 sn bir olması için



   void Start()
   {
            canAttack = true;
            agent = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();
            target = GameObject.FindGameObjectWithTag("Player").transform;
   }

   void Update()
   {
            float distance = Vector3.Distance(transform.position, target.position);

            if (distance < 10 && distance >agent.stoppingDistance && !isDead)
            {
                ChasePlayer();
            }
            else if (distance <= agent.stoppingDistance && canAttack && !PlayerHealth.PH.isDead)
            {
               agent.updateRotation = false;
               Vector3 direction = target.position - transform.position;
               direction.y = 0;
               transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), trunSpeed * Time.deltaTime);

               agent.updatePosition = false;
               anim.SetBool("isWalking", false);
               anim.SetBool("Attack", true);
            AttackPlayer();
            }
            else if (distance > 10)
            {
                StopChase();
            }
   }

   void ChasePlayer()//player takip etme
   {
        agent.updateRotation = true;
            agent.updatePosition = true;
            agent.SetDestination(target.position); //gidilecek noktayı ayarla yani güncelle
            anim.SetBool("isWalking", true);
            anim.SetBool("Attack", false);
   }

   void AttackPlayer()
   {
       PlayerHealth.PH.DamagePlayer(damage);
      
       

   }
   void StopChase()
   {
            agent.updatePosition = false;
            anim.SetBool("isWalking", false);
            anim.SetBool("Attack", false);
   }

   public void Hit()
   {
            agent.enabled = false;
            anim.SetTrigger("Hit");
            StartCoroutine(Nav());

   }
   public void Dead()
   {
            isDead = true;
            anim.SetTrigger("Dead");
   }
   IEnumerator Nav()
   {
            yield return new WaitForSeconds(1.5f);
            agent.enabled = true;
   }

 }


