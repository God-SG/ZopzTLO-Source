using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using ZOPZ_TLO.Properties;

namespace ZOPZ_TLO.UI;

public class Phonenumber : UserControl
{
	private IContainer components = null;

	private Label label1;

	private Guna2Button guna2Button1;

	private Guna2TextBox guna2TextBox1;

	private Guna2VScrollBar guna2VScrollBar2;

	private TreeView treeView1;

	public void alert(string msg, Alert.enmType type)
	{
		Alert alert = new Alert();
		alert.showAlert(msg, type);
	}

	public Phonenumber()
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

	private async Task<string> ValidatePhoneWithAPI(string phoneNumber)
	{
		try
		{
			string apiKey = "feea8fd1f565614a1ab4bfd02398a9ed";
			string apiUrl = "http://apilayer.net/api/validate?access_key=" + apiKey + "&number=1" + phoneNumber + "&format=1";
			HttpClient httpClient = new HttpClient();
			try
			{
				JObject data = JObject.Parse(await httpClient.GetStringAsync(apiUrl));
				List<string> details = new List<string>
				{
					string.Format("Valid: {0}", data["valid"]),
					string.Format("Local Format: {0}", data["local_format"]),
					string.Format("International Format: {0}", data["intl_format"]),
					string.Format("Country Code: {0}", data["country_code"]),
					string.Format("Country Name: {0}", data["country_name"]),
					string.Format("Location: {0}", data["location"]),
					string.Format("Carrier: {0}", data["carrier"]),
					string.Format("Line Type: {0}", data["line_type"])
				};
				AddToTreeView("API Validation", details.ToArray());
				return "Validation completed.";
			}
			finally
			{
				((IDisposable)httpClient)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			alert("Error during API validation: " + ex2.Message, Alert.enmType.Success);
			return "Validation failed.";
		}
	}

	private async Task LookupPhone(string phoneNumber)
	{
		try
		{
			string url = "https://thatsthem.com/phone/" + phoneNumber;
			HtmlWeb web = new HtmlWeb();
			web.PreRequest = (HtmlWeb.PreRequestHandler)Delegate.Combine(web.PreRequest, (HtmlWeb.PreRequestHandler)delegate(HttpWebRequest request)
			{
				request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
				return true;
			});
			HtmlAgilityPack.HtmlDocument doc = await web.LoadFromWebAsync(url);
			AddToTreeView("Web Lookup", "Results:");
			AddToTreeView("Name", ExtractName(doc));
			AddToTreeView("Age", ExtractAge(doc));
			AddToTreeView("Gender", ExtractGender(doc));
			AddToTreeView("Primary Address", ExtractPrimaryAddress(doc));
			AddToTreeView("Previous Addresses", ExtractPreviousAddresses(doc).Split('\n'));
			AddToTreeView("Phone Numbers", ExtractPhoneNumbers(doc).Split('\n'));
			AddToTreeView("Email Addresses", ExtractEmails(doc).Split('\n'));
			AddToTreeView("Associates", ExtractAssociates(doc).Split('\n'));
			await ValidatePhoneWithAPI(phoneNumber);
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			AddToTreeView("Error", "Error: " + ex2.Message);
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

	private async Task<string> FetchPhoneInfo(string phoneNumber)
	{
		try
		{
			string apiUrl = "https://trial.serviceobjects.com/gppl2/api.svc/PhoneInfo/" + phoneNumber + "/full/" + LoginForm.KeyAuthApp.var("key") + "?format=json";
			HttpClient httpClient = new HttpClient();
			try
			{
				JObject data = JObject.Parse(await httpClient.GetStringAsync(apiUrl));
				JToken provider = data["PhoneInfo"]["Provider"];
				JToken contacts = data["PhoneInfo"]["Contacts"];
				if (provider != null)
				{
					AddToTreeView("Provider Details", string.Format("Name: {0}", provider["Name"]), string.Format("City: {0}", provider["City"]), string.Format("State: {0}", provider["State"]), string.Format("Latitude: {0}", provider["Latitude"]), string.Format("Longitude: {0}", provider["Longitude"]), string.Format("Line Type: {0}", provider["LineType"]));
				}
				if (contacts != null)
				{
					foreach (JToken contact in (IEnumerable<JToken>)contacts)
					{
						AddToTreeView("Contact Details", string.Format("Name: {0}", contact["Name"]), string.Format("Address: {0}", contact["Address"]), string.Format("City: {0}", contact["City"]), string.Format("State: {0}", contact["State"]), string.Format("Postal Code: {0}", contact["PostalCode"]), string.Format("Phone Type: {0}", contact["PhoneType"]), string.Format("SIC Code: {0}", contact["SICCode"]), string.Format("SIC Description: {0}", contact["SICDesc"]), string.Format("Quality Score: {0}", contact["QualityScore"]));
					}
				}
				return "Phone info fetched successfully.";
			}
			finally
			{
				((IDisposable)httpClient)?.Dispose();
			}
		}
		catch (Exception)
		{
			return "Fetching phone info failed.";
		}
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
			if (string.IsNullOrWhiteSpace(guna2TextBox1.Text))
			{
				alert("Please fill in all fields.", Alert.enmType.Success);
				return;
			}
			treeView1.Nodes.Clear();
			await LookupPhone(guna2TextBox1.Text);
			await ValidatePhoneWithAPI(guna2TextBox1.Text);
			await FetchPhoneInfo(guna2TextBox1.Text);
		}
	}

	private void guna2Button1_Click(object sender, EventArgs e)
	{
		StringBuilder contentBuilder = new StringBuilder();
		foreach (TreeNode node4 in treeView1.Nodes)
		{
			node4.ExpandAll();
		}
		foreach (TreeNode node5 in treeView1.Nodes)
		{
			GatherNodeContent(node5, 0);
		}
		Clipboard.SetText(contentBuilder.ToString());
		void GatherNodeContent(TreeNode node, int indentLevel)
		{
			string text = new string(' ', indentLevel * 2);
			contentBuilder.AppendLine(text + node.Text);
			foreach (TreeNode node6 in node.Nodes)
			{
				GatherNodeContent(node6, indentLevel + 1);
			}
		}
	}

	private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
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
		this.label1.Size = new System.Drawing.Size(88, 15);
		this.label1.TabIndex = 10;
		this.label1.Text = "Phone Lookup";
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
		this.guna2TextBox1.IconLeft = ZOPZ_TLO.Properties.Resources.Phone;
		this.guna2TextBox1.Location = new System.Drawing.Point(14, 45);
		this.guna2TextBox1.Name = "guna2TextBox1";
		this.guna2TextBox1.PasswordChar = '\0';
		this.guna2TextBox1.PlaceholderForeColor = System.Drawing.Color.White;
		this.guna2TextBox1.PlaceholderText = "Enter Phone Number...  (802-536-4678)";
		this.guna2TextBox1.SelectedText = "";
		this.guna2TextBox1.Size = new System.Drawing.Size(685, 36);
		this.guna2TextBox1.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
		this.guna2TextBox1.TabIndex = 6;
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
		this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(treeView1_AfterSelect);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		base.Controls.Add(this.guna2VScrollBar2);
		base.Controls.Add(this.treeView1);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.guna2Button1);
		base.Controls.Add(this.guna2TextBox1);
		base.Name = "Phonenumber";
		base.Size = new System.Drawing.Size(758, 470);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
