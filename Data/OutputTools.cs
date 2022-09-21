namespace Data
{
    public class OutputTools
    {
        public static string VectorToReadableString(double[] vector)
        {
            string vectorPrint = "{ ";
            for (int i = 0; i < vector.Length; i++)
            {
                vectorPrint += vector[i] + ", ";
            }
            return vectorPrint.Remove(vectorPrint.LastIndexOf(',') - 1) + " }";
        }
    }
}