using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Linq;

namespace AutoClick_FirstBlood
{
    public partial class Form1 : Form
    {
        #region Constructor
        public Form1()
        {
            InitializeComponent(); 
            
        }

        private static Form1 instance;

        public static Form1 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Form1();
                }
                return instance;
            }
        }
        #endregion Constructor

        #region Enums
        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }
        #endregion Enums

        #region Properties
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;
        public const int MOUSEEVENTF_MOVE = 0x01;

        private bool isStopClick;
        private int currentImgIndex;
        private bool isRepeatImgClicked;
        //private bool isEndDragIndex;
        private int repeatCycleIndex;
        private int loopIndex;
        private int timeoutClickCount;
        private int detectIgnoreImgCount;
        private System.Timers.Timer aTimer;
        //private Keys startKey = Keys.F4;
        //private Keys recordKey = Keys.F3;
        private Keys imgKey = Keys.F6;
        private List<Point> posList;

        //private string resultFile;
        #endregion Properties

        #region Events
        private void Form1_Load(object sender, EventArgs e)
        { 
            //RegisterHotKey(this.Handle, 0, 0, startKey.GetHashCode());
            //RegisterHotKey(this.Handle, 1, 0, Keys.F2.GetHashCode());
            //RegisterHotKey(this.Handle, 2, (int)KeyModifier.Control, Keys.Space.GetHashCode());
            //RegisterHotKey(this.Handle, 3, 0, recordKey.GetHashCode());
            RegisterHotKey(this.Handle, 4, 0, imgKey.GetHashCode());

            isStopClick = true;
            currentImgIndex = 0;
            repeatCycleIndex = 0;
            loopIndex = 0;
            detectIgnoreImgCount = 0;
            timeoutClickCount = 30;
            isRepeatImgClicked = false;
            //isEndDragIndex = false;
            posList = new List<Point>();
            //resultFile = "result.txt";
            FileInfoConst.ReadConfigFileForImg();
            FileInfoConst.initImgSubScreenList();
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //UnregisterHotKey(this.Handle, 0);
            //UnregisterHotKey(this.Handle, 1);
            //UnregisterHotKey(this.Handle, 2);
            //UnregisterHotKey(this.Handle, 3);
            UnregisterHotKey(this.Handle, 4);
        }

        private void handIcon_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                handIcon.Visible = true;
                this.Hide();
                handIcon.BalloonTipText = "Auto click move to system tray.";
                handIcon.ShowBalloonTip(500);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartAutoClick();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            StopAutoClick();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            new HelpForm().Show();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (isStopClick)
            {
                aTimer.Enabled = false;
                return;
            }
            RunAutoForImg();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312) //WM_HOTKEY = 0x0312
            {
                int id = m.WParam.ToInt32();
                switch (id)
                {
                    //case 0:
                    //    if (isStopClick)
                    //    {
                    //        StartAutoClick();
                    //    }
                    //    else
                    //    {
                    //        StopAutoClick();
                    //    }
                    //    break;
                    //case 1:
                    //    MyMouseEventHandle.DoLeftMouseSingleClick();
                    //    break;
                    //case 2:
                    //    MyMouseEventHandle.DoRightMouseSingleClick();
                    //    break;
                    //case 3:
                    //    isAutoByImg = false;
                    //    RecordPositions();
                    //    break;
                    case 4:
                        if (isStopClick)
                        {
                            StartAutoClick();
                        }
                        else
                        {
                            StopAutoClick();
                        }
                        //RecodeImgPosition();
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion Events

        #region Methods
        private void StopAutoClick()
        {
            isStopClick = true;
            startButton.Enabled = true;
            stopButton.Enabled = false;
        }

        private void StartAutoClick()
        {
            startButton.Enabled = false;
            stopButton.Enabled = true;

            isStopClick = false;
            aTimer.Interval = 5000;
            aTimer.Enabled = true;
        }

        public void RecordPositions()
        {
            Point curPos = new Point();
            curPos.X = Cursor.Position.X;
            curPos.Y = Cursor.Position.Y;
            posList.Add(curPos);
        }

        //public void WriteResult(bool result)
        //{
        //    try
        //    {
        //        using (StreamWriter sw = new StreamWriter(resultFile, true))
        //        {
        //            if (result)
        //            {
        //                sw.WriteLine(DateTime.Now + " :: success");
        //            }
        //            else
        //            {
        //                sw.WriteLine(DateTime.Now + " :: failure");
        //            }
        //            sw.Close();
        //        }
        //    }
        //    catch { }
        //}

        public void RecodeImgPosition()
        {
#if DEBUG
            //MessageBox.Show(currentImgIndex + "");
#endif
            if(FileInfoConst.textAfterIndexList.ContainsKey(currentImgIndex))
            {
                SendTextToUI(FileInfoConst.textAfterIndexList[currentImgIndex]);
                currentImgIndex++;
                return;
            }
            if (FileInfoConst.endDragIndexList.Contains(currentImgIndex))
            {
                //isEndDragIndex = true;
            }
            else
            {
                ClearPositions();
                //isEndDragIndex = false;
            }
            if (FileInfoConst.longTimeImgIndexList.Contains(currentImgIndex))
            {
                timeoutClickCount = 60;
            }
            else
            {
                timeoutClickCount = 30;
            }
            if (loopIndex > 0 && FileInfoConst.ignoreWhenLoopImgIndexList.Contains(currentImgIndex))
            {
                currentImgIndex++;
            }
            CheckFinishALoop();
            CheckFinishARound();
            Point imgPos = new Point(0, 0);
            LaunchCommandLineApp(currentImgIndex);
            System.Threading.Thread.Sleep(500);
            imgPos = ReadImgPosFile(FileInfoConst.imgPosFile);
            if (imgPos.X < 0 || imgPos.Y < 0)
            {
                int jumpTupleIndex = GetTupleIndexWithCurrentIndex(FileInfoConst.jumpIndexList, currentImgIndex);
                if (jumpTupleIndex != -1)
                {
                    detectIgnoreImgCount++;
                    if (detectIgnoreImgCount >= FileInfoConst.jumpIndexList[jumpTupleIndex].Item3)
                    {
                        detectIgnoreImgCount = 0;
                        currentImgIndex = FileInfoConst.jumpIndexList[jumpTupleIndex].Item2;
                    }
                }
                if (FileInfoConst.repeatImgIndexList.Contains(currentImgIndex) && isRepeatImgClicked)
                {
                    currentImgIndex++;
                    isRepeatImgClicked = false;
                }
                repeatCycleIfNecessary();
                return;
            }
            if (GetTupleIndexWithCurrentIndex(FileInfoConst.jumpIndexList, currentImgIndex) != -1)
            {
                detectIgnoreImgCount = 0;
            }
            posList.Add(imgPos);
            if (FileInfoConst.repeatImgIndexList.Contains(currentImgIndex) == false)
            {
                currentImgIndex++;
                repeatCycleIndex = 0;
            }
            else
            {
                isRepeatImgClicked = true;
                repeatCycleIfNecessary();
            }
        }

        public void ResetARound()
        {
            currentImgIndex = 0;
            repeatCycleIndex = 0;
            isRepeatImgClicked = false;
            loopIndex = 0;
            detectIgnoreImgCount = 0;
            GetNextGmail(FileInfoConst.usernameDefault, FileInfoConst.passwordDefault);
        }

        public void repeatCycleIfNecessary()
        {
            if (repeatCycleIndex > timeoutClickCount)
            {
                if (FileInfoConst.longTimeImgIndexList.Contains(currentImgIndex))
                {
                    Point imgPos = new Point(0, 0);
                    LaunchCommandLineApp(FileInfoConst.cancelDownloadImg);
                    System.Threading.Thread.Sleep(500);
                    imgPos = ReadImgPosFile(FileInfoConst.imgPosFile);
                    posList.Add(imgPos);
                }
                ResetARound();
                //WriteResult(false);
            }
            repeatCycleIndex++;
        }

        public void CheckFinishALoop()
        {
            if (currentImgIndex == FileInfoConst.endLoopIndex)
            {
                currentImgIndex = FileInfoConst.startLoopIndex;
                isRepeatImgClicked = false;
                loopIndex++;
            }
            if (loopIndex >= FileInfoConst.loopCount)
            {
                ResetARound();
                return;
            }
        }

        public void CheckFinishARound()
        {
            if (currentImgIndex >= FileInfoConst.imgSubScreenList.Count)
            {
                ResetARound();
                //WriteResult(true);
            }
            while (!File.Exists(FileInfoConst.imgRecognizExeFile) ||
                   !File.Exists(FileInfoConst.imgScreenFile) ||
                   !File.Exists(FileInfoConst.imgSubScreenList[currentImgIndex]))
            {
                currentImgIndex++;
                if (currentImgIndex >= FileInfoConst.imgSubScreenList.Count)
                {
                    ResetARound();
                    //WriteResult(true);
                }
            }
        }

        public void LaunchCommandLineApp(int imgIndex)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = FileInfoConst.imgRecognizExeFile;
            proc.StartInfo.Arguments = " " + FileInfoConst.imgScreenFile +
                                       " " + FileInfoConst.imgSubScreenList[imgIndex] + 
                                       " " + FileInfoConst.imgPosFile;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            try
            {
                proc.Start();
                proc.WaitForExit();
            }
            catch
            {
                // Log error.
            }
        }

        public void LaunchCommandLineApp(string subScreenImg)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = FileInfoConst.imgRecognizExeFile;
            proc.StartInfo.Arguments = " " + FileInfoConst.imgScreenFile +
                                       " " + subScreenImg +
                                       " " + FileInfoConst.imgPosFile;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            try
            {
                proc.Start();
                proc.WaitForExit();
            }
            catch
            {
                // Log error.
            }
        }

        public int GetTupleIndexWithCurrentIndex(List<Tuple<int, int, int>> tupleList, int index)
        {
            for (int i = 0; i < tupleList.Count; i++)
            {
                if (tupleList[i].Item1 == index)
                {
                    return i;
                }
            }
            return -1;
        }

        public void SendTextToUI(string text)
        {
            try
            {
                Invoke((Action)(() => 
                {
                    string[] partsText = Regex.Split(text, " : ");
                    if (partsText.Length > 1)
                    {
                        Clipboard.SetText(partsText[1]);
                        System.Threading.Thread.Sleep(500);
                        SendKeys.SendWait("^{v}");
                        SendKeys.SendWait("~");
                    }
                    else
                    {
                        Clipboard.SetText(text);
                        System.Threading.Thread.Sleep(500);
                        SendKeys.SendWait("^{v}");
                        SendKeys.SendWait("~");
                    }
                }));
            }
            catch
            { }
        }

        public void GetNextGmail(string username, string password)
        {
            if (!File.Exists(FileInfoConst.mailListFile))
            {
                return;
            }
            try
            {
                string line;
                StreamReader sr = new StreamReader(FileInfoConst.mailListFile);
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains(username))
                    {
                        line = sr.ReadLine();
                        line = sr.ReadLine();
                        if (line.Trim() == "" || line == null) return;
                        string userNew = line;
                        int afterIndexUser = FileInfoConst.textAfterIndexList.FirstOrDefault(x => x.Value == username).Key;
                        FileInfoConst.textAfterIndexList[afterIndexUser] = userNew;
                        FileInfoConst.usernameDefault = userNew;
                        line = sr.ReadLine();
                        string passNew = line;
                        int afterIndexPass = FileInfoConst.textAfterIndexList.FirstOrDefault(x => x.Value == password).Key;
                        FileInfoConst.textAfterIndexList[afterIndexPass] = passNew;
                        FileInfoConst.passwordDefault = passNew;
                        FileInfoConst.WriteConfigFileForImg();
                        break;
                    }
                }
                sr.Close();
            }
            catch
            {
                
            }
        }

        public void ClearPositions()
        {
            posList.Clear();
        }

        private void DoLeftMouseDragOrClick()
        {
            if (posList.Count == 2)
            {
                MyMouseEventHandle.DoLeftMouseDrag(ref posList);
            }
            else
            {
                MyMouseEventHandle.DoLeftMouseSingleClickWithPostions(ref posList);
            }
        }

        public Point ReadImgPosFile(string file)
        {
            if (!File.Exists(file))
            {
                return new Point(-1, -1);
            }
            Point imgPos = new Point();
            string[] lines = System.IO.File.ReadAllLines(file);
            imgPos.X = Int32.Parse(lines[0]);
            imgPos.Y = Int32.Parse(lines[1]);
            return imgPos;
        }

        private void CaptureScreen(Screen window, string file)
        {
            try
            {
                Rectangle s_rect = window.Bounds;
                using (Bitmap bmp = new Bitmap(s_rect.Width, s_rect.Height))
                {
                    using (Graphics gScreen = Graphics.FromImage(bmp))
                        gScreen.CopyFromScreen(s_rect.Location, Point.Empty, s_rect.Size);
                    bmp.Save(file, System.Drawing.Imaging.ImageFormat.Png);
                    System.Threading.Thread.Sleep(500);
                }
            }
            catch (Exception) { /*TODO: Any exception handling.*/ }
        }

        private void RunAutoForImg()
        {
            CaptureScreen(Screen.PrimaryScreen, FileInfoConst.imgScreenFile);
            RecodeImgPosition();
            DoLeftMouseDragOrClick();
        }
        #endregion Methods
    }
}
