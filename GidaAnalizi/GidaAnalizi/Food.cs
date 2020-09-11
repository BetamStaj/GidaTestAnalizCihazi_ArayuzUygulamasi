using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidaAnalizi
{
    public class Food
    {

        public string foodName;
        public ArrayList datalar;
        public static float enBuyukData;
        public Food(string foodName)
        {
            this.foodName = foodName;
            this.datalar = new ArrayList();
        }

    }
}
