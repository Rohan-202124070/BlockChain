using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace BlockChain
{
    public partial class Form1 : Form
    {
        string selectedValue = null;
        int count = 0;
        int previous_cout = 0;
        List<TextBoxData> textBoxes = new List<TextBoxData>();
        List<PurchaseData> PurchaseDatas = new List<PurchaseData>();
        List<TextBox> _textBoxes = new List<TextBox>();
        List<Button> _buttons = new List<Button>();
        BlcokChain blcokChain = new BlcokChain();
        
        TextBox hidden_text_box;

        public Form1()
        {
            InitializeComponent();

            label3.Visible = false;
            textBox2.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            textBox4.Text = 0.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            selectedValue = cmb.SelectedItem.ToString();

            label3.Visible = true;
            textBox2.Visible = true;

            TextBox textbox = textBox1;

            if (selectedValue.Equals("1960s Oriental Vintage Carpet"))
            {
                textbox.Text = "£600";
            }
            else if (selectedValue.Equals("Oriental Bronze Foo-Dog Figurine"))
            {
                textbox.Text = "£700";
            }
            else if (selectedValue.Equals("Ancient Rare Bronze Roman Ring"))
            {
                textbox.Text = "£2300";
            }
            else if (selectedValue.Equals("Horse Ornament Brass Scarborough Castle"))
            {
                textbox.Text = "£900";
            }
            else if (selectedValue.Equals("Antique Coffee Urn 1901 Bowman/Meridan"))
            {
                textbox.Text = "£2500";
            }
            else if (selectedValue.Equals("Antique Barn Cupola Farm"))
            {
                textbox.Text = "£1000";
            }
            else if (selectedValue.Equals("Antique Plant Catalog-1898s, Switzerland"))
            {
                textbox.Text = "£500";
            }
            else if (selectedValue.Equals("Mickey Mantle rookie baseball 1951"))
            {
                textbox.Text = "£750";
            }
            else
            {
                textbox.Text = "£450";
            }
            this.Controls.Add(textbox);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            TextBox textBox = textBox2;
            string _count = textBox.Text;
            blcokChain._time_stamp = DateTime.Now;

            if (previous_cout != 0)
            {
                label4.Visible = false;
                label5.Visible = false;
                foreach (TextBox t in _textBoxes)
                {
                    this.Controls.Remove(t);
                    t.Dispose();
                }

                foreach (Button b in _buttons)
                {
                    this.Controls.Remove(b);
                    b.Dispose();
                }
                textBoxes = new List<TextBoxData>();
                _textBoxes = new List<TextBox>();
                _buttons = new List<Button>();
                if (hidden_text_box != null)
                {
                    hidden_text_box.Text = "";
                    hidden_text_box.Dispose();
                }
                blcokChain = new BlcokChain();
            }

            previous_cout = count;
            bool isNumber = int.TryParse(textBox.Text, out count);

            if (!isNumber)
            {
                MessageBox.Show("Please enter number and should be greater than 0", "Number only", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (_count == "0")
            {
                MessageBox.Show("Please enter number and it should be greater than 0", "Number only", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (isNumber && _count != "" && _count != "0")
            {

                count = int.Parse(textBox.Text);
                if (count > 10)
                {
                    MessageBox.Show("Bill can not be slipt between more than 10 people ", "Bill Split Policy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    label4.Visible = true;
                    label5.Visible = true;

                    int name_size_x = 120;
                    int name_size_y = 26;
                    int name_loc_x = 26;
                    int name_loc_y = 160;

                    int prop_size_x = 100;
                    int prop_size_y = 16;
                    int prop_loc_x = 150;
                    int prop_loc_y = 160;

                    int left = 260;
                    int top = 160;

                    for (int i = 0; i < count; i++)
                    {
                        TextBoxData textBoxData = new TextBoxData();
                        TextBox textBox_name = new TextBox();
                        textBox_name.Location = new Point(name_loc_x, name_loc_y);
                        textBox_name.Size = new Size(name_size_x, name_size_y);
                        textBox_name.Name = "Name" + i;
                        textBox_name.Text = "";
                        
                        textBoxData.Name = textBox_name;

                        _textBoxes.Add(textBox_name);

                        TextBox textBox_prop = new TextBox();
                        textBox_prop.Location = new Point(prop_loc_x, prop_loc_y);
                        textBox_prop.Size = new Size(prop_size_x, prop_size_y);
                        textBox_prop.Name = "prop" + i;
                        textBox_prop.Text = "";
                        textBoxData.Contribution = textBox_prop;

                        _textBoxes.Add(textBox_prop);

                        Button button = new Button();
                        button.Left = left;
                        button.Top = top;
                        button.BackColor = Color.DodgerBlue;
                        button.AccessibleName = "payButton" + i;
                        button.Text = "Pay";

                        _buttons.Add(button);
                        button.Click += new EventHandler(pay_button_click);
                        textBoxData.Button = button;

                        this.Controls.Add(button);
                        this.Controls.Add(textBox_prop);
                        this.Controls.Add(textBox_name);

                        name_loc_y = name_loc_y + 30;
                        prop_loc_y = prop_loc_y + 30;
                        top = top + 30;

                        textBoxes.Add(textBoxData);
                    }

                }
            }
        }

        private void pay_button_click(object sender, EventArgs e)
        {
            Boolean valid = true;
            Boolean isZeroPresent = true;
            if (count == 0)
            {
                MessageBox.Show("Please provide vaild data!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBoxes != null)
            {
                foreach (TextBoxData ted in textBoxes)
                {
                    if (ted != null && (ted.Name.Text.Equals("") || ted.Contribution.Text.Equals("")))
                    {
                        valid = false;
                        break;

                    }
                    else if (ted != null && ted.Contribution.Text.Equals("0"))
                    {
                        isZeroPresent = false;
                    }
                    else
                    {
                        valid = true;
                    }
                }
                if (!valid)
                {
                    MessageBox.Show("Please enter complete detalis for splitting the bill!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (!isZeroPresent)
                {
                    MessageBox.Show("Please split the bill properly, you have entered : £" + 0, "Please Check Entered Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (textBoxes != null && count != 0 && valid)
            {
                int price = 0;
                foreach (TextBoxData ted in textBoxes)
                {
                    price += int.Parse(ted.Contribution.Text);
                }
                TextBox textbox = textBox1;
                int actual_price = int.Parse(textBox1.Text.Replace("£", ""));
                int val = actual_price - price;
                if (price < actual_price)
                {
                    MessageBox.Show("Please split the bill properly, must pay another : £" + val.ToString(), "Please Check Entered Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    valid = false;
                }
                else if (price > actual_price)
                {
                    val = val * (-1);
                    MessageBox.Show("Please split the bill properly, your paying extra  : £" + val.ToString(), "Please Check Entered Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    valid = false;
                }
            }

            if (valid && isZeroPresent)
            {
                Button button = (Button)sender;
                string strName = button.AccessibleName;
                button.Enabled = false;
                BlockData blcokData = new BlockData();
                if (hidden_text_box != null)
                {
                    hidden_text_box.Text = "";
                    hidden_text_box.Dispose();
                }
                foreach (TextBoxData tdata in textBoxes)
                {
                    if (tdata.Button.AccessibleName.Equals(strName))
                    {
                        PurchaseData purchaseData = new PurchaseData();
                        purchaseData.From = tdata.Name.Text;
                        purchaseData.Amount = int.Parse(tdata.Contribution.Text);
                        purchaseData.DateTime = DateTime.Now;
                        blcokData = blcokData.PrepareBlock(blcokChain._time_stamp ,purchaseData, long.Parse(textBox4.Text), textBox3.Text != "" ? textBox3.Text : blcokData.Get_First_Pervious_Hash());
                        textBox3.Text = blcokData._hash;
                        textBox4.Text = blcokData._proof_of_ownership.ToString();
                        hidden_text_box = new TextBox();
                        hidden_text_box.Location = new Point(470, 38);
                        hidden_text_box.Size = new Size(530, 500);
                        hidden_text_box.Multiline = true;
                        hidden_text_box.ScrollBars = ScrollBars.Vertical;
                        hidden_text_box.BackColor = Color.Honeydew;

                        this.SetClientSizeCore(1000, 600);
                        button1.Location = new Point(800, 550);
                        button2.Location = new Point(890, 550);

                        Button download_button = new Button();
                        download_button.Location = new Point(710, 550);
                        download_button.Text = "Download";
                        download_button.BackColor = Color.MistyRose;
                        download_button.Visible = true;
                        download_button.Click += new EventHandler(download_button_click);

                        this.Controls.Add(download_button);
                        this.Controls.Add(hidden_text_box);

                        PurchaseDatas.Add(purchaseData);
                    }
                }
                blcokChain._seleted_service = comboBox1.SelectedItem.ToString();
                blcokChain._price = textBox1.Text; 
                blcokChain._block_chain.Add(blcokData);
                blcokChain._is_valid_chain =  blcokData.Validate_Chain(blcokChain._block_chain);
                blcokChain._index = blcokChain._block_chain.Count;
                string sJSONResponse = JsonConvert.SerializeObject(blcokChain);
                JToken parsedJson = JToken.Parse(sJSONResponse);
                var beautified = parsedJson.ToString(Formatting.Indented);
                hidden_text_box.Text = beautified;
            }
        }

        private void download_button_click(object sender, EventArgs e)
        {
            string download_data = hidden_text_box.Text;
            string path = @"C:\Temp\BlockChain.txt";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (FileStream fs = File.Create(path))
            {
                Byte[] title = new UTF8Encoding(true).GetBytes(download_data);
                fs.Write(title, 0, title.Length);
            }

            MessageBox.Show("Block chain downloaded successfully in the below path!!!\n" + path, "Download Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new Form1();
            NewForm.Show();
            this.Dispose(false);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.ReadOnly = false;
            label4.Visible = false;
            label5.Visible = false;
            textBox2.Text = "";
            foreach (TextBox t in _textBoxes)
            {
                this.Controls.Remove(t);
                t.Dispose();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
