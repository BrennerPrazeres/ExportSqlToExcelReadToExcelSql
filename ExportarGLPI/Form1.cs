using ClosedXML.Excel;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ExportarGLPI
{
    public partial class Form1 : Form
    {
        private BackgroundWorker BgwBtnCrm { get; set; }
        private BackgroundWorker BgwBtnXml { get; set; }
        public Form1()
        {
            InitializeComponent();

            this.BgwBtnCrm = new BackgroundWorker();
            this.BgwBtnCrm.DoWork += BgwBtnCrm_DoWork;
            this.BgwBtnCrm.RunWorkerCompleted += BgwBtnCrm_RunWorkerCompleted;

            this.BgwBtnXml = new BackgroundWorker();
            this.BgwBtnXml.DoWork += BgwBtnXml_DoWork;
            this.BgwBtnXml.RunWorkerCompleted += BgwBtnXml_RunWorkerCompleted;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dataTable = ObterGlpi();
            using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(@"\\dallas\tmp\Backlog TI.xlsx")))
            {
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("Backlog TI");
                excelWorksheet.Cells["A1"].LoadFromDataTable(dataTable, true);
                excelPackage.Save();
                MessageBox.Show("Executado com Sucesso!");
            }
        }

        private DataTable ObterGlpi()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection mySqlConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ToString()))
            {
                try
                {
                    mySqlConnection.Open();

                    string mSQL = @"use glpi;

                    select glpi_tickets.id as numero_chamado,
                           '' as referencia,
                           'Classificar' as tipo,
                           ifnull(concat(ua.firstname, ' ', ua.realname), 'Não Definido') as tecnico,
                           case glpi_tickets.status
                            when 1 then 'Não Iniciado'
                            when 2 then 'Em Andamento'
                            when 3 then 'Em Andamento'
                            when 4 then 'Não Iniciado'
                            when 5 then 'Finalizado'
                            when 6 then 'Finalizado'
                           end as status,
                           '0' as seq,
                           '0' as sequencia,
                           5 as prioridade,
                           glpi_tickets.name as titulo,
                           date_format(glpi_tickets.date, '%d/%m/%Y' ) as data_abertura,
                           glpi_groups.name as area,
                           ifnull(concat(ur.firstname, ' ', ur.realname), 'Não Definido') as requerente,
                           0 as qtd_horas,
                           '00/00/0000' as data_prev_entrega,
                           '00/00/0000' as data_inicio,
                           '00/00/0000' as data_homologacao,
                           '00/00/0000' as data_termino,
                           glpi_tickets.content as descricao

                      from glpi_tickets
                           left join glpi_tickets_users req on glpi_tickets.id = req.tickets_id
                                                           and 1               = req.type

                           left join glpi_tickets_users ate on glpi_tickets.id = ate.tickets_id
                                                           and 2               = ate.type


                           left join glpi_users ur on req.users_id = ur.id

                           left join glpi_users ua on ate.users_id = ua.id

                           left join glpi_groups_tickets on glpi_tickets.id = glpi_groups_tickets.tickets_id
                           left join glpi_groups on glpi_groups_tickets.groups_id = glpi_groups.id
                     where glpi_tickets.status not in (5,6)
                        -- and glpi_tickets.status in (1,2,3,4)
                         -- and glpi_tickets.id > 33116
                      --   and ua.firstname in ('Alexandre', 'Brenner', 'Carlos', 'Francisco', 'Marcelo', 'Marcos', 'Toni')
                      and glpi_groups.name = 'Desenvolvimento'

                    group by glpi_tickets.id, ua.firstname, ua.realname,
                             glpi_tickets.status, glpi_tickets.name, glpi_tickets.date,
                             glpi_groups.name, ur.firstname, ur.realname,
                             glpi_tickets.content
                    order by glpi_tickets.id;";

                    MySqlCommand cmd = new MySqlCommand(mSQL, mySqlConnection);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dataTable);
                }
                catch (MySqlException msqle)
                {
                    MessageBox.Show("Erro de acesso ao MySQL : " + msqle.Message, "Erro");
                }
                finally
                {
                    mySqlConnection.Close();
                }
            }

            return dataTable;
        }

        private void btnCrm_Click(object sender, EventArgs e)
        {
            btnCrm.Enabled = false;
            BgwBtnCrm.RunWorkerAsync();
        }

        private void BgwBtnCrm_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var xls = new XLWorkbook(@"C:\Fontes\C#\ExportarGLPI\ExportarGLPI\bin\Debug\Crm.xlsx");
                var planilha = xls.Worksheets.First(w => w.Name == "Planilha1");
                var totalLinhas = planilha.Rows().Count();
                for (int l = 2; l <= totalLinhas; l++)
                {
                    DataTable dt = Crm.SelectCrm(planilha.Cell($"A{l}").Value.ToString());

                    if (dt.Rows.Count > 0)
                    {
                        Crm.UpdateTbCrm(planilha.Cell($"A{l}").Value.ToString(), planilha.Cell($"B{l}").Value.ToString());
                    }
                    else
                    {
                        Crm.InsertCrm(planilha.Cell($"A{l}").Value.ToString(), planilha.Cell($"B{l}").Value.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao acessar os dados: " + ex.Message);
            }
        }

        private void BgwBtnXml_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DataTable xml = Crm.SelectXmlNcr();

                if (xml.Rows.Count > 0)
                {
                    foreach (DataRow dr in xml.Rows)
                    {
                        Crm.UpdateXml(dr["CHAVEACESSO"].ToString(), dr["XML"].ToString(), dr["XML_CA"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao acessar os dados: " + ex.Message);
            }
        }

        private void BgwBtnCrm_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(string.Format("{0} - {1}", e.Error.Message, e.Error.StackTrace), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MessageBox.Show("Executado com sucesso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnCrm.Enabled = true;
            GC.Collect();
        }

        private void BgwBtnXml_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(string.Format("{0} - {1}", e.Error.Message, e.Error.StackTrace), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MessageBox.Show("Executado com sucesso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnResolverXml.Enabled = true;
            GC.Collect();
        }

        private void btnResolverXml_Click(object sender, EventArgs e)
        {
            btnResolverXml.Enabled = false;
            BgwBtnXml.RunWorkerAsync();
        }
    }
}
