using System;
using System.ComponentModel;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using Newtonsoft.Json.Linq;
using ZOPZ_TLO.Properties;

namespace ZOPZ_TLO.UI;

public class TLO : UserControl
{
	private IContainer components = null;

	private Label label1;

	private Guna2Button guna2Button1;

	private Guna2TextBox guna2TextBox1;

	private Guna2TextBox guna2TextBox2;

	private TreeView treeView1;

	public void alert(string msg, Alert.enmType type)
	{
		Alert alert = new Alert();
		alert.showAlert(msg, type);
	}

	public TLO()
	{
		InitializeComponent();
	}

	private async Task<string> GetSearchResult(string firstName, string lastName)
	{
		try
		{
			string apiUrl = "https://search.zopz-api.com/tlo?first_name=" + firstName + "&last_name=" + lastName + "&limit=1";
			HttpClient client = new HttpClient();
			try
			{
				client.Timeout = TimeSpan.FromSeconds(60.0);
				HttpResponseMessage response = await client.GetAsync(apiUrl);
				response.EnsureSuccessStatusCode();
				return await response.Content.ReadAsStringAsync();
			}
			finally
			{
				((IDisposable)client)?.Dispose();
			}
		}
		catch (TaskCanceledException ex)
		{
			TaskCanceledException ex2 = ex;
			alert("Error: " + ex2.Message, Alert.enmType.Success);
			return null;
		}
		catch (Exception ex3)
		{
			Exception ex4 = ex3;
			alert("Error: " + ex4.Message, Alert.enmType.Success);
			return null;
		}
	}

	private void DisplayFormattedResult(string jsonResponse)
	{
		if (string.IsNullOrEmpty(jsonResponse))
		{
			return;
		}
		try
		{
			treeView1.Nodes.Clear();
			JObject jObject = JObject.Parse(jsonResponse);
			string text = jObject["message"]?.ToString();
			if (text != "Success results found.")
			{
				TreeNode node = new TreeNode("No results found or an error occurred.");
				treeView1.Nodes.Add(node);
				return;
			}
			JArray jArray = (JArray)jObject["results"];
			if (jArray == null || jArray.Count == 0)
			{
				TreeNode node2 = new TreeNode("No results found.");
				treeView1.Nodes.Add(node2);
				return;
			}
			JObject jObject2 = (JObject)jArray[0];
			TreeNode treeNode = new TreeNode("NPD Lookup");
			treeNode.Nodes.Add("First Name: " + (jObject2["firstName"]?.ToString() ?? "N/A"));
			treeNode.Nodes.Add("Middle Initial: " + (jObject2["middleInitial"]?.ToString() ?? "N/A"));
			treeNode.Nodes.Add("Last Name: " + (jObject2["lastName"]?.ToString() ?? "N/A"));
			treeNode.Nodes.Add("Date of Birth: " + (jObject2["dateOfBirth"]?.ToString() ?? "N/A"));
			treeNode.Nodes.Add("Address: " + (jObject2["address"]?.ToString() ?? "N/A"));
			treeNode.Nodes.Add("Phone Number: " + (jObject2["phoneNumber"]?.ToString() ?? "N/A"));
			treeNode.Nodes.Add("SSN: " + FormatSSN(jObject2["ssn"]?.ToString()));
			treeView1.Nodes.Add(treeNode);
			treeView1.ExpandAll();
		}
		catch (Exception ex)
		{
			alert("Error: " + ex.Message, Alert.enmType.Success);
		}
	}

	private string FormatSSN(string ssn)
	{
		if (!string.IsNullOrEmpty(ssn) && ssn.Length == 9)
		{
			return ssn.Substring(0, 3) + "-" + ssn.Substring(3, 2) + "-" + ssn.Substring(5, 4);
		}
		return ssn;
	}

	private void guna2Button1_Click(object sender, EventArgs e)
	{
		Clipboard.SetText(treeView1.SelectedNode?.Text ?? "");
	}

