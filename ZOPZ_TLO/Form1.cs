using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Guna.UI2.AnimatorNS;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using ZOPZ_TLO.UI;

namespace ZOPZ_TLO;

public class Form1 : Form
{
	private IContainer components;

	private Panel panel1;

	private Guna2DragControl guna2DragControl1;

	private Panel panel2;

	private Label label1;

	private Label label2;

	private Guna2Panel guna2Panel1;

	private Guna2Panel guna2Panel2;

	private Label label3;

	private Panel panel3;

	private Guna2Panel guna2Panel3;

	private Label label4;

	private Guna2Panel guna2Panel4;

	private Label label5;

	private IconButton iconButton1;

	private IconButton iconButton2;

	private IconButton iconButton3;

	private IconButton iconButton4;

	private IconButton iconButton5;

	private IconButton iconButton6;

	private IconButton iconButton7;

	private IconButton iconButton8;

	private Guna2Transition Ani;

	private Guna2ControlBox guna2ControlBox3;

	private Guna2ControlBox guna2ControlBox2;

	private Guna2ControlBox guna2ControlBox1;

	public Form1()
	{
		InitializeComponent();
		Text = string.Empty;
		base.ControlBox = false;
		DoubleBuffered = true;
		base.MaximizedBounds = Screen.FromHandle(base.Handle).WorkingArea;
		panel3.Controls.Add(new Addresslookup());
		MessageBox.Show("Nigger Zopz lol");
		Process.Start("https://discord.gg/shadowgarden");
	}

	private void guna2Button1_Click(object sender, EventArgs e)
	{
		panel3.Controls.Clear();
		panel3.Controls.Add(new Addresslookup());
	}

	private void Form1_Load(object sender, EventArgs e)
	{
	}

	private void iconButton1_Click(object sender, EventArgs e)
	{
		panel3.Controls.Clear();
		panel3.Controls.Add(new Addresslookup());
	}

	private void iconButton2_Click(object sender, EventArgs e)
	{
		panel3.Controls.Clear();
		panel3.Controls.Add(new Phonenumber());
	}

	private void iconButton3_Click(object sender, EventArgs e)
	{
		panel3.Controls.Clear();
		panel3.Controls.Add(new Fullnamelookup());
	}

	private void iconButton4_Click(object sender, EventArgs e)
	{
		panel3.Controls.Clear();
		panel3.Controls.Add(new Otheroptions());
	}

	private void iconButton5_Click(object sender, EventArgs e)
	{
		panel3.Controls.Clear();
		panel3.Controls.Add(new Moreoptions());
	}

	private void iconButton6_Click(object sender, EventArgs e)
	{
		panel3.Controls.Clear();
		panel3.Controls.Add(new TLOXp());
	}

	private void iconButton7_Click(object sender, EventArgs e)
	{
		panel3.Controls.Clear();
		panel3.Controls.Add(new restorecord());
	}

	private void iconButton8_Click(object sender, EventArgs e)
	{
		panel3.Controls.Clear();
		panel3.Controls.Add(new Govmail());
	}

	private void ShowMenuBTN_Click(object sender, EventArgs e)
	{
	}

	private void MinmizeBTN_Click(object sender, EventArgs e)
	{
		base.WindowState = FormWindowState.Minimized;
	}

	private void OpenDiscordBTN_Click(object sender, EventArgs e)
	{
		base.WindowState = FormWindowState.Maximized;
	}

	private void CloseBTN_Click(object sender, EventArgs e)
	{
		Environment.Exit(0);
	}

