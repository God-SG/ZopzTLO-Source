using System;
using System.ComponentModel;
using System.Drawing;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using Newtonsoft.Json.Linq;
using ZOPZ_TLO.Properties;

namespace ZOPZ_TLO.UI;

public class ssnlookup : UserControl
{
	private IContainer components = null;

	private Label label1;

	private Guna2Button guna2Button1;

	private Guna2TextBox guna2TextBox1;

	private TreeView treeView1;

	private Guna2VScrollBar guna2VScrollBar1;

	public void alert(string msg, Alert.enmType type)
	{
		Alert alert = new Alert();
		alert.showAlert(msg, type);
	}

	public ssnlookup()
	{
		InitializeComponent();
	}

	private void guna2Button1_Click(object sender, EventArgs e)
	{
		if (treeView1.Nodes.Count > 0 && treeView1.SelectedNode != null)
		{
			Clipboard.SetText(treeView1.SelectedNode.Text);
		}
	}

	private async Task<string> GetSearchResult(string ssn, CancellationToken cancellationToken)
	{
		try
		{
			string apiUrl = "https://search.zopz-api.com/tlo?ssn=" + ssn;
			HttpClient client = new HttpClient
			{
				Timeout = TimeSpan.FromSeconds(60.0)
			};
			try
			{
				HttpResponseMessage response = await client.GetAsync(apiUrl, cancellationToken);
				response.EnsureSuccessStatusCode();
				return await response.Content.ReadAsStringAsync();
			}
			finally
			{
				((IDisposable)client)?.Dispose();
			}
		}
		catch (TaskCanceledException)
		{
			throw new OperationCanceledException("The request was canceled or timed out.");
		}
		catch (HttpRequestException val)
		{
			HttpRequestException val2 = val;
			HttpRequestException ex2 = val2;
			throw new Exception("Network error: " + ((Exception)(object)ex2).Message);
		}
		catch (Exception ex3)
		{
			Exception ex4 = ex3;
			throw new Exception("Unexpected error: " + ex4.Message);
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
			if (jObject["message"]?.ToString() != "Success results found.")
			{
				treeView1.Nodes.Add(new TreeNode("No matching data found."));
				return;
			}
			JArray jArray = (JArray)jObject["results"];
			if (jArray == null || jArray.Count == 0)
			{
				treeView1.Nodes.Add(new TreeNode("No matching data found."));
				return;
			}
			JObject jObject2 = (JObject)jArray[0];
			TreeNode treeNode = new TreeNode("SSN Lookup");
			treeNode.Nodes.Add("First Name: " + (jObject2["firstName"]?.ToString() ?? "N/A"));
			treeNode.Nodes.Add("Middle Initial: " + (jObject2["middleInitial"]?.ToString() ?? "N/A"));
			treeNode.Nodes.Add("Last Name: " + (jObject2["lastName"]?.ToString() ?? "N/A"));
			string text = jObject2["dateOfBirth"]?.ToString() ?? "N/A";
			string text2 = ((text.Length == 8) ? (text.Substring(0, 4) + "-" + text.Substring(4, 2) + "-" + text.Substring(6, 2)) : text);
			treeNode.Nodes.Add("Date of Birth: " + text2);
			treeNode.Nodes.Add("Address: " + (jObject2["address"]?.ToString() ?? "N/A"));
			treeNode.Nodes.Add("Phone Number: " + (jObject2["phoneNumber"]?.ToString() ?? "N/A"));
			treeNode.Nodes.Add("SSN: " + FormatSSN(jObject2["ssn"]?.ToString()));
			treeView1.Nodes.Add(treeNode);
			treeView1.ExpandAll();
		}
		catch (Exception ex)
		{
			alert("Error formatting result: " + ex.Message, Alert.enmType.Success);
		}
	}

	private string FormatSSN(string ssn)
	{
		if (ssn.Length == 9)
		{
			return ssn.Substring(0, 3) + "-" + ssn.Substring(3, 2) + "-" + ssn.Substring(5, 4);
		}
		return ssn;
	}

	private async void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode != Keys.Return)
		{
			return;
		}
		e.SuppressKeyPress = true;
		string ssn = guna2TextBox1.Text.Trim();
		if (string.IsNullOrEmpty(ssn))
		{
			treeView1.Nodes.Clear();
			alert("Error: SSN field cannot be empty.", Alert.enmType.Success);
			return;
		}
		treeView1.Nodes.Clear();
		treeView1.Nodes.Add(new TreeNode("Searching for SSN: " + FormatSSN(ssn) + " in the database..."));
		CancellationTokenSource cts = new CancellationTokenSource();
		try
		{
			string result = await GetSearchResult(ssn, cts.Token);
			treeView1.Nodes.Clear();
			DisplayFormattedResult(result);
		}
		catch (OperationCanceledException)
		{
			treeView1.Nodes.Clear();
			alert("The request was canceled.", Alert.enmType.Success);
		}
		catch (Exception ex2)
		{
			Exception ex3 = ex2;
			treeView1.Nodes.Clear();
			alert("Error: " + ex3.Message, Alert.enmType.Success);
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
		this.label1 = new System.Windows.Forms.Label();
		this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
		this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
		this.treeView1 = new System.Windows.Forms.TreeView();
		this.guna2VScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.Gray;
		this.label1.Location = new System.Drawing.Point(11, 15);
		this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(76, 15);
		this.label1.TabIndex = 15;
		this.label1.Text = "SSN Lookup";
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
		this.guna2TextBox1.TabIndex = 11;
		this.guna2TextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(guna2TextBox1_KeyDown);
		this.treeView1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.treeView1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.treeView1.ForeColor = System.Drawing.Color.White;
		this.treeView1.LineColor = System.Drawing.Color.White;
		this.treeView1.Location = new System.Drawing.Point(17, 87);
		this.treeView1.Name = "treeView1";
		this.treeView1.Size = new System.Drawing.Size(725, 328);
		this.treeView1.TabIndex = 19;
		this.guna2VScrollBar1.BindingContainer = this.treeView1;
		this.guna2VScrollBar1.FillColor = System.Drawing.Color.White;
		this.guna2VScrollBar1.InUpdate = false;
		this.guna2VScrollBar1.LargeChange = 10;
		this.guna2VScrollBar1.Location = new System.Drawing.Point(724, 87);
		this.guna2VScrollBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.guna2VScrollBar1.Name = "guna2VScrollBar1";
		this.guna2VScrollBar1.ScrollbarSize = 18;
		this.guna2VScrollBar1.Size = new System.Drawing.Size(18, 328);
		this.guna2VScrollBar1.TabIndex = 20;
		this.guna2VScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(25, 25, 25);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		base.Controls.Add(this.guna2VScrollBar1);
		base.Controls.Add(this.treeView1);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.guna2Button1);
		base.Controls.Add(this.guna2TextBox1);
		base.Name = "ssnlookup";
		base.Size = new System.Drawing.Size(758, 470);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
