using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZOPZ_TLO;

public class Alert : Form
{
	public enum enmAction
	{
		wait,
		start,
		close
	}

	public enum enmType
	{
		Success,
		Warning,
		Error,
		Info
	}

	private enmAction action;

	private int x;

	private int y;

	private IContainer components = null;

	private Timer timer1;

	private Label lblMsg;

	private Label label19;

	public void showAlert(string msg, enmType type)
	{
		base.Opacity = 0.0;
		base.StartPosition = FormStartPosition.Manual;
		for (int i = 1; i < 10; i++)
		{
			string name = "alert" + i;
			Alert alert = (Alert)Application.OpenForms[name];
			if (alert == null)
			{
				base.Name = name;
				x = Screen.PrimaryScreen.WorkingArea.Width - base.Width + 15;
				y = Screen.PrimaryScreen.WorkingArea.Height - base.Height * i - 5 * i;
				base.Location = new Point(x, y);
				break;
			}
		}
		x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;
		lblMsg.Text = msg;
		Show();
		action = enmAction.start;
		timer1.Interval = 1;
		timer1.Start();
	}

	public Alert()
	{
		InitializeComponent();
	}

	private void lblMsg_Click(object sender, EventArgs e)
	{
	}

	private void label19_Click(object sender, EventArgs e)
	{
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		switch (action)
		{
		case enmAction.wait:
			timer1.Interval = 5000;
			action = enmAction.close;
			break;
		case enmAction.start:
			timer1.Interval = 1;
			base.Opacity += 0.1;
			if (x < base.Location.X)
			{
				base.Left--;
			}
			else if (base.Opacity == 1.0)
			{
				action = enmAction.wait;
			}
			break;
		case enmAction.close:
			timer1.Interval = 1;
			base.Opacity -= 0.1;
			base.Left -= 3;
			if (base.Opacity == 0.0)
			{
				Close();
			}
			break;
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
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZOPZ_TLO.Alert));
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.lblMsg = new System.Windows.Forms.Label();
		this.label19 = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.lblMsg.Dock = System.Windows.Forms.DockStyle.Top;
		this.lblMsg.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.lblMsg.ForeColor = System.Drawing.Color.White;
		this.lblMsg.Location = new System.Drawing.Point(0, 20);
		this.lblMsg.Name = "lblMsg";
		this.lblMsg.Size = new System.Drawing.Size(383, 113);
		this.lblMsg.TabIndex = 11;
		this.lblMsg.Text = "N/A";
		this.lblMsg.Click += new System.EventHandler(lblMsg_Click);
		this.label19.Dock = System.Windows.Forms.DockStyle.Top;
		this.label19.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.label19.ForeColor = System.Drawing.Color.White;
		this.label19.Location = new System.Drawing.Point(0, 0);
		this.label19.Name = "label19";
		this.label19.Size = new System.Drawing.Size(383, 20);
		this.label19.TabIndex = 10;
		this.label19.Text = "Alert";
		this.label19.Click += new System.EventHandler(label19_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
		base.ClientSize = new System.Drawing.Size(383, 136);
		base.Controls.Add(this.lblMsg);
		base.Controls.Add(this.label19);
		this.ForeColor = System.Drawing.Color.FromArgb(25, 25, 25);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Alert";
		this.Text = "Alert";
		base.ResumeLayout(false);
	}
}
