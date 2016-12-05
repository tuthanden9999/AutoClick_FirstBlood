using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoClick_FirstBlood
{
    class FileInfoConst
    {
        public static int imgSubScreenCount = 150;
        public static int downloadImgIndex = 10;
        public static List<string> imgSubScreenList = new List<string>();
        public static List<int> repeatImgIndexList = new List<int>(new int[] {
            5
        });
        //public static List<int> canIgnoreImgIndexList = new List<int>(new int[] {
        //    6,
        //    7,
        //    8,
        //    9
        //});
#if DEBUG
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
