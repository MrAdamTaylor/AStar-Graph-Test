using System;

namespace Scenes.TestScenes.Probability_and_Buffers.MonoComponents
{
    public static class AccuracyExtension
    {
        /// <summary>
        /// Метод переводит число слайдера от 1 до 6 в условные деления, для лучшего расчёта процентов.
        /// Деления (1 - возвращает 5 делений) (2 - возвращает 10 делений)
        /// (3 - возвращает 20 делений) (4 - возвращает 25 делений)
        /// (2 - возвращает 50 делений) (2 - возвращает 100 делений)
        /// </summary>
        /// <param name="range">Этот параметр нужен для определения числа делений. Должен быть от 1 до 6</param>
        /// <returns></returns>
        public static int AccuracyInterpretator(this int range)
        {
            int value = 0;
            switch (range)
            {
                case 1:
                    value = 5;
                    break;
                case 2:
                    value = 10;
                    break;
                case 3:
                    value = 20;
                    break;
                case 4:
                    value = 25;
                    break;
                case 5:
                    value = 50;
                    break;
                case 6:
                    value = 100;
                    break;
            }
            return value;
        }

        //TODO методы Jagged, Trapecioid, Triangle - принадлежат нечёткой логике!
        //SOURCE - Надо просмотреть исходники алгоритмов нечёткой логики
        public static float GetTrapecioidRange(this float range, float pickValue, float maxValue)
        {
            throw new Exception("Трапециойдный выход не реализован");
        }

        public static float GetJaggedRange(this float range, float pickValue)
        {
            float newRange = 0f;
            if (CheckRangeByNull(range, pickValue)) 
                return pickValue;

            newRange = IsLessThanPick(range, pickValue, newRange);
            if (range > pickValue)
            {
                newRange = range - pickValue;
            }
            return newRange;
        }

        public static float GetTriangleRange(this float range, float pickValue, float maxValue)
        {
            float newRange = 0f;
            if (CheckRangeByNull(range, pickValue)) 
                return pickValue;

            newRange = IsLessThanPick(range, pickValue, newRange);

            if (range > pickValue)
            {
                newRange =  maxValue - range;
            }

            return newRange;
        }

        private static float IsLessThanPick(float range, float pickValue, float newRange)
        {
            if (range < pickValue)
            {
                newRange = range;
            }

            return newRange;
        }

        private static bool CheckRangeByNull(float range, float pickValue)
        {
            if (range.Equals(pickValue))
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }
    }
}