	private async void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			treeView1.Nodes.Clear();
			treeView1.Nodes.Add(new TreeNode("Searching " + guna2TextBox1.Text + " " + guna2TextBox2.Text + " in the NDP database..."));
			e.SuppressKeyPress = true;
			string firstName = guna2TextBox1.Text.Trim();
			string lastName = guna2TextBox2.Text.Trim();
			string result = await GetSearchResult(firstName, lastName);
			treeView1.Nodes.Clear();
			DisplayFormattedResult(result);
		}
	}

	private void guna2TextBox1_TextChanged(object sender, EventArgs e)
	{
	}

	private async void guna2TextBox2_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			treeView1.Nodes.Clear();
			treeView1.Nodes.Add(new TreeNode("Searching " + guna2TextBox1.Text + " " + guna2TextBox2.Text + " in the NDP database..."));
			e.SuppressKeyPress = true;
			string firstName = guna2TextBox1.Text.Trim();
			string lastName = guna2TextBox2.Text.Trim();
			string result = await GetSearchResult(firstName, lastName);
			treeView1.Nodes.Clear();
			DisplayFormattedResult(result);
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZOPZ_TLO.UI.TLO));
		this.label1 = new System.Windows.Forms.Label();
		this.guna2TextBox2 = new Guna.UI2.WinForms.Guna2TextBox();
		this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
		this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
		this.treeView1 = new System.Windows.Forms.TreeView();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.Gray;
		this.label1.Location = new System.Drawing.Point(14, 15);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(76, 15);
		this.label1.TabIndex = 15;
		this.label1.Text = "NPD Lookup";
		this.guna2TextBox2.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.guna2TextBox2.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
		this.guna2TextBox2.DefaultText = "";
		this.guna2TextBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		this.guna2TextBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		this.guna2TextBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.guna2TextBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.guna2TextBox2.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2TextBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2TextBox2.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.guna2TextBox2.ForeColor = System.Drawing.Color.White;
		this.guna2TextBox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2TextBox2.IconLeft = (System.Drawing.Image)resources.GetObject("guna2TextBox2.IconLeft");
		this.guna2TextBox2.Location = new System.Drawing.Point(385, 45);
		this.guna2TextBox2.Name = "guna2TextBox2";
		this.guna2TextBox2.PasswordChar = '\0';
		this.guna2TextBox2.PlaceholderForeColor = System.Drawing.Color.White;
		this.guna2TextBox2.PlaceholderText = "Last Name";
		this.guna2TextBox2.SelectedText = "";
		this.guna2TextBox2.Size = new System.Drawing.Size(315, 36);
		this.guna2TextBox2.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
		this.guna2TextBox2.TabIndex = 16;
		this.guna2TextBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(guna2TextBox2_KeyDown);
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
		this.guna2Button1.TabIndex = 13;
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
		this.guna2TextBox1.IconLeft = (System.Drawing.Image)resources.GetObject("guna2TextBox1.IconLeft");
		this.guna2TextBox1.Location = new System.Drawing.Point(17, 45);
		this.guna2TextBox1.Name = "guna2TextBox1";
		this.guna2TextBox1.PasswordChar = '\0';
		this.guna2TextBox1.PlaceholderForeColor = System.Drawing.Color.White;
		this.guna2TextBox1.PlaceholderText = "First Name";
		this.guna2TextBox1.SelectedText = "";
		this.guna2TextBox1.Size = new System.Drawing.Size(361, 36);
		this.guna2TextBox1.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
		this.guna2TextBox1.TabIndex = 11;
		this.guna2TextBox1.TextChanged += new System.EventHandler(guna2TextBox1_TextChanged);
		this.guna2TextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(guna2TextBox1_KeyDown);
		this.treeView1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.treeView1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.treeView1.ForeColor = System.Drawing.Color.White;
		this.treeView1.LineColor = System.Drawing.Color.White;
		this.treeView1.Location = new System.Drawing.Point(17, 87);
		this.treeView1.Name = "treeView1";
		this.treeView1.Size = new System.Drawing.Size(725, 328);
		this.treeView1.TabIndex = 18;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		base.Controls.Add(this.treeView1);
		base.Controls.Add(this.guna2TextBox2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.guna2Button1);
		base.Controls.Add(this.guna2TextBox1);
		base.Name = "TLO";
		base.Size = new System.Drawing.Size(758, 470);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
