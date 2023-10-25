using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowObject : MonoBehaviour
{
    public void Init(Unit unit, float initSpeed, MonsterPrefab targetObject)
    {
        this.initialSpeed = initSpeed;
        this.targetObject = targetObject;
    }

    float initialSpeed; // �ʱ� �ӵ�
    MonsterPrefab targetObject; // Ÿ�� ������Ʈ 


    private float timer;

    private void FixedUpdate()
    {
        if (targetObject != null)
        {
            transform.position = Vector2.MoveTowards(gameObject.transform.position, targetObject.transform.position, initialSpeed * InGameManager.Instance.GameMultiplier);
            transform.rotation = Quaternion.Euler(0f, 0f, -(CalculateAngle.CalculateAngle(transform.position, targetObject.transform.position)));
        }
        else
        {
            Destroy(gameObject);
        }

        timer += Time.fixedDeltaTime; // �ð� ����

        if (timer >= 5f)
        {
            Destroy(gameObject); // ���� �ð� �ʰ��Ͽ� ����ü �ı�
        }
    }
}
