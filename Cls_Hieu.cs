using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWord_TrinhPhucHieu
{
    class Cls_Hieu
    {


        private static void Duyet()
        {
            Console.WriteLine("Test");
        }

        private static bool CheckDuyet()
        {
            return false;

        }

        private static void CheckChu(String i)
        {
            for(int y = 0; y < i.Length; y++)
            {
                Console.WriteLine(i);
            }

        }
        private static void countTu(String i)
        {
           string [] y1 = i.Split(' ');
            for (int y = 0; y < y1.Length; y++)
            {
                Console.WriteLine(y1);
            }

        }
    }
}
