using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace TranslateAPP
{
    public partial class Main : Form
    {
        string inputText;
        string sourceLanguage;
        string targetLanguage;
        string translatedTextVar;
        public Main()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async  void button2_Click(object sender, EventArgs e)
        {
            sourceLanguage = comboBox1.SelectedItem.ToString();
            targetLanguage = comboBox2.SelectedItem.ToString();

            string apiUrl = $"https://api.mymemory.translated.net/get?q={Uri.EscapeUriString(inputText)}&langpair={sourceLanguage}|{targetLanguage}";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var jsonResult = JObject.Parse(result);
                    var translatedText = jsonResult["responseData"]["translatedText"];

                    richTextBox2.Text = $"{translatedText}";
                    Clipboard.SetText(translatedText.ToString());

                }
                else
                {
                    richTextBox2.Text = $"Translation failed! Error code: {response.StatusCode}";
                  }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
                
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            inputText = richTextBox1.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
 
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
