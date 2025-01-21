using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace ZOPZ_TLO.UI;

public class Govmail : UserControl
{
	public class Contact
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("email")]
		public string Email { get; set; }

		[JsonPropertyName("location")]
		public string Location { get; set; }
	}

	private IContainer components = null;

	private Guna2DataGridView guna2DataGridView1;

	private Guna2VScrollBar guna2VScrollBar1;

	private new DataGridViewTextBoxColumn Name;

	private DataGridViewTextBoxColumn Email;

	private new DataGridViewTextBoxColumn Location;

	private Guna2ContextMenuStrip guna2ContextMenuStrip1;

	private ToolStripMenuItem copyToolStripMenuItem;

	public Govmail()
	{
		InitializeComponent();
		LoadData();
	}

	private async void LoadData()
	{
		try
		{
			HttpClient client = new HttpClient();
			try
			{
				string url = "https://zopzsniff.xyz/assets/zopzfiles/federalcontact.json";
				Contact[] contacts = JsonSerializer.Deserialize<Contact[]>(await client.GetStringAsync(url));
				guna2DataGridView1.Rows.Clear();
				Contact[] array = contacts;
				foreach (Contact contact in array)
				{
					Invoke((MethodInvoker)delegate
					{
						guna2DataGridView1.Rows.Add(contact.Name, contact.Email, contact.Location);
					});
				}
			}
			finally
			{
				((IDisposable)client)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			MessageBox.Show("Error loading data: " + ex2.Message);
		}
	}

	private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void guna2VScrollBar1_Scroll(object sender, ScrollEventArgs e)
	{
	}

	private void copyToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (guna2DataGridView1.SelectedRows.Count > 0)
		{
			DataGridViewRow dataGridViewRow = guna2DataGridView1.SelectedRows[0];
			string text = dataGridViewRow.Cells["Email"].Value.ToString();
			Clipboard.SetText(text);
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
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
		this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
		this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.guna2VScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
		this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
		this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		((System.ComponentModel.ISupportInitialize)this.guna2DataGridView1).BeginInit();
		this.guna2ContextMenuStrip1.SuspendLayout();
		base.SuspendLayout();
		this.guna2DataGridView1.AllowUserToAddRows = false;
		this.guna2DataGridView1.AllowUserToResizeColumns = false;
		this.guna2DataGridView1.AllowUserToResizeRows = false;
		dataGridViewCellStyle.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		dataGridViewCellStyle.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		dataGridViewCellStyle.ForeColor = System.Drawing.Color.White;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.Color.White;
		this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
		this.guna2DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(25, 25, 25);
		dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
		dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
		dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		this.guna2DataGridView1.ColumnHeadersHeight = 25;
		this.guna2DataGridView1.Columns.AddRange(this.Name, this.Email, this.Location);
		this.guna2DataGridView1.ContextMenuStrip = this.guna2ContextMenuStrip1;
		dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
		dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
		dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
		this.guna2DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2DataGridView1.Location = new System.Drawing.Point(0, 0);
		this.guna2DataGridView1.Name = "guna2DataGridView1";
		this.guna2DataGridView1.ReadOnly = true;
		this.guna2DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.guna2DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
		this.guna2DataGridView1.RowHeadersVisible = false;
		this.guna2DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		this.guna2DataGridView1.RowTemplate.Height = 35;
		this.guna2DataGridView1.Size = new System.Drawing.Size(758, 470);
		this.guna2DataGridView1.TabIndex = 0;
		this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
		this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
		this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
		this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
		this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
		this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(100, 88, 255);
		this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
		this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
		this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 25;
		this.guna2DataGridView1.ThemeStyle.ReadOnly = true;
		this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
		this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
		this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
		this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 35;
		this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(231, 229, 255);
		this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
		this.guna2DataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(guna2DataGridView1_CellContentClick);
		this.Name.HeaderText = "Name";
		this.Name.Name = "Name";
		this.Name.ReadOnly = true;
		this.Name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.Email.HeaderText = "Email";
		this.Email.Name = "Email";
		this.Email.ReadOnly = true;
		this.Email.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.Location.HeaderText = "Country / State";
		this.Location.Name = "Location";
		this.Location.ReadOnly = true;
		this.Location.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.guna2VScrollBar1.BindingContainer = this.guna2DataGridView1;
		this.guna2VScrollBar1.FillColor = System.Drawing.Color.White;
		this.guna2VScrollBar1.InUpdate = false;
		this.guna2VScrollBar1.LargeChange = 10;
		this.guna2VScrollBar1.Location = new System.Drawing.Point(740, 0);
		this.guna2VScrollBar1.Minimum = 1;
		this.guna2VScrollBar1.Name = "guna2VScrollBar1";
		this.guna2VScrollBar1.ScrollbarSize = 18;
		this.guna2VScrollBar1.Size = new System.Drawing.Size(18, 470);
		this.guna2VScrollBar1.TabIndex = 16;
		this.guna2VScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.guna2VScrollBar1.Value = 1;
		this.guna2VScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(guna2VScrollBar1_Scroll);
		this.guna2ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.copyToolStripMenuItem });
		this.guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
		this.guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(151, 143, 255);
		this.guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
		this.guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
		this.guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
		this.guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
		this.guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(100, 88, 255);
		this.guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
		this.guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
		this.guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
		this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(181, 48);
		this.copyToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.copyToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.copyToolStripMenuItem.ForeColor = System.Drawing.Color.White;
		this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
		this.copyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
		this.copyToolStripMenuItem.Text = "Copy";
		this.copyToolStripMenuItem.Click += new System.EventHandler(copyToolStripMenuItem_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		base.Controls.Add(this.guna2VScrollBar1);
		base.Controls.Add(this.guna2DataGridView1);
		base.Size = new System.Drawing.Size(758, 470);
		((System.ComponentModel.ISupportInitialize)this.guna2DataGridView1).EndInit();
		this.guna2ContextMenuStrip1.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
