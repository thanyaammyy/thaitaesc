using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thaitae.Backend
{
    public partial class UploadFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public string uploadFile(string fileName, string folderName)
        {
            if (fileName == "")
            {
                return "Invalid filename supplied";
            }
            if (fileUpload.PostedFile.ContentLength == 0)
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
                if (fileUpload.PostedFile.ContentLength <= 2048000)
                {
                    fileUpload.PostedFile.SaveAs(Server.MapPath(folderName) + "\\" + fileName);
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
            string strFilename, strMessage;
            strFilename = fileUpload.PostedFile.FileName.ToString();
            strMessage = uploadFile(strFilename, ConfigurationManager.AppSettings["newsFolderPath"]);
            lblMessage.Text = strMessage;
            lblMessage.ForeColor = Color.Red;
        }
    }
}