	private void guna2ControlBox1_Click_1(object sender, EventArgs e)
	{
		Environment.Exit(0);
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
		this.components = new System.ComponentModel.Container();
		Guna.UI2.AnimatorNS.Animation animation = new Guna.UI2.AnimatorNS.Animation();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZOPZ_TLO.Form1));
		this.panel1 = new System.Windows.Forms.Panel();
		this.label1 = new System.Windows.Forms.Label();
		this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
		this.panel2 = new System.Windows.Forms.Panel();
		this.iconButton8 = new FontAwesome.Sharp.IconButton();
		this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
		this.label5 = new System.Windows.Forms.Label();
		this.iconButton7 = new FontAwesome.Sharp.IconButton();
		this.iconButton6 = new FontAwesome.Sharp.IconButton();
		this.iconButton5 = new FontAwesome.Sharp.IconButton();
		this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
		this.label4 = new System.Windows.Forms.Label();
		this.iconButton4 = new FontAwesome.Sharp.IconButton();
		this.iconButton3 = new FontAwesome.Sharp.IconButton();
		this.iconButton2 = new FontAwesome.Sharp.IconButton();
		this.label2 = new System.Windows.Forms.Label();
		this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
		this.iconButton1 = new FontAwesome.Sharp.IconButton();
		this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
		this.label3 = new System.Windows.Forms.Label();
		this.panel3 = new System.Windows.Forms.Panel();
		this.Ani = new Guna.UI2.WinForms.Guna2Transition();
		this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
		this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
		this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
		this.panel1.SuspendLayout();
		this.panel2.SuspendLayout();
		this.guna2Panel4.SuspendLayout();
		this.guna2Panel3.SuspendLayout();
		this.guna2Panel2.SuspendLayout();
		base.SuspendLayout();
		this.panel1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.panel1.Controls.Add(this.guna2ControlBox3);
		this.panel1.Controls.Add(this.guna2ControlBox2);
		this.panel1.Controls.Add(this.guna2ControlBox1);
		this.panel1.Controls.Add(this.label1);
		this.Ani.SetDecoration(this.panel1, Guna.UI2.AnimatorNS.DecorationType.None);
		this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
		this.panel1.Location = new System.Drawing.Point(0, 0);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(956, 39);
		this.panel1.TabIndex = 0;
		this.label1.AutoSize = true;
		this.Ani.SetDecoration(this.label1, Guna.UI2.AnimatorNS.DecorationType.None);
		this.label1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.Gray;
		this.label1.Location = new System.Drawing.Point(3, 12);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(110, 15);
		this.label1.TabIndex = 3;
		this.label1.Text = "ZOPZ Shit Lookup";
		this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
		this.guna2DragControl1.TargetControl = this.panel1;
		this.guna2DragControl1.TransparentWhileDrag = false;
		this.panel2.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
		this.panel2.Controls.Add(this.iconButton8);
		this.panel2.Controls.Add(this.guna2Panel4);
		this.panel2.Controls.Add(this.iconButton7);
		this.panel2.Controls.Add(this.iconButton6);
		this.panel2.Controls.Add(this.iconButton5);
		this.panel2.Controls.Add(this.guna2Panel3);
		this.panel2.Controls.Add(this.iconButton4);
		this.panel2.Controls.Add(this.iconButton3);
		this.panel2.Controls.Add(this.iconButton2);
		this.panel2.Controls.Add(this.label2);
		this.panel2.Controls.Add(this.guna2Panel1);
		this.panel2.Controls.Add(this.iconButton1);
		this.panel2.Controls.Add(this.guna2Panel2);
		this.Ani.SetDecoration(this.panel2, Guna.UI2.AnimatorNS.DecorationType.None);
		this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
		this.panel2.Location = new System.Drawing.Point(0, 39);
		this.panel2.Name = "panel2";
		this.panel2.Size = new System.Drawing.Size(198, 470);
		this.panel2.TabIndex = 1;
		this.iconButton8.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
		this.Ani.SetDecoration(this.iconButton8, Guna.UI2.AnimatorNS.DecorationType.None);
		this.iconButton8.FlatAppearance.BorderSize = 0;
		this.iconButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.iconButton8.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.iconButton8.ForeColor = System.Drawing.Color.White;
		this.iconButton8.IconChar = FontAwesome.Sharp.IconChar.Flag;
		this.iconButton8.IconColor = System.Drawing.Color.White;
		this.iconButton8.IconFont = FontAwesome.Sharp.IconFont.Solid;
		this.iconButton8.IconSize = 25;
		this.iconButton8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.iconButton8.Location = new System.Drawing.Point(3, 419);
		this.iconButton8.Name = "iconButton8";
		this.iconButton8.Size = new System.Drawing.Size(192, 41);
		this.iconButton8.TabIndex = 20;
		this.iconButton8.Text = "Gov Report";
		this.iconButton8.UseVisualStyleBackColor = false;
		this.iconButton8.Click += new System.EventHandler(iconButton8_Click);
		this.guna2Panel4.Controls.Add(this.label5);
		this.Ani.SetDecoration(this.guna2Panel4, Guna.UI2.AnimatorNS.DecorationType.None);
		this.guna2Panel4.Location = new System.Drawing.Point(2, 389);
		this.guna2Panel4.Name = "guna2Panel4";
		this.guna2Panel4.Size = new System.Drawing.Size(193, 28);
		this.guna2Panel4.TabIndex = 19;
		this.Ani.SetDecoration(this.label5, Guna.UI2.AnimatorNS.DecorationType.None);
		this.label5.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold);
		this.label5.ForeColor = System.Drawing.Color.Gray;
		this.label5.Location = new System.Drawing.Point(3, 7);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(106, 15);
		this.label5.TabIndex = 11;
		this.label5.Text = "GOV Portal";
		this.iconButton7.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
		this.Ani.SetDecoration(this.iconButton7, Guna.UI2.AnimatorNS.DecorationType.None);
		this.iconButton7.FlatAppearance.BorderSize = 0;
		this.iconButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.iconButton7.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.iconButton7.ForeColor = System.Drawing.Color.White;
		this.iconButton7.IconChar = FontAwesome.Sharp.IconChar.Database;
		this.iconButton7.IconColor = System.Drawing.Color.White;
		this.iconButton7.IconFont = FontAwesome.Sharp.IconFont.Solid;
		this.iconButton7.IconSize = 25;
		this.iconButton7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.iconButton7.Location = new System.Drawing.Point(3, 346);
		this.iconButton7.Name = "iconButton7";
		this.iconButton7.Size = new System.Drawing.Size(192, 41);
		this.iconButton7.TabIndex = 19;
		this.iconButton7.Text = "Restore Cord DB";
		this.iconButton7.UseVisualStyleBackColor = false;
		this.iconButton7.Click += new System.EventHandler(iconButton7_Click);
		this.iconButton6.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
		this.Ani.SetDecoration(this.iconButton6, Guna.UI2.AnimatorNS.DecorationType.None);
		this.iconButton6.FlatAppearance.BorderSize = 0;
		this.iconButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.iconButton6.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.iconButton6.ForeColor = System.Drawing.Color.White;
		this.iconButton6.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
		this.iconButton6.IconColor = System.Drawing.Color.White;
		this.iconButton6.IconFont = FontAwesome.Sharp.IconFont.Solid;
		this.iconButton6.IconSize = 25;
		this.iconButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.iconButton6.Location = new System.Drawing.Point(3, 305);
		this.iconButton6.Name = "iconButton6";
		this.iconButton6.Size = new System.Drawing.Size(192, 41);
		this.iconButton6.TabIndex = 18;
		this.iconButton6.Text = "NPD Search";
		this.iconButton6.UseVisualStyleBackColor = false;
		this.iconButton6.Click += new System.EventHandler(iconButton6_Click);
		this.iconButton5.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
		this.Ani.SetDecoration(this.iconButton5, Guna.UI2.AnimatorNS.DecorationType.None);
		this.iconButton5.FlatAppearance.BorderSize = 0;
		this.iconButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.iconButton5.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.iconButton5.ForeColor = System.Drawing.Color.White;
		this.iconButton5.IconChar = FontAwesome.Sharp.IconChar.Brain;
		this.iconButton5.IconColor = System.Drawing.Color.White;
		this.iconButton5.IconFont = FontAwesome.Sharp.IconFont.Solid;
		this.iconButton5.IconSize = 25;
		this.iconButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.iconButton5.Location = new System.Drawing.Point(3, 264);
		this.iconButton5.Name = "iconButton5";
		this.iconButton5.Size = new System.Drawing.Size(192, 41);
		this.iconButton5.TabIndex = 17;
		this.iconButton5.Text = "Search Options";
		this.iconButton5.UseVisualStyleBackColor = false;
		this.iconButton5.Click += new System.EventHandler(iconButton5_Click);
		this.guna2Panel3.Controls.Add(this.label4);
		this.Ani.SetDecoration(this.guna2Panel3, Guna.UI2.AnimatorNS.DecorationType.None);
		this.guna2Panel3.Location = new System.Drawing.Point(3, 235);
		this.guna2Panel3.Name = "guna2Panel3";
		this.guna2Panel3.Size = new System.Drawing.Size(192, 27);
		this.guna2Panel3.TabIndex = 16;
		this.Ani.SetDecoration(this.label4, Guna.UI2.AnimatorNS.DecorationType.None);
		this.label4.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold);
		this.label4.ForeColor = System.Drawing.Color.Gray;
		this.label4.Location = new System.Drawing.Point(7, 6);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(106, 15);
		this.label4.TabIndex = 11;
		this.label4.Text = "Private Options";
		this.iconButton4.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
		this.Ani.SetDecoration(this.iconButton4, Guna.UI2.AnimatorNS.DecorationType.None);
		this.iconButton4.FlatAppearance.BorderSize = 0;
		this.iconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.iconButton4.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.iconButton4.ForeColor = System.Drawing.Color.White;
		this.iconButton4.IconChar = FontAwesome.Sharp.IconChar.Brain;
		this.iconButton4.IconColor = System.Drawing.Color.White;
		this.iconButton4.IconFont = FontAwesome.Sharp.IconFont.Solid;
		this.iconButton4.IconSize = 25;
		this.iconButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.iconButton4.Location = new System.Drawing.Point(3, 193);
		this.iconButton4.Name = "iconButton4";
		this.iconButton4.Size = new System.Drawing.Size(192, 41);
		this.iconButton4.TabIndex = 13;
		this.iconButton4.Text = "Search Options";
		this.iconButton4.UseVisualStyleBackColor = false;
		this.iconButton4.Click += new System.EventHandler(iconButton4_Click);
		this.iconButton3.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
		this.Ani.SetDecoration(this.iconButton3, Guna.UI2.AnimatorNS.DecorationType.None);
		this.iconButton3.FlatAppearance.BorderSize = 0;
		this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.iconButton3.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.iconButton3.ForeColor = System.Drawing.Color.White;
		this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
		this.iconButton3.IconColor = System.Drawing.Color.White;
		this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Solid;
		this.iconButton3.IconSize = 25;
		this.iconButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.iconButton3.Location = new System.Drawing.Point(3, 123);
		this.iconButton3.Name = "iconButton3";
		this.iconButton3.Size = new System.Drawing.Size(192, 41);
		this.iconButton3.TabIndex = 7;
		this.iconButton3.Text = "Name Lookup";
		this.iconButton3.UseVisualStyleBackColor = false;
		this.iconButton3.Click += new System.EventHandler(iconButton3_Click);
		this.iconButton2.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
		this.Ani.SetDecoration(this.iconButton2, Guna.UI2.AnimatorNS.DecorationType.None);
		this.iconButton2.FlatAppearance.BorderSize = 0;
		this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.iconButton2.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.iconButton2.ForeColor = System.Drawing.Color.White;
		this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.Phone;
		this.iconButton2.IconColor = System.Drawing.Color.White;
		this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Solid;
		this.iconButton2.IconSize = 25;
		this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.iconButton2.Location = new System.Drawing.Point(3, 82);
		this.iconButton2.Name = "iconButton2";
		this.iconButton2.Size = new System.Drawing.Size(192, 41);
		this.iconButton2.TabIndex = 6;
		this.iconButton2.Text = "Phone Lookup";
		this.iconButton2.UseVisualStyleBackColor = false;
		this.iconButton2.Click += new System.EventHandler(iconButton2_Click);
		this.label2.AutoSize = true;
		this.Ani.SetDecoration(this.label2, Guna.UI2.AnimatorNS.DecorationType.None);
		this.label2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold);
		this.label2.ForeColor = System.Drawing.Color.Gray;
		this.label2.Location = new System.Drawing.Point(7, 11);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(34, 15);
		this.label2.TabIndex = 4;
		this.label2.Text = "Main";
		this.Ani.SetDecoration(this.guna2Panel1, Guna.UI2.AnimatorNS.DecorationType.None);
		this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
		this.guna2Panel1.Name = "guna2Panel1";
		this.guna2Panel1.Size = new System.Drawing.Size(198, 39);
		this.guna2Panel1.TabIndex = 5;
		this.iconButton1.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
		this.Ani.SetDecoration(this.iconButton1, Guna.UI2.AnimatorNS.DecorationType.None);
		this.iconButton1.FlatAppearance.BorderSize = 0;
		this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.iconButton1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.iconButton1.ForeColor = System.Drawing.Color.White;
		this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
		this.iconButton1.IconColor = System.Drawing.Color.White;
		this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Solid;
		this.iconButton1.IconSize = 25;
		this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.iconButton1.Location = new System.Drawing.Point(3, 41);
		this.iconButton1.Name = "iconButton1";
		this.iconButton1.Size = new System.Drawing.Size(192, 41);
		this.iconButton1.TabIndex = 0;
		this.iconButton1.Text = "Address Lookup";
		this.iconButton1.UseVisualStyleBackColor = false;
		this.iconButton1.Click += new System.EventHandler(iconButton1_Click);
		this.guna2Panel2.Controls.Add(this.label3);
		this.Ani.SetDecoration(this.guna2Panel2, Guna.UI2.AnimatorNS.DecorationType.None);
		this.guna2Panel2.Location = new System.Drawing.Point(3, 166);
		this.guna2Panel2.Name = "guna2Panel2";
		this.guna2Panel2.Size = new System.Drawing.Size(192, 25);
		this.guna2Panel2.TabIndex = 12;
		this.label3.AutoSize = true;
		this.Ani.SetDecoration(this.label3, Guna.UI2.AnimatorNS.DecorationType.None);
		this.label3.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold);
		this.label3.ForeColor = System.Drawing.Color.Gray;
		this.label3.Location = new System.Drawing.Point(7, 5);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(77, 15);
		this.label3.TabIndex = 11;
		this.label3.Text = "Osint | Intelx";
		this.panel3.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.Ani.SetDecoration(this.panel3, Guna.UI2.AnimatorNS.DecorationType.None);
		this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
		this.panel3.Location = new System.Drawing.Point(198, 39);
		this.panel3.Name = "panel3";
		this.panel3.Size = new System.Drawing.Size(758, 470);
		this.panel3.TabIndex = 2;
		this.Ani.AnimationType = Guna.UI2.AnimatorNS.AnimationType.VertSlide;
		this.Ani.Cursor = null;
		animation.AnimateOnlyDifferences = true;
		animation.BlindCoeff = (System.Drawing.PointF)resources.GetObject("animation14.BlindCoeff");
		animation.LeafCoeff = 0f;
		animation.MaxTime = 1f;
		animation.MinTime = 0f;
		animation.MosaicCoeff = (System.Drawing.PointF)resources.GetObject("animation14.MosaicCoeff");
		animation.MosaicShift = (System.Drawing.PointF)resources.GetObject("animation14.MosaicShift");
		animation.MosaicSize = 0;
		animation.Padding = new System.Windows.Forms.Padding(0);
		animation.RotateCoeff = 0f;
		animation.RotateLimit = 0f;
		animation.ScaleCoeff = (System.Drawing.PointF)resources.GetObject("animation14.ScaleCoeff");
		animation.SlideCoeff = (System.Drawing.PointF)resources.GetObject("animation14.SlideCoeff");
		animation.TimeCoeff = 0f;
		animation.TransparencyCoeff = 0f;
		this.Ani.DefaultAnimation = animation;
		this.guna2ControlBox3.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
		this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
		this.Ani.SetDecoration(this.guna2ControlBox3, Guna.UI2.AnimatorNS.DecorationType.None);
		this.guna2ControlBox3.Dock = System.Windows.Forms.DockStyle.Right;
		this.guna2ControlBox3.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2ControlBox3.IconColor = System.Drawing.Color.White;
		this.guna2ControlBox3.Location = new System.Drawing.Point(821, 0);
		this.guna2ControlBox3.Name = "guna2ControlBox3";
		this.guna2ControlBox3.Size = new System.Drawing.Size(45, 39);
		this.guna2ControlBox3.TabIndex = 6;
		this.guna2ControlBox2.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
		this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
		this.Ani.SetDecoration(this.guna2ControlBox2, Guna.UI2.AnimatorNS.DecorationType.None);
		this.guna2ControlBox2.Dock = System.Windows.Forms.DockStyle.Right;
		this.guna2ControlBox2.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
		this.guna2ControlBox2.Location = new System.Drawing.Point(866, 0);
		this.guna2ControlBox2.Name = "guna2ControlBox2";
		this.guna2ControlBox2.Size = new System.Drawing.Size(45, 39);
		this.guna2ControlBox2.TabIndex = 5;
		this.guna2ControlBox1.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
		this.Ani.SetDecoration(this.guna2ControlBox1, Guna.UI2.AnimatorNS.DecorationType.None);
		this.guna2ControlBox1.Dock = System.Windows.Forms.DockStyle.Right;
		this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
		this.guna2ControlBox1.Location = new System.Drawing.Point(911, 0);
		this.guna2ControlBox1.Name = "guna2ControlBox1";
		this.guna2ControlBox1.Size = new System.Drawing.Size(45, 39);
		this.guna2ControlBox1.TabIndex = 4;
		this.guna2ControlBox1.Click += new System.EventHandler(guna2ControlBox1_Click_1);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		base.ClientSize = new System.Drawing.Size(956, 509);
		base.Controls.Add(this.panel3);
		base.Controls.Add(this.panel2);
		base.Controls.Add(this.panel1);
		this.Ani.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Form1";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Cracked by God <3";
		base.Load += new System.EventHandler(Form1_Load);
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		this.panel2.ResumeLayout(false);
		this.panel2.PerformLayout();
		this.guna2Panel4.ResumeLayout(false);
		this.guna2Panel3.ResumeLayout(false);
		this.guna2Panel2.ResumeLayout(false);
		this.guna2Panel2.PerformLayout();
		base.ResumeLayout(false);
	}
}
