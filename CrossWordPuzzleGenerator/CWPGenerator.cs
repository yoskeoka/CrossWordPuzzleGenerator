using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace BABEL.Puzzle.CrossWordPuzzle
{
    public class CWPDataIO
    {
        public static System.Exception Error;

        public static bool WriteWordList(String fileName, List<Word> wordList)
        {
            int writtenCount = 0;

            using (var fs = new System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                using (var sw = new System.IO.StreamWriter(fs, Encoding.GetEncoding(932)))
                {
                    for (int i = 0; i < wordList.Count; i++)
                    {
                        sw.WriteLine(wordList[i].str);
                        writtenCount++;
                    }
                }
            }

            if (writtenCount == wordList.Count)
                return true;
            else
                return false;
        }

        public static List<Word> ReadWordList(String fileName)
        {
            var wordList = new List<Word>();
            if (!System.IO.File.Exists(fileName))
            {
                return wordList;    //ファイル存在しない
            }
            using (var fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                using (var sr = new System.IO.StreamReader(fs, Encoding.GetEncoding(932)))
                {
                    String str;
                    while ((str = sr.ReadLine()) != null)
                    {
                        if (str.Length > 1)
                            wordList.Add(new Word(str));
                    }
                }
            }
            return wordList;
        }

        [Flags]
        public enum ConvertOption
        {
            None = 0x0,
            ToHiragana = 0x1,
            ToKatakana = 0x2,
            ToZenkaku = 0x4,
            ToUpper = 0x8,
            ToLower = 0x10,
            SokuonToNormal = 0x20,
        }
        public static List<String> ReadOuterDictionary(String fileName, ConvertOption opt)
        {
            var sw = new System.Diagnostics.Stopwatch();

            sw.Start();
            var wordList = new List<String>();
            if (!System.IO.File.Exists(fileName))
            {
                return wordList;    //外部ファイル存在しない
            }
            using (var fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                using (var sr = new System.IO.StreamReader(fs, Encoding.GetEncoding(932)))
                {
                    String str;
                    while ((str = sr.ReadLine()) != null)
                    {
                        if (str.Length > 1)
                        {
                            //ワード変換
                            if ((opt & ConvertOption.ToLower) == ConvertOption.ToLower)
                            {
                                str = str.ToLower();
                            }

                            if ((opt & ConvertOption.ToUpper) == ConvertOption.ToUpper)
                            {
                                str = str.ToUpper();
                            }

                            if ((opt & ConvertOption.ToZenkaku) == ConvertOption.ToZenkaku)
                            {
                                str = CSharp.Japanese.Kanaxs.Kana.ToZenkaku(str);
                                str = CSharp.Japanese.Kanaxs.Kana.ToZenkakuKana(str);
                            }

                            if ((opt & ConvertOption.ToKatakana) == ConvertOption.ToKatakana)
                            {
                                str = CSharp.Japanese.Kanaxs.Kana.ToKatakana(str);
                            }

                            if ((opt & ConvertOption.ToHiragana) == ConvertOption.ToHiragana)
                            {
                                str = CSharp.Japanese.Kanaxs.Kana.ToHiragana(str);
                            }

                            //クロスワードだけの特別変換
                            if ((opt & ConvertOption.SokuonToNormal) == ConvertOption.SokuonToNormal)
                            {
                                str = CSharp.Japanese.Kanaxs.Kana.ReplaceYouonSokuonToNormal(str);
                            }
                            wordList.Add(str);
                        }
                    }
                }
            }

            sw.Stop();
            //MessageBox.Show("外部辞書読込時間 " + ((double)sw.ElapsedMilliseconds / 1000).ToString("0.###") + "[秒]");

            wordList.Sort();

            return wordList;
        }

        public static bool WriteCWPFile(String fileName, CWPBoard board)
        {
            System.IO.StreamWriter sw = null;
            try
            {
                sw = new System.IO.StreamWriter(fileName, false);

                //ヘッダ部
                //sw.WriteLine("Name=" + board.name);
                sw.WriteLine("WordCount=" + board.checkedWordCount.ToString());
                sw.WriteLine("Size=" + board.HorizontalSize.ToString() + "," + board.VerticalSize.ToString());

                //データ部
                sw.WriteLine("[CrosswordPuzzle Data]");
                for (int x = 0; x < board.HorizontalSize; x++)
                    sw.Write("－");

                sw.WriteLine();

                String str;
                for (int y = 0; y < board.VerticalSize; y++)
                {
                    for (int x = 0; x < board.HorizontalSize; x++)
                    {
                        str = board.cells[board.GetIndex(x, y)].letter;
                        sw.Write(str == board.WallLetter ? "■" : str);
                    }
                    sw.WriteLine();
                }

            }
            catch (System.IO.IOException ioe)
            {
                Error = ioe;
                return false;
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }

            return true;

        }

    }

    public class CWPGenerateProgressInfo
    {
        public CWPGenerateProgressInfo(int currentProgress)
        {
            CurrentProgress = currentProgress;

            if (CurrentProgress > 100)
                CurrentProgress = 100;
        }

        public CWPGenerateProgressInfo(int currentProgress, String msg)
        {
            CurrentProgress = currentProgress;
            Message = msg;

            if (CurrentProgress > 100)
                CurrentProgress = 100;
        }

        public int CurrentProgress { get; private set; }
        public String Message { get; private set; }
    }

    public class CWPGenerator
    {
        //private List<String> TransposTable = new List<String>();    //置換表
        private Dictionary<String, bool> TransposTable = new Dictionary<String, bool>();    //置換表 Dictionaryの自動ハッシュインデックス生成に期待
        //private SortedList<String, bool> TransposTable = new SortedList<String, bool>();    //置換表
        public long transpositionedCount;
        public bool useTransPosition;
        public bool convYouonSokuon;
        public List<CWPBoard> CWPList;  //生成したクロスワードパズルのリスト
        public int generateLimit;
        public bool noSequentialWall;
        public int puzzleSize;
        public bool useOuterDictionary;
        public List<String> OuterDictionary;
        public String mustContainStr;
        private Object Lock_completedWordCount = "completedWordCount";
        private int completedWordCount;
        private Object Lock_minimumWallCount = "minimumWallCount";
        private int minimumWallCount;
        private int generatedCount;

        private CancellationTokenSource _CancellationTokenSource;

        public void CancelGenerate()
        {
            if (_CancellationTokenSource != null)
            {
                _CancellationTokenSource.Cancel();
            }
        }

        public CWPGenerator()
        {
            transpositionedCount = 0;
            completedWordCount = 0;
            useTransPosition = true;
            convYouonSokuon = false;
            CWPList = new List<CWPBoard>();
            generateLimit = 1000;
            noSequentialWall = false;
            puzzleSize = 1;
            useOuterDictionary = false;
        }

        public static List<Word> ConvertStringsToWordList(List<String> slist, int lenLimit)
        {
            int i;
            //使用ワードリストの取り込み
            var wordList = new List<Word>(slist.Count);
            for (i = 0; i < slist.Count; i++)
            {
                Word w = new Word(slist[i].Trim());

                //長さ1以下、パズルサイズより大きい文字列は対象外
                if (w.str.Length <= 1 || w.str.Length > lenLimit)
                    continue;

                wordList.Add(w);
            }

            return wordList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cpuClock_GHz"></param>
        /// <param name="cpuCoreCount"></param>
        /// <param name="words"></param>
        /// <param name="puzzleSizeX"></param>
        /// <param name="puzzleSizeY"></param>
        /// <returns></returns>
        public static int CalcProcessTime(double cpuClock_GHz, int cpuCoreCount, List<String> words, int puzzleSizeX, int puzzleSizeY)
        {
            const double DefcpuClock = 2.0;
            const int DefcpuCore = 2;   
            int ret = 0;
            double cpuRatio = (cpuClock_GHz / DefcpuClock) * (cpuCoreCount / DefcpuCore);
            double wordAveLen = words.Average(w => w.Length);
            double wordTotalLen = words.Sum(w => w.Length);
            int wordCount = words.Count;
            int puzzleSize = puzzleSizeX * puzzleSizeY;
            try
            {
                var wordRate = wordTotalLen * wordAveLen; //Math.Pow(wordAveLen, wordCount);
                var cpuPower = (1000 * 2.0 * 2 * cpuRatio);
                double parameter = 1000; 
                ret = (int)(wordRate / cpuPower * puzzleSize * parameter);
            }
            catch (OverflowException )
            {
                return -1;   //計算不能
            }

            return ret;
        }

        /// <summary>
        /// クロスワード生成ロジック(非同期)
        /// </summary>
        /// <param name="input"></param>
        /// <param name="progress"></param>
        /// <returns></returns>
        public async Task<int> GenerateAsync(List<String> input, IProgress<CWPGenerateProgressInfo> progress)
        {
            _CancellationTokenSource = new CancellationTokenSource();
            return await Task.Run<int>(()=>{
                return Generate(input, progress);
            });
        }

        /// <summary>
        /// クロスワード生成ロジック
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int Generate(List<String> input)
        {
            return Generate(input, new Progress<CWPGenerateProgressInfo>());
        }

        private int Generate(List<String> input, IProgress<CWPGenerateProgressInfo> progress)
        {
            
            int maxLen = puzzleSize;

            //初期化
            CWPList.Clear();

            //拗音促音変換
            if (convYouonSokuon)
            {
                for (int i = 0; i < input.Count; i++)
                {
                    input[i] = CSharp.Japanese.Kanaxs.Kana.ReplaceYouonSokuonToNormal(input[i]);
                }
            }

            //使用ワードリストの取り込み
            var wordListOriginal = ConvertStringsToWordList(input, puzzleSize);

            //状態変数の初期化
            int ret = 0;
            generatedCount = 0;
            completedWordCount = 0;
            minimumWallCount = puzzleSize * puzzleSize;
            transpositionedCount = 0;
            TransposTable.Clear();  //置換テーブルの初期化

            //初期ワードを配置
            //for (i = 0; i < wordList.Count; i++)
            Parallel.For(0, wordListOriginal.Count,(i) =>
            {
                //並列処理のため、ワードリストをコピー(Wordは参照型のため、Newし直しが必要)
                var wordList = new List<Word>(wordListOriginal.Count);
                for (int k = 0; k < wordListOriginal.Count; k++)
                {
                    wordList.Add(wordListOriginal[k].Copy());
                }

                //クロスワードデータ生成
                var p = new CWPBoard(puzzleSize, puzzleSize, "*");
                p.notAllowSequentialWall = noSequentialWall;

                //指定文字を含む条件の設定状況確認
                if (!mustContainStr.Contains("*"))
                {
                    p.useCondContains = true;
                    p.condContainsLetters = mustContainStr;
                }

                //外部辞書設定確認
                if (OuterDictionary != null)
                {
                    if (OuterDictionary.Count > 0)
                    {
                        p.useOuterDictionary = true;
                        p.OuterDictionary = OuterDictionary;
                    }
                }

                var resultList = new List<CWPBoard>();
                wordList[i].used = true;
                var undo = p.AddWord(new SetInfo(0, 0, WordDirection.Down, wordList[i].str));
                ret += SearchRecursive(0, p, wordList, ref resultList);
                p.RemoveWord(undo);
                wordList[i].used = false;
                lock (CWPList)
                {
                    CWPList.AddRange(resultList);
                }

                lock(Lock_completedWordCount){
                    completedWordCount++;
                }
                progress.Report(
                    new CWPGenerateProgressInfo((completedWordCount*100)/wordListOriginal.Count,
                        "生成済:" + generatedCount + " 最小空マス:"+ minimumWallCount + ", \"" + wordList[i].str + "\" から始まる処理が完了しました。"));

                resultList.Clear();
                wordList.Clear();

                if (CWPList.Count > generateLimit)
                {
                    return; //生成個数が多すぎるため中断
                }
            });

            return ret;
        }

        /// <summary>
        /// nの階乗を計算する。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static long Factorial(long n)
        {
            if (n == 0)
                return 1;
            return n * Factorial(n - 1);
        }

        static double Factorial(double n)
        {
            if (n < 1)
                return 1.0;
            return n * Factorial(n - 1.0);
        }

        /// <summary>
        /// 初期ワードを配置した後、そのワードに連結したCWPのリストを作成する(再帰処理)
        /// </summary>
        /// <param name="depth"></param>
        /// <param name="board"></param>
        /// <param name="wordList"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        private int SearchRecursive(int depth, CWPBoard board, List<Word> wordList, ref List<CWPBoard> list)
        {
            int i, k;
            if (depth == 0)
            {
                list = new List<CWPBoard>();
                //List<Word> wList = wordList.ToList();   //wordList書き換えのためのコピー
                //wordList = wList;
            }

            //キャンセル処理
            if (_CancellationTokenSource.IsCancellationRequested)
                return list.Count;

            //置換テーブルに一致があれば探索打ち切り
            
            if (useTransPosition)
            {
                var hashkey = board.GetStrKey();
                //var hashkey = board.GetHashIndex();
                lock (TransposTable)
                {
                    //if (TransposTable.BinarySearch(hashkey) > -1)
                    //{
                    //    transpositionedCount++;
                    //    return list.Count;
                    //}
                    //else
                    //{
                    //    TransposTable.Add(hashkey);
                    //    var mirrorKey = board.GetMirror().GetStrKey();
                    //    //if(!TransposTable.ContainsKey(mirrorKey))
                    //    TransposTable.Add(mirrorKey);
                    //    TransposTable.Sort();
                    //}
                    //List<T>.BinarySearch より、SortedList<T>.ContainsKeyの方がキー一致だけ探すなら高速
                    if (TransposTable.ContainsKey(hashkey))
                    {
                        transpositionedCount++;
                        return list.Count;
                    }
                    else
                    {
                        TransposTable.Add(hashkey, true);
                        var mirrorKey = board.GetMirror().GetStrKey();
                        if(!TransposTable.ContainsKey(mirrorKey))
                            TransposTable.Add(mirrorKey, true);
                    }
                }
            }

            List<SetInfo> seti = new List<SetInfo>();

            for (i = 0; i < wordList.Count; i++)
            {
                if (wordList[i].used)
                    continue;

                seti.AddRange(board.GetPutablePositionList(wordList[i].str));
            }

            if (seti.Count > 0) //ワード配置可能な場合
            {
                for (k = 0; k < seti.Count; k++)
                {
                    i = wordList.FindIndex((w) => w.str == seti[k].word);
                    if (i < 0)
                        continue;   //来るはずがないが、一応

                    wordList[i].used = true;
                    UndoInfo undoi = board.AddWord(seti[k]);

                    SearchRecursive(depth + 1, board, wordList, ref list);
                    board.RemoveWord(undoi);
                    wordList[i].used = false;
                }
            }
            else //これ以上配置できない＝＞完成
            {
                if (board.CheckWords(wordList))
                {
                    if (board.useCondContains)
                    {
                        if (!board.ContainsLetters(board.condContainsLetters))
                        {
                            return list.Count;
                        }
                    }

                    list.Add(board.Copy()); //コピーオブジェクトを結果リストに格納
                    generatedCount++;
                    lock (Lock_minimumWallCount)
                    {
                        if (board.GetWallCount() < minimumWallCount)
                            minimumWallCount = board.GetWallCount();
                    }

                }
            }


            return list.Count;

        }
    }

    public enum WordDirection
    {
        Right,
        Down
    }

    public struct SetInfo
    {
        public int x, y;
        public WordDirection dir;
        public String word;

        public SetInfo(int _x, int _y, WordDirection _dir, String _word)
        {
            x = _x;
            y = _y;
            dir = _dir;
            word = _word;
        }

        public override string ToString()
        {
            String str;
            str = "start={" + x + "," + y + "}" + " dir=\"" + Enum.GetName(typeof(WordDirection), dir) + "\" w=\"" + word + "\"";
            return str;
        }
    }

    public struct UndoInfo
    {
        public SetInfo setInfo;
        public int wordLen;
        public List<CWPCell> ReplaceList;

        public UndoInfo(SetInfo set)
        {
            setInfo = set;
            wordLen = set.word.Length;
            ReplaceList = new List<CWPCell>();
        }

        public void AddPrevInfo(CWPCell cell)
        {
            ReplaceList.Add(cell);
            wordLen = ReplaceList.Count;
        }
    }

    public class Word
    {
        public String str;
        public bool used;
        public Word(String s)
        {
            str = s;
            used = false;
        }
        public Word(String s, bool used_flag)
        {
            str = s;
            used = false;
        }

        public override string ToString()
        {
            return str +"(" + used.ToString()+")";
        }

        /// <summary>同一値をコピーしたインスタンスを返します</summary>
        public Word Copy()
        {
            return new Word(str, used);
        }
    }

    public class CWPCell
    {
        public String letter; // *=壁マス
        public int referCount;
        public int x, y;
        public CWPCell(int _x, int _y, String _letter)
        {
            x = _x;
            y = _y;
            letter = _letter;
            referCount = 0;
        }

        public override string ToString()
        {
            String str;
            str = "(" + x + "," + y + ")" + " letter=\"" + letter + "\"";
            return str;
        }
    }

    public class CWPBoard
    {
        private String WALL = "*";
        public String name = "";
        public List<CWPCell> cells = new List<CWPCell>();
        private int length_X, length_Y;
        public int setWordCount;
        public int checkedWordCount;
        public bool useOuterDictionary;
        public bool notAllowSequentialWall;
        public bool useCondContains;
        public String condContainsLetters; //完成時に含んでいなければならない文字 → 空白=チェックOK

        public List<String> OuterDictionary;

        public CWPBoard(int len_x, int len_y, String wallChar)
        {
            Init();
            Fill(len_x, len_y, wallChar);
        }

        public void Init()
        {
            WALL = "*";
            name = "";
            cells.Clear();
            length_X = 0;
            length_Y = 0;
            setWordCount = 0;
            useOuterDictionary = false;
            OuterDictionary = new List<String>();
            notAllowSequentialWall = false;
            useCondContains = false;
            condContainsLetters = "";
        }

        public override string ToString()
        {
            String str;
            var sb = new StringBuilder(length_X * length_Y * 2);
            for (int i = 0; i < cells.Count; i++)
                sb.Append(cells[i].letter);

            str = "size={" + length_X + "," + length_Y + "}" + " wall={" + GetWallCount() + "} words=\"" + sb.ToString() + "\"";
            return str;
        }

        public Bitmap ToBitmap(int width, int height)
        {
            Bitmap pic = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(pic);

            int grid_X, grid_Y;
            grid_X = width / length_X;
            grid_Y = height / length_Y;

            g.FillRectangle(Brushes.White, 0, 0, width, height);
            int x, y;

            Pen pen = new Pen(Color.Black, 1);
            Font font = new Font("MS UI Gothic", 20, FontStyle.Bold);

            for (y = 0; y < length_Y; y++)
            {
                for (x = 0; x < length_X; x++)
                {
                    if (cells[GetIndex(x, y)].letter == WALL)
                    {
                        g.DrawRectangle(pen, x * grid_X, y * grid_Y, grid_X, grid_Y);
                        g.FillRectangle(Brushes.Black, x * grid_X, y * grid_Y, grid_X, grid_Y);
                    }
                    else
                    {
                        g.DrawRectangle(pen, x * grid_X, y * grid_Y, grid_X, grid_Y);
                        Point pnt = new Point((int)(x * grid_X + grid_X * 0.2), (int)(y * grid_Y + grid_Y * 0.2));
                        g.DrawString(cells[GetIndex(x, y)].letter, font, Brushes.Black, pnt);
                    }

                }
            }

            g.Dispose();

            return pic;
        }

        public long GetHashIndex()
        {
            int i;
            long hash = 0;

            hash += length_X;
            hash += length_Y * 2;
            String str;
            for (i = 0; i < cells.Count; i++)
            {
                str = cells[i].letter;
                if (str != WALL)
                {
                    hash += char.ConvertToUtf32(cells[i].letter, 0) * (i + 1)
                        + char.ConvertToUtf32(cells[i].letter, 0) % (int)short.MaxValue * (i + 1);
                }
                else
                {
                    hash += 997 * (i + 1);  //とりあえず3桁最大の素数倍を足す
                }

            }
            return hash;
        }

        public String GetStrKey()
        {
            var sb = new StringBuilder(length_X * length_Y * 2);
            for (int i = 0; i < cells.Count; i++)
                sb.Append(cells[i].letter);

            return sb.ToString();
        }

        public CWPBoard Copy()
        {
            CWPBoard board = new CWPBoard(length_X, length_Y, WALL);

            board.name = name;
            board.checkedWordCount = checkedWordCount;
            board.setWordCount = setWordCount;
            board.useOuterDictionary = useOuterDictionary;
            board.OuterDictionary = OuterDictionary;
            for (int i = 0; i < length_X * length_Y; i++)
            {
                board.cells[i].letter = cells[i].letter;
                board.cells[i].referCount = cells[i].referCount;
            }

            return board;
        }

        public CWPBoard GetMirror()
        {
            CWPBoard mirror = this.Copy();

            for (int y = 0; y < length_Y; y++)
            {
                for (int x = 0; x < length_X; x++)
                {
                    mirror.cells[GetIndex(y,x)].letter = this.cells[GetIndex(x, y)].letter;
                    mirror.cells[GetIndex(y, x)].referCount = this.cells[GetIndex(x, y)].referCount;
                }
            }

            return mirror;

        }

        public int VerticalSize
        {
            get { return length_Y; }
        }

        public int HorizontalSize
        {
            get { return length_X; }
        }

        public String WallLetter
        {
            get { return WALL; }
        }

        public int GetIndex(int x, int y)
        {
            return x + length_X * y;
        }

        public bool IsInSquare(int x, int y)
        {
            return !(x < 0 || x >= length_X || y < 0 || y >= length_Y);
        }

        public void Fill(int len_x, int len_y, String defaultLetter)
        {
            cells.Clear();
            length_X = len_x;
            length_Y = len_y;

            for (int j = 0; j < len_y; j++)
            {
                for (int i = 0; i < len_x; i++)
                {
                    CWPCell c = new CWPCell(i, j, defaultLetter);
                    cells.Add(c);
                }
            }
        }

        public bool CheckWords(List<Word> wordList)
        {
            checkedWordCount = 0;
            return CheckWords_OneDirection(WordDirection.Down, wordList)
                && CheckWords_OneDirection(WordDirection.Right, wordList);
        }

        private bool CheckWords_OneDirection(WordDirection dir, List<Word> wordList)
        {

            int x = 0, y = 0;
            int ax = 0, ay = 0;
            int loopCount = 0, searchCount = 0;
            if (dir == WordDirection.Right)
            {
                ax = 1;
                ay = 0;
                loopCount = length_Y;
                searchCount = length_X;
            }
            if (dir == WordDirection.Down)
            {
                ax = 0;
                ay = 1;
                loopCount = length_X;
                searchCount = length_Y;
            }
            int loop, search;
            int wallCount;
            String str;
            for (loop = 0; loop < loopCount; loop++)
            {
                str = "";
                wallCount = 0;

                for (search = 0; search < searchCount; search++)
                {
                    String letter = cells[GetIndex(x + ax * search, y + ay * search)].letter;
                    if (letter == WALL)
                    {
                        str = "";

                        wallCount++;
                        if (notAllowSequentialWall && wallCount >= 2)   //空マスの連続を許可しない場合
                            return false;

                        continue;
                    }
                    else
                    {
                        str += letter;
                        wallCount = 0;
                    }

                    //次のマスが空きか、表外なら取得したワードのチェックをする
                    int nx = x + ax * (search + 1);
                    int ny = y + ay * (search + 1);
                    if (!IsInSquare(nx, ny) || cells[GetIndex(nx, ny)].letter == WALL)
                    {
                        //ワードが1文字以下はチェック対象外(空マスが連続している場合などは0文字になる)
                        if (str.Length <= 1)
                            continue;

                        //チェック開始
                        checkedWordCount++;

                        //ワードリストに存在しない場合はチェック不合格
                        int index = wordList.FindIndex((w) => w.str == str);
                        if (index < 0)
                        {
                            if (useOuterDictionary) //外部辞書を使わない場合はそのままチェック不合格
                            {
                                //index = OuterDictionary.FindIndex((w) => w == str);
                                index = OuterDictionary.BinarySearch(str); 
                                if (index < 0)
                                {
                                    //外部辞書にもないワードなら、チェック不合格
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }

                }

                x += ay;    //ワード探索方向の90°別方向へ1マス進める
                y += ax;
            }

            return true;
        }

        /// <summary>
        /// 指定した文字がすべて含まれているか
        /// </summary>
        /// <param name="cond"></param>
        /// <returns></returns>
        public bool ContainsLetters(String cond)
        {
            
            if (cond == null || cond.Length == 0)
                return true;

            String temp = cond;
            int index;

            for (int i = 0; i < cells.Count; i++)
            {
                index = temp.IndexOf(cells[i].letter);
                if (index < 0)
                    continue;

                temp = temp.Remove(index, cells[i].letter.Length);

                if (temp.Length == 0)
                    return true;
            }

            return false;
        }

        public int GetWallCount()
        {
            int count = 0;
            foreach (CWPCell cell in cells)
            {
                if (cell.letter == WALL)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// 指定ワードについて、すべての配置可能な場所リストを取得
        /// </summary>
        public List<SetInfo> GetPutablePositionList(String word)
        {
            var putList = new List<SetInfo>();
            putList.AddRange(GetPutablePositionList(word, WordDirection.Down));
            putList.AddRange(GetPutablePositionList(word, WordDirection.Right));

            return putList;
        }

        /// <summary>
        /// 指定ワードの指定方向について、すべての配置可能な場所リストを取得
        /// </summary>
        /// <param name="word"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public List<SetInfo> GetPutablePositionList(String word, WordDirection d)
        {
            int i, k, n;
            int x = 0;
            int y = 0;
            int ax = 0;
            int ay = 0;
            var putList = new List<SetInfo>();
            for (i = 0; i < word.Length; i++)
            {
                String L = word[i].ToString();

                var list = cells.FindAll((cell) => cell.letter == L);

                if (list.Count <= 0)
                {
                    continue;   //i番目の文字との一致無しのため次の文字へ
                }
                for (k = 0; k < list.Count; k++)
                {
                    int ox, oy;
                    ox = x = list[k].x;
                    oy = y = list[k].y;

                    //与えられたワードのi番目文字がクロスワード上で見つかった
                    //走査のための変数セット
                    if (d == WordDirection.Down)
                    {
                        oy = y -= i;
                        y--;
                        ax = 0;
                        ay = 1;
                    }
                    if (d == WordDirection.Right)
                    {
                        ox = x -= i;
                        x--;
                        ax = 1;
                        ay = 0;
                    }
                    bool result = true;

                    //走査し、見つかったものは候補リストに入れる
                    for (n = -1; n < word.Length + 1; n++)
                    {
                        //最初の文字の一つ前/一つ後が空白または枠外である
                        if (n == -1 || n == word.Length)
                        {
                            if (!IsInSquare(x, y))
                            {
                                x += ax;
                                y += ay;
                                continue;
                            }

                            if (cells[GetIndex(x, y)].letter == WALL)
                            {
                                x += ax;
                                y += ay;
                                continue;
                            }

                            result = false;
                            break;
                        }

                        //調査するマスが枠からはみ出す場合
                        if (!IsInSquare(x, y))
                        {
                            result = false;
                            break;
                        }

                        //他のワード列と重複するが、ワードが一致しない場合は対象外
                        if (cells[GetIndex(x, y)].letter != WALL && cells[GetIndex(x, y)].letter != L)
                        {
                            result = false;
                            break;
                        }


                        //「課題」
                        //→隣接する2マスが空白でない場合に、
                        //うまくワード辞書から候補を見つけて配置する/しないを決定できれば高速化できるかも？

                        //空白かつ、隣接する2マスが枠外または空白
                        //if (cells[GetIndex(x, y)].letter == WALL)
                        //{
                        //    if (IsInSquare(x - ay, y - ax) && cells[GetIndex(x - ay, y - ax)].letter != WALL)
                        //    {
                        //        result = false;
                        //        break;
                        //    }

                        //    if (IsInSquare(x + ay, y + ax) && cells[GetIndex(x + ay, y + ax)].letter != WALL)
                        //    {
                        //        result = false;
                        //        break;
                        //    }
                        //}

                        x += ax;
                        y += ay;

                    }

                    if (result)
                    {
                        var info = new SetInfo(ox,oy,d,word);
                        //info.dir = d;
                        //info.x = ox;
                        //info.y = oy;
                        //info.word = word;
                        putList.Add(info);
                    }
                }

            }

            return putList;
        }

        /// <summary>
        /// ワードを配置する
        /// </summary>
        /// <param name="seti">ワード配置情報</param>
        /// <returns></returns>
        public UndoInfo AddWord(SetInfo seti)
        {
            setWordCount++;

            UndoInfo undoi = new UndoInfo(seti);

            int i;
            int x, y;
            int ax = 0, ay = 0;
            if (seti.dir == WordDirection.Right)
            {
                ax = 1; ay = 0;
            }

            if (seti.dir == WordDirection.Down)
            {
                ax = 0; ay = 1;
            }

            for (i = 0; i < seti.word.Length; i++)
            {
                x = seti.x + ax * i;
                y = seti.y + ay * i;
                undoi.ReplaceList.Add(new CWPCell(x, y, cells[GetIndex(x, y)].letter));
                cells[GetIndex(x, y)].letter = seti.word[i].ToString();
                cells[GetIndex(x, y)].referCount += 1;

            }

            return undoi;
        }

        /// <summary>
        /// Undo情報を元にCWPの状態を戻す
        /// </summary>
        /// <param name="undoi"></param>
        public void RemoveWord(UndoInfo undoi)
        {
            setWordCount--;

            int i, index;

            for (i = 0; i < undoi.wordLen; i++)
            {
                index = GetIndex(undoi.ReplaceList[i].x, undoi.ReplaceList[i].y);
                cells[index].letter = undoi.ReplaceList[i].letter;
                cells[index].referCount = undoi.ReplaceList[i].referCount;
            }
        }

    }
}
