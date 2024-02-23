public static class ArrayExtension
{
    public static float[] ToFloat(this int[] array)
    {
        float[] tempArray = new float[array.Length];

        for (int i = 0; i < tempArray.Length; i++)
        {
            tempArray[i] = array[i];
        }

        return tempArray;
    }
}