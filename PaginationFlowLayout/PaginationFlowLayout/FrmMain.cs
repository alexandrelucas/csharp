using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaginationFlowLayout
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private List<Button> buttons = new List<Button>();
        private int currentPage = 1;
        private int btnPerPage = 16;
        private int countPages = 0;

        private void FrmMain_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < 100; i++)
            {
                var btn = new Button();
                btn.Text = $"Button {i}";
                btn.Name = $"btn_{i}";
                btn.Size = new Size(60, 40);
                btn.Click += Btn_Click;
                buttons.Add(btn);
                if (i < btnPerPage)
                    flowLayoutDisplay.Controls.Add(btn);
            }
            UpdateStatus();

        }
        private void UpdateStatus()
        {
            countPages = (int)Math.Ceiling(Convert.ToDecimal(buttons.Count) / Convert.ToDecimal(btnPerPage));
            //    1/7
            lblStatus.Text = $"Page {currentPage}/{countPages}";

            if (currentPage == 1)
                btnBack.Enabled = false;
            else if (currentPage == countPages)
            {
                btnBack.Enabled = true;
                btnNext.Enabled = false;
            }
            else
            {
                btnBack.Enabled = true;
                btnNext.Enabled = true;
            }

            if (countPages <= 1)
                btnNext.Enabled = false;

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btnItem = (Button)sender;
            btnItem.Text = btnItem.Name;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            flowLayoutDisplay.Controls.Clear();
            currentPage--;
            for (int i = (currentPage - 1) * btnPerPage; i < (currentPage * btnPerPage); i++)
            {
                if (i == btnPerPage - 1)
                    btnBack.Enabled = false;
                flowLayoutDisplay.Controls.Add(buttons[i]);
            }
            UpdateStatus();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            flowLayoutDisplay.Controls.Clear();
            currentPage++;
            for (int i = (currentPage - 1) * btnPerPage; i < (currentPage * btnPerPage); i++)
            {

                if (i < buttons.Count)
                    flowLayoutDisplay.Controls.Add(buttons[i]);
            }
            UpdateStatus();
        }
    }
}
