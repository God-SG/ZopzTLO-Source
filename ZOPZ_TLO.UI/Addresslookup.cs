using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using HtmlAgilityPack;
using ZOPZ_TLO.Properties;

namespace ZOPZ_TLO.UI;

public class Addresslookup : UserControl
{
	private IContainer components = null;

	private Guna2TextBox guna2TextBox1;

	private Guna2Button guna2Button1;

	private Label label1;

	private Guna2VScrollBar guna2VScrollBar2;

	private TreeView treeView1;

	public void alert(string msg, Alert.enmType type)
	{
		Alert alert = new Alert();
		alert.showAlert(msg, type);
	}

	public Addresslookup()
	{
		InitializeComponent();
	}

	private void AddToTreeView(string category, params string[] details)
	{
		if (treeView1.InvokeRequired)
		{
			treeView1.Invoke(new Action<string, string[]>(AddToTreeView), category, details);
			return;
		}
		TreeNode treeNode = treeView1.Nodes.Cast<TreeNode>().FirstOrDefault((TreeNode n) => n.Text == category);
		if (treeNode == null)
		{
			treeNode = new TreeNode(category);
			treeView1.Nodes.Add(treeNode);
		}
		foreach (string text in details)
		{
			treeNode.Nodes.Add(new TreeNode(text));
		}
		treeView1.ExpandAll();
	}

	private string NormalizeAddress(string address)
	{
		string text = address.Replace(" ", "-");
		text = text.Replace("-Rd", "-Rd.");
		text = text.Replace("-St", "-St.");
		text = text.Replace("-Ave", "-Ave.");
		text = text.Replace(",", "");
		return Uri.EscapeDataString(text);
	}

	private async Task LookupAddress(string normalizedAddress)
	{
		try
		{
			string url = "https://thatsthem.com/address/" + normalizedAddress;
			HtmlWeb web = new HtmlWeb();
			HtmlAgilityPack.HtmlDocument doc = await web.LoadFromWebAsync(url);
			AddToTreeView("Name", ExtractName(doc));
			AddToTreeView("Gender", ExtractGender(doc));
			AddToTreeView("Age", ExtractAge(doc));
			AddToTreeView("Primary Residence", ExtractPrimaryAddress(doc));
			AddToTreeView("Previous Addresses", ExtractPreviousAddresses(doc).Split('\n'));
			AddToTreeView("Phone Numbers", ExtractPhoneNumbers(doc).Split('\n'));
			AddToTreeView("Email Addresses", ExtractEmails(doc).Split('\n'));
			AddToTreeView("Associates", ExtractAssociates(doc).Split('\n'));
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			alert("Error: " + ex2.Message, Alert.enmType.Success);
		}
	}

	private string ExtractName(HtmlAgilityPack.HtmlDocument doc)
	{
		return doc.DocumentNode.SelectSingleNode("//div[@class='name']/a")?.InnerText.Trim() ?? "Not available";
	}

	private string ExtractGender(HtmlAgilityPack.HtmlDocument doc)
	{
		return doc.DocumentNode.SelectSingleNode("//div[@class='name']/span/i[@data-title]")?.Attributes["data-title"]?.Value.Trim() ?? "Not available";
	}

	private string ExtractAge(HtmlAgilityPack.HtmlDocument doc)
	{
		HtmlNode htmlNode = doc.DocumentNode.SelectSingleNode("//div[@class='age']");
		if (htmlNode != null)
		{
			string text = htmlNode.InnerText.Trim();
			return text.Contains("(") ? text.Substring(text.IndexOf("(") + 1).Replace(")", "").Trim() : "Not available";
		}
		return "Not available";
	}

	private string ExtractPrimaryAddress(HtmlAgilityPack.HtmlDocument doc)
	{
		HtmlNode htmlNode = doc.DocumentNode.SelectSingleNode("//div[@class='location ']/span[@class='address']");
		if (htmlNode != null)
		{
			string text = htmlNode.SelectSingleNode(".//span[@class='street']")?.InnerText.Trim() ?? "Street not available";
			string text2 = htmlNode.SelectSingleNode(".//span[@class='city']")?.InnerText.Trim() ?? "City not available";
			string text3 = htmlNode.SelectSingleNode(".//span[@class='state']")?.InnerText.Trim() ?? "State not available";
			string text4 = htmlNode.SelectSingleNode(".//span[@class='zip']")?.InnerText.Trim() ?? "ZIP not available";
			return text + ", " + text2 + ", " + text3 + " " + text4;
		}
		return "Primary Residence not available";
	}

	private string ExtractPreviousAddresses(HtmlAgilityPack.HtmlDocument doc)
	{
		HtmlNodeCollection htmlNodeCollection = doc.DocumentNode.SelectNodes("//div[@class='group'][./div[@class='subtitle' and text()='Previous Addresses:']]//span[@class='address']/a");
		if (htmlNodeCollection != null)
		{
			return string.Join("\n", htmlNodeCollection.Select(delegate(HtmlNode node)
			{
				string text = node.SelectSingleNode(".//span[@class='street']")?.InnerText.Trim() ?? "";
				string text2 = node.SelectSingleNode(".//span[@class='city']")?.InnerText.Trim() ?? "";
				string text3 = node.SelectSingleNode(".//span[@class='state']")?.InnerText.Trim() ?? "";
				string text4 = node.SelectSingleNode(".//span[@class='zip']")?.InnerText.Trim() ?? "";
				return text + " " + text2 + ", " + text3 + " " + text4;
			}));
		}
		return "Not available";
	}

