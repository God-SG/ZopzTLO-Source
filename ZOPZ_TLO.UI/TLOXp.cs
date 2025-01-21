using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using ZOPZ_TLO.Properties;

namespace ZOPZ_TLO.UI;

public class TLOXp : UserControl
{
	private IContainer components = null;

	private Guna2TextBox LastNTb;

	private Label label1;

	private Guna2Button guna2Button1;

	private Guna2TextBox firstNTb;

	private Guna2TextBox CityTb;

	private Guna2TextBox StreetTb;

	private Guna2TextBox AreaTb;

	private Guna2ComboBox StateTb;

	private Guna2TextBox DOBTb;

	private Guna2VScrollBar guna2VScrollBar1;

	private RichTextBox richTextBox1;

	public TLOXp()
	{
		InitializeComponent();
		StateTb.Items.Add("AL");
		StateTb.Items.Add("AK");
		StateTb.Items.Add("AZ");
		StateTb.Items.Add("AR");
		StateTb.Items.Add("CA");
		StateTb.Items.Add("CO");
		StateTb.Items.Add("CT");
		StateTb.Items.Add("DE");
		StateTb.Items.Add("FL");
		StateTb.Items.Add("GA");
		StateTb.Items.Add("HI");
		StateTb.Items.Add("ID");
		StateTb.Items.Add("IL");
		StateTb.Items.Add("IN");
		StateTb.Items.Add("IA");
		StateTb.Items.Add("KS");
		StateTb.Items.Add("KY");
		StateTb.Items.Add("LA");
		StateTb.Items.Add("ME");
		StateTb.Items.Add("MD");
		StateTb.Items.Add("MA");
		StateTb.Items.Add("MI");
		StateTb.Items.Add("MN");
		StateTb.Items.Add("MS");
		StateTb.Items.Add("MO");
		StateTb.Items.Add("MT");
		StateTb.Items.Add("NE");
		StateTb.Items.Add("NV");
		StateTb.Items.Add("NH");
		StateTb.Items.Add("NJ");
		StateTb.Items.Add("NM");
		StateTb.Items.Add("NY");
		StateTb.Items.Add("NC");
		StateTb.Items.Add("ND");
		StateTb.Items.Add("OH");
		StateTb.Items.Add("OK");
		StateTb.Items.Add("OR");
		StateTb.Items.Add("PA");
		StateTb.Items.Add("RI");
		StateTb.Items.Add("SC");
		StateTb.Items.Add("SD");
		StateTb.Items.Add("TN");
		StateTb.Items.Add("TX");
		StateTb.Items.Add("UT");
		StateTb.Items.Add("VT");
		StateTb.Items.Add("VA");
		StateTb.Items.Add("WA");
		StateTb.Items.Add("WV");
		StateTb.Items.Add("WI");
		StateTb.Items.Add("WY");
	}

	private void TLOXp_Load(object sender, EventArgs e)
	{
	}

