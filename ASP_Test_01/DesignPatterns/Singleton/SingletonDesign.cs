using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Singleton
{
    internal sealed class SingletonDesign
    {
        

        private static int counter = 0;
        private static SingletonDesign instance = null;
        private static readonly Object obj = new object();
     
        public static SingletonDesign GetInstance
        {
            get

            {
            
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                            instance = new SingletonDesign();

                    }
                }
                return instance;

            }
        }

        private SingletonDesign()
        {
            counter++;
            Console.WriteLine(counter.ToString());
        }

        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }

    }
}
