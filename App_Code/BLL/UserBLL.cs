using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using System.Net.Mail;

/// <summary>
/// UserBLL 的摘要说明
/// </summary>
/// 
namespace BLL
{
    public class UserBLL
    {
        UsersDAL ud = new UsersDAL();
        UserInfoDAL infod = new UserInfoDAL();
        StatusDAL stad = new StatusDAL();
        public UserBLL()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #region ### 

        #endregion

        #region ### 验证注册邮箱（未完成）
        public string VeriEmail(string Code)
        {
            //1、使用数据库记录验证码
            //2、使用加密解密算法分析传进来的值，得到用户名
            //int id = infod.Get_UserInfoByUserName(userName).user_id;
            //stad.Get_StatusByUserId(id).status_name = "允许访问";
            ; return "SUCC";
        }
        #endregion

        #region ### 验证登陆状态
        public string Check_Login(string UserName)
        {
            if (infod.Get_UserInfoByUserName(UserName) == null) { return "ERROR"; }
            return "SUCC";
        }
        #endregion

        #region ### 登陆 
        public string Login(string UserName, string PWD)
        {
            try
            {
                UserInfo UserInfo = infod.Get_UserInfoByUserName(UserName);
                if (UserInfo == null) { return "NOEXSIT"; }
                Users User = ud.Get_UsersById(UserInfo.user_id);
                if (User == null) { return "NOEXSIT"; }
                Status Status = stad.Get_StatusByUserId(User.id);
                if (Status == null) { return "NOEXSIT"; }
                if (Status.status_name != "禁止访问" && User.password.Equals(Common.Encrypt(PWD)))
                {
                    User.time = DateTime.Now;
                    ud.Update_Users(User);
                    return "SUCCESSLOGIN";
                }
                return "ERRORLOGIN";
            }
            catch(Exception ex)
            {
                return string.Format("错误{0}", ex);
            }         
        }
        #endregion

        #region ### 注册
        public string Register(string Name,string Password,string Email,string PhoneNumber)
        {
            UserInfo info = new UserInfo();
            Users user = new Users();
            Status status = new Status();
            DateTime time = DateTime.Now;
            string text = "Error";
            try
            {
                if (infod.Get_UserInfoByUserName(Name) != null) { text = "RENAME";return text; }
                if (infod.Get_UserInfoByUserEmail(Email) != null) { text = "REEMAIL"; return text; }
                user.create_time = time;
                user.password = Common.Encrypt(Password);
                if (!ud.Insert_Users(user)){ return text + "1"; }
                info.user_id = ud.Get_UsersByTime(time).id;
                info.username = Name;
                info.phone = PhoneNumber;
                info.email = Email;
                if (!infod.Insert_UserInfo(info)) { return text + "2"; }
                status.user_id = ud.Get_UsersByTime(time).id;
                status.status_name = "禁止访问";
                if (!stad.Insert_Status(status)) { return text + "3"; }
                //string rcontext = "请点击如下链接:<a href='http://localhost:86/verifemail.aspx?em=" + pu.pus_email + "&vercode=" + pu.pus_verif + "'>链接</a>";
                //SendEmail("tanlanz@163.com", Email, "xxx@126.com", "邮箱激活邮件", rcontext);
                text = "Success";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return text;
            }
            return text;
        }
        #endregion

        #region ###建立邮件实体
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email_from">邮件发送方</param>
        /// <param name="email_to">邮件接收方</param>
        /// <param name="email_cc">邮件接收方</param>
        /// <param name="subject">邮件标题</param>
        /// <param name="strBody">邮件内容</param>
        public void SendEmail(string email_from, string email_to, string email_cc, string subject, string strBody)
        {
            try
            {
                //建立一个邮件实体
                MailAddress from = new MailAddress(email_from);
                MailAddress to = new MailAddress(email_to);
                MailMessage massage = new MailMessage(from, to);
                if (string.IsNullOrEmpty(email_cc)) return;
                foreach (string css in email_cc.Split(';'))
                {
                    MailAddress cc = new MailAddress(css);
                    massage.CC.Add(cc);
                }
                massage.IsBodyHtml = true;
                massage.BodyEncoding = System.Text.Encoding.UTF8;
                massage.Priority = MailPriority.High;
                massage.Subject = subject;
                massage.Body = strBody;
                
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.163.com";
                smtp.Port = 25;
                smtp.Credentials = new System.Net.NetworkCredential("tanlanz@163.com", "85799491");//需要加密
                smtp.Send(massage);//发送邮件
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        #endregion

        #region ### RndCode  生成一组随机数
        public string RndCode(int length)
        {
            Char[] arcChar = new char[]{'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
            '0','1','2','3','4','5','6','7','8','9',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
            System.Text.StringBuilder num = new System.Text.StringBuilder();
            Random rnd = new Random(DateTime.Now.Millisecond + 3);
            for (int i = 0; i < length; i++)
            {
                num.Append(arcChar[rnd.Next(0, arcChar.Length)].ToString());
            }
            return num.ToString();
        }
        #endregion
    }
}