using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] waves;
    [SerializeField] private AudioClip waveSound;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack()) {
            Attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        SoundManager.instance.PlaySound(waveSound);
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        //pool waves
        StartCoroutine(AttackWithDelay());
    }

    private IEnumerator AttackWithDelay()
    {
        // Чекаємо 0.3 секунди
        yield return new WaitForSeconds(0.3f);

        // Активація
        waves[FindWave()].transform.position = firePoint.position;
        waves[FindWave()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindWave()
    {
        for (int i = 0; i < waves.Length; i++)
        {
            if (!waves[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
