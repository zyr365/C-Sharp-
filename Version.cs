using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public static class Version
    {
        /// <summary>
        /// 컴파일한 날짜를 구한다.
        ///   단, AssemblyInfo.cs 파일에서 AssemblyVersion는 다음 형식으로 되어있어야만 한다.
        ///   [assembly: AssemblyVersion("1.0.*")]
        /// </summary>
        /// <returns>컴파일한 날짜</returns>
        static public string BuildDate
        {
            get
            {
                System.Version assemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                // assemblyVersion.Build = days after 2000-01-01
                // assemblyVersion.Revision*2 = seconds after 0-hour  (NEVER daylight saving time) 
                DateTime buildDate = new DateTime(2010, 1, 1).AddDays(assemblyVersion.Build).AddSeconds(assemblyVersion.Revision * 2);

                string fileVer = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion.ToString();

                
                
                string tmp = string.Format("{0} ({1})", fileVer, buildDate.ToString("yyyyMMdd_HHmmss"));

                return assemblyVersion.ToString();
            }
        }
    }
}
