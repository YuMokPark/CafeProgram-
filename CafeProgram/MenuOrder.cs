using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeProgram
{
    class MenuOrder
    {
        //각 음료 한잔 당 곱해야할 가격
        private int won_1500 = 1500, won_2000 = 2000, won_2500 = 2500,
                    won_1000 = 1000, won_500 = 500;
        //각 음료별 잔수 카운트 (수량이니 금액 계산을 위해 1로 초기화)
        private int americano_c = 1, cafelatte_c = 1, caramel_c = 1, iceamericano_c = 1,
                    icecafelatte_c = 1, icecaramel_c = 1, sizeup_c = 1, shotadd_c = 1;
        //각 음료별 주문 총 금액
        private int americano_p = 0, cafelatte_p = 0,caramel_p = 0, iceamericano_p = 0, icecafelatte_p =0,
                    icecaramel_p = 0, sizeup_p = 0, shotadd_p = 0;

        //총 금액, 총 갯수 자동구형 프로퍼티
        private int sumnumber   //총 갯수
        {
            get;
            set;
        }
        private int sumcash
        {
            get;
            set;
        }
        //메뉴들 카운트에 대한 프로퍼티
        public int americanocount
        {
            get { return americano_c; }
            set { americano_c = value; }
        }
        public int iceamericanocount
        {
            get { return iceamericano_c; }
            set { iceamericano_c = value; }
        }
        public int cafelattecount
        {
            get { return cafelatte_c; }
            set { cafelatte_c = value; }
        }
        public int icecafelattecount
        {
            get { return icecafelatte_c; }
            set { icecafelatte_c = value; }
        }
        public int caramelcount
        {
            get { return caramel_c; }
            set { caramel_c = value; }
        }
        public int icecaramelcount
        {
            get { return icecaramel_c; }
            set { icecaramel_c = value; }
        }
        public int sizeupcount
        {
            get { return sizeup_c; }
            set { sizeup_c = value; }
        }
        public int shotcount
        {
            get { return shotadd_c; }
            set { shotadd_c = value; }
        }
        //메뉴들 금액에 대한 프로퍼티
        public int americanoprice
        {
            get { return americano_p; }
            set { americano_p = value; }
        }
        public int iceamericanoprice
        {
            get { return iceamericano_p; }
            set { iceamericano_p = value; }
        }
        public int cafelatteprice
        {
            get { return cafelatte_p; }
            set { cafelatte_p = value; }
        }
        public int icecafelatteprice
        {
            get { return icecafelatte_p; }
            set { icecafelatte_p = value; }
        }
        public int caramelprice
        {
            get { return caramel_p; }
            set { caramel_p = value; }
        }
        public int icecaramelprice
        {
            get { return icecaramel_p; }
            set { icecaramel_p = value; }
        }
        public int sizeupprice
        {
            get { return sizeup_p; }
            set { sizeup_p = value; }
        }
        public int shotaddprice
        {
            get { return shotadd_p; }
            set { shotadd_p = value; }
        }
        //메뉴의 총금액을 반환해주는 메서드
        public int AmericanoSum()
        {
            americanoprice = americanocount * won_1500;
            return americanoprice;
        }
        public int IceAmericanoSum()
        {
            iceamericanoprice = iceamericanocount * won_1500;
            return iceamericanoprice;
        }
        public int CafelatteSum()
        {
            cafelatteprice = cafelattecount * won_2000;
            return cafelatteprice;
        }
        public int IceCafelatteSum()
        {
            icecafelatteprice = icecafelattecount * won_2000;
            return icecafelatteprice;
        }
        public int CaramelSum()
        {
            caramelprice = caramelcount * won_2500;
            return caramelprice;
        }
        public int IceCaramelSum()
        {
            icecaramelprice = icecaramelcount * won_2500;
            return icecaramelprice;
        }
        public int SizeUpSum()
        {
            sizeupprice = sizeup_c * won_1000;
            return sizeupprice;
        }
        public int ShotAddsum()
        {
            shotaddprice = shotadd_c * won_500;
            return shotaddprice;
        }
        public int SumNumber()  //총 잔 수
        {
            sumnumber = americanocount + iceamericanocount + cafelattecount + icecafelattecount + caramelcount + icecaramelcount; //+ shotcount + sizeupcount;
            return sumnumber-6;
        }
        public int SumCash()    //총 금액
        {
            sumcash = americanoprice + iceamericanoprice + cafelatteprice + icecafelatteprice + caramelprice + icecaramelprice + shotaddprice + sizeupprice;
            return sumcash;
        }
        private int clear_num = 0;
        public int clear
        {
            get { return clear_num; }
            set { clear_num = value; }
        }
        public void SumNumber_Clear()
        {
            americanocount = 1;
            iceamericanocount = 1;
            cafelattecount = 1;
            icecafelattecount= 1;
            caramelcount = 1;
            icecaramelcount = 1;
            shotcount = 1;
            sizeupcount = 1;
            //sumnumber = 0;
        }

        public void SumCash_Clear()
        {
            americanoprice = 0;
            iceamericanoprice = 0;
            cafelatteprice = 0;
            icecafelatteprice = 0;
            caramelprice = 0;
            icecaramelprice = 0;
            shotaddprice = 0;
            sizeupprice = 0;
            //sumcash = 0;
        }


        public MenuOrder() { } // 기본생성자
        public MenuOrder(int americanocount, int iceamericanocount, int cafelattecount, int icecafelattecount, int caramelcount, int icecaramelcount, int shotcount, int sizeupcount)
        {

            this.americanocount += (americanocount - 2);
            this.iceamericanocount += (iceamericanocount - 2);
            this.cafelattecount += (cafelattecount - 2);
            this.icecafelattecount += (icecafelattecount - 2);
            this.caramelcount += (caramelcount - 2);
            this.icecaramelcount += (icecaramelcount - 2);
            this.shotcount += (shotcount - 2);
            this.sizeupcount += (sizeupcount - 2);

        }
    }
}
