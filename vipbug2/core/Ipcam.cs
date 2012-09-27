using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

using System.Net;


namespace CamRecord2
{
    class Ipcam
    {
        int Width;
        int Height;
        String login;
        String password;

        public Ipcam(int Width, int Height, String login, String password)
        {
            this.Width = Width;
            this.Height = Height;
            this.login = login;
            this.password = password;
        }

        public Ipcam(double Width, double Height, String login, String password)
        {
            this.Width = (int)Width;
            this.Height = (int)Height;
            this.login = login;
            this.password = password;
        }


         public void Ipcam_left()
        {
            //create HTTP request      
            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create(" http://140.122.184.227/nphControlCamera?Direction=PanLeft");
            WebRequest req = HttpWebRequest.Create("http://140.122.184.227/cgi-bin/camctrl?pan=-1&tilt=0");
            //set password
            req.Credentials = new NetworkCredential(login, password);
            //get response
            //WebResponse resp = req.GetResponse();
            req.GetResponse();
            req.Abort();
        }
        public void Ipcam_right()
        {
            //create HTTP request      
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(" http://140.122.184.227/cgi-bin/camctrl?pan=1&tilt=0");
            //set password
            req.Credentials = new NetworkCredential(login, password);
            //get response
            WebResponse resp = req.GetResponse();
            req.Abort();
        }
        public void Ipcam_up()
        {
            //create HTTP request      
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(" http://140.122.184.227/cgi-bin/camctrl?pan=0&tilt=-1");
            //set password
            req.Credentials = new NetworkCredential(login, password);
            //get response
            WebResponse resp = req.GetResponse();
            req.Abort();
        }
        public void Ipcam_down()
        {
            //create HTTP request      
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(" http://140.122.184.227/cgi-bin/camctrl?pan=0&tilt=1");
            //set password
            req.Credentials = new NetworkCredential(login, password);
            //get response
            WebResponse resp = req.GetResponse();
            req.Abort();
        }
        public void windows_click(int Width, int Height, int MousePositionX, int LocationX, int ImgLocationX, int MousePositionY, int LocationY, int ImgLocationY)
        {
            int x = ((MousePositionX - ImgLocationX) * 2);
            int y = ((MousePositionY - ImgLocationY) * 2);
            //create HTTP request      
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://140.122.184.227/cgi-bin/camctrl?resolution=" + Width + "x" + Height + "&center_x=" +x + "&center_y=" + y);
            //set password
            req.Credentials = new NetworkCredential(login, password);
            //get response
            WebResponse resp = req.GetResponse();
            req.Abort();
        }
        public void brightness_up()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://140.122.184.227/nphControlCamera?Direction=Brighter");
            req.Credentials = new NetworkCredential(login, password);
            HttpWebResponse response_image = (HttpWebResponse)req.GetResponse();
            req.Abort();
        }
        public void brightness_down()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://140.122.184.227/nphControlCamera?Direction=Darker");
            req.Credentials = new NetworkCredential(login, password);
            HttpWebResponse response_image = (HttpWebResponse)req.GetResponse();
            req.Abort();
        }
        public void zoom_in()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://140.122.184.227/nphControlCamera?Direction=ZoomTele");
            req.Credentials = new NetworkCredential(login, password);
            HttpWebResponse response_image = (HttpWebResponse)req.GetResponse();
            req.Abort();
        }
        public void zoom_out()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://140.122.184.227/nphControlCamera?Direction=ZoomWide");
            req.Credentials = new NetworkCredential(login, password);
            HttpWebResponse response_image = (HttpWebResponse)req.GetResponse();
            req.Abort();
        }

    }
}


/*

PAN RIGHT

GET /cgi-bin/camctrl?pan=1&tilt=0 HTTP/1.1\nHost: 172.27.1.180\nConnection:
keep-alive\nAuthorization: Basic YWRtaW46MTIzNDU=\r\n



PAN LEFT

GET /cgi-bin/camctrl?pan=-1&tilt=0 HTTP/1.1\nHost:
172.27.1.180\nConnection: keep-alive\nAuthorization: Basic
YWRtaW46MTIzNDU=\r\n



TILT UP

GET /cgi-bin/camctrl?pan=0&tilt=-1 HTTP/1.1\nHost:
172.27.1.180\nConnection: keep-alive\nAuthorization: Basic
YWRtaW46MTIzNDU=\r\n



TILT DOWN

GET /cgi-bin/camctrl?pan=0&tilt=1 HTTP/1.1\nHost: 172.27.1.180\nConnection:
keep-alive\nAuthorization: Basic YWRtaW46MTIzNDU=\r\n



ZOOM IN

GET /cgi-bin/directctrl?zoom=1 HTTP/1.1\nHost: 172.27.1.180\nConnection:
keep-alive\nAuthorization: Basic YWRtaW46MTIzNDU=\r\n



ZOOM OUT

GET /cgi-bin/directctrl?zoom=-1 HTTP/1.1\nHost: 172.27.1.180\nConnection:
keep-alive\nAuthorization: Basic YWRtaW46MTIzNDU=\r\n



PRESET 1

GET /cgi-bin/camctrl?preset=1 HTTP/1.1\nHost: 172.27.1.180\nConnection:
keep-alive\nAuthorization: Basic YWRtaW46MTIzNDU=\r\n



PRESET 2

GET /cgi-bin/camctrl?preset=2 HTTP/1.1\nHost: 172.27.1.180\nConnection:
keep-alive\nAuthorization: Basic YWRtaW46MTIzNDU=\r\n



PRESET 3

GET /cgi-bin/camctrl?preset=3 HTTP/1.1\nHost: 172.27.1.180\nConnection:
keep-alive\nAuthorization: Basic YWRtaW46MTIzNDU=\r\n



PRESET 4

GET /cgi-bin/camctrl?preset=4 HTTP/1.1\nHost: 172.27.1.180\nConnection:
keep-alive\nAuthorization: Basic YWRtaW46MTIzNDU=\r\n



*/