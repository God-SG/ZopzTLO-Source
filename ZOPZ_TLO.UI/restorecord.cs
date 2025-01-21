using System;
using System.ComponentModel;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using ZOPZ_TLO.Properties;

namespace ZOPZ_TLO.UI;

public class restorecord : UserControl
{
	private IContainer components = null;

	private Guna2VScrollBar guna2VScrollBar1;

	private RichTextBox richTextBox1;

	private Guna2ComboBox guna2ComboBox1;

	private Label label1;

	private Guna2Button guna2Button1;

	private Guna2TextBox guna2TextBox1;

	public void alert(string msg, Alert.enmType type)
	{
		Alert alert = new Alert();
		alert.showAlert(msg, type);
	}

	public restorecord()
	{
		InitializeComponent();
	}

	private void guna2Button1_Click(object sender, EventArgs e)
	{
		Clipboard.SetText(richTextBox1.Text);
	}

	private async Task GetApiData()
	{
		try
		{
			HttpClient client = new HttpClient();
			try
			{
				string url = "https://search.zopz-api.com/discord?" + guna2ComboBox1.Text + "=" + guna2TextBox1.Text;
				HttpResponseMessage response = await client.GetAsync(url);
				response.EnsureSuccessStatusCode();
				DisplayResults(await response.Content.ReadAsStringAsync());
			}
			finally
			{
				((IDisposable)client)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			alert("Error: " + ex2.Message, Alert.enmType.Success);
		}
	}

	private void DisplayResults(string data)
	{
		richTextBox1.Clear();
		string[] array = data.Split(new char[1] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
		string[] array2 = array;
		foreach (string text in array2)
		{
			richTextBox1.AppendText(text + Environment.NewLine);
		}
	}

	private async void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			e.SuppressKeyPress = true;
			if (string.IsNullOrWhiteSpace(guna2TextBox1.Text))
			{
				alert("Please fill in all fields.", Alert.enmType.Success);
				return;
			}
			richTextBox1.Clear();
			await GetApiData();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.guna2VScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
		this.richTextBox1 = new System.Windows.Forms.RichTextBox();
		this.guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
		this.label1 = new System.Windows.Forms.Label();
		this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
		this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
		base.SuspendLayout();
		this.guna2VScrollBar1.BindingContainer = this.richTextBox1;
		this.guna2VScrollBar1.FillColor = System.Drawing.Color.White;
		this.guna2VScrollBar1.InUpdate = false;
		this.guna2VScrollBar1.LargeChange = 10;
		this.guna2VScrollBar1.Location = new System.Drawing.Point(721, 87);
		this.guna2VScrollBar1.Name = "guna2VScrollBar1";
		this.guna2VScrollBar1.ScrollbarSize = 18;
		this.guna2VScrollBar1.Size = new System.Drawing.Size(18, 370);
		this.guna2VScrollBar1.TabIndex = 15;
		this.guna2VScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.richTextBox1.ForeColor = System.Drawing.Color.White;
		this.richTextBox1.Location = new System.Drawing.Point(14, 87);
		this.richTextBox1.Name = "richTextBox1";
		this.richTextBox1.ReadOnly = true;
		this.richTextBox1.Size = new System.Drawing.Size(725, 370);
		this.richTextBox1.TabIndex = 13;
		this.richTextBox1.Text = "Waiting for search...";
		this.guna2ComboBox1.BackColor = System.Drawing.Color.Transparent;
		this.guna2ComboBox1.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
		this.guna2ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.guna2ComboBox1.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2ComboBox1.FocusedColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2ComboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2ComboBox1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.guna2ComboBox1.ForeColor = System.Drawing.Color.White;
		this.guna2ComboBox1.ItemHeight = 30;
		this.guna2ComboBox1.Items.AddRange(new object[4] { "username", "userid", "ipaddress", "date" });
		this.guna2ComboBox1.ItemsAppearance.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2ComboBox1.ItemsAppearance.ForeColor = System.Drawing.Color.White;
		this.guna2ComboBox1.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.guna2ComboBox1.ItemsAppearance.SelectedForeColor = System.Drawing.Color.White;
		this.guna2ComboBox1.Location = new System.Drawing.Point(502, 45);
		this.guna2ComboBox1.Name = "guna2ComboBox1";
		this.guna2ComboBox1.Size = new System.Drawing.Size(197, 36);
		this.guna2ComboBox1.StartIndex = 0;
		this.guna2ComboBox1.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
		this.guna2ComboBox1.TabIndex = 17;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.Gray;
		this.label1.Location = new System.Drawing.Point(11, 15);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(165, 15);
		this.label1.TabIndex = 16;
		this.label1.Text = "ResoreCord DB Lookup Tool";
		this.guna2TextBox1.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.guna2TextBox1.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
		this.guna2TextBox1.DefaultText = "";
		this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.guna2TextBox1.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2TextBox1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.guna2TextBox1.ForeColor = System.Drawing.Color.White;
		this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2TextBox1.IconLeft = ZOPZ_TLO.Properties.Resources.Search;
		this.guna2TextBox1.Location = new System.Drawing.Point(14, 45);
		this.guna2TextBox1.Name = "guna2TextBox1";
		this.guna2TextBox1.PasswordChar = '\0';
		this.guna2TextBox1.PlaceholderForeColor = System.Drawing.Color.White;
		this.guna2TextBox1.PlaceholderText = "Search any value (username, userid, ipaddress)";
		this.guna2TextBox1.SelectedText = "";
		this.guna2TextBox1.Size = new System.Drawing.Size(482, 36);
		this.guna2TextBox1.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
		this.guna2TextBox1.TabIndex = 12;
		this.guna2TextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(guna2TextBox1_KeyDown);
		this.guna2Button1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2Button1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold);
		this.guna2Button1.ForeColor = System.Drawing.Color.White;
		this.guna2Button1.Image = ZOPZ_TLO.Properties.Resources.copy1;
		this.guna2Button1.Location = new System.Drawing.Point(705, 45);
		this.guna2Button1.Name = "guna2Button1";
		this.guna2Button1.Size = new System.Drawing.Size(34, 36);
		this.guna2Button1.TabIndex = 14;
		this.guna2Button1.Click += new System.EventHandler(guna2Button1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		base.Controls.Add(this.guna2VScrollBar1);
		base.Controls.Add(this.guna2ComboBox1);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.guna2Button1);
		base.Controls.Add(this.richTextBox1);
		base.Controls.Add(this.guna2TextBox1);
		base.Name = "restorecord";
		base.Size = new System.Drawing.Size(758, 470);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
