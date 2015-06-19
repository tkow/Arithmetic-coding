using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Arithmetic
{
    class Program
    {
        static void Main(string[] args)
        {
            double u=0, v=1,p=1,k=0;
            double[] answer=new double[2]{0,0};
            int n=16;
            long l = 0, m = 1;
            int[] number =new int[16]{6,1,5,1,3,4,5,5,6,5,2,4,6,3,1,3};
            double[] prepro = new double[6] { (double)3 / 16, (double)1 / 16, (double)3 / 16, (double)2 / 16, (double)4 / 16, (double)3 / 16 };
            List<double> probablities=new List<double>();
            List<double> q=new List<double>();
            
            q.Add(0);
            for(int i=0;i<prepro.Length-1;i++){
                k+=prepro[i]; 
                q.Add(k);
            }

            for (int i = 0; i < number.Length; i++)
            {
                probablities.Add(prepro[number[i]-1]);
            }

            for(int i=0;i<n;i++){
                p=1;
                for(int j=0;j<i;j++){
                    p *= probablities[j];
                }

             u+=p*q[number[i] - 1];
             v *= probablities[i];
               
                    }
            v += u;
            bool flag = false;

            answer[0] = (double)(1 / Math.Pow(2, l));
            answer[1] = (double)(2 / Math.Pow(2, l));

            while (answer[1] - answer[0] >= v - u)
            {
                l++;
                answer[0] = (double)1 / Math.Pow(2, l);
                answer[1] = (double)2 / Math.Pow(2, l);
            }
            while (true)
            {
                m = 0;
                long ll = l;
                while(ll>0){
                    if (((m + Math.Pow(2, ll - 1)) / Math.Pow(2, l)) < u) m += (long)(Math.Pow(2, ll - 1));
                    ll--;
                }
                    while (m <= Math.Pow(2, l))
                {
                    answer[0] = (double)m / Math.Pow(2, l);
                    answer[1] = (double)(m + 1) / Math.Pow(2, l);

                    if (u <= answer[0] && answer[1] < v) { flag = true; break; }
                    if (v < answer[1]) break;
                    m++;
                }

                if (flag) break;
                l++;
            }
            Console.WriteLine("u={0},v={1},m={2},l={3}", u, v,m,l);

            long ans=m;
            List<char> binary = new List<char>();
            while(ans/2!=0){
                if (ans % 2==1) binary.Add('1');
                if (ans % 2==0) binary.Add('0');
                ans /= 2;
            }
            binary.Add('1');
            binary.Reverse();
            Console.Write("binary=");
            for(int i=0;i<binary.Count;i++){
            Console.Write(binary[i]);
            }
            Console.WriteLine();
        }
    }
}
