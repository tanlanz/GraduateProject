using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Common 的摘要说明
/// </summary>
public class Common
{
    public Common()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    #region ###加密解密
    /// <summary>
    /// 加密字符串
    /// </summary>
    /// <param name="input"></param>
    /// <param name="sKey"></param>
    /// <returns>密文</returns>
    public static string EncryptString(string input, string sKey)
    {
        byte[] data = Encoding.UTF8.GetBytes(input);
        using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
        {
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            ICryptoTransform desencrypt = des.CreateEncryptor();
            byte[] result = desencrypt.TransformFinalBlock(data, 0, data.Length);
            return BitConverter.ToString(result);
        }
    }

    /// <summary>
    /// 解密字符串
    /// </summary>
    /// <param name="input"></param>
    /// <param name="sKey"></param>
    /// <returns>明文</returns>
    public static string DecryptString(string input, string sKey)
    {
        string[] sInput = input.Split("-".ToCharArray());
        byte[] data = new byte[sInput.Length];
        for (int i = 0; i < sInput.Length; i++)
        {
            data[i] = byte.Parse(sInput[i], NumberStyles.HexNumber);
        }
        using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
        {
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            ICryptoTransform desencrypt = des.CreateDecryptor();
            byte[] result = desencrypt.TransformFinalBlock(data, 0, data.Length);
            return Encoding.UTF8.GetString(result);
        }
    }

    /// <summary>
    /// RSA加密
    /// </summary>
    /// <param name="plaintext">明文</param>
    /// <param name="publicKey">公钥</param>
    /// <returns>密文字符串</returns>
    public static string EncryptByRSA(string plaintext, string publicKey)
    {
        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        byte[] dataToEncrypt = ByteConverter.GetBytes(plaintext);
        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
        {
            RSA.FromXmlString(publicKey);
            byte[] encryptedData = RSA.Encrypt(dataToEncrypt, false);
            return Convert.ToBase64String(encryptedData);
        }
    }

    /// <summary>
     /// RSA解密
     /// </summary>
     /// <param name="ciphertext">密文</param>
     /// <param name="privateKey">私钥</param>
     /// <returns>明文字符串</returns>
    public static string DecryptByRSA(string ciphertext, string privateKey)
    {
        UnicodeEncoding byteConverter = new UnicodeEncoding();
        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
        {
            RSA.FromXmlString(privateKey);
            byte[] encryptedData = Convert.FromBase64String(ciphertext);
            byte[] decryptedData = RSA.Decrypt(encryptedData, false);
            return byteConverter.GetString(decryptedData);
        }
    }
    #endregion

    #region ###加密
    public static string Encrypt(string PWD)
    {
        return PWD = MD5(PWD);
    }
    static string MD5(string Code)
    {
        return Code = getMd5Hash(getMd5Hash(Code)+Code.Length);
    }
    static string getMd5Hash(string input)
    {
        MD5CryptoServiceProvider Md5Hasher1 = new MD5CryptoServiceProvider();
        byte[] data = Md5Hasher1.ComputeHash(Encoding.Default.GetBytes(input));
        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }
    #endregion
}