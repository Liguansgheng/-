using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HL7LIB;

namespace HL7Test
{
    public partial class HL7Text : Form
    {
        public HL7Text()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            messageFactory factory = new messageFactory();
            ACK msg = factory.Create(null, enumMessages.ACK, "ACK") as ACK;
            msg.Msh.FieldSeparator.Value = "|";
            msg.Msh.EncodingCharacters.Value = "^~\\&";
            msg.Msh.DateOrTimeOfMessage.Value = DateTime.Now.ToString("yyyyMMddhhmmss.fff");
            msg.Msh.MessageType.MessageCode.Value = "ACK";
            msg.Msh.MessageType.TriggerEvent.Value = "A01";
            msg.Msh.MessageType.MessageStructure.Value = "ACK_A01";
            //msg.Msh.MessageType.Value = "ACK^A01^ACK_A01";
            msg.Msh.MessageControlID.Value = "A00002";
            msg.Msh.ProcessingID.ProcessingID.Value = "P";
            msg.Msh.VersionID.VersionID.Value = "2.4";
            msg.Msa.AcknowledgmentCode.Value = "AA";
            msg.Msa.MessageControlID.Value = "MSG00001";
            msg.Msa.TextMessage.Value = "Success";

            txtMessage.Text = msg.ToString();
        }

        private void BtnAnalyse_Click(object sender, EventArgs e)
        {
            messageFactory factory = new messageFactory();
            ACK msg = factory.Create(null, enumMessages.ACK, "ACK") as ACK;

            msg.Parse("Msh|^~\\&|HIS|00001|LIS|1234|2004112754000||ACK^A01^ACK_A01|0200002|P|2.4\rMSA|AE|0200001|type error|||102\r");
            //txtMessage.Text = msg.ToString(); 
            txtMsgControllID.Text = msg.Msa.MessageControlID.Value;
            txtTextMsg.Text = msg.Msa.TextMessage.Value;

        }

        private void BtnORMAnlyse_Click(object sender, EventArgs e)
        {
            messageFactory factory = new messageFactory();
            O01 msg = factory.Create(null, enumMessages.O01, "O01") as O01;
            msg.Parse("MSH|^~\\&|HIS||RIS||201405201200||ORM^O01| MSG0001|P|2.4||||||UNICODE UTF-8|\rPID|||10032002||刘明^liuming||19780509 |M|||||0591-63548155|\rPV1|1|I|2000^2012^01||||004777^LEBA UER^SIDNEY^J.|||SUR||||ADT^A01\rORC|NW|120003^HIS|||||1||20140518|||0146^ 王蔚||65390001|20140518||First Hospital|\rOBR|1|120003^HIS|| B02001^CT|\r");
            //程序必须把该有的段都要有，才可以正确执行Parse方法
            tbxORM_OBR_4.Text = msg.Obr.UniversalServiceIdentifier.Value;
            tbxORM_PID_5.Text = msg.Pid.PatientName.Value;

        }

        private void BtnORMCreate_Click(object sender, EventArgs e)
        {
            messageFactory factory = new messageFactory();
            O01 msg = factory.Create(null, enumMessages.O01, "O01") as O01;
            msg.Msh.FieldSeparator.Value = "|";
            msg.Msh.EncodingCharacters.Value = "^~\\&";
            msg.Msh.DateOrTimeOfMessage.Value = DateTime.Now.ToString("yyyyMMddhhmmss.fff");
            msg.Msh.MessageType.MessageCode.Value = "ORM";
            msg.Msh.MessageType.TriggerEvent.Value = "O01";
            msg.Msh.MessageType.MessageStructure.Value = "ORM^O01";
            //msg.Msh.MessageType.Value = "ACK^A01^ACK_A01";
            msg.Msh.MessageControlID.Value = "A00002";
            msg.Msh.ProcessingID.ProcessingID.Value = "P";
            msg.Msh.VersionID.VersionID.Value = "2.4";
            msg.Orc.OrderControl.Value = "NW";
            msg.Orc.PlacerOrderNumber.Value = "120003^HIS";
            msg.Orc.QuantityOrTiming.Value = "1";
            msg.Orc.DateOrTimeOfTransaction.Value = "20181210";
            msg.Orc.OrderingProvider.Value = "1519640315^李广盛";
            msg.Orc.EnteringOrganization.Value = "上海理工大学医学信息工程1班";
            msg.Obr.PlacerOrderNumber.Value = "120003^HIS";
            msg.Obr.UniversalServiceIdentifier.Value = "B02001^CT";
            msg.Obr.OrderingProvider.Value = "1519640315^李广盛";
            txtORM.Text = msg.ToString();
        }
    }
}
