/*
 * <Credits>
 * Base Code: Montesboogey
 * New Functions: Jairo Barreto
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MuDownloader
{
    public partial class MuDownloader : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        string serverHost = "http://localhost/downloader/";
        string fileClienteCompleto;
        string fileClienteNoSound;
        string fileClientePatch;
        string tamanhoClienteCompleto;
        string tamanhoClienteNoSound;
        string tamanhoClientePatch;
        int idCliente = 0;

        public MuDownloader()
        {
            InitializeComponent();
            downloadInfos.RunWorkerAsync();
        }
        
        private void Form1_MouseDown(object sender,
        System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        // CLOSE BTN
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeBtn_MouseEnter(object sender, EventArgs e)
        {
            closeBtn.BackgroundImage = Properties.Resources.close2;
        }

        private void closeBtn_MouseLeave(object sender, EventArgs e)
        {
            closeBtn.BackgroundImage = Properties.Resources.close1;
        }

        // MINIMIZE BTN
        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void minimizeBtn_MouseEnter(object sender, EventArgs e)
        {
            minimizeBtn.BackgroundImage = Properties.Resources.minimize2;
        }

        private void minimizeBtn_MouseLeave(object sender, EventArgs e)
        {
            minimizeBtn.BackgroundImage = Properties.Resources.minimize1;
        }

        // DELETE FILE
        static bool deletarArquivo(string f)
        {
            try
            {
                File.Delete(f);
                return true;
            }
            catch (IOException)
            {
                return false;
            }
        }

        // LEITURA DAS INFORMAÇÕES NA HOSPEDAGEM
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string Server = this.serverHost;

                XDocument serverXml = XDocument.Load(@Server + "downloader.xml");

                foreach (XElement downloadCompleto in serverXml.Descendants("ClienteCompleto"))
                {
                    this.fileClienteCompleto = downloadCompleto.Element("file").Value;
                    this.tamanhoClienteCompleto = downloadCompleto.Element("tamanho").Value;
                }

                foreach (XElement downloadSimples in serverXml.Descendants("ClienteNoSound"))
                {
                    this.fileClienteNoSound = downloadSimples.Element("file").Value;
                    this.tamanhoClienteNoSound = downloadSimples.Element("tamanho").Value;
                }

                foreach (XElement downloadPatch in serverXml.Descendants("ClientePatch"))
                {
                    this.fileClientePatch = downloadPatch.Element("file").Value;
                    this.tamanhoClientePatch = downloadPatch.Element("tamanho").Value;
                }
            }
            catch (Exception ex)
            {
                this.progressoTxt.Text = ex.Message;
            }
            
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            progressoTxt.ForeColor = System.Drawing.Color.Silver;
            progressoTxt.Text = "Baixando Informações...";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.progressoTxt.Text = e.Error.Message;
            }
            else if (e.Cancelled)
            {
                this.progressoTxt.Text = "Download Cancelado!";
            }
        }

        // DOWNLOAD CLIENTE COMPLETO
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string Server = this.serverHost;
                string Root = AppDomain.CurrentDomain.BaseDirectory;

                XDocument serverXml = XDocument.Load(@Server + "downloader.xml");

                foreach (XElement update in serverXml.Descendants("ClienteCompleto"))
                {
                    string file = update.Element("file").Value;
                    string sUrlToReadFileFrom = Server + file;
                    string sFilePathToWriteFileTo = Root + file;

                    if (File.Exists(file))
                    {
                        deletarArquivo(file);
                    }

                    Uri url = new Uri(sUrlToReadFileFrom);
                    System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                    System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                    response.Close();

                    Int64 iSize = response.ContentLength;

                    Int64 iRunningByteTotal = 0;

                    using (System.Net.WebClient client = new System.Net.WebClient())
                    {
                        using (System.IO.Stream streamRemote = client.OpenRead(new Uri(sUrlToReadFileFrom)))
                        {
                            using (Stream streamLocal = new FileStream(sFilePathToWriteFileTo, FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                int iByteSize = 0;
                                byte[] byteBuffer = new byte[iSize];
                                while ((iByteSize = streamRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
                                {
                                    streamLocal.Write(byteBuffer, 0, iByteSize);
                                    iRunningByteTotal += iByteSize;

                                    double dIndex = (double)(iRunningByteTotal);
                                    double dTotal = (double)byteBuffer.Length;
                                    double dProgressPercentage = (dIndex / dTotal);

                                    int iProgressPercentage = (int)(dProgressPercentage * 100);

                                    downloadClienteCompleto.ReportProgress(iProgressPercentage);
                                }

                                streamLocal.Close();
                            }

                            streamRemote.Close();
                        }
                    }

                }//foreach
            }
            catch (Exception ex)
            {
                this.progressoTxt.Text = ex.Message;
            }
        }

        private void backgroundWorker2_ProgressChanged2(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            progressoTxt.ForeColor = System.Drawing.Color.Silver;
            progressoTxt.Text = string.Concat("Fazendo Download: ", e.ProgressPercentage, "%"," => ", fileClienteCompleto);
        }

        private void backgroundWorker2_RunWorkerCompleted2(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.progressoTxt.Text = e.Error.Message;
            }
            else if (e.Cancelled)
            {
                this.progressoTxt.Text = "Download Offline!";
            }
            else
            {
                this.progressoTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(203)))));
                progressoTxt.Text = "Download CLIENTE COMPLETO finalizado.";
                this.downloadBtn.Enabled = true;

                if (checkAutoExe.Checked)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(this.fileClienteCompleto);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        this.progressoTxt.Text = ex.Message;
                    }
                }
                
            }
        }

        // DOWNLOAD CLIENTE SEM SOM
        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string Server = this.serverHost;
                string Root = AppDomain.CurrentDomain.BaseDirectory;

                XDocument serverXml = XDocument.Load(@Server + "downloader.xml");

                foreach (XElement update in serverXml.Descendants("ClienteNoSound"))
                {
                    string file = update.Element("file").Value;
                    string sUrlToReadFileFrom = Server + file;
                    string sFilePathToWriteFileTo = Root + file;

                    if (File.Exists(file))
                    {
                        deletarArquivo(file);
                    }

                    Uri url = new Uri(sUrlToReadFileFrom);
                    System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                    System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                    response.Close();

                    Int64 iSize = response.ContentLength;

                    Int64 iRunningByteTotal = 0;

                    using (System.Net.WebClient client = new System.Net.WebClient())
                    {
                        using (System.IO.Stream streamRemote = client.OpenRead(new Uri(sUrlToReadFileFrom)))
                        {
                            using (Stream streamLocal = new FileStream(sFilePathToWriteFileTo, FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                int iByteSize = 0;
                                byte[] byteBuffer = new byte[iSize];
                                while ((iByteSize = streamRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
                                {
                                    streamLocal.Write(byteBuffer, 0, iByteSize);
                                    iRunningByteTotal += iByteSize;

                                    double dIndex = (double)(iRunningByteTotal);
                                    double dTotal = (double)byteBuffer.Length;
                                    double dProgressPercentage = (dIndex / dTotal);

                                    int iProgressPercentage = (int)(dProgressPercentage * 100);

                                    downloadClienteSemSom.ReportProgress(iProgressPercentage);
                                }

                                streamLocal.Close();
                            }

                            streamRemote.Close();
                        }
                    }

                }//foreach
            }
            catch (Exception ex)
            {
                this.progressoTxt.Text = ex.Message;
            }
        }

        private void backgroundWorker3_ProgressChanged3(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            progressoTxt.ForeColor = System.Drawing.Color.Silver;
            progressoTxt.Text = string.Concat("Fazendo Download: ", e.ProgressPercentage, "%", " => ", fileClienteNoSound);
        }

        private void backgroundWorker3_RunWorkerCompleted3(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.progressoTxt.Text = e.Error.Message;
            }
            else if (e.Cancelled)
            {
                this.progressoTxt.Text = "Download Offline!";
            }
            else
            {
                this.progressoTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(203)))));
                progressoTxt.Text = "Download CLIENTE SEM SOM finalizado.";
                this.downloadBtn.Enabled = true;

                if (checkAutoExe.Checked)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(this.fileClienteNoSound);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        this.progressoTxt.Text = ex.Message;
                    }
                }
            }
        }

        // DOWNLOAD PATCH
        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string Server = this.serverHost;
                string Root = AppDomain.CurrentDomain.BaseDirectory;

                XDocument serverXml = XDocument.Load(@Server + "downloader.xml");

                foreach (XElement update in serverXml.Descendants("ClientePatch"))
                {
                    string file = update.Element("file").Value;
                    string sUrlToReadFileFrom = Server + file;
                    string sFilePathToWriteFileTo = Root + file;

                    if (File.Exists(file))
                    {
                        deletarArquivo(file);
                    }

                    Uri url = new Uri(sUrlToReadFileFrom);
                    System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                    System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                    response.Close();

                    Int64 iSize = response.ContentLength;

                    Int64 iRunningByteTotal = 0;

                    using (System.Net.WebClient client = new System.Net.WebClient())
                    {
                        using (System.IO.Stream streamRemote = client.OpenRead(new Uri(sUrlToReadFileFrom)))
                        {
                            using (Stream streamLocal = new FileStream(sFilePathToWriteFileTo, FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                int iByteSize = 0;
                                byte[] byteBuffer = new byte[iSize];
                                while ((iByteSize = streamRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
                                {
                                    streamLocal.Write(byteBuffer, 0, iByteSize);
                                    iRunningByteTotal += iByteSize;

                                    double dIndex = (double)(iRunningByteTotal);
                                    double dTotal = (double)byteBuffer.Length;
                                    double dProgressPercentage = (dIndex / dTotal);

                                    int iProgressPercentage = (int)(dProgressPercentage * 100);

                                    downloadPatch.ReportProgress(iProgressPercentage);
                                }

                                streamLocal.Close();
                            }

                            streamRemote.Close();
                        }
                    }

                }//foreach
            }
            catch (Exception ex)
            {
                this.progressoTxt.Text = ex.Message;
            }
        }

        private void backgroundWorker4_ProgressChanged4(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            progressoTxt.ForeColor = System.Drawing.Color.Silver;
            progressoTxt.Text = string.Concat("Fazendo Download: ", e.ProgressPercentage, "%", " => ", fileClientePatch);
        }

        private void backgroundWorker4_RunWorkerCompleted4(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.progressoTxt.Text = e.Error.Message;
            }
            else if (e.Cancelled)
            {
                this.progressoTxt.Text = "Download Offline!";
            }
            else
            {
                this.progressoTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(203)))));
                progressoTxt.Text = "Download CLIENTE PATCH finalizado.";
                this.downloadBtn.Enabled = true;

                if (checkAutoExe.Checked)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(this.fileClientePatch);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        this.progressoTxt.Text = ex.Message;
                    }
                }
            }
        }

        private void ClienteCompletoBtn_Click(object sender, EventArgs e)
        {
            this.nomeCliente.Text = "Cliente Completo";
            this.tamanhoCliente.Text = this.tamanhoClienteCompleto;
            this.idCliente = 1;
        }

        private void clienteSemSomBtn_Click(object sender, EventArgs e)
        {
            this.nomeCliente.Text = "Cliente Sem Som";
            this.tamanhoCliente.Text = this.tamanhoClienteNoSound;
            this.idCliente = 2;
        }

        private void clientePatchBtn_Click(object sender, EventArgs e)
        {
            this.nomeCliente.Text = "Cliente Patch";
            this.tamanhoCliente.Text = this.tamanhoClientePatch;
            this.idCliente = 3;
        }

        private void Download(int host)
        {
            switch (this.idCliente)
            {
                case 0:
                    progressoTxt.Text = "Selecione algum download";
                    break;
                case 1:
                    this.downloadBtn.Enabled = false;
                    downloadClienteCompleto.RunWorkerAsync();
                    break;
                case 2:
                    this.downloadBtn.Enabled = false;
                    downloadClienteSemSom.RunWorkerAsync();
                    break;
                case 3:
                    this.downloadBtn.Enabled = false;
                    downloadPatch.RunWorkerAsync();
                    break;
            }
        }

        private void downloadBtn_Click(object sender, EventArgs e)
        {
            Download(this.idCliente);
        }

    }
}
