using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ZOPZ_TLO.Properties;

namespace ZOPZ_TLO.UI;

public class breachsearch : UserControl
{
	public class ApiResponse
	{
		public Dictionary<string, Database> List { get; set; }

		public int NumOfDatabase { get; set; }

		public int NumOfResults { get; set; }

		public int FreeRequestsLeft { get; set; }

		public decimal Price { get; set; }

		public decimal SearchTime { get; set; }
	}

	public class Database
	{
		public List<Entry> Data { get; set; }

		public string InfoLeak { get; set; }

		public int NumOfResults { get; set; }
	}

	public class Entry
	{
		public string Email { get; set; }

		public string Password { get; set; }

		public string Link { get; set; }
	}

	private IContainer components = null;

	private Label label1;

	private Guna2Button guna2Button1;

	private Guna2TextBox guna2TextBox1;

	private Guna2VScrollBar guna2VScrollBar1;

	private TreeView treeView1;

	private Guna2ComboBox guna2ComboBox1;

	public void alert(string msg, Alert.enmType type)
	{
		Alert alert = new Alert();
		alert.showAlert(msg, type);
	}

	public breachsearch()
	{
		InitializeComponent();
	}

	private async Task PerformSearch()
	{
		string query = guna2TextBox1.Text.Trim();
		if (string.IsNullOrWhiteSpace(query))
		{
			treeView1.Nodes.Clear();
			alert("Please enter a valid search term.", Alert.enmType.Success);
			return;
		}
		string selectedApi = guna2ComboBox1.SelectedItem?.ToString();
		if (string.IsNullOrEmpty(selectedApi))
		{
			alert("Please select an API to search with.", Alert.enmType.Success);
			return;
		}
		treeView1.Nodes.Clear();
		switch (selectedApi)
		{
		case "BreachDirectory API":
			await CallBreachDirectoryApi(query);
			break;
		case "LeakLookup API":
			await CallLeakLookupApi(query);
			break;
		case "Hunter.io API":
			await CallHunterApi(query);
			break;
		case "Intelx API":
			await CallLeakOsintApi(query);
			break;
		default:
			treeView1.Nodes.Add("Unknown API selected.");
			break;
		}
	}

	private async Task CallBreachDirectoryApi(string query)
	{
		string apiUrl = "https://breachdirectory.p.rapidapi.com/?func=auto&term=" + Uri.EscapeDataString(query);
		HttpClient client = new HttpClient();
		try
		{
			((HttpHeaders)client.DefaultRequestHeaders).Add("x-rapidapi-host", "breachdirectory.p.rapidapi.com");
			((HttpHeaders)client.DefaultRequestHeaders).Add("x-rapidapi-key", "cc0689c709msh7b328d4b1102908p11ae43jsnd83ede598775");
			HttpResponseMessage response = await client.GetAsync(apiUrl);
			response.EnsureSuccessStatusCode();
			DisplayJsonResponse("BreachDirectory API", await response.Content.ReadAsStringAsync());
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			treeView1.Nodes.Add("Error: " + ex2.Message + " (BreachDirectory API)");
		}
		finally
		{
			((IDisposable)client)?.Dispose();
		}
	}

