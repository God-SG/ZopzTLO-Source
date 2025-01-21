using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using HtmlAgilityPack;
using ZOPZ_TLO.Properties;

namespace ZOPZ_TLO.UI;

public class ssnchecker : UserControl
{
	private IContainer components = null;

	private Label label1;

	private Guna2VScrollBar guna2VScrollBar1;

	private RichTextBox richTextBox1;

	private Guna2Button guna2Button1;

	private Guna2TextBox guna2TextBox1;

	public void alert(string msg, Alert.enmType type)
	{
		Alert alert = new Alert();
		alert.showAlert(msg, type);
	}

	public ssnchecker()
	{
		InitializeComponent();
	}

	private string ExtractValidationStatus(HtmlAgilityPack.HtmlDocument doc)
	{
		return doc.DocumentNode.SelectSingleNode("//p[contains(@class, 'text-success')]")?.InnerText.Trim() ?? "Validation status not available";
	}

	private string ExtractStateIssued(HtmlAgilityPack.HtmlDocument doc)
	{
		return doc.DocumentNode.SelectSingleNode("//p[contains(text(), 'was issued in')]")?.InnerText.Trim() ?? "State issued not available";
	}

	private string ExtractIssueDateRange(HtmlAgilityPack.HtmlDocument doc)
	{
		return doc.DocumentNode.SelectSingleNode("//p[contains(text(), 'between')]")?.InnerText.Trim() ?? "Date range not available";
	}

	private void AppendToRichTextBox(string text)
	{
		if (richTextBox1.InvokeRequired)
		{
			richTextBox1.Invoke(new Action<string>(AppendToRichTextBox), text);
		}
		else
		{
			richTextBox1.AppendText(text + Environment.NewLine);
		}
	}

	private bool IsValidSSNFormat(string ssn)
	{
		return Regex.IsMatch(ssn, "^\\d{3}-\\d{2}-\\d{4}$");
	}

	private async void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode != Keys.Return)
		{
			return;
		}
		e.SuppressKeyPress = true;
		string ssn = guna2TextBox1.Text.Trim();
		if (string.IsNullOrWhiteSpace(ssn))
		{
			AppendToRichTextBox("Please enter a valid SSN.");
			return;
		}
		if (!IsValidSSNFormat(ssn))
		{
			AppendToRichTextBox("Invalid SSN format. Please enter in the format XXX-XX-XXXX.");
			return;
		}
		AppendToRichTextBox("Searching for SSN: " + ssn + "...");
		try
		{
			string url = "https://www.ssn-check.org/verify/" + ssn;
			HtmlWeb web = new HtmlWeb();
			HtmlAgilityPack.HtmlDocument doc = await web.LoadFromWebAsync(url);
			string validationStatus = ExtractValidationStatus(doc);
			string stateIssued = ExtractStateIssued(doc);
			string issueDateRange = ExtractIssueDateRange(doc);
			richTextBox1.Text = "";
			AppendToRichTextBox("Validation Status: " + validationStatus);
			AppendToRichTextBox("State Issued: " + stateIssued);
			AppendToRichTextBox("Issue Date Range: " + issueDateRange);
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			alert("Error: " + ex2.Message, Alert.enmType.Success);
		}
	}

	private void guna2TextBox1_TextChanged(object sender, EventArgs e)
	{
	}

	private void guna2Button1_Click(object sender, EventArgs e)
	{
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
		this.label1 = new System.Windows.Forms.Label();
		this.guna2VScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
		this.richTextBox1 = new System.Windows.Forms.RichTextBox();
		this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
		this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.Gray;
		this.label1.Location = new System.Drawing.Point(11, 15);
		this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(82, 15);
		this.label1.TabIndex = 10;
		this.label1.Text = "SSN Checker";
		this.guna2VScrollBar1.BindingContainer = this.richTextBox1;
		this.guna2VScrollBar1.FillColor = System.Drawing.Color.White;
		this.guna2VScrollBar1.InUpdate = false;
		this.guna2VScrollBar1.LargeChange = 10;
		this.guna2VScrollBar1.Location = new System.Drawing.Point(724, 87);
		this.guna2VScrollBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.guna2VScrollBar1.Name = "guna2VScrollBar1";
		this.guna2VScrollBar1.ScrollbarSize = 18;
		this.guna2VScrollBar1.Size = new System.Drawing.Size(18, 328);
		this.guna2VScrollBar1.TabIndex = 9;
		this.guna2VScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.richTextBox1.DetectUrls = false;
		this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.richTextBox1.ForeColor = System.Drawing.Color.White;
		this.richTextBox1.Location = new System.Drawing.Point(17, 87);
		this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.richTextBox1.Name = "richTextBox1";
		this.richTextBox1.ReadOnly = true;
		this.richTextBox1.Size = new System.Drawing.Size(725, 328);
		this.richTextBox1.TabIndex = 7;
		this.richTextBox1.Text = "Waiting for search...";
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
		this.guna2TextBox1.IconLeft = ZOPZ_TLO.Properties.Resources.Identity_Theft;
		this.guna2TextBox1.Location = new System.Drawing.Point(17, 45);
		this.guna2TextBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.guna2TextBox1.Name = "guna2TextBox1";
		this.guna2TextBox1.PasswordChar = '\0';
		this.guna2TextBox1.PlaceholderForeColor = System.Drawing.Color.White;
		this.guna2TextBox1.PlaceholderText = "SSN (317-27-5810)";
		this.guna2TextBox1.SelectedText = "";
		this.guna2TextBox1.Size = new System.Drawing.Size(683, 36);
		this.guna2TextBox1.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
		this.guna2TextBox1.TabIndex = 6;
		this.guna2TextBox1.TextChanged += new System.EventHandler(guna2TextBox1_TextChanged);
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
		this.guna2Button1.Location = new System.Drawing.Point(708, 45);
		this.guna2Button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.guna2Button1.Name = "guna2Button1";
		this.guna2Button1.Size = new System.Drawing.Size(34, 36);
		this.guna2Button1.TabIndex = 8;
		this.guna2Button1.Click += new System.EventHandler(guna2Button1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		base.Controls.Add(this.guna2VScrollBar1);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.guna2Button1);
		base.Controls.Add(this.richTextBox1);
		base.Controls.Add(this.guna2TextBox1);
		this.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		base.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		base.Name = "ssnchecker";
		base.Size = new System.Drawing.Size(758, 470);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
