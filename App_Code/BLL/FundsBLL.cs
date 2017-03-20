using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// FundsBLL 的摘要说明
/// </summary>
public class FundsBLL
{
    Common common = new Common();
    public FundsBLL()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    //资金管理
    //
    //显示资金
    public string FundsShow(int id)
    {
        if (!common.Check(id)) { }
        try
        {
            string text = "";

            return text;
        }
        catch (Exception ex)
        {
            return string.Format("错误{0}", ex);
        }
    }
    //资金管理
    public string FundsManage(int id)
    {
        if (!common.Check(id)) { }
        try
        {
            string text = "";

            return text;
        }
        catch (Exception ex)
        {
            return string.Format("错误{0}", ex);
        }
    }
}