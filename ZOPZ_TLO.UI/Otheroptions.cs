using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace ZOPZ_TLO.UI;

public class Otheroptions : UserControl
{
	private IContainer components = null;

	private Guna2Panel guna2Panel1;

	private FlowLayoutPanel flowLayoutPanel1;

	private Label label1;

	private Label label2;

	private Label label3;

	public Otheroptions()
	{
		InitializeComponent();
		guna2Panel1.Controls.Clear();
		guna2Panel1.Controls.Add(new Shoden());
	}

	private void guna2Button1_Click(object sender, EventArgs e)
	{
	}

	private void guna2Button2_Click(object sender, EventArgs e)
	{
		guna2Panel1.Controls.Clear();
		guna2Panel1.Controls.Add(new Shoden());
	}

	private void guna2Button4_Click(object sender, EventArgs e)
	{
		guna2Panel1.Controls.Clear();
		guna2Panel1.Controls.Add(new googledork());
	}

	private void guna2Button3_Click(object sender, EventArgs e)
	{
		guna2Panel1.Controls.Clear();
		guna2Panel1.Controls.Add(new breachsearch());
	}

	private void label1_Click(object sender, EventArgs e)
	{
		guna2Panel1.Controls.Clear();
		guna2Panel1.Controls.Add(new Shoden());
	}

	private void label2_Click(object sender, EventArgs e)
	{
		guna2Panel1.Controls.Clear();
		guna2Panel1.Controls.Add(new googledork());
	}

	private void label3_Click(object sender, EventArgs e)
	{
		guna2Panel1.Controls.Clear();
		guna2Panel1.Controls.Add(new breachsearch());
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
		this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
		this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.flowLayoutPanel1.SuspendLayout();
		base.SuspendLayout();
		this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.guna2Panel1.Location = new System.Drawing.Point(0, 38);
		this.guna2Panel1.Name = "guna2Panel1";
		this.guna2Panel1.Size = new System.Drawing.Size(758, 432);
		this.guna2Panel1.TabIndex = 13;
		this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
		this.flowLayoutPanel1.Controls.Add(this.label1);
		this.flowLayoutPanel1.Controls.Add(this.label2);
		this.flowLayoutPanel1.Controls.Add(this.label3);
		this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
		this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
		this.flowLayoutPanel1.Name = "flowLayoutPanel1";
		this.flowLayoutPanel1.Size = new System.Drawing.Size(758, 32);
		this.flowLayoutPanel1.TabIndex = 14;
		this.label1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.label1.ForeColor = System.Drawing.Color.White;
		this.label1.Location = new System.Drawing.Point(3, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(246, 31);
		this.label1.TabIndex = 18;
		this.label1.Text = "Shoden ";
		this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label1.Click += new System.EventHandler(label1_Click);
		this.label2.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.label2.ForeColor = System.Drawing.Color.White;
		this.label2.Location = new System.Drawing.Point(255, 0);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(246, 31);
		this.label2.TabIndex = 19;
		this.label2.Text = "Google Dork";
		this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label2.Click += new System.EventHandler(label2_Click);
		this.label3.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.label3.ForeColor = System.Drawing.Color.White;
		this.label3.Location = new System.Drawing.Point(507, 0);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(246, 31);
		this.label3.TabIndex = 20;
		this.label3.Text = "Email Breach";
		this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label3.Click += new System.EventHandler(label3_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		base.Controls.Add(this.flowLayoutPanel1);
		base.Controls.Add(this.guna2Panel1);
		base.Name = "Otheroptions";
		base.Size = new System.Drawing.Size(758, 470);
		this.flowLayoutPanel1.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
