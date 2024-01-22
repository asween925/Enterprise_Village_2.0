// by Chtiwi Malek on CODICODE.COM
using System;
using System.Web;
using System.IO;
using System.Web.Script.Services;
using System.Web.Services;

[ScriptService]
public partial class Save_Picture : System.Web.UI.Page
{
    static string path = @"H:\EV Pictures";
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    [WebMethod()]
    public static void UploadPic(string imageData)
    {
        string fileNameWitPath = path + DateTime.Now.ToString().Replace("/", "-").Replace(" ", "- ").Replace(":", "") + ".png";
        using (FileStream fs = new FileStream(fileNameWitPath, FileMode.Create))
        {
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                byte[] data = Convert.FromBase64String(imageData);
                bw.Write(data);
                bw.Close();
            }
        }
    }
}