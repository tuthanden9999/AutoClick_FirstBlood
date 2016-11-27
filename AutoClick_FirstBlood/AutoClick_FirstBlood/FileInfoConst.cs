using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoClick_FirstBlood
{
    class FileInfoConst
    {
        public static List<int> repeatImgIndexList = new List<int>(new int[]{
            5
        });
#if DEBUG
        public static string imgRecognizExeFile = "..\\..\\testOpencv1.exe";
        public static string imgScreenFile = "..\\..\\img\\screen.png";
        public static string imgPosFile = "..\\..\\img\\imgPos.txt";
        public static List<string> imgSubScreenList = new List<string>(new string[]{
            "..\\..\\img\\1.png",
            "..\\..\\img\\2.png",
            "..\\..\\img\\3.png",
            "..\\..\\img\\4.png",
            "..\\..\\img\\5.png",
            "..\\..\\img\\6.png",
            "..\\..\\img\\7.png",
            "..\\..\\img\\8.png",
            "..\\..\\img\\9.png",
            "..\\..\\img\\10.png",
            "..\\..\\img\\11.png",
            "..\\..\\img\\12.png",
            "..\\..\\img\\13.png",
            "..\\..\\img\\14.png",
            "..\\..\\img\\15.png",
            "..\\..\\img\\16.png",
            "..\\..\\img\\17.png",
            "..\\..\\img\\18.png",
            "..\\..\\img\\19.png",
            "..\\..\\img\\20.png",
            "..\\..\\img\\21.png",
            "..\\..\\img\\22.png",
            "..\\..\\img\\23.png",
            "..\\..\\img\\24.png",
            "..\\..\\img\\25.png"
        });
#else
        public static string imgRecognizExeFile = "testOpencv1.exe";
        public static string imgScreenFile = "img\\screen.png";
        public static string imgPosFile = "img\\imgPos.txt";
        public static List<string> imgSubScreenList = new List<string>(new string[]{
            "img\\1.png",
            "img\\2.png",
            "img\\3.png",
            "img\\4.png",
            "img\\5.png",
            "img\\6.png",
            "img\\7.png",
            "img\\8.png",
            "img\\9.png",
            "img\\10.png",
            "img\\11.png",
            "img\\12.png",
            "img\\13.png",
            "img\\14.png",
            "img\\15.png",
            "img\\16.png",
            "img\\17.png",
            "img\\18.png",
            "img\\19.png",
            "img\\20.png",
            "img\\21.png",
            "img\\22.png",
            "img\\23.png",
            "img\\24.png",
            "img\\25.png"
        });
#endif
    }
}
