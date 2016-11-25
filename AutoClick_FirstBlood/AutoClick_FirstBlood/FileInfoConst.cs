using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoClick_FirstBlood
{
    class FileInfoConst
    {
#if DEBUG
        public static string imgRecognizExeFile = "..\\..\\testOpencv1.exe";
        public static string imgScreenFile = "..\\..\\img\\screen.png";
        public static string imgPosFile = "..\\..\\img\\imgPosition.txt";
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
            "..\\..\\img\\13.png"
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
            "img\\13.png"
        });
#endif
    }
}
