using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateAngle : MonoBehaviour
{
    public static float CalculateAngle(Vector2 currentObjectPosition, Vector2 targetObjectPosition)
    {
        // �� �� ���� ���̸� ���
        Vector2 direction = targetObjectPosition - currentObjectPosition;

        // Atan2 �Լ��� ����Ͽ� ��ũź��Ʈ ���� ���
        float radians = Mathf.Atan2(direction.x, direction.y);

        // ���� ���� ������ ��ȯ
        float degrees = radians * Mathf.Rad2Deg;

        // ��� ������ ������ ��� 360�� ���Ͽ� ����� ��ȯ
        if (degrees < 0)
        {
            degrees += 360;
        }
        return degrees;
    }
}
