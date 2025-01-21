using System;
using System.ComponentModel;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using Newtonsoft.Json.Linq;
using ZOPZ_TLO.Properties;

namespace ZOPZ_TLO.UI;

public class Shoden : UserControl
{
	private IContainer components = null;

	private Label label1;

	private Guna2VScrollBar guna2VScrollBar1;

	private Guna2Button guna2Button1;

	private Guna2TextBox guna2TextBox1;

	private TreeView treeView1;

	private Guna2HScrollBar guna2HScrollBar1;

	public void alert(string msg, Alert.enmType type)
	{
		Alert alert = new Alert();
		alert.showAlert(msg, type);
	}

	public Shoden()
	{
		InitializeComponent();
	}

	private async Task LookupShodan(string ip)
	{
		string apiKey = "nnKaUK8FAG3SQPE8ANQHdulhdxPNyDEo";
		string apiUrl = "https://api.shodan.io/shodan/host/" + ip + "?key=" + apiKey;
		HttpClient client = new HttpClient();
		try
		{
			HttpResponseMessage response = await client.GetAsync(apiUrl);
			response.EnsureSuccessStatusCode();
			JObject json = JObject.Parse(await response.Content.ReadAsStringAsync());
			PopulateTreeView(json);
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			alert("Error: " + ex2.Message, Alert.enmType.Success);
		}
		finally
		{
			((IDisposable)client)?.Dispose();
		}
	}

	private void PopulateTreeView(JObject json)
	{
		treeView1.Nodes.Clear();
		TreeNode treeNode = new TreeNode("Shodan Data");
		AddJsonToTreeView(json, treeNode);
		treeView1.Nodes.Add(treeNode);
		treeView1.ExpandAll();
	}

	private void AddJsonToTreeView(JToken token, TreeNode parentNode)
	{
		if (token is JObject jObject)
		{
			{
				foreach (JProperty item in jObject.Properties())
				{
					TreeNode treeNode = new TreeNode(item.Name);
					parentNode.Nodes.Add(treeNode);
					AddJsonToTreeView(item.Value, treeNode);
				}
				return;
			}
		}
		if (token is JArray jArray)
		{
			{
				foreach (JToken item2 in jArray)
				{
					TreeNode treeNode2 = new TreeNode("Item");
					parentNode.Nodes.Add(treeNode2);
					AddJsonToTreeView(item2, treeNode2);
				}
				return;
			}
		}
		parentNode.Nodes.Add(token.ToString());
	}

	private async void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			e.SuppressKeyPress = true;
			string ip = guna2TextBox1.Text.Trim();
			if (string.IsNullOrWhiteSpace(ip))
			{
				MessageBox.Show("Please enter a valid IP address.");
			}
			else
			{
				await LookupShodan(ip);
			}
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
		this.treeView1 = new System.Windows.Forms.TreeView();
		this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
		this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
		this.guna2HScrollBar1 = new Guna.UI2.WinForms.Guna2HScrollBar();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.Gray;
		this.label1.Location = new System.Drawing.Point(11, 15);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(95, 15);
		this.label1.TabIndex = 10;
		this.label1.Text = "Shoden Lookup";
		this.guna2VScrollBar1.BindingContainer = this.treeView1;
		this.guna2VScrollBar1.FillColor = System.Drawing.Color.White;
		this.guna2VScrollBar1.InUpdate = false;
		this.guna2VScrollBar1.LargeChange = 10;
		this.guna2VScrollBar1.Location = new System.Drawing.Point(724, 87);
		this.guna2VScrollBar1.Name = "guna2VScrollBar1";
		this.guna2VScrollBar1.ScrollbarSize = 18;
		this.guna2VScrollBar1.Size = new System.Drawing.Size(18, 328);
		this.guna2VScrollBar1.TabIndex = 9;
		this.guna2VScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.treeView1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.treeView1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.treeView1.ForeColor = System.Drawing.Color.White;
		this.treeView1.LineColor = System.Drawing.Color.White;
		this.treeView1.Location = new System.Drawing.Point(17, 87);
		this.treeView1.Name = "treeView1";
		this.treeView1.Size = new System.Drawing.Size(725, 328);
		this.treeView1.TabIndex = 19;
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
		this.guna2TextBox1.IconLeft = ZOPZ_TLO.Properties.Resources.Web_Address;
		this.guna2TextBox1.Location = new System.Drawing.Point(17, 45);
		this.guna2TextBox1.Name = "guna2TextBox1";
		this.guna2TextBox1.PasswordChar = '\0';
		this.guna2TextBox1.PlaceholderForeColor = System.Drawing.Color.White;
		this.guna2TextBox1.PlaceholderText = "IP Address (70.70.70.7)";
		this.guna2TextBox1.SelectedText = "";
		this.guna2TextBox1.Size = new System.Drawing.Size(685, 36);
		this.guna2TextBox1.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
		this.guna2TextBox1.TabIndex = 6;
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
		this.guna2HScrollBar1.BindingContainer = this.treeView1;
		this.guna2HScrollBar1.FillColor = System.Drawing.Color.White;
		this.guna2HScrollBar1.InUpdate = false;
		this.guna2HScrollBar1.LargeChange = 10;
		this.guna2HScrollBar1.Location = new System.Drawing.Point(17, 397);
		this.guna2HScrollBar1.Name = "guna2HScrollBar1";
		this.guna2HScrollBar1.ScrollbarSize = 18;
		this.guna2HScrollBar1.Size = new System.Drawing.Size(725, 18);
		this.guna2HScrollBar1.TabIndex = 21;
		this.guna2HScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(25, 25, 25);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		base.Controls.Add(this.guna2HScrollBar1);
		base.Controls.Add(this.guna2VScrollBar1);
		base.Controls.Add(this.treeView1);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.guna2Button1);
		base.Controls.Add(this.guna2TextBox1);
		base.Name = "Shoden";
		base.Size = new System.Drawing.Size(758, 470);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
