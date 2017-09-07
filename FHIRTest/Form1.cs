using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hl7.Fhir;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Model;

namespace FHIRTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var endpoint = new Uri("http://spark.furore.com/fhir");
            var client = new FhirClient(endpoint);

            var query = new string[] { "name=" + textBox1.Text };
            var bundle = client.Search("Patient", query);

            button1.Text = "Got " + bundle.Entry.Count() + " records!";

            label1.Text = "";
            foreach (var entry in bundle.Entry)
            {
                Patient p = (Patient)entry.Resource;
                //It should be noted that the data appears to be unformatted and unclean.
                //The data hled in the fields being referrenced is contained with the endpoint and is not
                //manipulatable within this app.
                label1.Text = label1.Text + "Patient: " + p.Id + " " + p.Name.First() + " " + p.Name.Last() +  "\r\n";
            }
        }

    }
}
