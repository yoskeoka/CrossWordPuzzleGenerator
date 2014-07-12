namespace CWPGeneratorView
{
    partial class DlgFormRandomWordSelecter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.numUDWordLength = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numWordSelectCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.grpBoxSelectDic = new System.Windows.Forms.GroupBox();
            this.radioBtnLargeDic = new System.Windows.Forms.RadioButton();
            this.radioBtnSmallDic = new System.Windows.Forms.RadioButton();
            this.textBoxMatchingWord = new System.Windows.Forms.TextBox();
            this.radioButtonNormalMatching = new System.Windows.Forms.RadioButton();
            this.radioButtonWildMatching = new System.Windows.Forms.RadioButton();
            this.radioButtonREMatching = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUDWordLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWordSelectCount)).BeginInit();
            this.grpBoxSelectDic.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(23, 235);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "追加";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // numUDWordLength
            // 
            this.numUDWordLength.Location = new System.Drawing.Point(23, 174);
            this.numUDWordLength.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUDWordLength.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numUDWordLength.Name = "numUDWordLength";
            this.numUDWordLength.Size = new System.Drawing.Size(66, 19);
            this.numUDWordLength.TabIndex = 1;
            this.numUDWordLength.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(126, 235);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "文字のワードを、";
            // 
            // numWordSelectCount
            // 
            this.numWordSelectCount.Location = new System.Drawing.Point(23, 199);
            this.numWordSelectCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numWordSelectCount.Name = "numWordSelectCount";
            this.numWordSelectCount.Size = new System.Drawing.Size(66, 19);
            this.numWordSelectCount.TabIndex = 4;
            this.numWordSelectCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "個ランダムに選んで追加する。";
            // 
            // grpBoxSelectDic
            // 
            this.grpBoxSelectDic.Controls.Add(this.radioBtnLargeDic);
            this.grpBoxSelectDic.Controls.Add(this.radioBtnSmallDic);
            this.grpBoxSelectDic.Location = new System.Drawing.Point(12, 12);
            this.grpBoxSelectDic.Name = "grpBoxSelectDic";
            this.grpBoxSelectDic.Size = new System.Drawing.Size(284, 62);
            this.grpBoxSelectDic.TabIndex = 6;
            this.grpBoxSelectDic.TabStop = false;
            this.grpBoxSelectDic.Text = "ワードリスト選択";
            // 
            // radioBtnLargeDic
            // 
            this.radioBtnLargeDic.AutoSize = true;
            this.radioBtnLargeDic.Location = new System.Drawing.Point(136, 19);
            this.radioBtnLargeDic.Name = "radioBtnLargeDic";
            this.radioBtnLargeDic.Size = new System.Drawing.Size(119, 16);
            this.radioBtnLargeDic.TabIndex = 1;
            this.radioBtnLargeDic.Text = "一般ワード辞書(大)";
            this.radioBtnLargeDic.UseVisualStyleBackColor = true;
            // 
            // radioBtnSmallDic
            // 
            this.radioBtnSmallDic.AutoSize = true;
            this.radioBtnSmallDic.Checked = true;
            this.radioBtnSmallDic.Location = new System.Drawing.Point(11, 19);
            this.radioBtnSmallDic.Name = "radioBtnSmallDic";
            this.radioBtnSmallDic.Size = new System.Drawing.Size(119, 16);
            this.radioBtnSmallDic.TabIndex = 0;
            this.radioBtnSmallDic.TabStop = true;
            this.radioBtnSmallDic.Text = "一般ワード辞書(小)";
            this.radioBtnSmallDic.UseVisualStyleBackColor = true;
            // 
            // textBoxMatchingWord
            // 
            this.textBoxMatchingWord.Location = new System.Drawing.Point(9, 38);
            this.textBoxMatchingWord.Name = "textBoxMatchingWord";
            this.textBoxMatchingWord.Size = new System.Drawing.Size(110, 19);
            this.textBoxMatchingWord.TabIndex = 7;
            // 
            // radioButtonNormalMatching
            // 
            this.radioButtonNormalMatching.AutoSize = true;
            this.radioButtonNormalMatching.Checked = true;
            this.radioButtonNormalMatching.Location = new System.Drawing.Point(132, 25);
            this.radioButtonNormalMatching.Name = "radioButtonNormalMatching";
            this.radioButtonNormalMatching.Size = new System.Drawing.Size(71, 16);
            this.radioButtonNormalMatching.TabIndex = 8;
            this.radioButtonNormalMatching.TabStop = true;
            this.radioButtonNormalMatching.Text = "単純比較";
            this.radioButtonNormalMatching.UseVisualStyleBackColor = true;
            // 
            // radioButtonWildMatching
            // 
            this.radioButtonWildMatching.AutoSize = true;
            this.radioButtonWildMatching.Location = new System.Drawing.Point(132, 41);
            this.radioButtonWildMatching.Name = "radioButtonWildMatching";
            this.radioButtonWildMatching.Size = new System.Drawing.Size(102, 16);
            this.radioButtonWildMatching.TabIndex = 9;
            this.radioButtonWildMatching.Text = "ワイルドカード(*)";
            this.radioButtonWildMatching.UseVisualStyleBackColor = true;
            // 
            // radioButtonREMatching
            // 
            this.radioButtonREMatching.AutoSize = true;
            this.radioButtonREMatching.Location = new System.Drawing.Point(132, 57);
            this.radioButtonREMatching.Name = "radioButtonREMatching";
            this.radioButtonREMatching.Size = new System.Drawing.Size(71, 16);
            this.radioButtonREMatching.TabIndex = 10;
            this.radioButtonREMatching.Text = "正規表現";
            this.radioButtonREMatching.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "検索ワード";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxMatchingWord);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.radioButtonNormalMatching);
            this.groupBox1.Controls.Add(this.radioButtonREMatching);
            this.groupBox1.Controls.Add(this.radioButtonWildMatching);
            this.groupBox1.Location = new System.Drawing.Point(12, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 82);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "検索条件";
            // 
            // DlgFormRandomWordSelecter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 270);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpBoxSelectDic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numWordSelectCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.numUDWordLength);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgFormRandomWordSelecter";
            this.Text = "DlgFormRandomWordSelecter";
            ((System.ComponentModel.ISupportInitialize)(this.numUDWordLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWordSelectCount)).EndInit();
            this.grpBoxSelectDic.ResumeLayout(false);
            this.grpBoxSelectDic.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.NumericUpDown numUDWordLength;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numWordSelectCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpBoxSelectDic;
        private System.Windows.Forms.RadioButton radioBtnSmallDic;
        private System.Windows.Forms.RadioButton radioBtnLargeDic;
        private System.Windows.Forms.TextBox textBoxMatchingWord;
        private System.Windows.Forms.RadioButton radioButtonNormalMatching;
        private System.Windows.Forms.RadioButton radioButtonWildMatching;
        private System.Windows.Forms.RadioButton radioButtonREMatching;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}