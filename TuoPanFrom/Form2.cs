using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuoPanFrom
{
    public partial class Form2 : Form
    {
        private static Form2 frm = null;
        private Form2()
        {
            InitializeComponent();
            dataGridView1.DataSource = Models;
            dataGridView1.Columns[0].HeaderCell.Value = "系统服务名";
            dataGridView1.Columns[1].HeaderCell.Value = "显示名";
            dataGridView1.Columns[1].Width = 125;
            dataGridView1.Columns[2].HeaderCell.Value = "服务状态";
            dataGridView1.ReadOnly = true;
            style();
        }

        #region 单例
        public static Form2 CreateInstrance(List<Form2Entity> list)
        {
            if (frm == null || frm.IsDisposed)
            {
                Models = list;
                frm = new Form2();
            }   
            return frm;
        }

        #endregion

        #region DataGridVeiw Style
        private void style()
        {
           
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;//211, 223, 240
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.RowTemplate.ReadOnly = true;
        }
        #endregion

        #region 窗口拖动
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }
        #endregion

        #region 事件
        private void button1_Click(object sender, EventArgs e)
        {

            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                int i = this.dataGridView1.CurrentRow.Index;
                SelectEntity = (Form2Entity)dataGridView1.Rows[i].DataBoundItem;
                //Form1 form1 = new Form1(SelectEntity);
                Form1 f1 = (Form1)this.Owner;
                f1.Get(SelectEntity);
                this.Close();
                //this.dataGridView1.SelectedRows[0].Cells["行"].Value.ToString();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2Entity entity = new Form2Entity();
            entity = Models.Find(h => h.PId.ToString() == textBox1.Text);
            if (entity == null)
            {
                MessageBox.Show("搜索的服务不存在");
                return;
            }
            foreach (DataGridViewRow dgvr in dataGridView1.Rows)
            {

                SelectEntity = (Form2Entity)dgvr.DataBoundItem;
                if (entity.PId == SelectEntity.PId)
                {
                    dataGridView1.ClearSelection();
                    dgvr.Selected = true;
                    dataGridView1.CurrentCell = dgvr.Cells[1];
                    return;
                }
            }
        }
        #endregion

        #region 属性
        public static List<Form2Entity> Models { get; set; }

        Form2Entity SelectEntity = new Form2Entity();
        #endregion
    }
}
