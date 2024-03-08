using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderNormalDistributer : MonoBehaviour
{
    [Range(1, 3)]
    public float sliderValue = 1.0f; // Привязать число из Unity Inspector (ползунок от 1 до 3)
    public float valuePick = 3.0f; // Максимальное значение на пике нормального распределения
    public float minValue = 0.0f; // Минимальное значение
    public float stdDev = 0.2f; // Стандартное отклонение нормального распределения

    float CalculateGaussValue(float x, float mean, float stdDev)
    {
        float exponent = -0.5f * Mathf.Pow((x - mean) / stdDev, 2);
        return Mathf.Exp(exponent) / (stdDev * Mathf.Sqrt(2 * Mathf.PI));
    }

    float CalculateCurrentValue(float sliderValue, float valuePick, float minValue, float stdDev)
    {
        // Приводим слайдер к интервалу [-1, 1]
        float x = 2.0f * (sliderValue - 1.0f) - 1.0f;

        // Используем среднее значение нормального распределения, чтобы значение было максимальным на пике
        float mean = 0.0f;

        // Рассчитываем значение в соответствии с функцией плотности вероятности Гаусса
        float gaussValue = CalculateGaussValue(x, mean, stdDev);

        // Масштабируем значение в пределах [minValue, valuePick]
        float currentValue = Mathf.Lerp(minValue, valuePick, gaussValue);

        return currentValue;
    }

    void Update()
    {
        float currentValue = CalculateCurrentValue(sliderValue, valuePick, minValue, stdDev);
        Debug.Log("Slider Value: " + sliderValue + " | Current Value: " + currentValue);
    }
}
