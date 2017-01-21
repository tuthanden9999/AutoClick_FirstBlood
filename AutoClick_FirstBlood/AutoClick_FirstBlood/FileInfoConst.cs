using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace AutoClick_FirstBlood
{
    class FileInfoConst
    {
        public static List<string> imgSubScreenList = new List<string>();
        public static int clickInterval = 5000;
        public static int clickIntervalForRepeat = 15000;
        public static int timeoutClickCount = 30;
        public static int timeoutClickCountLong = 60;
        public static int timeoutDragCount = 50;
        public static int imgSubScreenCount;
        public static int startLoopIndex;
        public static int endLoopIndex;
        public static int loopCount;
        public static List<Tuple<int, int, int>> jumpIndexList = new List<Tuple<int,int,int>>();
        ////for no income: public static int noIncomeTurnCount = 10;
        public static List<int> longTimeImgIndexList = new List<int>();
        public static List<int> repeatImgIndexList = new List<int>();
        public static List<int> ignoreWhenLoopImgIndexList = new List<int>();
        public static Dictionary<int, string> textAfterIndexList = new Dictionary<int, string>();
        public static List<int> mouseDownIndexList = new List<int>();
        public static string usernameDefault = "";
        public static string passwordDefault = "";

        enum IndexList
        {
            NONE = 0,
            JUMP_INDEX_LIST,
            LONG_TIME_IMG_INDEX_LIST,
            REPEAT_IMG_INDEX_LIST,
            IGNORE_WHEN_LOOP_IMG_INDEX_LIST,
            TEXT_AFTER_INDEX_LIST,
            MOUSE_DOWN_INDEX_LIST
        }

        public static void LoadDefault()
        {
            imgSubScreenCount = 150;
            startLoopIndex = 4;
            endLoopIndex = 19;
            loopCount = 3;
            jumpIndexList.Add(Tuple.Create(9, 10, 5));
            jumpIndexList.Add(Tuple.Create(10, 16, 5));
            jumpIndexList.Add(Tuple.Create(11, 12, 1));
            jumpIndexList.Add(Tuple.Create(12, 13, 1));
            ////for no income: noIncomeTurnCount = 10;
            longTimeImgIndexList.Add(7);//watch video
            longTimeImgIndexList.Add(14);//download
            repeatImgIndexList.Add(5);
            repeatImgIndexList.Add(6);
            ignoreWhenLoopImgIndexList.Add(5);
        }

        public static void ReadConfigFileForImg()
        {
            if (!File.Exists(configFileImg))
            {
                LoadDefault();
                return;
            }
            try
            {
                IndexList indexListId = IndexList.NONE;
                string line;
                StreamReader sr = new StreamReader(configFileImg);
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Trim() == "") continue;
                    if (line.Contains("clickInterval ="))
                    {
                        string[] tmpArr = Regex.Split(line, "clickInterval =");
                        clickInterval = Int32.Parse(tmpArr[1]);
                        continue;
                    }

                    if (line.Contains("clickIntervalForRepeat ="))
                    {
                        string[] tmpArr = Regex.Split(line, "clickIntervalForRepeat =");
                        clickIntervalForRepeat = Int32.Parse(tmpArr[1]);
                        continue;
                    }

                    if (line.Contains("timeoutClickCount ="))
                    {
                        string[] tmpArr = Regex.Split(line, "timeoutClickCount =");
                        timeoutClickCount = Int32.Parse(tmpArr[1]);
                        continue;
                    }

                    if (line.Contains("timeoutClickCountLong ="))
                    {
                        string[] tmpArr = Regex.Split(line, "timeoutClickCountLong =");
                        timeoutClickCountLong = Int32.Parse(tmpArr[1]);
                        continue;
                    }

                    if (line.Contains("timeoutDragCount ="))
                    {
                        string[] tmpArr = Regex.Split(line, "timeoutDragCount =");
                        timeoutDragCount = Int32.Parse(tmpArr[1]);
                        continue;
                    }

                    if (line.Contains("imgSubScreenCount ="))
                    {
                        string[] tmpArr = Regex.Split(line, "imgSubScreenCount =");
                        imgSubScreenCount = Int32.Parse(tmpArr[1]);
                        continue;
                    }

                    if (line.Contains("startLoopIndex ="))
                    {
                        string[] tmpArr = Regex.Split(line, "startLoopIndex =");
                        startLoopIndex = Int32.Parse(tmpArr[1]);
                        continue;
                    }

                    if (line.Contains("endLoopIndex ="))
                    {
                        string[] tmpArr = Regex.Split(line, "endLoopIndex =");
                        endLoopIndex = Int32.Parse(tmpArr[1]);
                        continue;
                    }

                    if (line.Contains("loopCount ="))
                    {
                        string[] tmpArr = Regex.Split(line, "loopCount =");
                        loopCount = Int32.Parse(tmpArr[1]);
                        continue;
                    }

                    if (line.Contains("jumpIndexList ="))
                    {
                        indexListId = IndexList.JUMP_INDEX_LIST;
                        continue;
                    }

                    if (line.Contains("longTimeImgIndexList ="))
                    {
                        indexListId = IndexList.LONG_TIME_IMG_INDEX_LIST;
                        continue;
                    }

                    if (line.Contains("repeatImgIndexList ="))
                    {
                        indexListId = IndexList.REPEAT_IMG_INDEX_LIST;
                        continue;
                    }

                    if (line.Contains("ignoreWhenLoopImgIndexList ="))
                    {
                        indexListId = IndexList.IGNORE_WHEN_LOOP_IMG_INDEX_LIST;
                        continue;
                    }

                    if (line.Contains("textAfterIndexList ="))
                    {
                        indexListId = IndexList.TEXT_AFTER_INDEX_LIST;
                        continue;
                    }

                    if (line.Contains("mouseDownIndexList ="))
                    {
                        indexListId = IndexList.MOUSE_DOWN_INDEX_LIST;
                        continue;
                    }

                    switch (indexListId)
                    {
                        case IndexList.JUMP_INDEX_LIST:
                            string[] tmpArr = Regex.Split(line, ",");
                            int jumpFrom = Int32.Parse(tmpArr[0]);
                            int jumpTo = Int32.Parse(tmpArr[1]);
                            int detectCountBeforeJump = Int32.Parse(tmpArr[2]);
                            jumpIndexList.Add(Tuple.Create(jumpFrom, jumpTo, detectCountBeforeJump));
                            break;
                        case IndexList.LONG_TIME_IMG_INDEX_LIST:
                            longTimeImgIndexList.Add(Int32.Parse(line));
                            break;
                        case IndexList.REPEAT_IMG_INDEX_LIST:
                            repeatImgIndexList.Add(Int32.Parse(line));
                            break;
                        case IndexList.IGNORE_WHEN_LOOP_IMG_INDEX_LIST:
                            ignoreWhenLoopImgIndexList.Add(Int32.Parse(line));
                            break;
                        case IndexList.TEXT_AFTER_INDEX_LIST:
                            string[] tmpArr2 = Regex.Split(line, ",");
                            int afterIndex = Int32.Parse(tmpArr2[0]);
                            string textAfterIndex = tmpArr2[1].Trim();
                            if (textAfterIndex.Contains("username : ")) usernameDefault = textAfterIndex;
                            if (textAfterIndex.Contains("password : ")) passwordDefault = textAfterIndex;
                            textAfterIndexList.Add(afterIndex, textAfterIndex);
                            break;
                        case IndexList.MOUSE_DOWN_INDEX_LIST:
                            mouseDownIndexList.Add(Int32.Parse(line));
                            break;
                        default:
                            break;
                    }
                }
                sr.Close();
            }
            catch
            {
                LoadDefault();
            }
        }

        public static void WriteConfigFileForImg()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FileInfoConst.configFileImg, false))
                {
                    sw.WriteLine("clickInterval = " + clickInterval);
                    sw.WriteLine("clickIntervalForRepeat = " + clickIntervalForRepeat);
                    sw.WriteLine("timeoutClickCount = " + timeoutClickCount);
                    sw.WriteLine("timeoutClickCountLong = " + timeoutClickCountLong);
                    sw.WriteLine("timeoutDragCount = " + timeoutDragCount);
                    sw.WriteLine("imgSubScreenCount = " + imgSubScreenCount);
                    sw.WriteLine("startLoopIndex = " + startLoopIndex);
                    sw.WriteLine("endLoopIndex = " + endLoopIndex);
                    sw.WriteLine("loopCount = " + loopCount);
                    sw.WriteLine("jumpIndexList = ");
                    for (int i = 0; i < jumpIndexList.Count; i++)
                    {
                        sw.WriteLine(jumpIndexList[i].Item1 + ", " + jumpIndexList[i].Item2 + ", " + jumpIndexList[i].Item3);
                    }
                    sw.WriteLine("longTimeImgIndexList = ");
                    for (int i = 0; i < longTimeImgIndexList.Count; i++)
                    {
                        sw.WriteLine(longTimeImgIndexList[i]);
                    }
                    sw.WriteLine("repeatImgIndexList = ");
                    for (int i = 0; i < repeatImgIndexList.Count; i++)
                    {
                        sw.WriteLine(repeatImgIndexList[i]);
                    }
                    sw.WriteLine("ignoreWhenLoopImgIndexList = ");
                    for (int i = 0; i < ignoreWhenLoopImgIndexList.Count; i++)
                    {
                        sw.WriteLine(ignoreWhenLoopImgIndexList[i]);
                    }
                    sw.WriteLine("textAfterIndexList = ");
                    for (int i = 0; i < textAfterIndexList.Count; i++)
                    {
                        sw.WriteLine(textAfterIndexList.Keys.ElementAt(i) + ", " + textAfterIndexList.Values.ElementAt(i) );
                    }
                    sw.WriteLine("endDragIndexList = ");
                    for (int i = 0; i < mouseDownIndexList.Count; i++)
                    {
                        sw.WriteLine(mouseDownIndexList[i]);
                    }
                    sw.Close();
                }
            }
            catch { }
        }

