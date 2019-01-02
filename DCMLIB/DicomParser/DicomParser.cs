using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DCMLIB;

namespace DicomParser
{
    public partial class DicomParser : Form
    {
        public DicomParser()
        {
            InitializeComponent();
        }

        private void DicomParser_Load(object sender, EventArgs e)
        {
            TransferSyntaxes tsfactory = new TransferSyntaxes();
            cbTransferSyntax.Items.Clear();
            foreach (TransferSyntax syntax in tsfactory.TSs)
            {
                cbTransferSyntax.Items.Add(syntax);
            }

        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            byte[] data = Read.HexStringToByteArray(txtInput.Text);
            DCMDataSet DCMData = new DCMDataSet((TransferSyntax)cbTransferSyntax.SelectedItem);
            uint idx = 0;
            DCMData.Decode(data, ref idx);  //万恶之源：1
            //数据集转换为字符串显示
            string str = DCMData.ToString("");
            string[] lines = str.Split('\n');
            lvOutput.Items.Clear();
            for (int i = 0; i < lines.Length; i++)
            {
                ListViewItem item = new ListViewItem(lines[i].Split('\t'));
                lvOutput.Items.Add(item);
            }
         }

        private void btnFile_Click(object sender, EventArgs e)
        {
            openFileDlg.Filter = "Dicom文件|*.dcm";
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                DCMFile dcm = new DCMFile(openFileDlg.FileName);
                uint idx = 0;
                dcm.Decode(null, ref idx);
                string str = dcm.ToString("");
                string[] lines = str.Split('\n');
                lvOutput.Items.Clear();
                for (int i = 0; i < lines.Length; i++)
                {
                    ListViewItem item = new ListViewItem(lines[i].Split('\t'));
                    lvOutput.Items.Add(item);
                }
                Form Iamge = new frmImage(dcm);
                Iamge.Show();
            }
        }
    }
}
