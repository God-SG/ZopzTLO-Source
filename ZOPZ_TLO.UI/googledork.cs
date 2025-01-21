using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using HtmlAgilityPack;
using ZOPZ_TLO.Properties;

namespace ZOPZ_TLO.UI;

public class googledork : UserControl
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

	public googledork()
	{
		InitializeComponent();
	}

	private void guna2TextBox1_TextChanged(object sender, EventArgs e)
	{
	}

	private async Task PerformSearch(string query)
	{
		HttpClient client = new HttpClient();
		try
		{
			string url = "https://duckduckgo.com/html/?q=" + Uri.EscapeDataString(query);
			try
			{
				HttpResponseMessage response = await client.GetAsync(url);
				response.EnsureSuccessStatusCode();
				string responseContent = await response.Content.ReadAsStringAsync();
				HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
				htmlDoc.LoadHtml(responseContent);
				HtmlNodeCollection searchResults = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'result')]");
				if (searchResults != null)
				{
					foreach (HtmlNode result in (IEnumerable<HtmlNode>)searchResults)
					{
						HtmlNode titleNode = result.SelectSingleNode(".//a[contains(@class, 'result__a')]");
						HtmlNode snippetNode = result.SelectSingleNode(".//a[contains(@class, 'result__snippet')]");
						string duckDuckGoUrl = titleNode?.GetAttributeValue("href", null);
						string title = titleNode?.InnerText.Trim() ?? "No Title";
						string snippet = snippetNode?.InnerText.Trim() ?? "No Snippet";
						string realUrl = "No URL";
						if (!string.IsNullOrEmpty(duckDuckGoUrl))
						{
							Match match = Regex.Match(duckDuckGoUrl, "uddg=([^&]+)");
							if (match.Success)
							{
								realUrl = Uri.UnescapeDataString(match.Groups[1].Value);
							}
						}
						richTextBox1.AppendText("Title: " + title + "\n");
						richTextBox1.AppendText("Link: " + realUrl + "\n");
						richTextBox1.AppendText("Snippet: " + snippet + "\n\n");
					}
				}
				else
				{
					alert("No results found.", Alert.enmType.Success);
				}
			}
			catch (Exception)
			{
				alert("Error", Alert.enmType.Success);
			}
		}
		finally
		{
			((IDisposable)client)?.Dispose();
		}
	}

	private async void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			richTextBox1.Clear();
			e.SuppressKeyPress = true;
			await PerformSearch(guna2TextBox1.Text);
		}
	}

	private void guna2Button1_Click(object sender, EventArgs e)
	{
		Clipboard.SetText(richTextBox1.Text);
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
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(121, 15);
		this.label1.TabIndex = 10;
		this.label1.Text = "Google Dork Lookup";
		this.guna2VScrollBar1.BindingContainer = this.richTextBox1;
		this.guna2VScrollBar1.FillColor = System.Drawing.Color.White;
		this.guna2VScrollBar1.InUpdate = false;
		this.guna2VScrollBar1.LargeChange = 10;
		this.guna2VScrollBar1.Location = new System.Drawing.Point(724, 87);
		this.guna2VScrollBar1.Name = "guna2VScrollBar1";
		this.guna2VScrollBar1.ScrollbarSize = 18;
		this.guna2VScrollBar1.Size = new System.Drawing.Size(18, 328);
		this.guna2VScrollBar1.TabIndex = 9;
		this.guna2VScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.richTextBox1.ForeColor = System.Drawing.Color.White;
		this.richTextBox1.Location = new System.Drawing.Point(17, 87);
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
		this.guna2TextBox1.IconLeft = ZOPZ_TLO.Properties.Resources.Person;
		this.guna2TextBox1.Location = new System.Drawing.Point(17, 45);
		this.guna2TextBox1.Name = "guna2TextBox1";
		this.guna2TextBox1.PasswordChar = '\0';
		this.guna2TextBox1.PlaceholderForeColor = System.Drawing.Color.White;
		this.guna2TextBox1.PlaceholderText = "Enter a username";
		this.guna2TextBox1.SelectedText = "";
		this.guna2TextBox1.Size = new System.Drawing.Size(685, 36);
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
		this.guna2Button1.Name = "guna2Button1";
		this.guna2Button1.Size = new System.Drawing.Size(34, 36);
		this.guna2Button1.TabIndex = 8;
		this.guna2Button1.Click += new System.EventHandler(guna2Button1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		base.Controls.Add(this.guna2VScrollBar1);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.guna2Button1);
		base.Controls.Add(this.richTextBox1);
		base.Controls.Add(this.guna2TextBox1);
		base.Name = "googledork";
		base.Size = new System.Drawing.Size(758, 470);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
