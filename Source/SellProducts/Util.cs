using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts
{
    internal class Util
    {
        public static void SaveSettings(Model.SETTING setting1)
        {
            try
            {
                bool existSettingRemember = Common.ConnectDB.Get.Settings().Where(p => p.account == setting1.account && p.name == SellProduct_CONSTANT.SETTING_AUTO_LOGIN).FirstOrDefault() != null;
                if (existSettingRemember)
                {

                    if (Common.ConnectDB.Update.Instance(setting1) == 0)
                    {
                        throw new Exception("");
                    }
                }
                else
                {
                    throw new Exception("");
                }
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(Exception) && ex.Message == "")
                {
                    Common.ConnectDB.Insert.Instance(setting1);
                }
            }
        }
    }
}
