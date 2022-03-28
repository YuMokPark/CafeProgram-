using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;


namespace CafeProgram
{
    public partial class MainForm : Form
    {
        MenuOrder ord = new MenuOrder();
        InventoryClear iv = new InventoryClear();
        MenuOrder sale;
        private ArrayList arrlist3 = new ArrayList();// 판매물품 


        int cash = 0;//총 받을 금액

        Person p; // 클래스 선언(회원)
        string str = "";    //(회원)
        private ArrayList arrlist = new ArrayList();// 배열 선언(회원)

        //int stockcount = 0; // 재고 검색 버튼 카운터
        string Stockname, Stockcount, Stocknblank; // 재고 수정 에 사용되는 변수들 수정 이전 내용을 저장해놈


        public MainForm()
        {
            InitializeComponent();

            timer1.Interval = 1000; //1초 단위
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            timer1.Start();
            // this는 Form1을 가리킴
            //this.Text = "myDigitalClock";

            //label14.Text = DateTime.Now.ToString();


        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();

            DialogResult Result = loginForm.ShowDialog();   //자식폼 LoginForm을 실행

            if (Result == DialogResult.OK)
            {
                MessageBox.Show("로그인 성공");

            }
            else
            {
                this.Close();
            }

            listview_Stock.View = View.Details; //컬럼 형식으로 변경
            listview_Stock.FullRowSelect = true;//Row 전체 추가

            listview_Stock.Columns.Add("재고명", 180);//컬럼 추가
            listview_Stock.Columns.Add("개수", 150);
            listview_Stock.Columns.Add("비고", 340);

            StockAddToList();//데이터 삽입을 위한 함수

        }
        public int openclosecount // 로그인 폼에서 openclosecount 값 전달받는곳, 즉 로그인폼에서 메인폼으로 값 전달
        {
            set; get;
        }
        private void btn_order_Click(object sender, EventArgs e)
        {
            if (groupBox_order.Visible == false)
            {
                groupBox_order.Visible = true;
            }
            else
            {
                groupBox_order.Visible = false;

            }
            groupBox_member.Visible = false;
            groupBox_Inventory.Visible = false;
            groupBox_Sales2.Visible = false;
            openclosecount = 0;

        }
        /*-------------------------------------------------------주문---------------------------------------------*/
        private void btn_Americano_Click(object sender, EventArgs e)//아메리카노 hot 버튼을 누르면 list view에 show
        {
            int count = listView_Order.Items.Count;// list view 항목 수 반환
          
           
            if (ord.americanocount >= 2)
            {
                for (int i = 0; i < count; i++)//list view 내에서 검색하는 포문
                {
                    if (listView_Order.Items[i].SubItems[0].Text == btn_Americano.Text)
                    {
                        listView_Order.Items[i].Focused = true;
                        listView_Order.Items[i].Selected = true;
                        listView_Order.FocusedItem.SubItems[0].Text = btn_Americano.Text;
                        listView_Order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.americanocount);
                        listView_Order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.AmericanoSum());
                        ord.americanocount++;
                        iv.americano++;
                        iv.americanocnt++;
                        listView_Order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new string[] { this.btn_Americano.Text, Convert.ToString(ord.americanocount), Convert.ToString(ord.AmericanoSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_Order.Items.Add(lvt);
                listView_Order.Focus();
                ord.americanocount++;
                iv.americano++;
                iv.americanocnt++;
            }
            txt_sumnumber.Text = Convert.ToString(ord.SumNumber());
            txt_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void btn_IceAmericano_Click(object sender, EventArgs e)//아메리카노 ice 버튼을 누르면 list view에 show
        {
            int count = listView_Order.Items.Count;
            if (ord.iceamericanocount >= 2)
            {
                for (int i = 0; i < count; i++)
                {
                    if (listView_Order.Items[i].SubItems[0].Text == btn_IceAmericano.Text)
                    {
                        listView_Order.Items[i].Focused = true;
                        listView_Order.Items[i].Selected = true;
                        listView_Order.FocusedItem.SubItems[0].Text = btn_IceAmericano.Text;
                        listView_Order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.iceamericanocount);
                        listView_Order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.IceAmericanoSum());
                        ord.iceamericanocount++;
                        iv.iceamericano++;
                        iv.iceamericanocnt++;
                        listView_Order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new String[] { this.btn_IceAmericano.Text, Convert.ToString(ord.iceamericanocount), Convert.ToString(ord.IceAmericanoSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_Order.Items.Add(lvt);
                listView_Order.Focus();
                ord.iceamericanocount++;
                iv.iceamericano++;
                iv.iceamericanocnt++;
            }
            txt_sumnumber.Text = Convert.ToString(ord.SumNumber());
            txt_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void btn_caramel_Click(object sender, EventArgs e)//카라멜 마끼아또 hot 버튼을 누르면 list view에 show
        {
            int count = listView_Order.Items.Count;
            if (ord.caramelcount >= 2)
            {
                for (int i = 0; i < count; i++)
                {
                    if (listView_Order.Items[i].SubItems[0].Text == btn_caramel.Text)
                    {
                        listView_Order.Items[i].Focused = true;
                        listView_Order.Items[i].Selected = true;
                        listView_Order.FocusedItem.SubItems[0].Text = btn_caramel.Text;
                        listView_Order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.caramelcount);
                        listView_Order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.CaramelSum());
                        ord.caramelcount++;
                        iv.caramel++;
                        iv.caramelcnt++;
                        listView_Order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new String[] { this.btn_caramel.Text, Convert.ToString(ord.caramelcount), Convert.ToString(ord.CaramelSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_Order.Items.Add(lvt);
                listView_Order.Focus();
                ord.caramelcount++;
                iv.caramel++;
                iv.caramelcnt++;
            }
            txt_sumnumber.Text = Convert.ToString(ord.SumNumber());
            txt_sumcash.Text = Convert.ToString(ord.SumCash());
        }
        private void btn_IceCaramel_Click(object sender, EventArgs e)//카라멜 마끼아또 ice 버튼을 누르면 list view에 show
        {

            int count = listView_Order.Items.Count;
            if (ord.icecaramelcount >= 2)
            {
                for (int i = 0; i < count; i++)
                {
                    if (listView_Order.Items[i].SubItems[0].Text == btn_IceCaramel.Text)
                    {
                        listView_Order.Items[i].Focused = true;
                        listView_Order.Items[i].Selected = true;
                        listView_Order.FocusedItem.SubItems[0].Text = btn_IceCaramel.Text;
                        listView_Order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.icecaramelcount);
                        listView_Order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.IceCaramelSum());
                        ord.icecaramelcount++;
                        iv.icecaramel++;
                        iv.icecaramelcnt++;
                        listView_Order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new string[] { this.btn_IceCaramel.Text, Convert.ToString(ord.icecaramelcount), Convert.ToString(ord.IceCaramelSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_Order.Items.Add(lvt);
                listView_Order.Focus();
                ord.icecaramelcount++;
                iv.icecaramel++;
                iv.icecaramelcnt++;
            }
            txt_sumnumber.Text = Convert.ToString(ord.SumNumber());
            txt_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void btn_CafeLatte_Click(object sender, EventArgs e)//카페라떼 hot 버튼을 누르면 list view에 show
        {
            int count = listView_Order.Items.Count;
            if (ord.cafelattecount >= 2)
            {
                for (int i = 0; i < count; i++)
                {
                    if (listView_Order.Items[i].SubItems[0].Text == btn_CafeLatte.Text)
                    {
                        listView_Order.Items[i].Focused = true;
                        listView_Order.Items[i].Selected = true;
                        listView_Order.FocusedItem.SubItems[0].Text = btn_CafeLatte.Text;
                        listView_Order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.cafelattecount);
                        listView_Order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.CafelatteSum());
                        ord.cafelattecount++;
                        iv.cafelatte++;
                        iv.cafelattecnt++;
                        listView_Order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new string[] { this.btn_CafeLatte.Text, Convert.ToString(ord.cafelattecount), Convert.ToString(ord.CafelatteSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_Order.Items.Add(lvt);
                listView_Order.Focus();
                ord.cafelattecount++;
                iv.cafelatte++;
                iv.cafelattecnt++;
            }
            txt_sumnumber.Text = Convert.ToString(ord.SumNumber());
            txt_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void btn_IceCafeLatte_Click(object sender, EventArgs e)//카페라떼 ice 버튼을 누르면 list view에 show
        {
            int count = listView_Order.Items.Count;
            if (ord.icecafelattecount >= 2)
            {
                for (int i = 0; i < count; i++)
                {
                    if (listView_Order.Items[i].SubItems[0].Text == btn_IceCafeLatte.Text)
                    {
                        listView_Order.Items[i].Focused = true;
                        listView_Order.Items[i].Selected = Capture;
                        listView_Order.FocusedItem.SubItems[0].Text = btn_IceCafeLatte.Text;
                        listView_Order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.icecafelattecount);
                        listView_Order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.IceCafelatteSum());
                        //listView_Order.FocusedItem.SubItems[3].Text = btn_ShotAdd.Text;
                        ord.icecafelattecount++;
                        iv.icecafelatte++;
                        iv.icecafelattecnt++;
                        listView_Order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new string[] { this.btn_IceCafeLatte.Text, Convert.ToString(ord.icecafelattecount), Convert.ToString(ord.IceCafelatteSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_Order.Items.Add(lvt);
                listView_Order.Focus();
                ord.icecafelattecount++;
                iv.icecafelatte++;
                iv.icecafelattecnt++;

            }
            txt_sumnumber.Text = Convert.ToString(ord.SumNumber());
            txt_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void btn_ShotAdd_Click(object sender, EventArgs e)//샷 버튼을 누르면 list view에 show
        {
            int count = listView_Order.Items.Count;
            if (ord.shotcount >= 2)
            {
                for (int i = 0; i < count; i++)
                {
                    if (listView_Order.Items[i].SubItems[0].Text == btn_ShotAdd.Text)
                    {
                        listView_Order.Items[i].Focused = true;
                        listView_Order.Items[i].Selected = true;
                        listView_Order.FocusedItem.SubItems[0].Text = btn_ShotAdd.Text;
                        listView_Order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.shotcount);
                        listView_Order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.ShotAddsum());
                        ord.shotcount++;
                        listView_Order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var shot = new string[] { this.btn_ShotAdd.Text, Convert.ToString(ord.shotcount), Convert.ToString(ord.ShotAddsum()) };
                var lvt = new ListViewItem(shot);
                this.listView_Order.Items.Add(lvt);
                listView_Order.Focus();
                ord.shotcount++;
            }
            txt_sumcash.Text = Convert.ToString(ord.SumCash());
        }
        private void btn_SizeUp_Click(object sender, EventArgs e)//사이즈업 버튼을 누르면 list view에 show
        {
            int count = listView_Order.Items.Count;
            if (ord.sizeupcount >= 2)
            {
                for (int i = 0; i < count; i++)
                {
                    if (listView_Order.Items[i].SubItems[0].Text == btn_SizeUp.Text)
                    {
                        listView_Order.Items[i].Focused = true;
                        listView_Order.Items[i].Selected = true;
                        listView_Order.FocusedItem.SubItems[0].Text = btn_SizeUp.Text;
                        listView_Order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.sizeupcount);
                        listView_Order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.SizeUpSum());
                        ord.sizeupcount++;
                        listView_Order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var sizeup = new string[] { this.btn_SizeUp.Text, Convert.ToString(ord.sizeupcount), Convert.ToString(ord.SizeUpSum()) };
                var lvt = new ListViewItem(sizeup);
                this.listView_Order.Items.Add(lvt);
                listView_Order.Focus();
                ord.sizeupcount++;
            }
            txt_sumcash.Text = Convert.ToString(ord.SumCash());
        }
        private void btn_Discount_Click(object sender, EventArgs e)//회원 할인 버튼
        {
            double discount = (double)ord.SumCash() * 0.05;
            int remaincash = ord.SumCash() - (int)discount;
            String t1 = discount.ToString();
            String t2 = remaincash.ToString();
            txt_discount.Text = t1;
            //ord.SumCash_Clear();
            txt_sumcash.Text = ord.clear.ToString();
            txt_sumcash.Text = t2;
        }

        private void btn_ChoiceCancel_Click(object sender, EventArgs e)//선택할인 수정완료
        {
            int count = listView_Order.Items.Count;
            if (count == 0)
            {
                MessageBox.Show("취소할 음료가 없습니다!!", "알림!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (listView_Order.FocusedItem.SubItems[0].Text == btn_Americano.Text)
                {
                    ord.americanocount = 1;
                    ord.americanoprice = 0;
                    for (int i = 0; i < iv.americanocnt; i++)
                    {
                        iv.americano--;
                    }
                    iv.americanocnt = 0;

                }
                else if (listView_Order.FocusedItem.SubItems[0].Text == btn_IceAmericano.Text)
                {
                    ord.iceamericanocount = 1;
                    ord.iceamericanoprice = 0;
                    for (int i = 0; i < iv.iceamericanocnt; i++)
                    {
                        iv.iceamericano--;
                    }
                    iv.iceamericanocnt = 0;
                }
                else if (listView_Order.FocusedItem.SubItems[0].Text == btn_caramel.Text)
                {
                    ord.caramelcount = 1;
                    ord.caramelprice = 0;
                    for (int i = 0; i < iv.caramelcnt; i++)
                    {
                        iv.caramel--;
                    }
                    iv.caramelcnt = 0;
                }
                else if (listView_Order.FocusedItem.SubItems[0].Text == btn_IceCaramel.Text)
                {
                    ord.icecaramelcount = 1;
                    ord.icecaramelprice = 0;
                    for (int i = 0; i < iv.icecaramelcnt; i++)
                    {
                        iv.icecaramel--;
                    }
                    iv.icecaramelcnt = 0;
                }
                else if (listView_Order.FocusedItem.SubItems[0].Text == btn_CafeLatte.Text)
                {
                    ord.cafelattecount = 1;
                    ord.cafelatteprice = 0;
                    for (int i = 0; i < iv.cafelattecnt; i++)
                    {
                        iv.cafelatte--;
                    }
                    iv.cafelattecnt = 0;
                }
                else if (listView_Order.FocusedItem.SubItems[0].Text == btn_IceCafeLatte.Text)
                {
                    ord.icecafelattecount = 1;
                    ord.icecafelatteprice = 0;
                    for (int i = 0; i < iv.icecafelattecnt; i++)
                    {
                        iv.icecafelatte--;
                    }
                    iv.icecafelattecnt = 0;

                }
                else if (listView_Order.FocusedItem.SubItems[0].Text == btn_ShotAdd.Text)
                {
                    ord.shotcount = 1;
                    ord.shotaddprice = 0;
                }
                else if (listView_Order.FocusedItem.SubItems[0].Text == btn_SizeUp.Text)
                {
                    ord.sizeupcount = 1;
                    ord.sizeupprice = 0;
                }
            }
            txt_sumcash.Text = Convert.ToString(ord.SumCash());
            txt_sumnumber.Text = Convert.ToString(ord.SumNumber());
            listView_Order.Items.Remove(listView_Order.FocusedItem);    //컨트롤 부분을 제거
        }

        private void btn_AllCancel_Click(object sender, EventArgs e)//전체 취소 버튼
        {
            for (int i = listView_Order.Items.Count - 1; i >= 0; i--)
            {
                listView_Order.Items.RemoveAt(i);
            }
            txt_sumcash.Text = ord.clear.ToString();
            txt_sumnumber.Text = ord.clear.ToString();
            txt_discount.Text = ord.clear.ToString();
            ord.SumCash_Clear();
            ord.SumNumber_Clear();

            for (int i = 0; i < iv.americanocnt; i++)
            {
                iv.americano--;
            }
            iv.americanocnt = 0;

            for (int i = 0; i < iv.iceamericanocnt; i++)
            {
                iv.iceamericano--;
            }
            iv.iceamericanocnt = 0;
          
            for (int i = 0; i < iv.caramelcnt; i++)
            {
                iv.caramel--;
            }
            iv.caramelcnt = 0;

            for (int i = 0; i < iv.icecaramelcnt; i++)
            {
                iv.icecaramel--;
            }
            iv.icecaramelcnt = 0;

            for (int i = 0; i < iv.cafelattecnt; i++)
            {
                iv.cafelatte--;
            }
            iv.cafelattecnt = 0;

            for (int i = 0; i < iv.icecafelattecnt; i++)
            {
                iv.icecafelatte--;
            }
            iv.icecafelattecnt = 0;

        }
        private void btn_Card_Click(object sender, EventArgs e)//카드 결제 버튼
        {
            for (int i = listView_Order.Items.Count - 1; i >= 0; i--)
            {
                listView_Order.Items.RemoveAt(i);
            }
            txt_sumcash.Text = ord.clear.ToString();
            txt_sumnumber.Text = ord.clear.ToString();
            txt_discount.Text = ord.clear.ToString();
            sale = new MenuOrder(ord.americanocount, ord.iceamericanocount, ord.cafelattecount, ord.icecafelattecount, ord.caramelcount, ord.icecaramelcount, ord.shotcount, ord.sizeupcount) { };
            arrlist3.Add(sale);

            int coffeebeanscount = (50 - iv.SumCoffeeBeans());

            for (int i = 0; i < 6; i++)
            {
                int j = 0;
                if (listview_Stock.Items[i].Text == "원두")                 // 원두 재고 
                {
                    for (j = 1; j < 3; j++)
                    {
                        listview_Stock.Items[i].SubItems[1].Text = coffeebeanscount.ToString();
                    }
                }
            }

            //int milkcount = -iv.SumMilk();
            int milkcount = (50 - iv.SumMilk());

            for (int i = 0; i < 6; i++)
            {
                int j = 0;
                if (listview_Stock.Items[i].Text == "우유")                 // 우유 재고 
                {
                    for (j = 1; j < 3; j++)
                    {
                        listview_Stock.Items[i].SubItems[1].Text = milkcount.ToString();
                    }
                }
            }

            int mochasyrupcount = (40 - iv.SumMochaSyrup());

            for (int i = 0; i < 6; i++)
            {
                int j = 0;
                if (listview_Stock.Items[i].Text == "모카시럽")                 // 모카시럽 재고 
                {
                    for (j = 1; j < 3; j++)
                    {
                        listview_Stock.Items[i].SubItems[1].Text = mochasyrupcount.ToString();
                    }
                }
            }

            int caramelsyrupcount = (40 - iv.SumCaramelSyrup());

            for (int i = 0; i < 6; i++)
            {
                int j = 0;
                if (listview_Stock.Items[i].Text == "카라멜시럽")                 // 카라멜시럽 재고 
                {
                    for (j = 1; j < 3; j++)
                    {
                        listview_Stock.Items[i].SubItems[1].Text = caramelsyrupcount.ToString();
                    }
                }
            }

            int plasticcount = (100 - iv.SumPlastic());

            for (int i = 0; i < 6; i++)
            {
                int j = 0;
                if (listview_Stock.Items[i].Text == "일회용 컵")                 // 일회용 컵 재고 
                {
                    for (j = 1; j < 3; j++)
                    {
                        listview_Stock.Items[i].SubItems[1].Text = plasticcount.ToString();
                    }
                }
            }

            int strawcount = (100 - iv.SumStraw());

            for (int i = 0; i < 6; i++)
            {
                int j = 0;
                if (listview_Stock.Items[i].Text == "종이 빨대")                 // 빨대 재고 
                {
                    for (j = 1; j < 3; j++)
                    {
                        listview_Stock.Items[i].SubItems[1].Text = strawcount.ToString();
                    }
                }
            }

            ord.SumCash_Clear();
            ord.SumNumber_Clear();
            iv.americanocnt = 0;
            iv.iceamericanocnt = 0;
            iv.caramelcnt = 0;
            iv.icecaramelcnt = 0;
            iv.icecafelattecnt = 0;
            iv.cafelattecnt = 0;

            MessageBox.Show("결제 되었습니다.");
        }
        private void btn_Pay_Click(object sender, EventArgs e)
        {
            for (int i = listView_Order.Items.Count - 1; i >= 0; i--)
            {
                listView_Order.Items.RemoveAt(i);
            }
            String retext = txt_Cash.Text;
            int renum = Convert.ToInt32(retext);
            int sumcashnum = Convert.ToInt32(txt_sumcash.Text);
            int charge = renum - sumcashnum;
            if (sumcashnum > renum)
            {
                MessageBox.Show("금액이 부족합니다!!", "알림!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Cash.Text = "0";
                txt_Charge.Text = "0";
            }
            else
            {
                //txt_Charge.Text = charge.ToString();
                MessageBox.Show("결제가 완료되었습니다.");
                txt_Cash.Text = "0";
                txt_Charge.Text = "0";

                txt_sumcash.Text = ord.clear.ToString();
                txt_sumnumber.Text = ord.clear.ToString();
                txt_discount.Text = ord.clear.ToString();
                sale = new MenuOrder(ord.americanocount, ord.iceamericanocount, ord.cafelattecount, ord.icecafelattecount, ord.caramelcount, ord.icecaramelcount, ord.shotcount, ord.sizeupcount) { };
                arrlist3.Add(sale);
                ord.SumCash_Clear();
                ord.SumNumber_Clear();
            }

            int coffeebeanscount = (50 - iv.SumCoffeeBeans());

            for (int i = 0; i < 6; i++)
            {
                int j = 0;
                if (listview_Stock.Items[i].Text == "원두")                 // 원두 재고 
                {
                    for (j = 1; j < 3; j++)
                    {
                        listview_Stock.Items[i].SubItems[1].Text = coffeebeanscount.ToString();
                    }
                }
            }

            //int milkcount = -iv.SumMilk();
            int milkcount = (50 - iv.SumMilk());

            for (int i = 0; i < 6; i++)
            {
                int j = 0;
                if (listview_Stock.Items[i].Text == "우유")                 // 우유 재고 
                {
                    for (j = 1; j < 3; j++)
                    {
                        listview_Stock.Items[i].SubItems[1].Text = milkcount.ToString();
                    }
                }
            }

            int mochasyrupcount = (40 - iv.SumMochaSyrup());

            for (int i = 0; i < 6; i++)
            {
                int j = 0;
                if (listview_Stock.Items[i].Text == "모카시럽")                 // 모카시럽 재고 
                {
                    for (j = 1; j < 3; j++)
                    {
                        listview_Stock.Items[i].SubItems[1].Text = mochasyrupcount.ToString();
                    }
                }
            }

            int caramelsyrupcount = (40 - iv.SumCaramelSyrup());

            for (int i = 0; i < 6; i++)
            {
                int j = 0;
                if (listview_Stock.Items[i].Text == "카라멜시럽")                 // 카라멜시럽 재고 
                {
                    for (j = 1; j < 3; j++)
                    {
                        listview_Stock.Items[i].SubItems[1].Text = caramelsyrupcount.ToString();
                    }
                }
            }

            int plasticcount = (100 - iv.SumPlastic());

            for (int i = 0; i < 6; i++)
            {
                int j = 0;
                if (listview_Stock.Items[i].Text == "일회용 컵")                 // 일회용 컵 재고 
                {
                    for (j = 1; j < 3; j++)
                    {
                        listview_Stock.Items[i].SubItems[1].Text = plasticcount.ToString();
                    }
                }
            }

            int strawcount = (100 - iv.SumStraw());

            for (int i = 0; i < 6; i++)
            {
                int j = 0;
                if (listview_Stock.Items[i].Text == "종이 빨대")                 // 빨대 재고 
                {
                    for (j = 1; j < 3; j++)
                    {
                        listview_Stock.Items[i].SubItems[1].Text = strawcount.ToString();
                    }
                }
            }

            ord.SumCash_Clear();
            ord.SumNumber_Clear();
            iv.americanocnt = 0;
            iv.iceamericanocnt = 0;
            iv.caramelcnt = 0;
            iv.icecaramelcnt = 0;
            iv.icecafelattecnt = 0;
            iv.cafelattecnt = 0;
        }
        private void btn_MemberResarch_Click(object sender, EventArgs e)
        {
            if (groupBox_member.Visible == false)
            {
                groupBox_member.Visible = true;
            }
            else
            {

                groupBox_member.Visible = false;
            }
            groupBox_order.Visible = false;
            groupBox_Inventory.Visible = false;
            openclosecount = 0;
        }
        /*---------------------------------------------------------------키패드-----------------------------------------------*/
        private void btn_1_Click(object sender, EventArgs e)//키패드 1번
        {
            if (cash == 0)
            {
                cash = 1;
                txt_Cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 1;
                txt_Cash.Text = Convert.ToString(cash);
            }
            txt_Charge.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void btn_2_Click(object sender, EventArgs e)//키패드 2번
        {
            if (cash == 0)
            {
                cash = 2;
                txt_Cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 2;
                txt_Cash.Text = Convert.ToString(cash);
            }
            txt_Charge.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void btn_3_Click(object sender, EventArgs e)//키패드 3번
        {
            if (cash == 0)
            {
                cash = 3;
                txt_Cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 3;
                txt_Cash.Text = Convert.ToString(cash);
            }
            txt_Charge.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void btn_4_Click(object sender, EventArgs e)//키패드 4번
        {
            if (cash == 0)
            {
                cash = 4;
                txt_Cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 4;
                txt_Cash.Text = Convert.ToString(cash);
            }
            txt_Charge.Text = Convert.ToString(cash - ord.SumCash());
        }
        private void btn_5_Click(object sender, EventArgs e)//키패드 5번
        {
            if (cash == 0)
            {
                cash = 5;
                txt_Cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 5;
                txt_Cash.Text = Convert.ToString(cash);
            }
            txt_Charge.Text = Convert.ToString(cash - ord.SumCash());
        }
        private void btn_6_Click(object sender, EventArgs e)//키패드 6번
        {
            if (cash == 0)
            {
                cash = 6;
                txt_Cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 6;
                txt_Cash.Text = Convert.ToString(cash);
            }
            txt_Charge.Text = Convert.ToString(cash - ord.SumCash());
        }
        private void btn_7_Click(object sender, EventArgs e)//키패드 7번
        {
            if (cash == 0)
            {
                cash = 7;
                txt_Cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 7;
                txt_Cash.Text = Convert.ToString(cash);
            }
            txt_Charge.Text = Convert.ToString(cash - ord.SumCash());
        }
        private void btn_8_Click(object sender, EventArgs e)//키패드 8번
        {
            if (cash == 0)
            {
                cash = 8;
                txt_Cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 8;
                txt_Cash.Text = Convert.ToString(cash);
            }
            txt_Charge.Text = Convert.ToString(cash - ord.SumCash());
        }
        private void btn_9_Click(object sender, EventArgs e)//키패드 9번
        {
            if (cash == 0)
            {
                cash = 9;
                txt_Cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 9;
                txt_Cash.Text = Convert.ToString(cash);
            }
            txt_Charge.Text = Convert.ToString(cash - ord.SumCash());
        }
        private void btn_0_Click(object sender, EventArgs e)//키패드 0번
        {
            cash *= 10;
            txt_Cash.Text = Convert.ToString(cash);
            txt_Charge.Text = Convert.ToString(cash - ord.SumCash());
        }
        private void btn_00_Click(object sender, EventArgs e)//키패드 00번
        {
            cash *= 100;
            txt_Cash.Text = Convert.ToString(cash);
            txt_Charge.Text = Convert.ToString(cash - ord.SumCash());
        }
        private void btn_clear_Click(object sender, EventArgs e)//키패드 clear
        {
            cash = 0;
            txt_Cash.Text = Convert.ToString(cash);
            txt_Charge.Text = Convert.ToString(cash - ord.SumCash());
        }
        /*--------------------------------------------------------------회원 관리-----------------------------------------------*/
        private void btn_Member_Click(object sender, EventArgs e)
        {
            if (groupBox_member.Visible == false)
            {
                groupBox_member.Visible = true;
            }
            else
            {

                groupBox_member.Visible = false;
            }
            groupBox_order.Visible = false;
            groupBox_Inventory.Visible = false;
            groupBox_Sales2.Visible = false;
            openclosecount = 0;
        }
        private void btn_member_register_Click(object sender, EventArgs e)
        {
            p = new Person(textBox_name.Text, textBox_birth.Text, textBox_tell.Text); // 클래스에 저장 
            { }

            arrlist.Add(p);

            dataGridView1.Rows.Add(textBox_name.Text, textBox_birth.Text, textBox_tell.Text);
            textBox_name.Clear();
            textBox_birth.Clear();
            textBox_tell.Clear();
            label2.Text = p.Name.ToString();
        }
        private void btn_member_delete_Click(object sender, EventArgs e)
        {
            int index = 0;
            try
            {
                index = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.Remove(dataGridView1.Rows[index]);
                arrlist.RemoveAt(index); // 클래스 삭제 
            }
            catch (Exception)
            {
                MessageBox.Show("선택한 cell이 잘못되었습니다");
            }
        }
        int count = 0;// 횟수 초기화
        private void btn_member_search_Click(object sender, EventArgs e)
        {
            for (int i = count; i < (dataGridView1.RowCount - 1); i++)
            {
                Person temp_p = (Person)arrlist[i];
                if (temp_p.Name == textBox_search.Text)
                {
                    textBox_name.Text = temp_p.Name.ToString();
                    textBox_birth.Text = temp_p.Birth.ToString();
                    textBox_tell.Text = temp_p.Tell.ToString();
                    count++;
                    break;
                }
                else
                {
                    count++;
                }
            }
            // 끝을 알려주는 if문 
            if (count >= (dataGridView1.RowCount - 1))
            {
                MessageBox.Show("더이상 회원 정보가 없습니다");
                count = 0;
            }
        }
        private void btn_member_clear_Click(object sender, EventArgs e)
        {
            textBox_search.Clear();
            textBox_name.Clear();
            textBox_birth.Clear();
            textBox_tell.Clear();
        }
        /*--------------------------------------------------------------메뉴-----------------------------------------------*/
        private void timer1_Tick(object sender, EventArgs e)//현재 시간 표시
        {
            label14.Text = DateTime.Now.ToString();
        }

        private void Memo_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Memo memo = new Memo();
            memo.Show();
        }
        private void inform_ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }

        private void Exit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /*--------------------------------------------------------------재고 관리-----------------------------------------------*/
        private void btn_Inventory_Click(object sender, EventArgs e)
        {
            if (groupBox_Inventory.Visible == false)
            {
                groupBox_Inventory.Visible = true;
            }
            else
            {
                groupBox_Inventory.Visible = false;
            }
            groupBox_order.Visible = false;
            groupBox_member.Visible = false;
            groupBox_Sales2.Visible = false;
            openclosecount = 0;
                       
           
        }
        public void StockAddToList()    //데이터 삽입을 위한 함수
        {
            listview_Stock.BeginUpdate();
            int coffeebeanscount = (50 - iv.SumCoffeeBeans());
            int coffeebeanscountstack =- coffeebeanscount;
            
            ListViewItem lvi1 = new ListViewItem("원두");
            lvi1.SubItems.Add("50");
            lvi1.SubItems.Add("50개당 1통(1kg) 소요, 1잔 당 20g, 원산지: 콜롬비아");
            lvi1.ImageIndex = 0;
            listview_Stock.Items.Add(lvi1);

            ListViewItem lvi2 = new ListViewItem("우유");
            lvi2.SubItems.Add("50");
            lvi2.SubItems.Add("4개당 1통(1L) 소요, 1잔 당 250ml, 원산지: 케이 밀크");
            lvi2.ImageIndex = 0;
            listview_Stock.Items.Add(lvi2);

            ListViewItem lvi3 = new ListViewItem("모카시럽");
            lvi3.SubItems.Add("40");
            lvi3.SubItems.Add("40개당 1통(1L) 소요,1잔 당 25ml, 원산지: 말레이시아");
            lvi3.ImageIndex = 0;
            listview_Stock.Items.Add(lvi3);

            ListViewItem lvi4 = new ListViewItem("카라멜시럽");
            lvi4.SubItems.Add("40");
            lvi4.SubItems.Add("40개당 1통(1L) 소요,1잔 당 25ml, 원산지: 프랑스");
            lvi4.ImageIndex = 0;
            listview_Stock.Items.Add(lvi4);

            ListViewItem lvi5 = new ListViewItem("일회용 컵");
            lvi5.SubItems.Add("100");
            lvi5.SubItems.Add("1개 음료 당 1개(1EA) 소요, 원산지: 중국");
            lvi5.ImageIndex = 0;
            listview_Stock.Items.Add(lvi5);

            ListViewItem lvi6 = new ListViewItem("종이 빨대");
            lvi6.SubItems.Add("100");
            lvi6.SubItems.Add("1컵 당 1(1EA) 소요, 원산지: 중국");
            lvi6.ImageIndex = 0;
            listview_Stock.Items.Add(lvi6);
        }
        private void btn3_search_Click(object sender, EventArgs e)//재고 검색
        {
            int count = listview_Stock.Items.Count;
            if (txt3_search.Text == "")
            {
                MessageBox.Show("검색할 재고명을 입력해주세요!!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            for(int i = 0; i < count; i++)
            {
                if(listview_Stock.Items[i].SubItems[0].Text.Equals(txt3_search.Text) == true)   //문자열을 비교해야하니까(주소가 다르니 문자열 자체를 비교하기 위해서)
                {
                    txt_Stock.Text = listview_Stock.Items[i].SubItems[0].Text;
                    txt_count.Text = listview_Stock.Items[i].SubItems[1].Text;
                    txt_blank.Text = listview_Stock.Items[i].SubItems[2].Text;
                    break;
                }
            }
        }

        private void btn_Sales_Click(object sender, EventArgs e)
        {
            if (groupBox_Sales2.Visible == false)
            {

                groupBox_Sales2.Visible = true;
            }
            else
            {
                groupBox_Sales2.Visible = false;
            }
            groupBox_order.Visible = false;
            groupBox_Inventory.Visible = false;
            groupBox_member.Visible = false;
            openclosecount = 0;



        }

        int americanoSum1 = 0;
        int americanoSum2 = 0;
        int americanoSum3 = 0;
        int iceamericanoSum1 = 0;
        int iceamericanoSum2 = 0;
        int iceamericanoSum3 = 0;
        int cafelatteSum1 = 0;
        int cafelatteSum2 = 0;
        int cafelatteSum3 = 0;


        
        int icecafelatteSum1 = 0;
        int icecafelatteSum2 = 0;
        int icecafelatteSum3 = 0;
        int caramelSum1 = 0;
        int caramelSum2 = 0;
        int caramelSum3 = 0;
        int icecaramelSum1 = 0;
        int icecaramelSum2 = 0;
        int icecaramelSum3 = 0;
        int shotSum1 = 0;
        int shotSum2 = 0;
        int shotSum3 = 0;
        int sizeupSum1 = 0;
        int sizeupSum2 = 0;
        int sizeupSum3 = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < arrlist3.Count; i++)
            {
                MenuOrder temp_s = (MenuOrder)arrlist3[i];
                americanoSum2 += temp_s.americanocount;
                iceamericanoSum2 += temp_s.iceamericanocount;
                cafelatteSum2 += temp_s.cafelattecount;


                icecafelatteSum2 += temp_s.icecafelattecount;
                caramelSum2 += temp_s.caramelcount;
                icecaramelSum2 += temp_s.icecaramelcount;
                shotSum2 += temp_s.shotcount;
                sizeupSum2 += temp_s.sizeupcount;
                
                



            }
            for (int i = 0; i < (arrlist3.Count - 1); i++)
            {
                MenuOrder temp_s = (MenuOrder)arrlist3[i];
                americanoSum3 += temp_s.americanocount;
                iceamericanoSum3 += temp_s.iceamericanocount;
                cafelatteSum3 += temp_s.cafelattecount;



                icecafelatteSum3 += temp_s.icecafelattecount;
                    caramelSum3+= temp_s.caramelcount;
                     icecaramelSum3+=temp_s.icecaramelcount;
                     shotSum3 += temp_s.shotcount;
                     sizeupSum3+=temp_s.sizeupcount;
            }

            //매출 출력 

            americanoSum1 += (americanoSum2 - americanoSum3);
            iceamericanoSum1 += (iceamericanoSum2 - iceamericanoSum3);
            cafelatteSum1 += (cafelatteSum2 - cafelatteSum3);
            icecafelatteSum1 += (iceamericanoSum2 - iceamericanoSum3);
             caramelSum1+=(caramelSum2-caramelSum3);
             icecaramelSum1 += (icecaramelSum2 - icecaramelSum3);
             shotSum1 +=(shotSum2-shotSum3);
             sizeupSum1+=(sizeupSum2-sizeupSum3);

            textBox_Sales2.Text = "(Hot) 아메리카노 :" + americanoSum1.ToString() + "잔\r\n"
                + "(Ice) 아메리카노 :" + iceamericanoSum1.ToString() + "잔\r\n"
                + "카페라떼 :" + cafelatteSum1.ToString() + "잔\r\n"
              + "아이스 카페라떼 :" + icecafelatteSum1.ToString() + "잔\r\n"
           + "카라멜 마키아또 :" + caramelSum1.ToString() + "잔\r\n"
           + "(Ice)카라멜 마키아또 :" + icecaramelSum1.ToString() + "잔\r\n"
           + "샷 추가 :" + shotSum1.ToString() + "개\r\n"
           + "사이즈업:" + sizeupSum1.ToString() + "개\r\n";


            textBox_done.Text =( (Convert.ToInt32(americanoSum1) * 1500)+ (Convert.ToInt32(iceamericanoSum1) * 1500)+ (Convert.ToInt32(cafelatteSum1) * 2000)+ (Convert.ToInt32(icecafelatteSum1) * 2000)+ (Convert.ToInt32(sizeupSum1) * 1000)+ (Convert.ToInt32(caramelSum1) * 2500)+ (Convert.ToInt32(icecaramelSum1) * 2500)+ (Convert.ToInt32(shotSum1) * 500)).ToString();

            // 저장된 값 초기화
           
            americanoSum2 = 0;
            americanoSum3 = 0;
            iceamericanoSum2 = 0;
            iceamericanoSum3 = 0;
            cafelatteSum2 = 0;
            cafelatteSum3 = 0;


            

            icecafelatteSum2 = 0;
            icecafelatteSum3 = 0;
             caramelSum2 = 0;
             caramelSum3 = 0;
             icecaramelSum2 = 0;
             icecaramelSum3 = 0;
             shotSum2 = 0;
             shotSum3 = 0;
             sizeupSum2 = 0;
             sizeupSum3 = 0;





        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            String date = monthCalendar1.SelectionRange.Start.ToShortDateString();
            textBox_Date.Text = date;
        }

       

        private void btn_change_Click(object sender, EventArgs e)//재고 수정
        {
            int count = listview_Stock.Items.Count;
            if (txt_Stock.Text == "" || txt_count.Text == "" || txt_blank.Text =="")
            {
                MessageBox.Show("수정할 재고명,수량,비고를 입력해주세요!", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            for(int i=0; i< count; i++)
            {
                if (listview_Stock.Items[i].SubItems[0].Text.Equals(txt_Stock.Text) == true)
                {
                    listview_Stock.Items[i].SubItems[0].Text = txt_Stock.Text;
                    listview_Stock.Items[i].SubItems[1].Text = txt_count.Text;
                    listview_Stock.Items[i].SubItems[2].Text = txt_blank.Text;
                    break;
                }
            }
        }
        private void btn3_add_Click(object sender, EventArgs e)
        {
            int count = listview_Stock.Items.Count;
            if (txt_Stock.Text == "" || txt_count.Text == "" || txt_blank.Text == "")
            {
                MessageBox.Show("추가할 재고를 입력해주세요!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                listview_Stock.Items.Add(new ListViewItem(txt_Stock.Text));
                for (int i = 0; i < count + 1; i++)//count가 6으로 지정되어있으니까 다음번에 새로운 객체가 들어가기위해 count+1을 해서 7번째에 들어가게 하는 것
                {
                    if (listview_Stock.Items[i].SubItems[0].Text.Equals(txt_Stock.Text) == true)
                    {
                        listview_Stock.Items[i].SubItems.Add(txt_count.Text);
                        listview_Stock.Items[i].SubItems.Add(txt_blank.Text);
                        break;
                    }
                }
            }
        }
    }
}




