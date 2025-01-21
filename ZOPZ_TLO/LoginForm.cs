using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using KeyAuth;
using ZOPZ_TLO.Properties;

namespace ZOPZ_TLO;

public class LoginForm : Form
{
	public static api KeyAuthApp;

	private IContainer components;

	private Panel panel1;

	private Label label1;

	private Guna2ControlBox guna2ControlBox3;

	private Guna2ControlBox guna2ControlBox2;

	private Guna2ControlBox guna2ControlBox1;

	private Guna2TextBox txtLicense;

	private Guna2Button guna2Button1;

	private Guna2CheckBox guna2CheckBox1;

	private Guna2DragControl guna2DragControl1;

	public void alert(string msg, Alert.enmType type)
	{
		new Alert().showAlert(msg, type);
	}

	public LoginForm()
	{
		InitializeComponent();
	}

	public static bool SubExist(string name)
	{
		return KeyAuthApp.user_data.subscriptions.Exists((api.Data x) => x.subscription == name);
	}

	private static string random_string()
	{
		string text = null;
		Random random = new Random();
		for (int i = 0; i < 5; i++)
		{
			text += Convert.ToChar(Convert.ToInt32(Math.Floor(26.0 * random.NextDouble() + 65.0)));
		}
		return text;
	}

	private void guna2Button1_Click(object sender, EventArgs e)
	{
		new Form1().Show();
		Hide();
		MessageBox.Show("God on Top - Discord.gg/ShadowGarden");
	}

	private void LoginForm_Load(object sender, EventArgs e)
	{
		MessageBox.Show("Cracked by God <3");
	}

	private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
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
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZOPZ_TLO.LoginForm));
		this.panel1 = new System.Windows.Forms.Panel();
		this.label1 = new System.Windows.Forms.Label();
		this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
		this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
		this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
		this.txtLicense = new Guna.UI2.WinForms.Guna2TextBox();
		this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
		this.guna2CheckBox1 = new Guna.UI2.WinForms.Guna2CheckBox();
		this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
		this.panel1.SuspendLayout();
		base.SuspendLayout();
		this.panel1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.panel1.Controls.Add(this.label1);
		this.panel1.Controls.Add(this.guna2ControlBox3);
		this.panel1.Controls.Add(this.guna2ControlBox2);
		this.panel1.Controls.Add(this.guna2ControlBox1);
		this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
		this.panel1.Location = new System.Drawing.Point(0, 0);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(526, 39);
		this.panel1.TabIndex = 1;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.Gray;
		this.label1.Location = new System.Drawing.Point(3, 12);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(110, 15);
		this.label1.TabIndex = 3;
		this.label1.Text = "God on top - Cracked Zopz tool";
		this.guna2ControlBox3.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
		this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
		this.guna2ControlBox3.Dock = System.Windows.Forms.DockStyle.Right;
		this.guna2ControlBox3.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2ControlBox3.IconColor = System.Drawing.Color.White;
		this.guna2ControlBox3.Location = new System.Drawing.Point(391, 0);
		this.guna2ControlBox3.Name = "guna2ControlBox3";
		this.guna2ControlBox3.Size = new System.Drawing.Size(45, 39);
		this.guna2ControlBox3.TabIndex = 2;
		this.guna2ControlBox2.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
		this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
		this.guna2ControlBox2.Dock = System.Windows.Forms.DockStyle.Right;
		this.guna2ControlBox2.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
		this.guna2ControlBox2.Location = new System.Drawing.Point(436, 0);
		this.guna2ControlBox2.Name = "guna2ControlBox2";
		this.guna2ControlBox2.Size = new System.Drawing.Size(45, 39);
		this.guna2ControlBox2.TabIndex = 1;
		this.guna2ControlBox1.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
		this.guna2ControlBox1.Dock = System.Windows.Forms.DockStyle.Right;
		this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
		this.guna2ControlBox1.Location = new System.Drawing.Point(481, 0);
		this.guna2ControlBox1.Name = "guna2ControlBox1";
		this.guna2ControlBox1.Size = new System.Drawing.Size(45, 39);
		this.guna2ControlBox1.TabIndex = 0;
		this.txtLicense.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.txtLicense.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.txtLicense.Cursor = System.Windows.Forms.Cursors.IBeam;
		this.txtLicense.DefaultText = "";
		this.txtLicense.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		this.txtLicense.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		this.txtLicense.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.txtLicense.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.txtLicense.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.txtLicense.FocusedState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.txtLicense.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.txtLicense.ForeColor = System.Drawing.Color.White;
		this.txtLicense.HoverState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.txtLicense.IconLeft = ZOPZ_TLO.Properties.Resources.Identity_Theft1;
		this.txtLicense.Location = new System.Drawing.Point(29, 88);
		this.txtLicense.Name = "txtLicense";
		this.txtLicense.PasswordChar = '*';
		this.txtLicense.PlaceholderForeColor = System.Drawing.Color.White;
		this.txtLicense.PlaceholderText = "Discord.gg/ShadowGarden";
		this.txtLicense.SelectedText = "";
		this.txtLicense.Size = new System.Drawing.Size(470, 36);
		this.txtLicense.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
		this.txtLicense.TabIndex = 18;
		this.guna2Button1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2Button1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold);
		this.guna2Button1.ForeColor = System.Drawing.Color.White;
		this.guna2Button1.Location = new System.Drawing.Point(29, 186);
		this.guna2Button1.Name = "guna2Button1";
		this.guna2Button1.Size = new System.Drawing.Size(470, 36);
		this.guna2Button1.TabIndex = 17;
		this.guna2Button1.Text = "Bypass";
		this.guna2Button1.Click += new System.EventHandler(guna2Button1_Click);
		this.guna2CheckBox1.AutoSize = true;
		this.guna2CheckBox1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2CheckBox1.CheckedState.BorderRadius = 0;
		this.guna2CheckBox1.CheckedState.BorderThickness = 0;
		this.guna2CheckBox1.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2CheckBox1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.guna2CheckBox1.ForeColor = System.Drawing.Color.White;
		this.guna2CheckBox1.Location = new System.Drawing.Point(29, 143);
		this.guna2CheckBox1.Name = "guna2CheckBox1";
		this.guna2CheckBox1.Size = new System.Drawing.Size(103, 19);
		this.guna2CheckBox1.TabIndex = 19;
		this.guna2CheckBox1.Text = "ShadowGarden <3";
		this.guna2CheckBox1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2CheckBox1.UncheckedState.BorderRadius = 0;
		this.guna2CheckBox1.UncheckedState.BorderThickness = 0;
		this.guna2CheckBox1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2CheckBox1.CheckedChanged += new System.EventHandler(guna2CheckBox1_CheckedChanged);
		this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
		this.guna2DragControl1.TargetControl = this.panel1;
		this.guna2DragControl1.TransparentWhileDrag = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
		base.ClientSize = new System.Drawing.Size(526, 312);
		base.Controls.Add(this.guna2CheckBox1);
		base.Controls.Add(this.txtLicense);
		base.Controls.Add(this.guna2Button1);
		base.Controls.Add(this.panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "LoginForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Login";
		base.Load += new System.EventHandler(LoginForm_Load);
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	static LoginForm()
	{
		KeyAuthApp = new api("ZOPZTLO", "PH2Z3ApDrO", "1.0");
	}
}
