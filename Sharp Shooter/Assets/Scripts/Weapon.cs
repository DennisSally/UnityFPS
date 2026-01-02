using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] int damageAmount = 1;
    [SerializeField] ParticleSystem muzzleFlash;

    const string SHOOT_STRING = "Shoot";

    StarterAssetsInputs starterAssetsInputs;
    Animator animator;

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleShoot();
    }

    private void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return;
        muzzleFlash.Play();
        animator.Play(SHOOT_STRING, 0, 0f);
        starterAssetsInputs.ShootInput(false);
        
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(damageAmount);
        }
    }
}