	private void guna2Button1_Click(object sender, EventArgs e)
	{
		Clipboard.SetText(richTextBox1.Text);
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
		this.CityTb = new Guna.UI2.WinForms.Guna2TextBox();
		this.StateTb = new Guna.UI2.WinForms.Guna2ComboBox();
		this.guna2VScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
		this.richTextBox1 = new System.Windows.Forms.RichTextBox();
		this.DOBTb = new Guna.UI2.WinForms.Guna2TextBox();
		this.AreaTb = new Guna.UI2.WinForms.Guna2TextBox();
		this.StreetTb = new Guna.UI2.WinForms.Guna2TextBox();
		this.LastNTb = new Guna.UI2.WinForms.Guna2TextBox();
		this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
		this.firstNTb = new Guna.UI2.WinForms.Guna2TextBox();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.Gray;
		this.label1.Location = new System.Drawing.Point(11, 15);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(89, 15);
		this.label1.TabIndex = 20;
		this.label1.Text = "TLOxp Lookup";
		this.CityTb.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.CityTb.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.CityTb.Cursor = System.Windows.Forms.Cursors.IBeam;
		this.CityTb.DefaultText = "";
		this.CityTb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		this.CityTb.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		this.CityTb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.CityTb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.CityTb.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.CityTb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.CityTb.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.CityTb.ForeColor = System.Drawing.Color.White;
		this.CityTb.HoverState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.CityTb.IconLeft = ZOPZ_TLO.Properties.Resources.Building_With_Top_View;
		this.CityTb.Location = new System.Drawing.Point(295, 75);
		this.CityTb.Name = "CityTb";
		this.CityTb.PasswordChar = '\0';
		this.CityTb.PlaceholderForeColor = System.Drawing.Color.White;
		this.CityTb.PlaceholderText = "City";
		this.CityTb.SelectedText = "";
		this.CityTb.Size = new System.Drawing.Size(272, 36);
		this.CityTb.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
		this.CityTb.TabIndex = 23;
		this.StateTb.BackColor = System.Drawing.Color.Transparent;
		this.StateTb.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.StateTb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
		this.StateTb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.StateTb.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.StateTb.FocusedColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.StateTb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.StateTb.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.StateTb.ForeColor = System.Drawing.Color.White;
		this.StateTb.ItemHeight = 30;
		this.StateTb.ItemsAppearance.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.StateTb.ItemsAppearance.ForeColor = System.Drawing.Color.White;
		this.StateTb.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.StateTb.ItemsAppearance.SelectedForeColor = System.Drawing.Color.White;
		this.StateTb.Location = new System.Drawing.Point(573, 75);
		this.StateTb.Name = "StateTb";
		this.StateTb.Size = new System.Drawing.Size(165, 36);
		this.StateTb.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
		this.StateTb.TabIndex = 26;
		this.guna2VScrollBar1.BindingContainer = this.richTextBox1;
		this.guna2VScrollBar1.FillColor = System.Drawing.Color.White;
		this.guna2VScrollBar1.InUpdate = false;
		this.guna2VScrollBar1.LargeChange = 10;
		this.guna2VScrollBar1.Location = new System.Drawing.Point(720, 159);
		this.guna2VScrollBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.guna2VScrollBar1.Name = "guna2VScrollBar1";
		this.guna2VScrollBar1.ScrollbarSize = 18;
		this.guna2VScrollBar1.Size = new System.Drawing.Size(18, 295);
		this.guna2VScrollBar1.TabIndex = 29;
		this.guna2VScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.richTextBox1.DetectUrls = false;
		this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.richTextBox1.ForeColor = System.Drawing.Color.White;
		this.richTextBox1.Location = new System.Drawing.Point(14, 159);
		this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.richTextBox1.Name = "richTextBox1";
		this.richTextBox1.ReadOnly = true;
		this.richTextBox1.Size = new System.Drawing.Size(724, 295);
		this.richTextBox1.TabIndex = 28;
		this.richTextBox1.Text = "Waiting for search...";
		this.DOBTb.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.DOBTb.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.DOBTb.Cursor = System.Windows.Forms.Cursors.IBeam;
		this.DOBTb.DefaultText = "";
		this.DOBTb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		this.DOBTb.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		this.DOBTb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.DOBTb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.DOBTb.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.DOBTb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.DOBTb.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.DOBTb.ForeColor = System.Drawing.Color.White;
		this.DOBTb.HoverState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.DOBTb.IconLeft = ZOPZ_TLO.Properties.Resources.Person_Calendar;
		this.DOBTb.Location = new System.Drawing.Point(176, 117);
		this.DOBTb.Name = "DOBTb";
		this.DOBTb.PasswordChar = '\0';
		this.DOBTb.PlaceholderForeColor = System.Drawing.Color.White;
		this.DOBTb.PlaceholderText = "DOB (MM/DD/YYYY)";
		this.DOBTb.SelectedText = "";
		this.DOBTb.Size = new System.Drawing.Size(522, 36);
		this.DOBTb.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
		this.DOBTb.TabIndex = 27;
		this.AreaTb.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.AreaTb.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.AreaTb.Cursor = System.Windows.Forms.Cursors.IBeam;
		this.AreaTb.DefaultText = "";
		this.AreaTb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		this.AreaTb.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		this.AreaTb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.AreaTb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.AreaTb.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.AreaTb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.AreaTb.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.AreaTb.ForeColor = System.Drawing.Color.White;
		this.AreaTb.HoverState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.AreaTb.IconLeft = ZOPZ_TLO.Properties.Resources.Location;
		this.AreaTb.Location = new System.Drawing.Point(14, 117);
		this.AreaTb.Name = "AreaTb";
		this.AreaTb.PasswordChar = '\0';
		this.AreaTb.PlaceholderForeColor = System.Drawing.Color.White;
		this.AreaTb.PlaceholderText = "Zip Code (5 digits)";
		this.AreaTb.SelectedText = "";
		this.AreaTb.Size = new System.Drawing.Size(156, 36);
		this.AreaTb.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
		this.AreaTb.TabIndex = 25;
		this.StreetTb.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.StreetTb.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.StreetTb.Cursor = System.Windows.Forms.Cursors.IBeam;
		this.StreetTb.DefaultText = "";
		this.StreetTb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		this.StreetTb.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		this.StreetTb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.StreetTb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.StreetTb.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.StreetTb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.StreetTb.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.StreetTb.ForeColor = System.Drawing.Color.White;
		this.StreetTb.HoverState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.StreetTb.IconLeft = ZOPZ_TLO.Properties.Resources.Real_Estate;
		this.StreetTb.Location = new System.Drawing.Point(14, 75);
		this.StreetTb.Name = "StreetTb";
		this.StreetTb.PasswordChar = '\0';
		this.StreetTb.PlaceholderForeColor = System.Drawing.Color.White;
		this.StreetTb.PlaceholderText = "Street Address";
		this.StreetTb.SelectedText = "";
		this.StreetTb.Size = new System.Drawing.Size(275, 36);
		this.StreetTb.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
		this.StreetTb.TabIndex = 24;
		this.LastNTb.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.LastNTb.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.LastNTb.Cursor = System.Windows.Forms.Cursors.IBeam;
		this.LastNTb.DefaultText = "";
		this.LastNTb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		this.LastNTb.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		this.LastNTb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.LastNTb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.LastNTb.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.LastNTb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.LastNTb.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.LastNTb.ForeColor = System.Drawing.Color.White;
		this.LastNTb.HoverState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.LastNTb.IconLeft = ZOPZ_TLO.Properties.Resources.Person;
		this.LastNTb.Location = new System.Drawing.Point(361, 33);
		this.LastNTb.Name = "LastNTb";
		this.LastNTb.PasswordChar = '\0';
		this.LastNTb.PlaceholderForeColor = System.Drawing.Color.White;
		this.LastNTb.PlaceholderText = "Last Name";
		this.LastNTb.SelectedText = "";
		this.LastNTb.Size = new System.Drawing.Size(377, 36);
		this.LastNTb.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
		this.LastNTb.TabIndex = 21;
		this.guna2Button1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
		this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
		this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
		this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
		this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.guna2Button1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold);
		this.guna2Button1.ForeColor = System.Drawing.Color.White;
		this.guna2Button1.Image = ZOPZ_TLO.Properties.Resources.copy1;
		this.guna2Button1.Location = new System.Drawing.Point(704, 117);
		this.guna2Button1.Name = "guna2Button1";
		this.guna2Button1.Size = new System.Drawing.Size(34, 36);
		this.guna2Button1.TabIndex = 19;
		this.guna2Button1.Click += new System.EventHandler(guna2Button1_Click);
		this.firstNTb.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		this.firstNTb.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.firstNTb.Cursor = System.Windows.Forms.Cursors.IBeam;
		this.firstNTb.DefaultText = "";
		this.firstNTb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		this.firstNTb.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		this.firstNTb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.firstNTb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.firstNTb.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.firstNTb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.firstNTb.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.firstNTb.ForeColor = System.Drawing.Color.White;
		this.firstNTb.HoverState.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.firstNTb.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
		this.firstNTb.HoverState.ForeColor = System.Drawing.Color.White;
		this.firstNTb.HoverState.PlaceholderForeColor = System.Drawing.Color.White;
		this.firstNTb.IconLeft = ZOPZ_TLO.Properties.Resources.Person;
		this.firstNTb.Location = new System.Drawing.Point(14, 33);
		this.firstNTb.Name = "firstNTb";
		this.firstNTb.PasswordChar = '\0';
		this.firstNTb.PlaceholderForeColor = System.Drawing.Color.White;
		this.firstNTb.PlaceholderText = "First Name";
		this.firstNTb.SelectedText = "";
		this.firstNTb.Size = new System.Drawing.Size(341, 36);
		this.firstNTb.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
		this.firstNTb.TabIndex = 18;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		base.Controls.Add(this.guna2VScrollBar1);
		base.Controls.Add(this.richTextBox1);
		base.Controls.Add(this.DOBTb);
		base.Controls.Add(this.StateTb);
		base.Controls.Add(this.AreaTb);
		base.Controls.Add(this.StreetTb);
		base.Controls.Add(this.CityTb);
		base.Controls.Add(this.LastNTb);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.guna2Button1);
		base.Controls.Add(this.firstNTb);
		base.Name = "TLOXp";
		base.Size = new System.Drawing.Size(758, 470);
		base.Load += new System.EventHandler(TLOXp_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
