using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeProgram
{
    public partial class Memo : Form
    {
        private string fileName = "noname.txt";   // 파일 이름
        bool modifyFlag = false;    //문서가 수정되었는 체크하는 modifyFlag 변수
        public Memo()
        {
            InitializeComponent();
        }
        private void rtxtbox_memo_TextChanged(object sender, EventArgs e)
        {
            modifyFlag = true;
            // richtextbox는 텍스트가 수정되면 textchanged 이벤트가 발생합니다.
            // modfiyFlag = true 상태에서 문서가 수정되면 다른 메뉴 클릭 시
            // 반드시 수정된 문서를 저장할 지 확인하는 코드가 들어가야 한다.
        }
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //작업중 파일 처리
            FileProcessBeforeClose();

            rtxtbox_memo.Text = "";
            modifyFlag = false;
            fileName = "noname.txt";
        }
        private void FileProcessBeforeClose()//수정중인 파일을 닫기 전에 어떻게 처리할 지(저장할 지 그냥 닫을 지)
        {
            if(modifyFlag == true)
            {
                DialogResult ans = MessageBox.Show("변경된 내용을 저장하시겠습니까?","저장",MessageBoxButtons.YesNo);
                if(ans == DialogResult.Yes)
                {
                    if (fileName == "noname.txt")//파일 이름을 지정하지 않았다면
                    {
                        if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            StreamWriter sw = File.CreateText(saveFileDialog1.FileName);
                            sw.WriteLine(rtxtbox_memo.Text);
                            sw.Close();
                        }
                    }
                    else//파일 이름이 지정되어 있다면
                    {
                        StreamWriter sw = File.CreateText(fileName);
                        sw.WriteLine(rtxtbox_memo.Text);
                        sw.Close();
                    }
                }
            }
        }
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //현재 열려있는 파일이 수정되었다면 저장할 필요가 있다.
            FileProcessBeforeClose();

            //열려있던 파일에 대한 저장 처리가 끝났으므로
            //새로 파일을 열 수 있도록 다이얼로그를 띄운다.
            openFileDialog1.ShowDialog();
            fileName = openFileDialog1.FileName;
            try
            {
                StreamReader r = File.OpenText(fileName);
                rtxtbox_memo.Text = r.ReadToEnd();

                modifyFlag = false;
                r.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(fileName == "noname.txt")
            {
                saveFileDialog1.ShowDialog();
                fileName = saveFileDialog1.FileName;
            }
            StreamWriter sw = File.CreateText(fileName);
            sw.WriteLine(rtxtbox_memo.Text);

            modifyFlag = false;
            sw.Close();
        }
        private void EndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //작업중 파일 처리
            FileProcessBeforeClose();
            Close();
        }
    }
}
