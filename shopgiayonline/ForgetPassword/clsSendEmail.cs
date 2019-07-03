using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace shopgiayonline.ForgetPassword
{
    public class clsSendEmail
    {
        public clsSendEmail()
        {
        }

        SmtpClient smtpClient = new SmtpClient();

        //xác định smtpserver để gửi mail, với gmail là smtp.gmail.com
        string smtpServer = "smtp.gmail.com";
        public string SmtpServer
        {
            get { return smtpServer; }
            set { smtpServer = value; }
        }

        //Gửi từ mail nào, là một địa chỉ mail từ GMAIL 
        string smtpMailFrom = "dkniken0601@gmail.com";
        public string SmtpMailFrom
        {
            get { return smtpMailFrom; }
            set { smtpMailFrom = value; }
        }

        //user đăng nhập vào gmail
        string smtpUser = "dkniken0601@gmail.com";
        public string SmtpUser
        {
            set { smtpUser = value; }
        }

        //mật khẩu đăng nhập gmail
        string smtpPassword = "dkniken0601";
        public string SmtpPassword
        {
            set { smtpPassword = value; }
        }

        //port của smtpserver khi dùng gmail là 587 hoặc 465
        int smtpPort = 587;
        public int SmtpPort
        {
            get { return smtpPort; }
            set { smtpPort = value; }
        }

        /// <summary>
        /// Hàm gửi mail với mail client là gmail
        /// </summary>
        /// <param name="strMailTo">Mail muốn gửi đến</param>
        /// <param name="strMailSubject">Tựa đề mail</param>
        /// <param name="strContent">Nội dung mail</param>
        /// <param name="bolIsHTMLFormat">Định dạng mail gửi đi là HTML hay Text</param>
        /// <returns>Trả về thông tin sau khi gửi là thành công hay thất bại và lỗi khi thất bại.</returns>
        public string SendMail(string strMailTo, string strMailSubject, string strContent, bool bolIsHTMLFormat)
        {
            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(smtpMailFrom);
                //mail.ReplyTo = new MailAddress(smtpMailFrom);

                //gửi file đính kèm
                //Attachment fileAttach=new Attachment("duong dan");
                //mail.Attachments.Add(fileAttach);

                mail.To.Add(new MailAddress(strMailTo));
                mail.Subject = strMailSubject;
                if (bolIsHTMLFormat)
                {
                    mail.IsBodyHtml = true;
                    mail.Body = string.Format(@"<html><head><title><u>{0}</u></title></head><body>{1}<br><br><center>
<b>Shop giày Online NikeSwing</b><br>Trần Khánh Dư, Quận 1, TP.Hồ Chí Minh</center>
</body>", strMailSubject, strContent);
                }
                else
                {
                    mail.IsBodyHtml = false;
                    mail.Body = strContent;
                }
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                smtpClient = new SmtpClient();

                smtpClient.Host = smtpServer;
                smtpClient.Port = smtpPort;
                smtpClient.Credentials = new NetworkCredential(smtpUser, smtpPassword);//cơ chế chứng thực xác nhận email
                smtpClient.EnableSsl = true;//xác định cơ chế bảo mật mã hóa kết nối
                smtpClient.Send(mail);

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Successful!";
        }
    }
}