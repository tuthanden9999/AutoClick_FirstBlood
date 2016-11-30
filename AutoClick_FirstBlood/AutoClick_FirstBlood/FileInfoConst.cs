using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoClick_FirstBlood
{
    class FileInfoConst
    {
        public static int imgSubScreenCount = 150;
        public static List<string> imgSubScreenList = new List<string>();
        public static List<int> repeatImgIndexList = new List<int>(new int[]{
            5
        });
#if DEBUG
        public static string imgRecognizExeFile = "..\\..\\testOpencv1.exe";
        public static string imgScreenFile = "..\\..\\img\\screen.png";
        public static string imgPosFile = "..\\..\\img\\imgPos.txt";
        public static void initImgSubScreenList()
        {
            imgSubScreenList.Clear();
            for (int i = 0; i < imgSubScreenCount; i++)
            {
                imgSubScreenList.Add("..\\..\\img\\" + i + ".png");
            }
        }
        
#else
        public static string imgRecognizExeFile = "testOpencv1.exe";
        public static string imgScreenFile = "img\\screen.png";
        public static string imgPosFile = "img\\imgPos.txt";
        public static void initImgSubScreenList()
        {
            imgSubScreenList.Clear();
            for (int i = 0; i < imgSubScreenCount; i++)
            {
                imgSubScreenList.Add("img\\" + i + ".png");
            }
        }
#endif
    }
}
