using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

using BABEL.Puzzle.CrossWordPuzzle;

namespace CWPGeneratorView
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        String defaultFile = "default.wl";
        CWPGenerator cwg;
        List<String> OuterDictionary = null;
        bool UseOuterDictionary = false;

        public DlgFormRandomWordSelecter dlgRandomWordSelecter = new DlgFormRandomWordSelecter();

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnRotate.Enabled = false;
            btnSavePic.Enabled = false;

            CanStart = true;

            chkBoxConvYouonSokuon.Checked = true;

            numUDHorizontalSize.Value = 6;
            numUDVerticalSize.Value = 6;
            numUDWallLimit.Value = 20;

            toolStripGenerateProgressBar.Value = 0;
            toolStripGenerateProgressMessage.Text = "";
            toolStripProgressPercentage.Text = "";

            LoadDefaultWordList();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveDefaultWordList();
        }

        private void LoadDefaultWordList()
        {
            List<Word> wordList;
            if (!System.IO.File.Exists(defaultFile))    //ファイルが存在しない場合はデフォルトデータを書き込む
            {
                wordList = CWPGenerator.ConvertStringsToWordList(new List<String>(txtBxInputWords.Lines), 16);
                CWPDataIO.WriteWordList(defaultFile, wordList);
                return;
            }

            wordList = CWPDataIO.ReadWordList(defaultFile);
            txtBxInputWords.Clear();
            String[] slist = new String[wordList.Count];
            for (int i = 0; i < wordList.Count; i++)
            {
                slist[i] = wordList[i].str;
            }
            txtBxInputWords.Lines = slist;
        }

        private void SaveDefaultWordList()
        {
            List<Word> wordList;
            wordList = CWPGenerator.ConvertStringsToWordList(new List<String>(txtBxInputWords.Lines), 20);
            CWPDataIO.WriteWordList(defaultFile, wordList);
        }

        private void comboBoxGeneratedPic_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxGeneratedPic.SelectedIndex;
            if (index < 0)
                return;

            pbOutImage.Image = cwg.CWPList[index].ToBitmap(pbOutImage.Width, pbOutImage.Height);
        }

        private bool CanStart;

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!CanStart)
            {
                cwg.CancelGenerate();
                btnGenerate.Enabled = false;
                groupBoxGenerationCondition.Enabled = true;
                return;
            }

            groupBoxGenerationCondition.Enabled = false;
            btnGenerate.Text = "生成中断";
            CanStart = false;

            if (txtBxInputWords.Lines.Length < 1)
            {
                MessageBox.Show("ワードリストが空です");
                btnGenerate.Enabled = true;
                return;
            }
            cwg = new CWPGenerator();
            //オプションの適用
            cwg.convYouonSokuon = chkBoxConvYouonSokuon.Checked;
            cwg.noSequentialWall = chkBoxNotAllowSequentialWall.Checked;
            cwg.puzzleSize = (int)numUDVerticalSize.Value;
            cwg.useOuterDictionary = this.UseOuterDictionary;
            cwg.OuterDictionary = this.OuterDictionary;
            cwg.mustContainStr = txtBoxEmbedKeyWord.Text;

            //処理時間計測
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            //進捗通知用オブジェクト
            toolStripGenerateProgressBar.Value = 0;
            toolStripGenerateProgressMessage.Text = "";
            toolStripProgressPercentage.Text = "";

            var progress = new Progress<CWPGenerateProgressInfo>((info)=>
                {
                    toolStripGenerateProgressBar.Value = info.CurrentProgress;
                    toolStripProgressPercentage.Text = info.CurrentProgress.ToString() + "%";
                    toolStripGenerateProgressMessage.Text = info.Message;
                });

            //非同期で実行
            await cwg.GenerateAsync(new List<String>(txtBxInputWords.Lines), progress);

            cwg.CWPList.Sort((b1, b2) => b1.GetWallCount() - b2.GetWallCount());

            //空マスの最大値が空マス制限を超えている場合は、削除処理を実施
            if (cwg.CWPList.Count > 0 && cwg.CWPList[cwg.CWPList.Count - 1].GetWallCount() > (int)numUDWallLimit.Value)
            {
                int index = cwg.CWPList.FindIndex((b) => b.GetWallCount() > (int)numUDWallLimit.Value);
                cwg.CWPList.RemoveRange(index, cwg.CWPList.Count - index);
            }

            sw.Stop();
            MessageBox.Show(cwg.CWPList.Count + "個のクロスワードパズルが生成されました! (処理時間:" + ((double)sw.ElapsedMilliseconds / 1000).ToString("0.###") + "秒)");

            //デバッグ用
            //MessageBox.Show("TransPositionedCount=" + g.transpositionedCount);

            comboBoxGeneratedPic.Items.Clear();
            for (int i = 0; i < cwg.CWPList.Count; i++)
            {
                comboBoxGeneratedPic.Items.Add(cwg.CWPList[i].ToString());
            }

            if (comboBoxGeneratedPic.Items.Count > 0)
            {
                comboBoxGeneratedPic.SelectedIndex = 0;
                btnSavePic.Enabled = true;
                btnSaveTxt.Enabled = true;
                btnRotate.Enabled = true;
            }
            else
            {
                btnSavePic.Enabled = false;
                btnSaveTxt.Enabled = false;
                btnRotate.Enabled = false;
            }

            btnGenerate.Enabled = true;
            btnGenerate.Text = "自動生成";
            CanStart = true;
        }

        private void numUDVerticalSize_ValueChanged(object sender, EventArgs e)
        {
            numUDHorizontalSize.Value = numUDVerticalSize.Value;
        }



        private void chkBoxUseDic_CheckedChanged(object sender, EventArgs e)
        {
            UseOuterDictionary = chkBoxUseDic.Checked;
            if (chkBoxUseDic.Checked)
            {
                OuterDictionary = CWPDataIO.ReadOuterDictionary("dic\\WordDictionaryLarge.wl", 
                    CWPDataIO.ConvertOption.ToKatakana | CWPDataIO.ConvertOption.SokuonToNormal);

            }
            else
            {
                OuterDictionary = null;
            }

        }

        private void btnSaveTxt_Click(object sender, EventArgs e)
        {
            if (cwg.CWPList.Count > 0 && comboBoxGeneratedPic.Items.Count > 0 && comboBoxGeneratedPic.SelectedIndex >= 0)
            {
                SaveFileDialog fd = new SaveFileDialog();
                fd.AddExtension = true;
                fd.OverwritePrompt = true;
                fd.DefaultExt = ".cwp";
                fd.FileName = "New CrossWordPuzzle.cwp";
                fd.Filter = "クロスワードパズルファイル(*.cwp)|*.cwp";
                DialogResult dr = fd.ShowDialog(this);

                if(dr == System.Windows.Forms.DialogResult.OK)
                {
                    CWPDataIO.WriteCWPFile(fd.FileName, cwg.CWPList[comboBoxGeneratedPic.SelectedIndex]);
                }

                fd.Dispose();
            }

        }

        private void btnSavePic_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.AddExtension = true;
            fd.OverwritePrompt = true;
            fd.DefaultExt = ".bmp";
            fd.FileName = "New CrossWordPuzzle.bmp";
            fd.Filter = "クロスワードパズル画像(*.bmp)|*.bmp";
            DialogResult dr = fd.ShowDialog(this);

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap img = cwg.CWPList[comboBoxGeneratedPic.SelectedIndex].ToBitmap(pbOutImage.Width, pbOutImage.Height);
                img.Save(fd.FileName);
                img.Dispose();
            }

            fd.Dispose();
        }

        private void txtBxInputWords_Validated(object sender, EventArgs e)
        {
            int maxlen=0;
            String temp;
            int wordCount = 0;
            for (int i = 0; i < txtBxInputWords.Lines.Length; i++)
            {
                temp = txtBxInputWords.Lines[i];
                temp = temp.Trim();
                if (maxlen < temp.Length)
                    maxlen = temp.Length;
                wordCount++;
            }

            lblMaxWordLen.Text = maxlen.ToString();
            lblMaxWordLen.Tag = maxlen;
            lblWordCount.Text = wordCount.ToString();
            lblWordCount.Tag = wordCount;

            //予想処理時間を計算
            var sec = CWPGenerator.CalcProcessTime(2.0, 2, new List<string>(txtBxInputWords.Lines), 
                                                    (int)numUDHorizontalSize.Value, (int)numUDVerticalSize.Value);

            var time = new TimeSpan(0,0,0,sec);
            lblPredictedProcessTime.Text = time.ToString(@"hh\:mm\:ss");
        }

        private void txtBxAddWord_TextChanged(object sender, EventArgs e)
        {
            if (txtBxAddWord.Text.Length > 1)
            {
                btnAdd.Enabled = true;
                String temp = txtBxAddWord.Text.Trim();
                labelAddingWordLength.Text = temp.Length.ToString("##0");

                if (temp.Length > (int)lblMaxWordLen.Tag)
                {
                    labelAddingWordLength.ForeColor = Color.Red;
                }
                else
                {
                    labelAddingWordLength.ForeColor = SystemColors.ControlText;
                }
            }
            else
            {
                btnAdd.Enabled = false;
                labelAddingWordLength.Text = "---";
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String temp = txtBxAddWord.Text.Trim();
            List<String> lines = new List<string>(txtBxInputWords.Lines);
            lines.Add(temp);

            txtBxInputWords.Lines = lines.ToArray();
        }

        private void btnSortAsc_Click(object sender, EventArgs e)
        {
            String temp = txtBxAddWord.Text.Trim();
            List<String> lines = new List<string>(txtBxInputWords.Lines);
            lines.Sort();
            lines.Sort(CompareLengthAscending);
            txtBxInputWords.Lines = lines.ToArray();
        }

        private void btnSortDes_Click(object sender, EventArgs e)
        {
            String temp = txtBxAddWord.Text.Trim();
            List<String> lines = new List<string>(txtBxInputWords.Lines);
            lines.Sort(CompareDescending);
            lines.Sort(CompareLengthDescending);
            txtBxInputWords.Lines = lines.ToArray();
        }

        static int CompareDescending(String x, String y)
        {
            return y.CompareTo(x);
        }

        static int CompareLengthAscending(String x, String y)
        {
            return x.Length - y.Length;
        }
        static int CompareLengthDescending(String x, String y)
        {
            return y.Length - x.Length;
        }

        private void btnRandomAdd_Click(object sender, EventArgs e)
        {
            if (dlgRandomWordSelecter.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                return;

            List<String> lines = new List<string>(txtBxInputWords.Lines);
            lines.AddRange(dlgRandomWordSelecter.AddWords);
            txtBxInputWords.Lines = lines.ToArray();
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            int index = comboBoxGeneratedPic.SelectedIndex;
            if (index < 0)
                return;

            cwg.CWPList[index] = cwg.CWPList[index].GetMirror();
            pbOutImage.Image = cwg.CWPList[index].ToBitmap(pbOutImage.Width, pbOutImage.Height);
        }



    }

}
