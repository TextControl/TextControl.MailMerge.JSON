using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using TXTextControl;
using TXTextControl.DocumentServer;

namespace tx_json_sample
{
    public partial class index : System.Web.UI.Page
    {
        private DocumentController documentController1;
        private ServerTextControl serverTextControl1;
        private System.ComponentModel.IContainer components;

        protected void Button1_Click(object sender, EventArgs e)
        {
            MergeTemplate("template.tx", TextBox1.Text);
        }

        private void MergeTemplate(string templateName, string JsonData)
        {
            // creating a new ServerTextControl and MailMerge class
            using (ServerTextControl tx = new ServerTextControl())
            {
                tx.Create();
                MailMerge mailMerge = new MailMerge();
                mailMerge.TextComponent = tx;

                // load the template
                mailMerge.LoadTemplate(Server.MapPath("templates/" + templateName),
                    FileFormat.InternalUnicodeFormat);

                // create a new DataSet object
                DataSet ds = new DataSet();
                XmlDocument doc;

                // convert the JSON string to an XML document
                // object using Newtonsoft.Json
                try
                {
                    doc = JsonConvert.DeserializeXmlNode(JsonData);
                    lblError.Visible = false;
                }
                catch (Exception exc)
                {
                    lblError.Visible = true;
                    lblError.Text = exc.Message;
                    DocumentViewer1.Visible = false;
                    return;
                }

                // convert the XML to a DataSet
                XmlNodeReader reader = new XmlNodeReader(doc);
                ds.ReadXml(reader, XmlReadMode.Auto);

                // merge the template with the DataSet
                mailMerge.Merge(ds.Tables[0]);

                // load the resulting document into the DocumentViewer
                byte[] data;
                mailMerge.SaveDocumentToMemory(out data, BinaryStreamType.InternalUnicodeFormat, null);
                DocumentViewer1.LoadDocumentFromMemory(data, FileFormat.InternalUnicodeFormat);
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.documentController1 = new TXTextControl.DocumentServer.DocumentController(this.components);
            this.serverTextControl1 = new TXTextControl.ServerTextControl();
            // 
            // documentController1
            // 
            this.documentController1.TextComponent = this.serverTextControl1;
            // 
            // serverTextControl1
            // 
            this.serverTextControl1.SpellChecker = null;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            DocumentViewer1.DocumentController = documentController1;
            DocumentViewer1.Visible = true;
        }
    }
}