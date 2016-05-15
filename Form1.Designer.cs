namespace SpeechDota
{
	partial class Form1
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose( bool disposing ) {
			if ( disposing && (components != null) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent() {
			this.enableBtn = new System.Windows.Forms.Button();
			this.logBox = new System.Windows.Forms.TextBox();
			this.quickCast = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// enableBtn
			// 
			this.enableBtn.Location = new System.Drawing.Point(52, 226);
			this.enableBtn.Name = "enableBtn";
			this.enableBtn.Size = new System.Drawing.Size(107, 23);
			this.enableBtn.TabIndex = 0;
			this.enableBtn.Text = "Comenzar";
			this.enableBtn.UseVisualStyleBackColor = true;
			this.enableBtn.Click += new System.EventHandler(this.enableBtn_Click);
			// 
			// logBox
			// 
			this.logBox.Location = new System.Drawing.Point(12, 12);
			this.logBox.Multiline = true;
			this.logBox.Name = "logBox";
			this.logBox.Size = new System.Drawing.Size(260, 208);
			this.logBox.TabIndex = 1;
			this.logBox.Visible = false;
			// 
			// quickCast
			// 
			this.quickCast.AutoSize = true;
			this.quickCast.Location = new System.Drawing.Point(194, 230);
			this.quickCast.Name = "quickCast";
			this.quickCast.Size = new System.Drawing.Size(74, 17);
			this.quickCast.TabIndex = 2;
			this.quickCast.Text = "Quickcast";
			this.quickCast.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.quickCast);
			this.Controls.Add(this.logBox);
			this.Controls.Add(this.enableBtn);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button enableBtn;
		private System.Windows.Forms.TextBox logBox;
		private System.Windows.Forms.CheckBox quickCast;
	}
}

