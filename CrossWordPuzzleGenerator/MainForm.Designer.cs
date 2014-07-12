namespace CWPGeneratorView
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.pbOutImage = new System.Windows.Forms.PictureBox();
            this.txtBxInputWords = new System.Windows.Forms.TextBox();
            this.txtBxAddWord = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSortAsc = new System.Windows.Forms.Button();
            this.btnSortDes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxGeneratedPic = new System.Windows.Forms.ComboBox();
            this.btnSavePic = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnRotate = new System.Windows.Forms.Button();
            this.numUDVerticalSize = new System.Windows.Forms.NumericUpDown();
            this.numUDHorizontalSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxGenerationCondition = new System.Windows.Forms.GroupBox();
            this.chkBoxConvYouonSokuon = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBoxEmbedKeyWord = new System.Windows.Forms.TextBox();
            this.btnDicSetting = new System.Windows.Forms.Button();
            this.chkBoxUseDic = new System.Windows.Forms.CheckBox();
            this.chkBoxNotAllowSequentialWall = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numUDWallLimit = new System.Windows.Forms.NumericUpDown();
            this.labelAddingWordLength = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSaveTxt = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.lblMaxWordLen = new System.Windows.Forms.Label();
            this.btnRandomAdd = new System.Windows.Forms.Button();
            this.statusStripMainBottom = new System.Windows.Forms.StatusStrip();
            this.toolStripGenerateProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripProgressPercentage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripGenerateProgressMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWordCount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblPredictedProcessTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDVerticalSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDHorizontalSize)).BeginInit();
            this.groupBoxGenerationCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDWallLimit)).BeginInit();
            this.statusStripMainBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbOutImage
            // 
            this.pbOutImage.BackColor = System.Drawing.Color.White;
            this.pbOutImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbOutImage.Location = new System.Drawing.Point(328, 67);
            this.pbOutImage.Name = "pbOutImage";
            this.pbOutImage.Size = new System.Drawing.Size(400, 400);
            this.pbOutImage.TabIndex = 0;
            this.pbOutImage.TabStop = false;
            // 
            // txtBxInputWords
            // 
            this.txtBxInputWords.Location = new System.Drawing.Point(12, 54);
            this.txtBxInputWords.MaxLength = 32000;
            this.txtBxInputWords.Multiline = true;
            this.txtBxInputWords.Name = "txtBxInputWords";
            this.txtBxInputWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBxInputWords.Size = new System.Drawing.Size(187, 290);
            this.txtBxInputWords.TabIndex = 1;
            this.txtBxInputWords.Text = "オトシダマ\r\nオヤフコウ\r\nウマ\r\nシチ\r\nマキ\r\nダキアワセ\r\nコママワシ\r\nキセツ\r\nチキ\r\nアワ\r\nワシツ\r\nフウ";
            this.txtBxInputWords.Validated += new System.EventHandler(this.txtBxInputWords_Validated);
            // 
            // txtBxAddWord
            // 
            this.txtBxAddWord.Location = new System.Drawing.Point(12, 26);
            this.txtBxAddWord.Name = "txtBxAddWord";
            this.txtBxAddWord.Size = new System.Drawing.Size(187, 19);
            this.txtBxAddWord.TabIndex = 2;
            this.txtBxAddWord.TextChanged += new System.EventHandler(this.txtBxAddWord_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(207, 24);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(43, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "追加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSortAsc
            // 
            this.btnSortAsc.Location = new System.Drawing.Point(207, 289);
            this.btnSortAsc.Name = "btnSortAsc";
            this.btnSortAsc.Size = new System.Drawing.Size(75, 23);
            this.btnSortAsc.TabIndex = 4;
            this.btnSortAsc.Text = "昇順";
            this.btnSortAsc.UseVisualStyleBackColor = true;
            this.btnSortAsc.Click += new System.EventHandler(this.btnSortAsc_Click);
            // 
            // btnSortDes
            // 
            this.btnSortDes.Location = new System.Drawing.Point(207, 319);
            this.btnSortDes.Name = "btnSortDes";
            this.btnSortDes.Size = new System.Drawing.Size(75, 23);
            this.btnSortDes.TabIndex = 5;
            this.btnSortDes.Text = "降順";
            this.btnSortDes.UseVisualStyleBackColor = true;
            this.btnSortDes.Click += new System.EventHandler(this.btnSortDes_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "ソート";
            // 
            // comboBoxGeneratedPic
            // 
            this.comboBoxGeneratedPic.FormattingEnabled = true;
            this.comboBoxGeneratedPic.Location = new System.Drawing.Point(328, 473);
            this.comboBoxGeneratedPic.Name = "comboBoxGeneratedPic";
            this.comboBoxGeneratedPic.Size = new System.Drawing.Size(400, 20);
            this.comboBoxGeneratedPic.TabIndex = 7;
            this.comboBoxGeneratedPic.SelectedIndexChanged += new System.EventHandler(this.comboBoxGeneratedPic_SelectedIndexChanged);
            // 
            // btnSavePic
            // 
            this.btnSavePic.Location = new System.Drawing.Point(645, 35);
            this.btnSavePic.Name = "btnSavePic";
            this.btnSavePic.Size = new System.Drawing.Size(83, 23);
            this.btnSavePic.TabIndex = 8;
            this.btnSavePic.Text = "画像を保存";
            this.btnSavePic.UseVisualStyleBackColor = true;
            this.btnSavePic.Click += new System.EventHandler(this.btnSavePic_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(328, 35);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "自動生成";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnRotate
            // 
            this.btnRotate.Location = new System.Drawing.Point(582, 35);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(59, 23);
            this.btnRotate.TabIndex = 10;
            this.btnRotate.Text = "反転";
            this.btnRotate.UseVisualStyleBackColor = true;
            this.btnRotate.Click += new System.EventHandler(this.btnRotate_Click);
            // 
            // numUDVerticalSize
            // 
            this.numUDVerticalSize.Location = new System.Drawing.Point(435, 35);
            this.numUDVerticalSize.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numUDVerticalSize.Name = "numUDVerticalSize";
            this.numUDVerticalSize.Size = new System.Drawing.Size(48, 19);
            this.numUDVerticalSize.TabIndex = 11;
            this.numUDVerticalSize.ValueChanged += new System.EventHandler(this.numUDVerticalSize_ValueChanged);
            // 
            // numUDHorizontalSize
            // 
            this.numUDHorizontalSize.Enabled = false;
            this.numUDHorizontalSize.Location = new System.Drawing.Point(514, 35);
            this.numUDHorizontalSize.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numUDHorizontalSize.Name = "numUDHorizontalSize";
            this.numUDHorizontalSize.ReadOnly = true;
            this.numUDHorizontalSize.Size = new System.Drawing.Size(48, 19);
            this.numUDHorizontalSize.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "縦";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(492, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "横";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(414, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "パズルのサイズ";
            // 
            // groupBoxGenerationCondition
            // 
            this.groupBoxGenerationCondition.Controls.Add(this.chkBoxConvYouonSokuon);
            this.groupBoxGenerationCondition.Controls.Add(this.label7);
            this.groupBoxGenerationCondition.Controls.Add(this.txtBoxEmbedKeyWord);
            this.groupBoxGenerationCondition.Controls.Add(this.btnDicSetting);
            this.groupBoxGenerationCondition.Controls.Add(this.chkBoxUseDic);
            this.groupBoxGenerationCondition.Controls.Add(this.chkBoxNotAllowSequentialWall);
            this.groupBoxGenerationCondition.Controls.Add(this.label6);
            this.groupBoxGenerationCondition.Controls.Add(this.label5);
            this.groupBoxGenerationCondition.Controls.Add(this.numUDWallLimit);
            this.groupBoxGenerationCondition.Location = new System.Drawing.Point(12, 350);
            this.groupBoxGenerationCondition.Name = "groupBoxGenerationCondition";
            this.groupBoxGenerationCondition.Size = new System.Drawing.Size(309, 148);
            this.groupBoxGenerationCondition.TabIndex = 16;
            this.groupBoxGenerationCondition.TabStop = false;
            this.groupBoxGenerationCondition.Text = "条件";
            // 
            // chkBoxConvYouonSokuon
            // 
            this.chkBoxConvYouonSokuon.AutoSize = true;
            this.chkBoxConvYouonSokuon.Location = new System.Drawing.Point(16, 100);
            this.chkBoxConvYouonSokuon.Name = "chkBoxConvYouonSokuon";
            this.chkBoxConvYouonSokuon.Size = new System.Drawing.Size(132, 16);
            this.chkBoxConvYouonSokuon.TabIndex = 20;
            this.chkBoxConvYouonSokuon.Text = "拗音促音を変換する。";
            this.chkBoxConvYouonSokuon.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(133, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "が埋め込まれている。( * :チェック無)";
            // 
            // txtBoxEmbedKeyWord
            // 
            this.txtBoxEmbedKeyWord.Location = new System.Drawing.Point(16, 75);
            this.txtBoxEmbedKeyWord.Name = "txtBoxEmbedKeyWord";
            this.txtBoxEmbedKeyWord.Size = new System.Drawing.Size(113, 19);
            this.txtBoxEmbedKeyWord.TabIndex = 18;
            this.txtBoxEmbedKeyWord.Text = "*";
            // 
            // btnDicSetting
            // 
            this.btnDicSetting.Enabled = false;
            this.btnDicSetting.Location = new System.Drawing.Point(254, 55);
            this.btnDicSetting.Name = "btnDicSetting";
            this.btnDicSetting.Size = new System.Drawing.Size(42, 19);
            this.btnDicSetting.TabIndex = 17;
            this.btnDicSetting.Text = "設定";
            this.btnDicSetting.UseVisualStyleBackColor = true;
            // 
            // chkBoxUseDic
            // 
            this.chkBoxUseDic.AutoSize = true;
            this.chkBoxUseDic.Location = new System.Drawing.Point(16, 58);
            this.chkBoxUseDic.Name = "chkBoxUseDic";
            this.chkBoxUseDic.Size = new System.Drawing.Size(214, 16);
            this.chkBoxUseDic.TabIndex = 16;
            this.chkBoxUseDic.Text = "外部単語辞書を使用したチェックを行う。";
            this.chkBoxUseDic.UseVisualStyleBackColor = true;
            this.chkBoxUseDic.CheckedChanged += new System.EventHandler(this.chkBoxUseDic_CheckedChanged);
            // 
            // chkBoxNotAllowSequentialWall
            // 
            this.chkBoxNotAllowSequentialWall.AutoSize = true;
            this.chkBoxNotAllowSequentialWall.Location = new System.Drawing.Point(16, 39);
            this.chkBoxNotAllowSequentialWall.Name = "chkBoxNotAllowSequentialWall";
            this.chkBoxNotAllowSequentialWall.Size = new System.Drawing.Size(232, 16);
            this.chkBoxNotAllowSequentialWall.TabIndex = 15;
            this.chkBoxNotAllowSequentialWall.Text = "空マスが連続していない場合のみ出力する。";
            this.chkBoxNotAllowSequentialWall.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(109, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "以下のみ出力する。(全体の1/4が理想)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "空マスが";
            // 
            // numUDWallLimit
            // 
            this.numUDWallLimit.Location = new System.Drawing.Point(61, 16);
            this.numUDWallLimit.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.numUDWallLimit.Name = "numUDWallLimit";
            this.numUDWallLimit.Size = new System.Drawing.Size(43, 19);
            this.numUDWallLimit.TabIndex = 12;
            // 
            // labelAddingWordLength
            // 
            this.labelAddingWordLength.AutoSize = true;
            this.labelAddingWordLength.Location = new System.Drawing.Point(257, 29);
            this.labelAddingWordLength.Name = "labelAddingWordLength";
            this.labelAddingWordLength.Size = new System.Drawing.Size(23, 12);
            this.labelAddingWordLength.TabIndex = 17;
            this.labelAddingWordLength.Text = "---";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Yellow;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(12, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(255, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "※ワード数の階乗に比例した処理時間がかかります。";
            // 
            // btnSaveTxt
            // 
            this.btnSaveTxt.Enabled = false;
            this.btnSaveTxt.Location = new System.Drawing.Point(645, 8);
            this.btnSaveTxt.Name = "btnSaveTxt";
            this.btnSaveTxt.Size = new System.Drawing.Size(83, 23);
            this.btnSaveTxt.TabIndex = 19;
            this.btnSaveTxt.Text = "テキストを保存";
            this.btnSaveTxt.UseVisualStyleBackColor = true;
            this.btnSaveTxt.Click += new System.EventHandler(this.btnSaveTxt_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(205, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "最大長";
            // 
            // lblMaxWordLen
            // 
            this.lblMaxWordLen.AutoSize = true;
            this.lblMaxWordLen.Location = new System.Drawing.Point(259, 77);
            this.lblMaxWordLen.Name = "lblMaxWordLen";
            this.lblMaxWordLen.Size = new System.Drawing.Size(23, 12);
            this.lblMaxWordLen.TabIndex = 21;
            this.lblMaxWordLen.Text = "---";
            // 
            // btnRandomAdd
            // 
            this.btnRandomAdd.Location = new System.Drawing.Point(207, 99);
            this.btnRandomAdd.Name = "btnRandomAdd";
            this.btnRandomAdd.Size = new System.Drawing.Size(83, 23);
            this.btnRandomAdd.TabIndex = 22;
            this.btnRandomAdd.Text = "ランダムに追加";
            this.btnRandomAdd.UseVisualStyleBackColor = true;
            this.btnRandomAdd.Click += new System.EventHandler(this.btnRandomAdd_Click);
            // 
            // statusStripMainBottom
            // 
            this.statusStripMainBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripGenerateProgressBar,
            this.toolStripProgressPercentage,
            this.toolStripGenerateProgressMessage});
            this.statusStripMainBottom.Location = new System.Drawing.Point(0, 512);
            this.statusStripMainBottom.Name = "statusStripMainBottom";
            this.statusStripMainBottom.Size = new System.Drawing.Size(742, 23);
            this.statusStripMainBottom.SizingGrip = false;
            this.statusStripMainBottom.TabIndex = 23;
            this.statusStripMainBottom.Text = "statusStrip1";
            // 
            // toolStripGenerateProgressBar
            // 
            this.toolStripGenerateProgressBar.Name = "toolStripGenerateProgressBar";
            this.toolStripGenerateProgressBar.Size = new System.Drawing.Size(100, 17);
            this.toolStripGenerateProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // toolStripProgressPercentage
            // 
            this.toolStripProgressPercentage.AutoSize = false;
            this.toolStripProgressPercentage.Name = "toolStripProgressPercentage";
            this.toolStripProgressPercentage.Size = new System.Drawing.Size(42, 18);
            this.toolStripProgressPercentage.Text = "100%";
            this.toolStripProgressPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripGenerateProgressMessage
            // 
            this.toolStripGenerateProgressMessage.Name = "toolStripGenerateProgressMessage";
            this.toolStripGenerateProgressMessage.Size = new System.Drawing.Size(108, 18);
            this.toolStripGenerateProgressMessage.Text = "ProgressMessage";
            // 
            // lblWordCount
            // 
            this.lblWordCount.AutoSize = true;
            this.lblWordCount.Location = new System.Drawing.Point(259, 57);
            this.lblWordCount.Name = "lblWordCount";
            this.lblWordCount.Size = new System.Drawing.Size(23, 12);
            this.lblWordCount.TabIndex = 25;
            this.lblWordCount.Text = "---";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(205, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 24;
            this.label11.Text = "単語数";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(276, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 26;
            this.label10.Text = "予想時間";
            // 
            // lblPredictedProcessTime
            // 
            this.lblPredictedProcessTime.AutoSize = true;
            this.lblPredictedProcessTime.Location = new System.Drawing.Point(364, 5);
            this.lblPredictedProcessTime.Name = "lblPredictedProcessTime";
            this.lblPredictedProcessTime.Size = new System.Drawing.Size(23, 12);
            this.lblPredictedProcessTime.TabIndex = 27;
            this.lblPredictedProcessTime.Text = "---";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 535);
            this.Controls.Add(this.lblPredictedProcessTime);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblWordCount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.statusStripMainBottom);
            this.Controls.Add(this.btnRandomAdd);
            this.Controls.Add(this.lblMaxWordLen);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSaveTxt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelAddingWordLength);
            this.Controls.Add(this.groupBoxGenerationCondition);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numUDHorizontalSize);
            this.Controls.Add(this.numUDVerticalSize);
            this.Controls.Add(this.btnRotate);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnSavePic);
            this.Controls.Add(this.comboBoxGeneratedPic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSortDes);
            this.Controls.Add(this.btnSortAsc);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtBxAddWord);
            this.Controls.Add(this.txtBxInputWords);
            this.Controls.Add(this.pbOutImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "クロスワード生成";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbOutImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDVerticalSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDHorizontalSize)).EndInit();
            this.groupBoxGenerationCondition.ResumeLayout(false);
            this.groupBoxGenerationCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDWallLimit)).EndInit();
            this.statusStripMainBottom.ResumeLayout(false);
            this.statusStripMainBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbOutImage;
        private System.Windows.Forms.TextBox txtBxInputWords;
        private System.Windows.Forms.TextBox txtBxAddWord;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSortAsc;
        private System.Windows.Forms.Button btnSortDes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxGeneratedPic;
        private System.Windows.Forms.Button btnSavePic;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnRotate;
        private System.Windows.Forms.NumericUpDown numUDVerticalSize;
        private System.Windows.Forms.NumericUpDown numUDHorizontalSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBoxGenerationCondition;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numUDWallLimit;
        private System.Windows.Forms.CheckBox chkBoxNotAllowSequentialWall;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDicSetting;
        private System.Windows.Forms.CheckBox chkBoxUseDic;
        private System.Windows.Forms.Label labelAddingWordLength;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBoxEmbedKeyWord;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSaveTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblMaxWordLen;
        private System.Windows.Forms.Button btnRandomAdd;
        private System.Windows.Forms.CheckBox chkBoxConvYouonSokuon;
        private System.Windows.Forms.StatusStrip statusStripMainBottom;
        private System.Windows.Forms.ToolStripProgressBar toolStripGenerateProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripGenerateProgressMessage;
        private System.Windows.Forms.ToolStripStatusLabel toolStripProgressPercentage;
        private System.Windows.Forms.Label lblWordCount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblPredictedProcessTime;
    }
}

