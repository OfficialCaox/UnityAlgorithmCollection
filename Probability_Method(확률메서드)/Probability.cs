using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Probability : MonoBehaviour
{
    public void Awake()
    {
        for (int i = 0; i < 100000; i++)
        {
            Debug.Log("90% Chance :" + Probability(0.9f));
        }
    }

    public static bool Probability(double chance)
    {
        if (chance <= 0 || chance >= 1)
        {
            throw new ArgumentException("Chance should be between 0 and 1.");
        }
        return (UnityEngine.Random.value <= chance);
    }
    public static bool Probability(float chance)
    {
        if (chance <= 0 || chance >= 1)
        {
            throw new ArgumentException("Chance should be between 0 and 1.");
        }
        return (UnityEngine.Random.value <= chance);
    }
}
