using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BTKAkademi_TurnikeOrnek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public clsData data=new clsData();
        private void button2_Click(object sender, EventArgs e)
        {
            hideIcons();

            DateTime dt = DateTime.Now.Date.AddHours(8);
            DateTime lastdt = dt;
            workerCode = txtBarcode.Text;
          
          

            //Barkod bilgisinden kişi bilgisini sorgulama
            string sql = "SELECT * FROM WORKERS WHERE WORKERBARCODE='" + workerCode + "'";
            DataSet ds = new DataSet();
             ds = data.fill(CommandType.Text, sql);
            if (ds.Tables[0].Rows.Count ==0)
            {
                lblStatus.Text = "Geçersiz kart";
                lblStatus.ForeColor = Color.Red;
                showIcons("G", false);
                Update();
                System.Threading.Thread.Sleep(2000);
                lblStatus.Text = "";
                hideIcons();
                Update();
                return;
            }
            else
            {
                workerId = Convert.ToInt16 (ds.Tables[0].Rows[0]["ID"]);
                workerName = ds.Tables[0].Rows[0]["WORKERNAME"].ToString();
                lblWorkerName.Text = workerName;
                MessageBox.Show("Adım 1:Kart geçerliliği kontrol edildi.");
                

            }

            //Son hareket sorgulama
              sql = "SELECT TOP 1 * FROM WORKERTRANSACTIONS WHERE WORKERID="+workerId.ToString()+" AND DATE_>='" + DateTime.Now.ToString("yyyy-MM-dd")+"' ORDER BY DATE_ DESC";
  
            ds = data.fill(CommandType.Text, sql);
              string lastIOType="" ;
            if (ds.Tables[0].Rows.Count>0)
            {
                lastIOType = ds.Tables[0].Rows[0]["IOTYPE"].ToString();
                lastdt = Convert.ToDateTime(ds.Tables[0].Rows[0]["DATE_"]);
            }
            
            if (lastIOType=="G" )
            {
                lblStatus.Text = "Çıkış kaydı bulunamadı.";
                lblStatus.ForeColor = Color.Red;
                Update();
                showIcons("G", false);
                Update();
                System.Threading.Thread.Sleep(2000);
                lblStatus.Text = "";
                hideIcons();
                Update();

                return;
            }
            else
            {
                MessageBox.Show("Adım 2:Son hareketin çıkış olduğu teyyid edildi.");
            }
            if (lastdt !=null)
            {
                dt = lastdt.AddHours(0.3);
            }
            string dtStr = dt.ToString("yyyy-MM-dd HH:mm:ss");
            MessageBox.Show(dtStr);
            lblDate.Text = dtStr;
            sql = "INSERT INTO WORKERTRANSACTIONS (WORKERID,IOTYPE,DATE_,GATEID) VALUES (" + workerId.ToString() + ",'G','" + dtStr + "',1)";
            data.executeNonQuery(CommandType.Text, sql);
            MessageBox.Show("Adım 3:Giriş işlemi gerçekleşti.");

            lblStatus.Text = "Giriş başarılı.";
            lblStatus.ForeColor = Color.Green;
            Update();
            showIcons("G", true);
            Update();
            System.Threading.Thread.Sleep(2000);
            lblStatus.Text = "";
            hideIcons();
            Update();

        }
        private void hideIcons( )
        {
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
            pictureBox3.Visible = true;
            Update();
        }
            private void showIcons(string io,bool status)
        {
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
            pictureBox3.Visible = true;
            Update();
            if (io=="C")
            {
                if (status ==true )
                {
                    panel2.Visible = false;
                    pictureBox3.Visible = false;

                }
                if (status == false)
                {
                    panel1.Visible = false;
                }
            }
            if (io == "G")
            {
                if (status == true)
                {
                    panel4.Visible = false;
                    pictureBox3.Visible = false;

                }
                if (status == false)
                {
                    panel3.Visible = false;
                }
            }
            if (io == "")
            {
                panel1.Visible = true;
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                Update();
            }

        }
        string workerCode = "";
        int workerId;
        string workerName = "";
        DateTime dt;
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideIcons();
            DateTime dt = DateTime.Now.Date.AddHours(9.3);
            DateTime lastdt = dt;
            workerCode = txtBarcode.Text;
   

            //Barkod bilgisinden kişi bilgisini sorgulama
            string sql = "SELECT * FROM WORKERS WHERE WORKERBARCODE='" + workerCode + "'";
            DataSet ds = new DataSet();
            ds = data.fill(CommandType.Text, sql);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Kart bulunamadı");
                return;
            }
            else
            {
                workerId = Convert.ToInt16(ds.Tables[0].Rows[0]["ID"]);
                workerName = ds.Tables[0].Rows[0]["WORKERNAME"].ToString();
                lblWorkerName.Text = workerName;
                MessageBox.Show("Adım 1:Kart geçerliliği kontrol edildi.");
            }

            //Son hareket sorgulama
            sql = "SELECT TOP 1 * FROM WORKERTRANSACTIONS WHERE WORKERID=" + workerId.ToString() + " AND DATE_>='" + DateTime.Now.ToString("yyyy-MM-dd") + "' ORDER BY DATE_ DESC";



            ds = data.fill(CommandType.Text, sql);
            string lastIOType = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                lastIOType = ds.Tables[0].Rows[0]["IOTYPE"].ToString();
                lastdt = Convert.ToDateTime(ds.Tables[0].Rows[0]["DATE_"]);
            }

            if (lastIOType == "C")
            {
                lblStatus.Text = "Zaten dışarıda görünüyorsunuz.";
                lblStatus.ForeColor = Color.Red;
                return;
            }
            else
            {
                MessageBox.Show("Adım 2:Son hareketin giriş olduğu teyyid edildi.");
            }

            if (lastdt != null)
            {
                dt = lastdt.AddHours(0.3);
            }
            string dtStr = dt.ToString("yyyy-MM-dd HH:mm:ss");
            MessageBox.Show(dtStr);
            lblDate.Text = dtStr;
            sql = "INSERT INTO WORKERTRANSACTIONS (WORKERID,IOTYPE,DATE_,GATEID) VALUES (" + workerId.ToString() + ",'C','" + dtStr + "',1)";
            data.executeNonQuery(CommandType.Text, sql);
            MessageBox.Show("Adım 3:Çıkış işlemi gerçekleşti.");
            lblStatus.Text = "Çıkış yapıldı.";

       
            lblStatus.ForeColor = Color.Green;
            Update();
            showIcons("C", true);
            Update();
            System.Threading.Thread.Sleep(2000);
            lblStatus.Text = "";
            hideIcons();
            Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
        
            DateTime dt = DateTime.Now.Date.AddHours(8);
            DateTime lastdt = dt;
            workerCode = txtBarcode.Text;
            string sql;
            //Son hareket sorgulama
            sql = "SELECT TOP 1 * FROM WORKERTRANSACTIONS WHERE WORKERID IN (SELECT ID FROM WORKERS WHERE WORKERBARCODE='" + workerCode + "') AND DATE_>='" + DateTime.Now.ToString("yyyy-MM-dd") + "' ORDER BY DATE_ DESC, ID DESC";
            ds = data.fill(CommandType.Text, sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lastdt = Convert.ToDateTime(ds.Tables[0].Rows[0]["DATE_"]);
            }
            if (lastdt != null)
            {
                dt = lastdt.AddHours(0.3);
            }


            SqlParameter spWorkerBarcode = new SqlParameter("@WORKERBARCODE", SqlDbType.VarChar);
            spWorkerBarcode.Value = workerCode;

            SqlParameter spIOType = new SqlParameter("@IOTYPE", SqlDbType.VarChar);
            spIOType.Value = "G";
            
                 SqlParameter spGateId = new SqlParameter("@GATEID", SqlDbType.Int);
            spGateId.Value = 5;
            SqlParameter spDate = new SqlParameter("@DATE", SqlDbType.DateTime);
            spDate.Value = dt;

            try
            {
                ds.Clear();
                ds.Reset();

                ds=data.fill(CommandType.StoredProcedure, "SP_WORKER_INOUT", spWorkerBarcode, spIOType, spDate, spGateId);
                lblWorkerName.Text = ds.Tables[0].Rows[0]["WORKERNAME"].ToString();
                lblDate.Text =Convert.ToDateTime( ds.Tables[0].Rows[0]["DATE_"]).ToString("yyyy-MM-dd HH:mm:ss");
                lblStatus.Text = "Giriş başarılı.";
                lblStatus.ForeColor = Color.Green;
                Update();
                showIcons("G", true);
                Update();
                System.Threading.Thread.Sleep(2000);
                lblStatus.Text = "";
                hideIcons();
                Update();
            }
            catch (Exception ex)
            {

                lblStatus.Text = ex.Message;
                lblStatus.ForeColor = Color.Red;
                Update();
                showIcons("G", false);
                Update();
                System.Threading.Thread.Sleep(2000);
                lblStatus.Text = "";
                lblDate.Text = "...";
                lblWorkerName.Text = "...";

            }
         


        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
        
            DateTime dt = DateTime.Now.Date.AddHours(8);
            DateTime lastdt = dt;
            workerCode = txtBarcode.Text;
            string sql;
            //Son hareket sorgulama
            sql = "SELECT TOP 1 * FROM WORKERTRANSACTIONS WHERE WORKERID IN (SELECT ID FROM WORKERS WHERE WORKERBARCODE='" + workerCode + "') AND DATE_>='" + DateTime.Now.ToString("yyyy-MM-dd") + "' ORDER BY DATE_ DESC, ID DESC";
            ds = data.fill(CommandType.Text, sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lastdt = Convert.ToDateTime(ds.Tables[0].Rows[0]["DATE_"]);
            }
            if (lastdt != null)
            {
                dt = lastdt.AddHours(0.3);
            }


            SqlParameter spWorkerBarcode = new SqlParameter("@WORKERBARCODE", SqlDbType.VarChar);
            spWorkerBarcode.Value = workerCode;

            SqlParameter spIOType = new SqlParameter("@IOTYPE", SqlDbType.VarChar);
            spIOType.Value = "C";

            SqlParameter spDate = new SqlParameter("@DATE", SqlDbType.DateTime);
            spDate.Value = dt;
            SqlParameter spGateId = new SqlParameter("@GATEID", SqlDbType.Int);
            spGateId.Value = 5;
            try
            {
                ds = data.fill(CommandType.StoredProcedure, "SP_WORKER_INOUT", spWorkerBarcode, spIOType, spDate, spGateId);
                
                
                lblWorkerName.Text = ds.Tables[0].Rows[0]["WORKERNAME"].ToString();
                lblDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DATE_"]).ToString("yyyy-MM-dd HH:mm:ss");
                lblStatus.Text = "Çıkış başarılı.";
                lblStatus.ForeColor = Color.Green;
                showIcons("C", true);
                Update();
                System.Threading.Thread.Sleep(2000);
                lblStatus.Text = "";
                hideIcons();

            }
            catch (Exception ex)
            {

                lblStatus.Text = ex.Message;
                lblStatus.ForeColor = Color.Red;
                showIcons("C", false);
                Update();
               System.Threading.Thread.Sleep(2000);
               lblStatus.Text = "";
                hideIcons();
                Update();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            hideIcons();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            SqlParameter spWorkerBarcode = new SqlParameter("@WORKERBARCODE", SqlDbType.VarChar);
            spWorkerBarcode.Value  = txtBarcode.Text;
            SqlParameter spDate = new SqlParameter("@DATE", SqlDbType.DateTime);
            spDate.Value = DateTime.Now.Date.AddHours(8.1);
            SqlParameter spGateId = new SqlParameter("@GATEID", SqlDbType.Int);
            spGateId.Value = 5;
            SqlParameter spIOType = new SqlParameter("@IOTYPE", SqlDbType.VarChar);
            spIOType.Value = "G";

            DataSet ds = new DataSet();

            try
            {
                ds = data.fill(CommandType.StoredProcedure, "SP_WORKER_INOUT", spWorkerBarcode, spDate, spGateId, spIOType);

                MessageBox.Show(ds.Tables[0].Rows[0]["WORKERNAME"].ToString() + " Giriş işlemi başarılı.");


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        


        }

        private void button6_Click(object sender, EventArgs e)
        {
            data.cs = txtConnectionString.Text;
            DataSet ds = new DataSet();
            ds = data.fill(CommandType.Text, "SELECT top 1 * FROM WORKERS ORDER BY NEWID()");
            MessageBox.Show("Bağlandı");
            workerCode = ds.Tables[0].Rows[0]["WORKERBARCODE"].ToString();
            workerId = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
        }
    }
}
