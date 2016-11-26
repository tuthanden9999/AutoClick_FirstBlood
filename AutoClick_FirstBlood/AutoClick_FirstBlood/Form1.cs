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
        private int mins;
        private int seconds;
        private int miliseconds;
        private int totalClicks;
        private string mouseType;
        private string clickType;
        private int repeatTimes;
        private bool isPick;
        private bool isAutoByImg;
        private int currentImgIndex;
        private bool isRepeatImgClicked;
        private int repeatCycleIndex;
        private System.Timers.Timer aTimer;
        private Keys startKey = Keys.F4;
        private Keys recordKey = Keys.F3;
        private Keys imgKey = Keys.F6;
        private List<Point> posList;

        private string configFile;
        #endregion Properties

        #region Events
        private void Form1_Load(object sender, EventArgs e)
        { 
            RegisterHotKey(this.Handle, 0, 0, startKey.GetHashCode());
            RegisterHotKey(this.Handle, 1, 0, Keys.F2.GetHashCode());
            RegisterHotKey(this.Handle, 2, (int)KeyModifier.Control, Keys.Space.GetHashCode());
            RegisterHotKey(this.Handle, 3, 0, recordKey.GetHashCode());
            RegisterHotKey(this.Handle, 4, 0, imgKey.GetHashCode());

            isStopClick = true;
            mins = 0;
            seconds = 2;
            miliseconds = 0;
            totalClicks = 0;
            mouseType = "Left";
            clickType = "Single";
            repeatTimes = 0;
            isPick = false;
            isAutoByImg = false;
            currentImgIndex = 0;
            repeatCycleIndex = 0;
            isRepeatImgClicked = false;
            posList = new List<Point>();
            configFile = "config.txt";
            ReadConfigFile();
            SetConfigToUI();
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, 0);
            UnregisterHotKey(this.Handle, 1);
            UnregisterHotKey(this.Handle, 2);
            UnregisterHotKey(this.Handle, 3);
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

        private void repeat1Radio_Click(object sender, EventArgs e)
        {
            repeat2Radio.Checked = false;
            totalClicks = 0;
        }

        private void repeat2Radio_Click(object sender, EventArgs e)
        {
            repeat1Radio.Checked = false;
        }

        private void clearPosButton_Click(object sender, EventArgs e)
        {
            ClearPositions();
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
            if (!isAutoByImg)
            {
                if (repeat1Radio.Checked)
                {
                    try
                    {
                        if (timesCombobox.InvokeRequired)
                        {
                            timesCombobox.Invoke(new MethodInvoker(delegate { repeatTimes = Int32.Parse(timesCombobox.Text); }));
                        }
                    }
                    catch
                    {
                        repeatTimes = 1;
                    }

                    if (repeatTimes <= totalClicks)
                    {
                        aTimer.Enabled = false;
                        if (stopButton.InvokeRequired)
                        {
                            stopButton.Invoke(new MethodInvoker(delegate { stopButton.PerformClick(); }));
                        }
                        return;
                    }
                }
                DoMouseClick();
                totalClicks++;
            }
            else
            {
                RunAutoForImg();
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312) //WM_HOTKEY = 0x0312
            {
                int id = m.WParam.ToInt32();
                switch (id)
                {
                    case 0:
                        if (isStopClick)
                        {
                            StartAutoClick();
                        }
                        else
                        {
                            StopAutoClick();
                        }
                        break;
                    case 1:
                        MyMouseEventHandle.DoLeftMouseSingleClick();
                        break;
                    case 2:
                        MyMouseEventHandle.DoRightMouseSingleClick();
                        break;
                    case 3:
                        isAutoByImg = false;
                        RecordPositions();
                        break;
                    case 4:
                        isAutoByImg = true;
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
            if (!isAutoByImg)
            {
                if (!CheckUserTyping())
                {
                    return;
                }
                startButton.Enabled = false;
                stopButton.Enabled = true;

                isStopClick = false;
                WriteConfigFile();

                totalClicks = 0;
                mins = Int32.Parse(minTextbox.Text);
                seconds = Int32.Parse(secondTextbox.Text);
                miliseconds = Int32.Parse(milisecondTextbox.Text);
                double totalMiliseconds = miliseconds + seconds * 1000 + mins * 60 * 1000;
                aTimer.Interval = totalMiliseconds;
                aTimer.Enabled = true;
            }
            else
            {
                startButton.Enabled = false;
                stopButton.Enabled = true;

                isStopClick = false;
                aTimer.Interval = 5000;
                aTimer.Enabled = true;
            }
        }

        private bool CheckUserTyping()
        {
            int tmp_mins, tmp_seconds, tmp_miliseconds;
            bool isNumeric1, isNumeric2, isNumeric3;
            isNumeric1 = int.TryParse(minTextbox.Text, out tmp_mins);
            isNumeric2 = int.TryParse(secondTextbox.Text, out tmp_seconds);
            isNumeric3 = int.TryParse(milisecondTextbox.Text, out tmp_miliseconds);

            if (isNumeric1 && isNumeric2 && isNumeric3
                && tmp_mins >= 0 && tmp_mins < 60
                && tmp_seconds >= 0 && tmp_seconds < 60
                && tmp_miliseconds >= 0 && tmp_miliseconds < 1000)
            {
                if (mins == 0 && seconds == 0 && miliseconds < 100)
                {
                    milisecondTextbox.Text = "100";
                }
            }
            else
            {
                MessageBox.Show("Please re-type click interval!");
                return false;
            }

            if (repeat1Radio.Checked)
            {
                int tmp_times;
                bool isNumeric4;
                isNumeric4 = int.TryParse(timesCombobox.Text, out tmp_times);
                if (!(isNumeric4 && tmp_times > 0 && tmp_times <= 1000000))
                {
                    MessageBox.Show("Please re-type click times!");
                    return false;
                }
            }
            return true;
        }

        public void RecordPositions()
        {
            Point curPos = new Point();
            curPos.X = Cursor.Position.X;
            curPos.Y = Cursor.Position.Y;
            posListTextbox.Text = posListTextbox.Text + curPos.X + " ; " + curPos.Y + "\r\n";
            posList.Add(curPos);
        }

        public void RecodeImgPosition()
        {
            if (currentImgIndex >= FileInfoConst.imgSubScreenList.Count)
            {
                currentImgIndex = 0;
            }
            while (!File.Exists(FileInfoConst.imgRecognizExeFile) ||
                   !File.Exists(FileInfoConst.imgScreenFile) ||
                   !File.Exists(FileInfoConst.imgSubScreenList[currentImgIndex]))
            {
                currentImgIndex++;
                if (currentImgIndex >= FileInfoConst.imgSubScreenList.Count)
                {
                    currentImgIndex = 0;
                }
            }
            Point imgPos = new Point(0, 0);
            LaunchCommandLineApp(currentImgIndex);
            System.Threading.Thread.Sleep(500);
            imgPos = ReadImgPosFile(FileInfoConst.imgPosFile);
            if (imgPos.X < 0 || imgPos.Y < 0)
            {
                if (FileInfoConst.repeatImgIndexList.Contains(currentImgIndex) && isRepeatImgClicked)
                {
                    currentImgIndex++;
                    isRepeatImgClicked = false;
                }
                repeatCycleIfNecessary();
                return;
            }
            if (posListTextbox.InvokeRequired)
            {
                posListTextbox.Invoke(new MethodInvoker(delegate { 
                    posListTextbox.Text = posListTextbox.Text + imgPos.X + " ; " + imgPos.Y + "\r\n"; 
                }));
            }
            posList.Add(imgPos);
            if (FileInfoConst.repeatImgIndexList.Contains(currentImgIndex) == false)
            {
                currentImgIndex++;
            }
            else
            {
                isRepeatImgClicked = true;
                repeatCycleIfNecessary();
            }
        }

        public void repeatCycleIfNecessary()
        {
            if (repeatCycleIndex > 30)
            {
                repeatCycleIndex = 0;
                currentImgIndex = FileInfoConst.imgSubScreenList.Count - 1;
            }
            repeatCycleIndex++;
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

        public void ClearPositions()
        {
            posList.Clear();
            if (posListTextbox.InvokeRequired)
            {
                posListTextbox.Invoke(new MethodInvoker(delegate { posListTextbox.Text = ""; }));
            }
            posListTextbox.Text = "";
        }

        private void DoMouseClick()
        {
            if (pickPosCheckbox.Checked)
            {
                MyMouseEventHandle.DoLeftMouseSingleClickWithPostions(ref posList);
                return;
            }
            int mouseTypeIndex = 0, clickTypeIndex = 0;
            if (mouseCombobox.InvokeRequired)
            {
                mouseCombobox.Invoke(new MethodInvoker(delegate { mouseTypeIndex = mouseCombobox.SelectedIndex; }));
            }

            if (clickTypeCombobox.InvokeRequired)
            {
                clickTypeCombobox.Invoke(new MethodInvoker(delegate { clickTypeIndex = clickTypeCombobox.SelectedIndex; }));
            }

            if (mouseTypeIndex == 0)
            {
                if (clickTypeIndex == 0)
                {
                    MyMouseEventHandle.DoLeftMouseSingleClick();
                }
                else
                {
                    MyMouseEventHandle.DoLeftMouseDoubleClick();
                }
            }
            else
            {
                if (clickTypeIndex == 0)
                {
                    MyMouseEventHandle.DoRightMouseSingleClick();
                }
                else
                {
                    MyMouseEventHandle.DoRightMouseDoubleClick();
                }
            }
        }

        public void ReadConfigFile()
        {
            if ( ! File.Exists(configFile))
            {
                return;
            }
            try
            {
                string line;
                StreamReader sr = new StreamReader(configFile);
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("Click interval ="))
                    {
                        string[] tmpArr = Regex.Split(line, "Click interval =");
                        string interval = tmpArr[1];
                        if (interval.Contains(":"))
                        {
                            string[] tmpArr2 = Regex.Split(interval, ":");
                            mins = Int32.Parse(tmpArr2[0]);
                            seconds = Int32.Parse(tmpArr2[1]);
                            miliseconds = Int32.Parse(tmpArr2[2]);
                        }
                        continue;
                    }

                    if (line.Contains("Mouse type ="))
                    {
                        string[] tmpArr = Regex.Split(line, "Mouse type =");
                        mouseType = tmpArr[1].Trim();
                        continue;
                    }

                    if (line.Contains("Click type ="))
                    {
                        string[] tmpArr = Regex.Split(line, "Click type =");
                        clickType = tmpArr[1].Trim();
                        continue;
                    }

                    if (line.Contains("Repeat ="))
                    {
                        string[] tmpArr = Regex.Split(line, "Repeat =");
                        repeatTimes = Int32.Parse(tmpArr[1]);
                        continue;
                    }

                    if (line.Contains("Pick position ="))
                    {
                        string[] tmpArr = Regex.Split(line, "Pick position =");
                        isPick = (Int32.Parse(tmpArr[1]) == 1) ? true : false;
                        continue;
                    }

                    if (line.Contains(";"))
                    {
                        string[] tmpArr = Regex.Split(line, ";");
                        posList.Add(new Point(Int32.Parse(tmpArr[0]), Int32.Parse(tmpArr[1])));
                        continue;
                    }
                }
                sr.Close();
            }
            catch
            {
            }
        }

        public void WriteConfigFile()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(configFile, false))
                {
                    sw.WriteLine("Click interval = " + minTextbox.Text.Trim() + ":" + secondTextbox.Text.Trim() + ":" + milisecondTextbox.Text.Trim());
                    sw.WriteLine("Mouse type = " + mouseCombobox.Text);
                    sw.WriteLine("Click type = " + clickTypeCombobox.Text);
                    sw.WriteLine("Repeat = " + (repeat2Radio.Checked ? "0" : timesCombobox.Text.Trim()));
                    sw.WriteLine("Pick position = " + (pickPosCheckbox.Checked ? "1" : "0"));
                    if (pickPosCheckbox.Checked)
                    {
                        sw.Write(posListTextbox.Text.Trim());
                    }
                    sw.Close();
                }
            }
            catch { }
        }

        public void SetConfigToUI()
        {
            minTextbox.Text = mins + "";
            secondTextbox.Text = seconds + "";
            milisecondTextbox.Text = miliseconds + "";
            mouseCombobox.SelectedIndex = (mouseType.Trim().ToLower().CompareTo("left") == 0) ? 0 : 1;
            clickTypeCombobox.SelectedIndex = (clickType.Trim().ToLower().CompareTo("single") == 0) ? 0 : 1;
            if (repeatTimes == 0)
            {
                repeat2Radio.Checked = true;
                timesCombobox.SelectedIndex = 0;
            }
            else if (repeatTimes > 0)
            {
                repeat1Radio.Checked = true;
                timesCombobox.Text = repeatTimes + "";
            }
            if ( ! isPick)
            {
                pickPosCheckbox.Checked = false;
            }
            else
            {
                pickPosCheckbox.Checked = true;
                foreach (Point pos in posList)
                {
                    posListTextbox.Text += pos.X + ";" + pos.Y + "\r\n";
                }
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
            pickPosCheckbox.Checked = true;
            isPick = true;
            CaptureScreen(Screen.PrimaryScreen, FileInfoConst.imgScreenFile);
            ClearPositions();
            RecodeImgPosition();
            MyMouseEventHandle.DoLeftMouseSingleClickWithPostions(ref posList);
        }
        #endregion Methods
    }
}
