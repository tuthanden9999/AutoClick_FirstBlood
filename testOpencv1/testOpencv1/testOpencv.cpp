#include "opencv2/core/core.hpp"
#include "opencv2/imgproc/imgproc.hpp"
#include <opencv2/highgui/highgui.hpp>
#include <windows.h>
#include <iostream>
#include <string>
#include <sstream>
#include <vector>
#include <fstream>

using namespace std;
using namespace cv;

void split(const std::string &s, char delim, std::vector<std::string> &elems) {
    std::stringstream ss;
    ss.str(s);
    std::string item;
    while (std::getline(ss, item, delim)) {
        elems.push_back(item);
    }
}


std::vector<std::string> split(const std::string &s, char delim) {
    std::vector<std::string> elems;
    split(s, delim, elems);
    return elems;
}

void findImgInScreenCapture(int &centerX, int &centerY, const char *inputName, const char *templName){
	IplImage *ipl_img   = cvLoadImage(inputName, 1);
	IplImage *ipl_templ = cvLoadImage( templName, 1 );

	Mat img(ipl_img);
	Mat templ(ipl_templ);
	int result_cols =  img.cols - templ.cols + 1;
	int result_rows = img.rows - templ.rows + 1;

    Mat result( result_cols, result_rows, CV_32FC1 );

	matchTemplate(img, templ, result, CV_TM_CCOEFF_NORMED);
    //useless here: normalize(result, result, 0, 1, NORM_MINMAX, -1, Mat());

	double minVal = 0; double maxVal = 1; Point minLoc; Point maxLoc;
	minMaxLoc( result, &minVal, &maxVal, &minLoc, &maxLoc, Mat() );
	//printf("%.3f \n %.3f \n", minVal, maxVal);
	//int in;
	//scanf("%d", &in);
	if(maxVal >= 0.9)
	{
		centerX = maxLoc.x + templ.cols / 2;
		centerY = maxLoc.y + templ.rows / 2;
	}
	else
	{
		centerX = -1;
		centerY = -1;
	}

	//rectangle(result, maxLoc, Point( maxLoc.x + templ.cols , maxLoc.y + templ.rows ), Scalar(0, 255, 0), 2);
    //imshow("result", result);
	//rectangle(img, maxLoc, Point( maxLoc.x + templ.cols , maxLoc.y + templ.rows ), Scalar(0, 255, 0), 2);
    //imshow("screen", img);
    //waitKey(0);
}

int APIENTRY WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
	nCmdShow = 0;
	std::vector<std::string> args = split(lpCmdLine, ' ');
	if(args.size() < 3){
		return -1;
	}
	int x, y;
	findImgInScreenCapture(x, y, args.at(0).data(), args.at(1).data());

    std::ofstream out(args.at(2).data());
    out << x << "\n" << y;
    out.close();

	return 0;
}