using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using HtmlAgilityPack;
using ZOPZ_TLO.Properties;

namespace ZOPZ_TLO.UI;

public class Fullnamelookup : UserControl
{
	private readonly List<string> _proxies = new List<string> { "123.45.67.89:8080", "98.76.54.32:3128", "203.0.113.0:8000" };

	private readonly List<string> _userAgents = new List<string> { "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36", "Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:98.0) Gecko/20100101 Firefox/98.0" };

	private IContainer components = null;

	private Label label1;

	private Guna2Button guna2Button1;

	private Guna2TextBox firstNameTextBox;

	private Guna2TextBox stateTextBox;

	private Guna2TextBox lastNameTextBox;

	private Guna2VScrollBar guna2VScrollBar2;

	private TreeView treeView1;

	public void alert(string msg, Alert.enmType type)
	{
		Alert alert = new Alert();
		alert.showAlert(msg, type);
	}

	public Fullnamelookup()
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

	private async Task LookupPerson(string firstName, string lastName, string state)
	{
		try
		{
			string url = "https://thatsthem.com/name/" + firstName + "-" + lastName + "/" + state;
			string proxy = _proxies[new Random().Next(_proxies.Count)];
			string userAgent = _userAgents[new Random().Next(_userAgents.Count)];
			HtmlWeb web = new HtmlWeb
			{
				UserAgent = userAgent,
				PreRequest = delegate(HttpWebRequest request)
				{
					WebProxy proxy2 = new WebProxy(proxy)
					{
						BypassProxyOnLocal = false
					};
					request.Proxy = proxy2;
					return true;
				}
			};
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
			AddToTreeView("Error", ex2.Message);
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

	private async void firstNameTextBox_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			e.SuppressKeyPress = true;
			string firstName = firstNameTextBox.Text.Trim();
			string lastName = lastNameTextBox.Text.Trim();
			string state = stateTextBox.Text.Trim().ToUpper();
			if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(state))
			{
				alert("Please fill in all fields.", Alert.enmType.Success);
				return;
			}
			treeView1.Nodes.Clear();
			await LookupPerson(firstName, lastName, state);
		}
	}

	private void lastNameTextBox_MouseDown(object sender, MouseEventArgs e)
	{
	}

	private async void lastNameTextBox_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			e.SuppressKeyPress = true;
			string firstName = firstNameTextBox.Text.Trim();
			string lastName = lastNameTextBox.Text.Trim();
			string state = stateTextBox.Text.Trim().ToUpper();
			if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(state))
			{
				alert("Please fill in all fields.", Alert.enmType.Success);
				return;
			}
			treeView1.Nodes.Clear();
			await LookupPerson(firstName, lastName, state);
		}
	}

	private async void stateTextBox_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			e.SuppressKeyPress = true;
			string firstName = firstNameTextBox.Text.Trim();
			string lastName = lastNameTextBox.Text.Trim();
			string state = stateTextBox.Text.Trim().ToUpper();
			if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(state))
			{
				alert("Please fill in all fields.", Alert.enmType.Success);
				return;
			}
			treeView1.Nodes.Clear();
			await LookupPerson(firstName, lastName, state);
		}
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZOPZ_TLO.UI.Fullnamelookup));
		this.label1 = new System.Windows.Forms.Label();
		this.lastNameTextBox = new Guna.UI2.WinForms.Guna2TextBox();
		this.stateTextBox = new Guna.UI2.WinForms.Guna2TextBox();
		this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
		this.firstNameTextBox = new Guna.UI2.WinForms.Guna2TextBox();
		this.guna2VScrollBar2 = new Guna.UI2.WinForms.Guna2VScrollBar();
		this.treeView1 = new System.Windows.Forms.TreeView();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.Gray;
		this.label1.Location = new System.Drawing.Point(11, 15);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(107, 15);
		this.label1.TabIndex = 10;
		this.label1.Text = "Full Name Lookup";
		this.lastNameTextBox.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.lastNameTextBox.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.lastNameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
		this.lastNameTextBox.DefaultText = "";
		this.lastNameTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.lastNameTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.lastNameTextBox.DisabledState.ForeColor = System.Drawing.Color.White;
		this.lastNameTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.White;
		this.lastNameTextBox.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.lastNameTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.lastNameTextBox.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.lastNameTextBox.ForeColor = System.Drawing.Color.White;
		this.lastNameTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.lastNameTextBox.IconLeft = (System.Drawing.Image)resources.GetObject("lastNameTextBox.IconLeft");
		this.lastNameTextBox.Location = new System.Drawing.Point(257, 45);
		this.lastNameTextBox.Name = "lastNameTextBox";
		this.lastNameTextBox.PasswordChar = '\0';
		this.lastNameTextBox.PlaceholderForeColor = System.Drawing.Color.White;
		this.lastNameTextBox.PlaceholderText = "Last Name";
		this.lastNameTextBox.SelectedText = "";
		this.lastNameTextBox.Size = new System.Drawing.Size(226, 36);
		this.lastNameTextBox.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
		this.lastNameTextBox.TabIndex = 12;
		this.lastNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(lastNameTextBox_KeyDown);
		this.lastNameTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(lastNameTextBox_MouseDown);
		this.stateTextBox.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.stateTextBox.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.stateTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
		this.stateTextBox.DefaultText = "";
		this.stateTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.stateTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.stateTextBox.DisabledState.ForeColor = System.Drawing.Color.White;
		this.stateTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.White;
		this.stateTextBox.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.stateTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.stateTextBox.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.stateTextBox.ForeColor = System.Drawing.Color.White;
		this.stateTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.stateTextBox.IconLeft = ZOPZ_TLO.Properties.Resources.Location;
		this.stateTextBox.Location = new System.Drawing.Point(489, 45);
		this.stateTextBox.Name = "stateTextBox";
		this.stateTextBox.PasswordChar = '\0';
		this.stateTextBox.PlaceholderForeColor = System.Drawing.Color.White;
		this.stateTextBox.PlaceholderText = "State";
		this.stateTextBox.SelectedText = "";
		this.stateTextBox.Size = new System.Drawing.Size(210, 36);
		this.stateTextBox.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
		this.stateTextBox.TabIndex = 11;
		this.stateTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(stateTextBox_KeyDown);
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
		this.guna2Button1.TabIndex = 8;
		this.guna2Button1.Click += new System.EventHandler(guna2Button1_Click);
		this.firstNameTextBox.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.firstNameTextBox.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.firstNameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
		this.firstNameTextBox.DefaultText = "";
		this.firstNameTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.firstNameTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.firstNameTextBox.DisabledState.ForeColor = System.Drawing.Color.White;
		this.firstNameTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.White;
		this.firstNameTextBox.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.firstNameTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.firstNameTextBox.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.firstNameTextBox.ForeColor = System.Drawing.Color.White;
		this.firstNameTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.firstNameTextBox.IconLeft = (System.Drawing.Image)resources.GetObject("firstNameTextBox.IconLeft");
		this.firstNameTextBox.Location = new System.Drawing.Point(14, 45);
		this.firstNameTextBox.Name = "firstNameTextBox";
		this.firstNameTextBox.PasswordChar = '\0';
		this.firstNameTextBox.PlaceholderForeColor = System.Drawing.Color.White;
		this.firstNameTextBox.PlaceholderText = "First Name";
		this.firstNameTextBox.SelectedText = "";
		this.firstNameTextBox.Size = new System.Drawing.Size(237, 36);
		this.firstNameTextBox.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
		this.firstNameTextBox.TabIndex = 6;
		this.firstNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(firstNameTextBox_KeyDown);
		this.guna2VScrollBar2.BindingContainer = this.treeView1;
		this.guna2VScrollBar2.FillColor = System.Drawing.Color.White;
		this.guna2VScrollBar2.InUpdate = false;
		this.guna2VScrollBar2.LargeChange = 10;
		this.guna2VScrollBar2.Location = new System.Drawing.Point(721, 87);
		this.guna2VScrollBar2.Name = "guna2VScrollBar2";
		this.guna2VScrollBar2.ScrollbarSize = 18;
		this.guna2VScrollBar2.Size = new System.Drawing.Size(18, 370);
		this.guna2VScrollBar2.TabIndex = 20;
		this.guna2VScrollBar2.ThumbColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.treeView1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.treeView1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.treeView1.ForeColor = System.Drawing.Color.White;
		this.treeView1.LineColor = System.Drawing.Color.White;
		this.treeView1.Location = new System.Drawing.Point(14, 87);
		this.treeView1.Name = "treeView1";
		this.treeView1.Size = new System.Drawing.Size(725, 370);
		this.treeView1.TabIndex = 21;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		base.Controls.Add(this.guna2VScrollBar2);
		base.Controls.Add(this.treeView1);
		base.Controls.Add(this.lastNameTextBox);
		base.Controls.Add(this.stateTextBox);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.guna2Button1);
		base.Controls.Add(this.firstNameTextBox);
		base.Name = "Fullnamelookup";
		base.Size = new System.Drawing.Size(758, 470);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
