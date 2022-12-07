using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using CustomControl;
using System.IO;
using Utilities;
using System.Diagnostics;
using System.Threading;

namespace Aplicacion.Configuracion.Backup
{
    public partial class FrmBackup : Form
    {
        private StringBuilder sbPG_dumpPath;

        private String strPG_dumpPath;

        private string strInstallLocation;

        private string server;

        private string port;

        private string Pass;

        private string dataBase;

        private Thread miThread;

        private OptionPane miOption;

        private bool postgresServicio;

        public FrmBackup()
        {
            InitializeComponent();
            this.lblMensaje.Text = "";

            this.sbPG_dumpPath = new StringBuilder();
            this.strPG_dumpPath = String.Empty;
            this.strInstallLocation = string.Empty;
            this.server = string.Empty;
            this.port = string.Empty;
            this.Pass = string.Empty;
            this.dataBase = string.Empty;
            this.postgresServicio = false;
        }

        private void FrmBackup_Load(object sender, EventArgs e)
        {
            try
            {
                this.server = AppConfiguracion.ValorSeccion("server");
                this.port = AppConfiguracion.ValorSeccion("port");
                this.Pass = AppConfiguracion.ValorSeccion("password");
                this.dataBase = AppConfiguracion.ValorSeccion("dataBase");

                this.strPG_dumpPath = AppConfiguracion.ValorSeccion("rutaInstalPostresql");
                if (this.strPG_dumpPath == string.Empty)
                {
                    this.lblMensaje.ForeColor = Color.Black;
                    this.lblMensaje.Text = "Espere a que se identifique la base de datos...";
                }
                if (AppConfiguracion.ValorSeccion("rutaCopyBackup") != "")
                {
                    this.txtRuta.Text = AppConfiguracion.ValorSeccion("rutaCopyBackup") + "Backup_" + this.dataBase + "_" + 
                    DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + 
                    DateTime.Now.Minute + "_" + DateTime.Now.Second + ".backup";
                }

                /*miOption = new OptionPane();
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                miOption.FrmProgressBar.Closed_ = true;
                miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");*/
                //this.Enabled = false;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                miThread = new Thread(CargarDatos);
                miThread.Start();
                
                //postgresServicio = false;
               /* ServiceController[] servicios = ServiceController.GetServices();
                foreach (ServiceController servicio in servicios)
                {
                    if (servicio.ServiceName.Contains("postgre") == true)
                    {
                        postgresServicio = true;
                        break;
                    }
                }
                if (postgresServicio)
                {
                    PG_DumpExeRutaInstall();
                    AppConfiguracion.SaveConfiguration("rutaInstalPostresql", this.strPG_dumpPath);
                    //PG_DumpExePath();
                   // if (strPG_dumpPath.Length != 0 && this.txtRuta.Text != "")
                   // {
                     //   //this.btnBuscarRuta.Enabled = true;
                       // this.btnBackup.Enabled = true;
                    //}
                }*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnBuscarRuta_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Title = "Ubicación para el archivo";
                save.Filter = "Backup File|*.backup";
                save.FilterIndex = 0;
                //save.RestoreDirectory = true;
                save.FileName = "Backup_" + this.dataBase + "_" + 
                DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + 
                DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    this.txtRuta.Text = save.FileName;
                    string ruta = save.FileName.Substring(0, save.FileName.IndexOf("Backup"));
                    AppConfiguracion.SaveConfiguration("rutaCopyBackup", save.FileName.Substring(0, save.FileName.IndexOf("Backup")));
                    this.btnBackup.Enabled = true;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter("DBBackup.bat");
                StringBuilder strSB = new StringBuilder(/*strPG_dumpPath*/);
              //  if (strSB.Length != 0)
                //{
                    strSB.Append("@echo off\n");
                    strSB.Append("setlocal\n");
                    strSB.Append("set PGPASSWORD=" + this.Pass + "\n");
                    strSB.Append("REM Run psql\n");
                    strSB.Append("\"");
                    strSB.Append(this.strPG_dumpPath);
                    strSB.Append("pg_dump.exe");
                    strSB.Append("\" ");
                    strSB.Append("-i -h " + this.server + " -p " + this.port + " -U postgres -F c -b -v -f ");
                    strSB.Append("\"" + this.txtRuta.Text + "\"");
                    strSB.Append(" " + this.dataBase + " \n");
                    strSB.Append("pause exit[/quote]\n");
                    strSB.Append("endlocal\n");

                   // strSB.Append("pg_dump.exe --host " + server + " --port " + port + " --username postgres --format custom --blobs --verbose --file ");
                   // strSB.Append("\"" + this.txtRuta.Text + "\"");
                   // strSB.Append(" \"" + dataBase + "\r\n\r\n");
                    sw.WriteLine(strSB);
                    sw.Dispose();
                    sw.Close();
                    Process processDB = Process.Start("DBBackup.bat");
                    do
                    {//dont perform anything
                    }
                    while (!processDB.HasExited);
                    {
                        OptionPane.MessageInformation("El proceso culmino con éxito.");
                    }
                    if (File.Exists("DBBackup.bat"))
                    {
                        File.Delete("DBBackup.bat");
                    }
               // }
            }
            catch { }
        }