#if DEBUG
        public static string mailListFile = "..\\..\\mailList.txt";
        public static string configFileImg = "..\\..\\config_img.txt";
        public static string imgRecognizExeFile = "..\\..\\testOpencv1.exe";
        public static string imgScreenFile = "..\\..\\img\\screen.png";
        public static string cancelDownloadImg = "..\\..\\img\\cancel.png";
        public static string imgPosFile = "..\\..\\img\\imgPos.txt";
        public static void initImgSubScreenList()
        {
            imgSubScreenList.Clear();
            for (int i = 1; i <= imgSubScreenCount; i++)
            {
                imgSubScreenList.Add("..\\..\\img\\" + i + ".png");
            }
        }
        
#else
        public static string mailListFile = "mailList.txt";
        public static string configFileImg = "config_img.txt";
        public static string imgRecognizExeFile = "testOpencv1.exe";
        public static string imgScreenFile = "img\\screen.png";
        public static string cancelDownloadImg = "img\\cancel.png";
        public static string imgPosFile = "img\\imgPos.txt";
        public static void initImgSubScreenList()
        {
            imgSubScreenList.Clear();
            for (int i = 1; i <= imgSubScreenCount; i++)
            {
                imgSubScreenList.Add("img\\" + i + ".png");
            }
        }
#endif
    }
}
