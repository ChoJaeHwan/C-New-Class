using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStudy
{
    class Cat 
    {
        public string[] Name = new string[10];


      protected virtual void Meow()
        {

            for (int i = 0; i < Name.Count(); i++)
            {

                Console.WriteLine("/w 야옹" + i, Name[i]);
            }

        }
        public string dogs;
      public  string dog
        {
            get { return dogs; }
            set { dogs = value; }
        }
    }

    class mainclass : Cat
    {
        public int p=0;
        void refer(ref int a)
        {
            a = 20;
        }
        void Origin(int a)
        {
            a = 10;
           
        }
        protected override void Meow()
        {
           
            for (int i = 0; i < Name.Count(); i++)
            {

                Console.WriteLine("/w 멍멍" + i, Name[i]);
            }
        }

        void prams(params int[] ar)
        {
            int[] sum = new int[ar.Length];
            for (int i = 0; i < ar.Length; i++)
            {
                //sum[i] = ar[i];
               // return sum;
                Console.WriteLine(ar[i]);
            }
        }
        static void Main(string[] args)
        {
            mainclass ap = new mainclass();

            // ap.prams(10, 20, 30, 40);
            object a = 10;
            
            if(a is int i)
            Console.WriteLine(i);
            ap.Meow();
           
            
            //  ap.refer(ref ap.p);

        
          

        }
    }
    
}
