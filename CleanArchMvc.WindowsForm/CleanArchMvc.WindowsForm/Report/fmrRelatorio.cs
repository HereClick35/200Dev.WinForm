using CleanArchMvc.WindowsForm.Classes;
using CleanArchMvc.WindowsForm.Entity;
using CleanArchMvc.WindowsForm.Services;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CleanArchMvc.WindowsForm.Report
{
    public partial class fmrRelatorio : Form
    {
        public fmrRelatorio()
        {
            InitializeComponent();            
        }

        public string NomeReport { get; set; }
        public int idCompra { get; set; }
        private void fmrRelatorio_Load(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource();            
            DataTable dt = new DataTable();
            
            rds.Name = "datasetoficial";

            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.EnableExternalImages = true;

            reportViewer1.DataBindings.Clear();
            reportViewer1.LocalReport.DataSources.Clear();

            switch (NomeReport.ToString())
            {
                case "relanimal":
                    {   
                        List<Animal> lst = new List<Animal>();
                        lst.AddRange(animalService.ListaAnimal().ToList());
                        //lst.Add(new Animal() { Id = 1, Descricao = "Porco", Preco = 15 });
                        dt = CollectionHelper.ConvertTo<Animal>(lst);
                        break;
                    }
                case "relpecuarista":
                    {
                        List<Pecuarista> lst = new List<Pecuarista>();
                        lst.AddRange(pecuaristaService.ListaPecuarista().ToList());
                        dt = CollectionHelper.ConvertTo<Pecuarista>(lst);
                        break;
                    }
                case "relcompra":
                    {
                        List<CompraGadoGrid> lst = new List<CompraGadoGrid>();
                        lst.AddRange(compraService.ListaCompra().ToList());
                        dt = CollectionHelper.ConvertTo<CompraGadoGrid>(lst);
                        break;
                    }
                case "relcompradetalhe":
                    {
                        CompraGado lst = new CompraGado();

                        List<CompraGadoGrid> lstGrid = new List<CompraGadoGrid>();
                        lst = compraService.GetCompra(idCompra);
                        lstGrid.Add(new CompraGadoGrid()
                        {
                            dataEntrega = lst.dataEntrega,
                            Id = lst.Id,
                            Pecuarista = lst.Pecuarista.Name,
                            PecuaristaId = lst.PecuaristaId,
                            ValorCompra = lst.valorCompra
                        });
                        dt = CollectionHelper.ConvertTo<CompraGadoGrid>(lstGrid);
                        idCompra = 0;
                        ReportDataSource rdsD = new ReportDataSource();
                        DataTable dtD = CollectionHelper.ConvertTo<CompraGadoItem>(lst.items);
                        rdsD.Name = "datasetdetalheoficial";
                        rdsD.Value = dtD;
                        reportViewer1.LocalReport.DataSources.Add(rdsD);
                        break;
                    }

            }

            rds.Value = dt;


                       
            
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.ReportEmbeddedResource = string.Format("CleanArchMvc.WindowsForm.Report.{0}.rdlc", NomeReport.ToString());
            reportViewer1.RefreshReport();

            
        }
    }


    public class CollectionHelper
    {
        private CollectionHelper()
        { }
        public static DataTable ConvertTo<T>(IList<T> list)
        {
            DataTable table = CreateTable<T>();
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
            foreach (T item in list)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }
                table.Rows.Add(row);
            }
            return table;
        }
        public static DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            return table;
        }
    }
}