	private async Task CallLeakLookupApi(string query)
	{
		string apiUrl = "https://leak-lookup.com/api/search";
		string apiKey = "bd799485f61f730b765dc97a87a46a9c";
		HttpClient client = new HttpClient();
		try
		{
			FormUrlEncodedContent content = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)new KeyValuePair<string, string>[3]
			{
				new KeyValuePair<string, string>("key", apiKey),
				new KeyValuePair<string, string>("type", "email"),
				new KeyValuePair<string, string>("query", query)
			});
			HttpResponseMessage response = await client.PostAsync(apiUrl, (HttpContent)(object)content);
			response.EnsureSuccessStatusCode();
			DisplayJsonResponse("LeakLookup API", await response.Content.ReadAsStringAsync());
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			treeView1.Nodes.Add("Error: " + ex2.Message + " (LeakLookup API)");
		}
		finally
		{
			((IDisposable)client)?.Dispose();
		}
	}

	private async Task CallHunterApi(string query)
	{
		string apiUrl = "https://api.hunter.io/v2/email-verifier?email=" + query + "&api_key=6b80968ffdc2210b33b855a7a405bbb9e12f9dfa";
		HttpClient client = new HttpClient();
		try
		{
			HttpResponseMessage response = await client.GetAsync(apiUrl);
			response.EnsureSuccessStatusCode();
			DisplayJsonResponse("Hunter.io API", await response.Content.ReadAsStringAsync());
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			treeView1.Nodes.Add("Error: " + ex2.Message + " (Hunter.io API)");
		}
		finally
		{
			((IDisposable)client)?.Dispose();
		}
	}

	private async Task CallLeakOsintApi(string query)
	{
		string apiUrl = "https://leakosintapi.com/";
		HttpClient client = new HttpClient();
		try
		{
			var data = new
			{
				token = "5392788187:MwSUYNjI",
				request = query,
				limit = 100,
				lang = "en"
			};
			string jsonPayload = JsonConvert.SerializeObject(data);
			StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
			HttpResponseMessage response = await client.PostAsync(apiUrl, (HttpContent)(object)content);
			response.EnsureSuccessStatusCode();
			DisplayJsonResponse("LeakOsintAPI", await response.Content.ReadAsStringAsync());
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			treeView1.Nodes.Add("Error: " + ex2.Message + " (LeakOsintAPI)");
		}
		finally
		{
			((IDisposable)client)?.Dispose();
		}
	}

	private void DisplayJsonResponse(string apiName, string jsonResponse)
	{
		try
		{
			JObject jObject = JObject.Parse(jsonResponse);
			TreeNode treeNode = new TreeNode(apiName);
			if (jObject["error"] != null && jObject["error"].ToString() == "true")
			{
				string text = jObject["message"]?.ToString() ?? "Unknown error.";
				treeNode.Nodes.Add("Error: " + text);
			}
			else
			{
				AddNodes(treeNode, jObject);
			}
			treeView1.Nodes.Add(treeNode);
			treeView1.ExpandAll();
		}
		catch (Exception ex)
		{
			treeView1.Nodes.Add("Error parsing JSON response: " + ex.Message);
		}
	}

	private void AddNodes(TreeNode treeNode, JToken token)
	{
		if (token is JObject jObject)
		{
			{
				foreach (JProperty item in jObject.Properties())
				{
					if (item.Name != "InfoLeak" && !item.Name.Contains("NumOfResults") && !item.Name.Contains("NumOfDatabase") && !item.Name.Contains("free_requests_left") && !item.Name.Contains("price") && !item.Name.Contains("search time"))
					{
						TreeNode treeNode2 = new TreeNode(item.Name);
						AddNodes(treeNode2, item.Value);
						treeNode.Nodes.Add(treeNode2);
					}
				}
				return;
			}
		}
		if (token is JArray jArray)
		{
			int num = 1;
			{
				foreach (JToken item2 in jArray)
				{
					TreeNode treeNode3 = new TreeNode($"Item {num}");
					AddNodes(treeNode3, item2);
					treeNode.Nodes.Add(treeNode3);
					num++;
				}
				return;
			}
		}
		treeNode.Text += $": {token}";
	}

	private async void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			await PerformSearch();
		}
	}

	private void guna2TextBox1_TextChanged(object sender, EventArgs e)
	{
	}

	private string GetTreeViewText(TreeView treeView)
	{
		string text = string.Empty;
		foreach (TreeNode node in treeView.Nodes)
		{
			text += GetNodeText(node, 0);
		}
		return text;
	}

	private string GetNodeText(TreeNode node, int level)
	{
		string text = new string(' ', level * 2);
		string text2 = text + node.Text + Environment.NewLine;
		foreach (TreeNode node2 in node.Nodes)
		{
			text2 += GetNodeText(node2, level + 1);
		}
		return text2;
	}

	private void guna2Button1_Click(object sender, EventArgs e)
	{
		Clipboard.SetText(GetTreeViewText(treeView1));
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
		this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
		this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
		this.guna2VScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
		this.treeView1 = new System.Windows.Forms.TreeView();
		this.guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.Gray;
		this.label1.Location = new System.Drawing.Point(14, 15);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(126, 15);
		this.label1.TabIndex = 16;
		this.label1.Text = "Email Breach Search";
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
		this.guna2TextBox1.Location = new System.Drawing.Point(17, 45);
		this.guna2TextBox1.Name = "guna2TextBox1";
		this.guna2TextBox1.PasswordChar = '\0';
		this.guna2TextBox1.PlaceholderForeColor = System.Drawing.Color.White;
		this.guna2TextBox1.PlaceholderText = "Enter a email";
		this.guna2TextBox1.SelectedText = "";
		this.guna2TextBox1.Size = new System.Drawing.Size(477, 36);
		this.guna2TextBox1.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
		this.guna2TextBox1.TabIndex = 12;
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
		this.guna2Button1.TabIndex = 14;
		this.guna2Button1.Click += new System.EventHandler(guna2Button1_Click);
		this.guna2VScrollBar1.BindingContainer = this.treeView1;
		this.guna2VScrollBar1.FillColor = System.Drawing.Color.White;
		this.guna2VScrollBar1.InUpdate = false;
		this.guna2VScrollBar1.LargeChange = 10;
		this.guna2VScrollBar1.Location = new System.Drawing.Point(724, 87);
		this.guna2VScrollBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.guna2VScrollBar1.Name = "guna2VScrollBar1";
		this.guna2VScrollBar1.ScrollbarSize = 18;
		this.guna2VScrollBar1.Size = new System.Drawing.Size(18, 328);
		this.guna2VScrollBar1.TabIndex = 24;
		this.guna2VScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.treeView1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.treeView1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.treeView1.ForeColor = System.Drawing.Color.White;
		this.treeView1.LineColor = System.Drawing.Color.White;
		this.treeView1.Location = new System.Drawing.Point(17, 87);
		this.treeView1.Name = "treeView1";
		this.treeView1.Size = new System.Drawing.Size(725, 328);
		this.treeView1.TabIndex = 23;
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
		this.guna2ComboBox1.Items.AddRange(new object[4] { "BreachDirectory API", "LeakLookup API", "Hunter.io API", "Intelx API" });
		this.guna2ComboBox1.ItemsAppearance.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2ComboBox1.ItemsAppearance.ForeColor = System.Drawing.Color.White;
		this.guna2ComboBox1.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.guna2ComboBox1.ItemsAppearance.SelectedForeColor = System.Drawing.Color.White;
		this.guna2ComboBox1.Location = new System.Drawing.Point(500, 45);
		this.guna2ComboBox1.Name = "guna2ComboBox1";
		this.guna2ComboBox1.Size = new System.Drawing.Size(202, 36);
		this.guna2ComboBox1.StartIndex = 0;
		this.guna2ComboBox1.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
		this.guna2ComboBox1.TabIndex = 25;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		base.Controls.Add(this.guna2ComboBox1);
		base.Controls.Add(this.guna2VScrollBar1);
		base.Controls.Add(this.treeView1);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.guna2Button1);
		base.Controls.Add(this.guna2TextBox1);
		base.Name = "breachsearch";
		base.Size = new System.Drawing.Size(758, 470);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
