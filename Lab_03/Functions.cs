using System;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Double;
using Data;
using static MathNet.Numerics.Precision;

namespace parallel_programming
{
    public class Functions
    {
        public int N = Program.N;
        
        public void Func1()
        {
            double[] a;
            if (!Program.Key)
            {
                var (b,c,d,md,me)= InputTools.GetInputForF1(N);
                a = Calculate(b, c, d, md, me);
        
            }
            else
            {
                a = Calculate(Creator.RandomVectorCreator(N),
                        Creator.RandomVectorCreator(N),
                        Creator.RandomVectorCreator(N),
                        Creator.RandomMatrixCreator(N),
                        Creator.RandomMatrixCreator(N));
            }
            
            lock (InputTools.Locker)
            {
                Console.WriteLine($"Thread 'F1' finished work and returned result: {OutputTools.VectorToReadableString(a)}\n");
            } 
            
            double[] Calculate(double[] b, double[] c, double[] d, double[,] md, double[,] me)
            {
                return (DenseVector.OfArray(c) + DenseVector.OfArray(b) + d * (DenseMatrix.OfArray(md) * DenseMatrix.OfArray(me))).ToArray();
            }
        }
        
        public void Func2()
        {
            double q;
            if (!Program.Key)
            {
                var (mh,mk,ml) = InputTools.GetInputForF2(N);
                q = Calculate(mh, mk, ml);
            }
            else
            {
                q = Calculate(Creator.RandomMatrixCreator(N),
                        Creator.RandomMatrixCreator(N),
                        Creator.RandomMatrixCreator(N));
            }
            
            lock (InputTools.Locker)
            {
                Console.WriteLine($"Thread 'F2' finished work and returned result: {q.Round(2)}\n");

            } 
            
            double Calculate(double[,] mh, double[,] mk, double[,] ml)
            {
                return DenseMatrix.OfArray((DenseMatrix.OfArray(mh) *
                    DenseMatrix.OfArray(mk) - DenseMatrix.OfArray(ml)).ToArray()).Values.Max();
            }
        }
        
        public void Func3()
        {
            double S;
            if (!Program.Key)
            {
                var (s, mo, mt, ms, mp) = InputTools.GetInputForF3(N);
                S = Calculate(s, mo, mt, ms, mp);
            }
            else
            {
                S = Calculate(Creator.RandomVectorCreator(N),
                        Creator.RandomMatrixCreator(N),
                        Creator.RandomMatrixCreator(N),
                        Creator.RandomMatrixCreator(N),
                        Creator.RandomMatrixCreator(N));
            }
        
            lock (InputTools.Locker)
            {
                Console.WriteLine($"Thread 'F3' finished work and returned result: {S.Round(2)}\n");
            } 
            
            double Calculate(double[] s, double[,] mo, double[,] mt, double[,] ms, double[,] mp)
            {
                return (DenseVector.OfArray(s) * DenseMatrix.OfArray(mo)).Max() 
                        + DenseMatrix.OfArray((DenseMatrix.OfArray(mt) * DenseMatrix.OfArray(ms) + DenseMatrix.OfArray(mp)).ToArray()).Values.Max();
            }
        }
    }
}