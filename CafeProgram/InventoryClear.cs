using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeProgram
{
    internal class InventoryClear
    {

        public int americano=0;           // hot 아메리카노
        public int iceamericano=0;        // 아이스 아메리카노
        public int cafelatte=0;           // 카페라떼
        public int icecafelatte=0;        // 아이스 카페라떼
        public int caramel=0;             // 카라멜라떼
        public int icecaramel=0;          // 아이스 카라멜라떼

        public int americanocnt=0;
        public int iceamericanocnt = 0;
        public int cafelattecnt = 0;
        public int icecafelattecnt = 0;
        public int caramelcnt = 0;
        public int icecaramelcnt = 0;


      

        int coffeebeans
        {
            get;
            set;
        }

        int milk
        {
            get;
            set;
        }

        int straw
        {
            get;
            set;
        }

        int ice
        {
            get;
            set;
        }

        int caramelsyrup
        {
            get;
            set;
        }

        int mochasyrup
        {
            get;
            set;
        }

        int plastic
        {
            get;
            set;
        }

        public void ItemsClear()
        {
            americano = 0;
            iceamericano = 0;
            cafelatte = 0;
            icecafelatte = 0;
            caramel = 0;
            icecaramel = 0;
        }
       

        //-------------------------------------------------------- 재고 개수 표시하는 매서드 -------------------------------------------
        public int SumCoffeeBeans()                             // 원두 재고 개수
        {
            coffeebeans = americano + iceamericano + cafelatte + icecafelatte + caramel + icecaramel; // 커피 모든 종류(6)
            return coffeebeans;
        }

        public int SumMilk()                                    // 우유 재고 개수
        {
            milk = cafelatte + icecafelatte + caramel + icecaramel;     // 카페라떼,카페라떼(ice), 카라멜,카라멜(ice)
            return milk;
        }

        public int SumStraw()                                   // 빨대 재고 개수
        {
            straw = americano + iceamericano + cafelatte + icecafelatte + caramel + icecaramel; // 커피 모든 종류(6)
            return straw;
        }

        public int SumIce()                                       // 얼음 재고 개수
        {
            ice = iceamericano + icecafelatte + icecaramel;         // ice(아메리카노,카페라떼,카라멜 마끼아또)
            return ice;
        }

        public int SumCaramelSyrup()                                      // 생크림 재고 개수
        {
            caramelsyrup = icecaramel + caramel;                       // 카라멜 마끼아또, ice 카라멜 마끼아또
            return caramelsyrup;
        }

        public int SumMochaSyrup()                                        // 설탕 재고 개수
        {
            mochasyrup = cafelatte + icecafelatte;                   // 카페라떼, ice카페라떼
            return mochasyrup;
        }

        public int SumPlastic()                                         // 플라스틱 컵 재고 개수
        {
            plastic = americano + iceamericano + cafelatte + icecafelatte + caramel + icecaramel;       // 모든 커피 종류(6)
            return plastic;
        }

        //----------------------------------------------선택 삭제 매서드---------------------------------

       
    }
}
