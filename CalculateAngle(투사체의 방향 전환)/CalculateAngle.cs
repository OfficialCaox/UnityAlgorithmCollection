using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateAngle : MonoBehaviour
{
    public static float CalculateAngle(Vector2 currentObjectPosition, Vector2 targetObjectPosition)
    {
        // 두 점 간의 차이를 계산
        Vector2 direction = targetObjectPosition - currentObjectPosition;

        // Atan2 함수를 사용하여 아크탄젠트 값을 계산
        float radians = Mathf.Atan2(direction.x, direction.y);

        // 라디안 값을 각도로 변환
        float degrees = radians * Mathf.Rad2Deg;

        // 결과 각도가 음수인 경우 360을 더하여 양수로 변환
        if (degrees < 0)
        {
            degrees += 360;
        }
        return degrees;
    }
}
