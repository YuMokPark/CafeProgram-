using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeProgram
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void txt_Pw_KeyDown(object sender, KeyEventArgs e)  
        {   //pw taxtbox에 Enter가 입력되면 로그인 버튼 클릭 이벤트 호출
            if (e.KeyCode == Keys.Enter)
            {
                btn_login_Click(sender, e);
                btn_login.Select();
            }
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            string Id = txt_Id.Text;
            string Pw = txt_Pw.Text;

            if (EmptyCheck())
            {
                if (Id == "박유목" && Pw == "1234")
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    txt_Result.Text = "사용자명과 비밀번호가 알맞지 않습니다.";
                }
            }
        }
        
        private bool EmptyCheck()   //Id,Pw 빈 값 처리.
        {
            if(String.IsNullOrEmpty(txt_Id.Text))
            {
                txt_Result.Text = "아이디를 입력해주세요.";
                return false;
            }
            else if(String.IsNullOrEmpty(txt_Pw.Text))
            {
                txt_Result.Text = "비밀번호를 입력해주세요.";
                return false;
            }
            return true;
        }

        private void bnt_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
