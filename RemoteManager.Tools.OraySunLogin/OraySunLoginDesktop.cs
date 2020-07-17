using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
using Twoxzi.RemoteManager.Entity;

namespace Twoxzi.RemoteManager.Tools.TeamViewer
{
    /// <summary>
    /// TeamViewer桌面远程
    /// </summary>
    [RemoteTool(ToolCode = "OSL", Memo = "向日葵桌面远程", ToolName = "向日葵桌面远程")]
    public class OraySunLoginDesktop : RemoteToolBase
    {
        /// <summary>
        /// 打开远程
        /// </summary>
        /// <param name="info"></param>
        public override void Open(RemoteInfo info)
        {
            Open(info, info.ToolCode == "OSL");
        }
        /// <summary>
        /// 打开远程
        /// </summary>
        /// <param name="info"></param>
        /// <param name="isDesktop"></param>
        protected void Open(RemoteInfo info, Boolean isDesktop)
        {
            String exe = GetExePath("向日葵");

            if(String.IsNullOrEmpty(exe))
            {
                throw new Exception("工具 向日葵 未找到，请确保正确安装，启动已中止");
            }
            String id = info.ID ?? "";
            // 去除ID里的空格
            id = id.Replace(" ", "");
            String pwd = (info.Password ?? "").Replace(" ", "");
            exe = Path.Combine(exe, "SunloginClient.exe");
            var process = Process.Start(exe, $"--mod=fastcontrol --fastcode={id} --pwd={pwd}");
            process.WaitForExit();
            Console.WriteLine(process.ExitCode);
        }
    }
}
