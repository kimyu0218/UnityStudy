using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollision : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine("AutoDisable");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().TakeDamage(10);
        }
    }

    private IEnumerator AutoDisable()   //  0.1초 후 오브젝트 사라짐
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }
}
