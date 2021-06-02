using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade_B : MonoBehaviour
{
    public LayerMask whatIsMonster;
    public ParticleSystem explosionParticle;
    public AudioSource explosionAudio;
    public float maxDamage = 100f;
    public float explosionForce = 1000f;//�ڱ� �ݰ����� 1000force������ ƨ�ܳ�����
    public float lifeTime = 5f;
    public float explosionRadius = 20f;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //������ ���� �׷��� �� �ȿ� �ִ� collider�� ���������� ��
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, whatIsMonster);//�� ��ġ�� radius�ݰ����� whatismonster�Ҵ�� �ֵ鸸 ������
        //Collier[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, whatIsMonster);
        if (colliders.Length <= 0)
        {
            explosionParticle.transform.parent = null;//��ƼŬ�� ����ź���� ��������
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
                targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);//������ ��ġ�� ���߷�, ���� �ݰ�
                MonsterCtrl_C targetMonster = colliders[i].GetComponent<MonsterCtrl_C>();
                float damage = CalculateDamage(colliders[i].transform.position);
                targetMonster.GetDamage(damage);

            }
            explosionParticle.transform.parent = null;//��ƼŬ�� ����ź���� ��������
            explosionParticle.Play();
            explosionAudio.Play();
            Destroy(explosionParticle.gameObject, explosionParticle.main.duration);//explosionParticle.duration
            Destroy(gameObject);
        }
        //for (int i = 0; i < colliders.Length; i++)
        //{
        //    Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
        //    targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);//������ ��ġ�� ���߷�, ���� �ݰ�
        //    MonsterCtrl_C targetMonster = colliders[i].GetComponent<MonsterCtrl_C>();
        //    float damage = CalculateDamage(colliders[i].transform.position);
        //    targetMonster.GetDamage(damage);

        //}
        //explosionParticle.transform.parent = null;//��ƼŬ�� ����ź���� ��������
        //explosionParticle.Play();
        //explosionAudio.Play();
        //Destroy(explosionParticle.gameObject, explosionParticle.main.duration);//explosionParticle.duration
        //Destroy(gameObject);
    }
    private float CalculateDamage(Vector3 targetPosition) // � ��ġ�� �ָ� �� ��ġ���� �� ��ġ������ �Ÿ��� �缭 ������ �� ������ ���, �������� �������� �ַ���
    {
        Vector3 explosionToTarget = targetPosition - transform.position;
        float distance = explosionToTarget.magnitude;
        float edgeToCenterDistance = explosionRadius - distance; //���ʿ��� �������� �󸶳� ����
        float percentage = edgeToCenterDistance / explosionRadius;
        float damage = maxDamage * percentage;
        damage = Mathf.Max(0, damage);
        return damage;

    }
    void Update()
    {
        
    }
}
