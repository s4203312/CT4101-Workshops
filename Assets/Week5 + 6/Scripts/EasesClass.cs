using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasesClass
{

    private const float easeElasticConst = (2f * Mathf.PI) / 3f;
    private const float easeInOutElasticConst = (2f * Mathf.PI) / 4.5f;

    public static float Linear(float t)
    {
        return t;
    }
    public class Quadratic
    {
        public static float In(float t)
        {
            return t * t;
        }
        public static float Out(float t)
        {
            return t * (2f - t);
        }
        public static float InOut(float t)
        {
            if ((t *= 2f) < 1f) return 0.5f * t * t;
            return -0.5f * ((t -= 1f) * (t - 2f) - 1f);
        }
        public static float Bezier(float t, float c)
        {
            return c * 2 * t * (1 - t) + t * t;
        }
    }
    public class Trigonometric
    {
        public static float SinIn(float t)
        {
            return 1f - Mathf.Cos(t * Mathf.PI * 0.5f);
        }
        public static float SinOut(float t)
        {
            return Mathf.Sin(t * Mathf.PI * 0.5f);
        }
        public static float SinInOut(float t)
        {
            if ((t *= 2f) < 1f) return 0.5f * (1f - Mathf.Cos(t * Mathf.PI * 0.5f));
            return -0.5f * (Mathf.Sin((t -1) * Mathf.PI * 0.5f));
        }
    }
    public class Elastic
    {
        public static float easeInElastic(float t)
        {
            if (t == 0) return 0f;
            if (t == 1) return 1f;
            return -Mathf.Pow(2, 10 * t - 10) * Mathf.Sin((t * 10f - 10.75f) * easeElasticConst);
        }

        public static float easeOutElastic(float t)
        {
            if (t == 0) return 0f;
            if (t == 1) return 1f;
            return Mathf.Pow(2, -10 * t) * Mathf.Sin((t * 10f - 0.75f) * easeElasticConst) + 1;
        }

        public static float easeInOutElastic(float t)
        {
            if (t == 0) return 0f;
            if (t == 1) return 1f;
            if (t < 0.5f) return -(Mathf.Pow(2, 20 * t - 10) * Mathf.Sin((20f * t - 11.125f) * easeInOutElasticConst)) / 2;
            return (Mathf.Pow(2, -20 * t + 10) * Mathf.Sin((20f * t - 11.125f) * easeInOutElasticConst)) / 2 + 1;
        }
    }
}





