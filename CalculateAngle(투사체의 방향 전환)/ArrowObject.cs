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

    float initialSpeed; // 초기 속도
    MonsterPrefab targetObject; // 타겟 오브젝트 


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

        timer += Time.fixedDeltaTime; // 시간 측정

        if (timer >= 5f)
        {
            Destroy(gameObject); // 수명 시간 초과하여 유도체 파괴
        }
    }
}