	private string ExtractPhoneNumbers(HtmlAgilityPack.HtmlDocument doc)
	{
		HtmlNodeCollection htmlNodeCollection = doc.DocumentNode.SelectNodes("//div[@class='phone']//span[@class='number']/a");
		if (htmlNodeCollection != null)
		{
			return string.Join("\n", htmlNodeCollection.Select((HtmlNode node) => node.InnerText.Trim()));
		}
		return "Not available";
	}

	private string ExtractEmails(HtmlAgilityPack.HtmlDocument doc)
	{
		HtmlNodeCollection htmlNodeCollection = doc.DocumentNode.SelectNodes("//div[@class='email']//span[@class='inbox']/a");
		if (htmlNodeCollection != null)
		{
			return string.Join("\n", htmlNodeCollection.Select((HtmlNode node) => node.InnerText.Trim()));
		}
		return "Not available";
	}

	private string ExtractAssociates(HtmlAgilityPack.HtmlDocument doc)
	{
		HtmlNodeCollection htmlNodeCollection = doc.DocumentNode.SelectNodes("//div[@class='group'][./div[@class='subtitle' and text()='Associates:']]//ul[@class='dotted']//li//a");
		if (htmlNodeCollection != null)
		{
			return string.Join("\n", htmlNodeCollection.Select((HtmlNode node) => node.InnerText.Trim()));
		}
		return "Not available";
	}

	private async void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			e.SuppressKeyPress = true;
			string inputAddress = guna2TextBox1.Text.Trim();
			if (!string.IsNullOrWhiteSpace(inputAddress))
			{
				treeView1.Nodes.Clear();
				string normalizedAddress = NormalizeAddress(inputAddress);
				await LookupAddress(normalizedAddress);
			}
		}
	}

	private void guna2Button1_Click(object sender, EventArgs e)
	{
		Clipboard.SetText(string.Join("\n", from TreeNode node in treeView1.Nodes
			select node.Text + "\n" + string.Join("\n", from TreeNode subNode in node.Nodes
				select "  - " + subNode.Text)));
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
		this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
		this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
		this.guna2VScrollBar2 = new Guna.UI2.WinForms.Guna2VScrollBar();
		this.treeView1 = new System.Windows.Forms.TreeView();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.Gray;
		this.label1.Location = new System.Drawing.Point(11, 15);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(100, 15);
		this.label1.TabIndex = 5;
		this.label1.Text = "Address Lookup";
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
		this.guna2Button1.TabIndex = 2;
		this.guna2Button1.Click += new System.EventHandler(guna2Button1_Click);
		this.guna2TextBox1.Animated = true;
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
		this.guna2TextBox1.IconLeft = ZOPZ_TLO.Properties.Resources.Location;
		this.guna2TextBox1.Location = new System.Drawing.Point(14, 45);
		this.guna2TextBox1.Name = "guna2TextBox1";
		this.guna2TextBox1.PasswordChar = '\0';
		this.guna2TextBox1.PlaceholderForeColor = System.Drawing.Color.White;
		this.guna2TextBox1.PlaceholderText = "Enter Address (159 Ray Hill Rd Wilmington VT 05363)";
		this.guna2TextBox1.SelectedText = "";
		this.guna2TextBox1.Size = new System.Drawing.Size(685, 36);
		this.guna2TextBox1.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
		this.guna2TextBox1.TabIndex = 0;
		this.guna2TextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(guna2TextBox1_KeyDown);
		this.guna2VScrollBar2.BindingContainer = this.treeView1;
		this.guna2VScrollBar2.FillColor = System.Drawing.Color.White;
		this.guna2VScrollBar2.InUpdate = false;
		this.guna2VScrollBar2.LargeChange = 10;
		this.guna2VScrollBar2.Location = new System.Drawing.Point(721, 87);
		this.guna2VScrollBar2.Name = "guna2VScrollBar2";
		this.guna2VScrollBar2.ScrollbarSize = 18;
		this.guna2VScrollBar2.Size = new System.Drawing.Size(18, 370);
		this.guna2VScrollBar2.TabIndex = 22;
		this.guna2VScrollBar2.ThumbColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.treeView1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.treeView1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.treeView1.ForeColor = System.Drawing.Color.White;
		this.treeView1.LineColor = System.Drawing.Color.White;
		this.treeView1.Location = new System.Drawing.Point(14, 87);
		this.treeView1.Name = "treeView1";
		this.treeView1.Size = new System.Drawing.Size(725, 370);
		this.treeView1.TabIndex = 23;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		base.Controls.Add(this.guna2VScrollBar2);
		base.Controls.Add(this.treeView1);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.guna2Button1);
		base.Controls.Add(this.guna2TextBox1);
		base.Name = "Addresslookup";
		base.Size = new System.Drawing.Size(758, 470);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
