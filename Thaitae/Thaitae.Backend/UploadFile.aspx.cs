using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using thaitae.lib;
using Image = System.Drawing.Image;

namespace Thaitae.Backend
{
    public partial class UploadFile : System.Web.UI.Page
    {
        private string _fileIdName = "";
        private string _savePath = "";
        private string _fileType = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["newsid"]))
            {
                _fileIdName = Request.QueryString["newsid"];
                _savePath = ConfigurationManager.AppSettings["BackendUrl"] + ConfigurationManager.AppSettings["newsFolderPath"];
                _fileType = "news";
            }

            if (!string.IsNullOrEmpty(Request.QueryString["leagueid"]))
            {
                _fileIdName = Request.QueryString["leagueid"];
                _savePath = ConfigurationManager.AppSettings["BackendUrl"] + ConfigurationManager.AppSettings["leagueFolderPath"];
                _fileType = "league";
            }
        }

        public string uploadFile(string fileName, string folderName)
        {
            if (fileName == "")
            {
                return "Invalid filename supplied";
            }
            if (FileUpload1.PostedFile.ContentLength == 0)
            {
                return "Invalid file content";
            }
            fileName = System.IO.Path.GetFileName(fileName);
            if (folderName == "")
            {
                return "Path not found";
            }
            try
            {
                if (FileUpload1.PostedFile.ContentLength <= 8192000)
                {
                    var tempPath = Server.MapPath(folderName) + "\\Temp\\" + _fileIdName + "_" + fileName;
                    var serverPath = Server.MapPath(folderName) + "\\" + _fileIdName + ".jpg";
                    var thumbPath = Server.MapPath(folderName) + "\\Thumbs\\" + _fileIdName + "_thumb.jpg";
                    FileUpload1.PostedFile.SaveAs(tempPath);
                    using (var fs = new FileStream(tempPath, FileMode.Open))
                    {
                        var myimg = System.Drawing.Image.FromStream(fs);
                        if (_fileType.Equals("news"))
                        {
                            var resizedImg = Resize(myimg, 520, 390);
                            resizedImg.Save(serverPath, myimg.RawFormat);
                            var thumbImg = myimg.GetThumbnailImage(100, 74, null, IntPtr.Zero);
                            thumbImg.Save(thumbPath, myimg.RawFormat);
                            using (var dc = ThaitaeDataDataContext.Create())
                            {
                                var newsObject = dc.News.Single(item => item.newsId == Convert.ToInt32(_fileIdName));
                                newsObject.picture = ConfigurationManager.AppSettings["ServerNewsPath"] + _fileIdName + ".jpg";
                                dc.SubmitChanges();
                            }
                        }
                        else
                        {
                            myimg = myimg.GetThumbnailImage(70, 65, null, IntPtr.Zero);
                            myimg.Save(serverPath, myimg.RawFormat);
                            using (var dc = ThaitaeDataDataContext.Create())
                            {
                                var leagueObject = dc.Leagues.Single(item => item.LeagueId == Convert.ToInt32(_fileIdName));
                                leagueObject.Picture = ConfigurationManager.AppSettings["ServerLeaguePath"] + _fileIdName + ".jpg";
                                dc.SubmitChanges();
                            }
                        }
                    }
                    File.Delete(tempPath);
                    return "File uploaded successfully";
                }
                else
                {
                    return "Unable to upload,file exceeds maximum limit";
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                return ex.Message + "Permission to upload file denied";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var strFilename = FileUpload1.PostedFile.FileName.ToString(CultureInfo.InvariantCulture);
            var strMessage = uploadFile(strFilename, _savePath);
            lblMessage.Text = strMessage;
            lblMessage.ForeColor = Color.Red;
        }

        public Image Resize(Image img, int width, int height)
        {
            Image cropedImage = new Bitmap(width, height);
            using (Graphics G = Graphics.FromImage(cropedImage))
            {
                G.SmoothingMode = SmoothingMode.HighQuality;
                G.InterpolationMode = InterpolationMode.HighQualityBicubic;
                G.PixelOffsetMode = PixelOffsetMode.HighQuality;
                G.DrawImage(img, 0, 0, width, height);
            }

            return cropedImage;
        }
    }
}