        private void CargarDatos()
        {
            try
            {
                ServiceController[] servicios = ServiceController.GetServices();
                foreach (ServiceController servicio in servicios)
                {
                    if (servicio.ServiceName.Contains("postgre") == true)
                    {
                        postgresServicio = true;
                        break;
                    }
                }
                if (postgresServicio)
                {
                    PG_DumpExeRutaInstall();
                    AppConfiguracion.SaveConfiguration("rutaInstalPostresql", this.strPG_dumpPath);
                }
                if (this.InvokeRequired)
                    this.Invoke(new Action(Finalizar));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                if (this.InvokeRequired)
                    this.Invoke(new Action(Finalizar));
            }
        }

        private void Finalizar()
        {
            if (strPG_dumpPath == string.Empty)
            {
                this.lblMensaje.ForeColor = Color.Red;
                this.lblMensaje.Text = "No se encontró la base de datos.";
            }
            else
            {
                this.btnBuscarRuta.Enabled = true;
                this.lblMensaje.Text = "";
            }
            if (strPG_dumpPath.Length != 0 && this.txtRuta.Text != "")
            {
                this.btnBackup.Enabled = true;
                this.lblMensaje.Text = "";
            }
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           //this.Enabled = true;
           /* miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
            miOption.FrmProgressBar.Closed_ = false;
            miOption.FrmProgressBar.Close();*/
        }

        private void PG_DumpExeRutaInstall()
        {
            try
            {
                if (sbPG_dumpPath.Length == 0)
                {
                    //string strPG_dumpPath = string.Empty;
                    if (strPG_dumpPath == string.Empty)
                    {
                        strPG_dumpPath = LookForFile("pg_dump.exe");
                       /* if (strPG_dumpPath == string.Empty)
                        {
                            this.lblMensaje.Text = "No se encontró la base de datos.";
                        }
                        else
                        {
                            this.lblMensaje.Text = "";
                        }*/
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void PG_DumpExePath()
        {
            try
            {
                // Do not change lines / spaces b/w words.
                if (!(strPG_dumpPath == string.Empty))
                {
                    //string strPG_dumpPath = string.Empty;
                   /* if (strPG_dumpPath == string.Empty)
                    {
                        strPG_dumpPath = LookForFile("pg_dump.exe");
                        if (strPG_dumpPath == string.Empty)
                        {
                            this.lblMensaje.Text = "No se encontró la base de datos.";
                            //MessageBox.Show("Postgres is not installed");
                        }
                        else
                        {
                            this.lblMensaje.Text = "";
                        }
                    }*/

                    int a = strPG_dumpPath.IndexOf(":\\", 0);
                    a = a + 2;
                    string strSub = strPG_dumpPath.Substring(0, (a - 2));
                    strPG_dumpPath = strPG_dumpPath.Substring(a, (strPG_dumpPath.Length - a));

                    StringBuilder sbSB1 = new StringBuilder(strPG_dumpPath);
                    sbSB1.Replace("\\", "\r\n\r\ncd ");

                    StringBuilder sbSB2 = new StringBuilder("cd /D ");
                    sbSB2.Append(strSub);
                    sbSB2.Append(":\\");

                    sbSB1 = sbSB2.Append(sbSB1);
                    sbSB1 = sbSB1.Remove((sbSB1.Length - 3), 3);
                    sbPG_dumpPath = sbSB1;
                    strPG_dumpPath = sbSB1.ToString();
                }
            }
            catch (Exception ex)
            { }
        }

        private string LookForFile(string strFileName)
        {
            string strPG_dumpPath = string.Empty;
            try
            {
                DriveInfo[] drives = DriveInfo.GetDrives();

                foreach (DriveInfo drive in drives)
                {
                    strPG_dumpPath = performFileSearchTask(drive.Name, strFileName);
                    if (strPG_dumpPath.Length != 0)
                        break;
                }

            }
            catch (Exception ex)
            { }
            return strPG_dumpPath;
        }

        private string performFileSearchTask(string dirName, string strfileName)
        {
            try
            {
                if (strPG_dumpPath.Length == 0)
                {
                    try
                    {

                        foreach (string ddir in Directory.GetDirectories(dirName))
                        {
                            System.Security.Permissions.FileIOPermission ReadPermission =
                                new System.Security.Permissions.FileIOPermission(System.Security.Permissions.FileIOPermissionAccess.Write, ddir);
                            if (System.Security.SecurityManager.IsGranted(ReadPermission))
                            {
                                try
                                {
                                    foreach (string dfile in Directory.GetFiles(ddir, strfileName))
                                    {
                                        strPG_dumpPath = ddir + "\\";
                                        if (strPG_dumpPath.Length > 0)
                                        {
                                            strInstallLocation = strPG_dumpPath;
                                            break;
                                        }
                                    }
                                    if (strPG_dumpPath.Length == 0)
                                        performFileSearchTask(ddir, strfileName);
                                }
                                catch (Exception ex)
                                { }
                            }
                            if (strPG_dumpPath != string.Empty)
                                break;
                        }
                    }
                    catch (Exception ex)
                    { }

                }

            }
            catch (Exception ex)
            { }
            return strPG_dumpPath;
        }

    }
}