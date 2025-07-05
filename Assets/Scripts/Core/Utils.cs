using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Utils
{
    public static float PercentageScale(int currentHealth, int maxHealth)
    {
        if (maxHealth <= 0) return 0f;
        return Mathf.Clamp01((float)currentHealth / maxHealth);
    }
}
