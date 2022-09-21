using System;

namespace Data
{
    public class InputTools
    {
        public static readonly object Locker = new object();

        public static (double[], double[], double[], double[,], double[,]) GetInputForF1(int N)
        {
            lock (Locker)
            {
                Console.WriteLine("Inputs for F1");
                
                return (Creator.VectorCreator("B", N),
                        Creator.VectorCreator("C", N),
                        Creator.VectorCreator("D", N),
                        Creator.MatrixCreator("MD", N),
                        Creator.MatrixCreator("ME", N));
            }
        }
        
        public static (double[,], double[,], double[,]) GetInputForF2(int N)
        {
            lock (Locker)
            {
                Console.WriteLine("Inputs for F2");
                
                return (Creator.MatrixCreator("MH", N),
                        Creator.MatrixCreator("MK", N),
                        Creator.MatrixCreator("ML", N));
            }            
        }
        
        public static (double[], double[,], double[,], double[,], double[,]) GetInputForF3(int N)
        {
            lock (Locker)
            {
                Console.WriteLine("Inputs for F3");
                
                return (Creator.VectorCreator("S", N),
                Creator.MatrixCreator("MO", N),
                Creator.MatrixCreator("MT", N),
                Creator.MatrixCreator("MS", N),
                Creator.MatrixCreator("MP", N));
            }
        }
    }
}