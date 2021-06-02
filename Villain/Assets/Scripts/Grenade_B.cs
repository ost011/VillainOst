using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade_B : MonoBehaviour
{
    public LayerMask whatIsMonster;
    public ParticleSystem explosionParticle;
    public AudioSource explosionAudio;
    public float maxDamage = 100f;
    public float explosionForce = 1000f;//자기 반경으로 1000force힘으로 튕겨나가게
    public float lifeTime = 5f;
    public float explosionRadius = 20f;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //가상의 구를 그려서 그 안에 있는 collider를 가져오려고 함
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, whatIsMonster);//그 위치에 radius반경으로 whatismonster할당된 애들만 가져옴
        //Collier[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, whatIsMonster);
        if (colliders.Length <= 0)
        {
            explosionParticle.transform.parent = null;//파티클이 수류탄에서 빠져나옴
            explosionParticle.Play();
            explosionAudio.Play();
            Destroy(explosionParticle.gameObject, explosionParticle.main.duration);//explosionParticle.duration
            Destroy(gameObject);
        }
        else if(colliders.Length >0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
                targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);//폭발의 위치와 폭발력, 폭발 반경
                MonsterCtrl_C targetMonster = colliders[i].GetComponent<MonsterCtrl_C>();
                float damage = CalculateDamage(colliders[i].transform.position);
                targetMonster.GetDamage(damage);

            }
            explosionParticle.transform.parent = null;//파티클이 수류탄에서 빠져나옴
            explosionParticle.Play();
            explosionAudio.Play();
            Destroy(explosionParticle.gameObject, explosionParticle.main.duration);//explosionParticle.duration
            Destroy(gameObject);
        }
        //for (int i = 0; i < colliders.Length; i++)
        //{
        //    Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
        //    targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);//폭발의 위치와 폭발력, 폭발 반경
        //    MonsterCtrl_C targetMonster = colliders[i].GetComponent<MonsterCtrl_C>();
        //    float damage = CalculateDamage(colliders[i].transform.position);
        //    targetMonster.GetDamage(damage);

        //}
        //explosionParticle.transform.parent = null;//파티클이 수류탄에서 빠져나옴
        //explosionParticle.Play();
        //explosionAudio.Play();
        //Destroy(explosionParticle.gameObject, explosionParticle.main.duration);//explosionParticle.duration
        //Destroy(gameObject);
    }
    private float CalculateDamage(Vector3 targetPosition) // 어떤 위치를 주면 내 위치에서 그 위치까지의 거리르 재서 데미지 얼마 받을지 계산, 데미지를 차등으로 주려고
    {
        Vector3 explosionToTarget = targetPosition - transform.position;
        float distance = explosionToTarget.magnitude;
        float edgeToCenterDistance = explosionRadius - distance; //가쪽에서 안쪽으로 얼마나 들어갔냐
        float percentage = edgeToCenterDistance / explosionRadius;
        float damage = maxDamage * percentage;
        damage = Mathf.Max(0, damage);
        return damage;

    }
    void Update()
    {
        
    }
}
