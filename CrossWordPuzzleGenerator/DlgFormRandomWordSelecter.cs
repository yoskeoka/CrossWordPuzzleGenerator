using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BABEL.Puzzle.CrossWordPuzzle;

namespace CWPGeneratorView
{
    public partial class DlgFormRandomWordSelecter : Form
    {
        public DlgFormRandomWordSelecter()
        {
            InitializeComponent();
        }

        public List<String> AddWords = new List<string>();
        private const String SmallDicPath = "dic\\WordDictionarySmall.wl";
        private const String LargeDicPath = "dic\\WordDictionaryLarge.wl";

        private Random rand = new Random();

        private void btnOK_Click(object sender, EventArgs e)
        {
            String dicName = "";
            AddWords.Clear();

            //ワード辞書の読み込み
            if(radioBtnSmallDic.Checked)
                dicName = SmallDicPath;

            if(radioBtnLargeDic.Checked)
                dicName = LargeDicPath;

            var dic = CWPDataIO.ReadOuterDictionary(dicName, CWPDataIO.ConvertOption.ToKatakana);
            int len = (int)numUDWordLength.Value;
            int select = (int)numWordSelectCount.Value;

            //条件に一致するワードを残す
            
            //指定の長さ以外を削除
            dic.RemoveAll((s) => s.Length != len);

            //指定の検索条件に一致するワードのみ残す
            if (radioButtonREMatching.Checked) //正規表現
            {
                var m = new Regex(textBoxMatchingWord.Text, RegexOptions.IgnoreCase);
                dic.RemoveAll(s => !m.IsMatch(s));
            }
            else if (radioButtonWildMatching.Checked)   //ワイルドカード
            {
                var p = textBoxMatchingWord.Text;
                p = p.Replace("*",".");
                var m = new Regex(p, RegexOptions.IgnoreCase);
                dic.RemoveAll(s => !m.IsMatch(s));
            }
            else //単純比較
            {
                var t = textBoxMatchingWord.Text;
                dic.RemoveAll(s => !s.Contains(t));
            }

            int randi;

            for (int i = 0; i < select; i++)
            {
                if (dic.Count < 1)
                    break;

                randi = rand.Next(dic.Count);

                AddWords.Add(dic[randi]);
                dic.RemoveAt(randi);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
