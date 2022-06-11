using SellProducts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Common.Utils
{
    class ConverterUtil
    {
        internal static ACTION Dictionary2Action(Dictionary<string, object> keyValues)
        {
            ACTION a = new ACTION();

            try
            {
                a.id = (int)keyValues["id"];
            }
            catch (Exception) { }

            try
            {
                a.idref = (string)keyValues["idref"];
            }
            catch (Exception) { }

            try
            {
                a.time = (DateTime?)keyValues["time"];
            }
            catch (Exception) { }

            try
            {
                a.detail = (string)keyValues["detail"];
            }
            catch (Exception) { }

            try
            {
                a.manager = (string)keyValues["manager"];
            }
            catch (Exception) { }

            return a;
        }

        internal static CART Dictionary2Cart(Dictionary<string, object> i)
        {
            CART c = new CART();

            try
            {
                c.idorder = (int)i["idorder"];
            }
            catch (Exception) { }

            try
            {
                c.idproduct = (int)i["idproduct"];
            }
            catch (Exception) { }

            try
            {
                c.amount = (int)i["amount"];
            }
            catch (Exception) { }

            try
            {
                c.price = (int)i["price"];
            }
            catch (Exception) { }

            return c;
        }

        internal static CATEGORY Dictionary2Categoty(Dictionary<string, object> keyValues)
        {
            CATEGORY result = new CATEGORY();

            try
            {
                result.id = (int)keyValues["id"];
            }
            catch (Exception) { }

            try
            {
                result.name = (string)keyValues["name"];
            }
            catch (Exception) { }

            try
            {
                result.detail = (string)keyValues["detail"];
            }
            catch (Exception) { }

            try
            {
                result.cat_parent = (int?)keyValues["cat_parent"];
            }
            catch (Exception) { }

            return result;
        }

        internal static CLASSIFY Dictionary2Classify(Dictionary<string, object> keyValues)
        {
            CLASSIFY result = new CLASSIFY();

            try
            {
                result.category = (int)keyValues["category"];
            }
            catch (Exception) { }

            try
            {
                result.product = (int)keyValues["product"];
            }
            catch (Exception) { }

            return result;
        }

        internal static CUSTOMER Dictionary2Customer(Dictionary<string, object> keyValues)
        {
            CUSTOMER result = new CUSTOMER();

            try
            {
                result.phone = (string)keyValues["phone"];
            }
            catch (Exception) { }

            try
            {
                result.name = (string)keyValues["name"];
            }
            catch (Exception) { }

            try
            {
                result.address = (string)keyValues["address"];
            }
            catch (Exception) { }

            return result;
        }

        internal static HISTORY Dictionary2History(Dictionary<string, object> keyValues)
        {
            HISTORY result = new HISTORY();

            try
            {
                result.idorder = (int)keyValues["idorder"];
            }
            catch (Exception) { }

            try
            {
                result.datetime = (DateTime)keyValues["datetime"];
            }
            catch (Exception) { }

            try
            {
                result.detail = (string)keyValues["detail"];
            }
            catch (Exception) { }

            try
            {
                result.act = (string)keyValues["act"];
            }
            catch (Exception) { }

            return result;
        }

        internal static MADEIN Dictionary2MadeIn(Dictionary<string, object> keyValues)
        {
            MADEIN result = new MADEIN();

            try
            {
                result.id = (int)keyValues["id"];
            }
            catch (Exception) { }

            try
            {
                result.location = (string)keyValues["location"];
            }
            catch (Exception) { }

            try
            {
                result.detail = (string)keyValues["detail"];
            }
            catch (Exception) { }

            return result;
        }

        internal static MANAGER Dictionary2Manager(Dictionary<string, object> keyValues)
        {
            MANAGER result = new MANAGER();

            try
            {
                result.account = (string)keyValues["account"];
            }
            catch (Exception) { }

            try
            {
                result.address = (string)keyValues["address"];
            }
            catch (Exception) { }

            try
            {
                result.comment = (string)keyValues["comment"];
            }
            catch (Exception) { }

            try
            {
                result.email = (string)keyValues["email"];
            }
            catch (Exception) { }

            try
            {
                result.is_disable = (bool?)keyValues["is_disable"];
            }
            catch (Exception) { }

            try
            {
                result.name = (string)keyValues["name"];
            }
            catch (Exception) { }

            try
            {
                result.password = (string)keyValues["password"];
            }
            catch (Exception) { }

            try
            {
                result.phone = (string)keyValues["phone"];
            }
            catch (Exception) { }

            try
            {
                result.type = (string)keyValues["type"];
            }
            catch (Exception) { }

            return result;
        }

        internal static MANUFACTURER Dictionary2Manufacturer(Dictionary<string, object> keyValues)
        {
            MANUFACTURER result = new MANUFACTURER();

            try
            {
                result.id = (int)keyValues["id"];
            }
            catch (Exception) { }

            try
            {
                result.name = (string)keyValues["name"];
            }
            catch (Exception) { }

            try
            {
                result.detail = (string)keyValues["detail"];
            }
            catch (Exception) { }

            return result;
        }

        internal static ORDER Dictionary2Order(Dictionary<string, object> keyValues)
        {
            ORDER result = new ORDER();

            try
            {
                result.id = (int)keyValues["id"];
            }
            catch (Exception) { }

            try
            {
                result.time = (DateTime)keyValues["time"];
            }
            catch (Exception) { }

            try
            {
                result.customer = (string)keyValues["customer"];
            }
            catch (Exception) { }

            try
            {
                result.promotion = (int?)keyValues["promotion"];
            }
            catch (Exception) { }

            try
            {
                result.total = (int?)keyValues["total"];
            }
            catch (Exception) { }

            try
            {
                result.comment = (string)keyValues["comment"];
            }
            catch (Exception) { }

            return result;
        }

        internal static PRODUCT Dictionary2Product(Dictionary<string, object> keyValues)
        {
            PRODUCT result = new PRODUCT();

            try
            {
                result.id = (int)keyValues["id"];
            }
            catch (Exception) { }

            try
            {
                result.code = (string)keyValues["code"];
            }
            catch (Exception) { }

            try
            {
                result.name = (string)keyValues["name"];
            }
            catch (Exception) { }

            try
            {
                result.price = (int?)keyValues["price"];
            }
            catch (Exception) { }

            try
            {
                result.price_sale = (int?)keyValues["price_sale"];
            }
            catch (Exception) { }

            try
            {
                result.describe = (string)keyValues["describe"];
            }
            catch (Exception) { }

            try
            {
                result.detail = (string)keyValues["detail"];
            }
            catch (Exception) { }

            try
            {
                result.amount_current = (int?)keyValues["amount_current"];
            }
            catch (Exception) { }

            try
            {
                result.madein = (int?)keyValues["madein"];
            }
            catch (Exception) { }

            try
            {
                result.manufacturer = (int?)keyValues["manufacturer"];
            }
            catch (Exception) { }

            try
            {
                result.is_hide = (bool)keyValues["is_hide"];
            }
            catch (Exception) { }

            return result;
        }

        internal static PROMOTION Dictionary2Promotion(Dictionary<string, object> keyValues)
        {
            PROMOTION result = new PROMOTION();

            try
            {
                result.id = (int)keyValues["id"];
            }
            catch (Exception) { }

            try
            {
                result.code = (string)keyValues["code"];
            }
            catch (Exception) { }

            try
            {
                result.title = (string)keyValues["title"];
            }
            catch (Exception) { }

            try
            {
                result.detail = (string)keyValues["detail"];
            }
            catch (Exception) { }

            try
            {
                result.date_start = (DateTime?)keyValues["date_start"];
            }
            catch (Exception) { }

            try
            {
                result.date_end = (DateTime?)keyValues["date_end"];
            }
            catch (Exception) { }

            try
            {
                result.type = (string)keyValues["type"];
            }
            catch (Exception) { }

            try
            {
                result.percent_discount = (decimal?)keyValues["percent_discount"];
            }
            catch (Exception) { }

            try
            {
                result.discount = (int?)keyValues["discount"];
            }
            catch (Exception) { }

            try
            {
                result.is_stop = (bool)keyValues["is_stop"];
            }
            catch (Exception) { }

            try
            {
                result.is_hide = (bool)keyValues["is_hide"];
            }
            catch (Exception) { }

            try
            {
                result.amount = (int?)keyValues["amount"];
            }
            catch (Exception) { }

            return result;
        }

        internal static SETTING Dictionary2Setting(Dictionary<string, object> keyValues)
        {
            SETTING result = new SETTING();

            try
            {
                result.account = (string)keyValues["account"];
            }
            catch (Exception) { }

            try
            {
                result.name = (string)keyValues["name"];
            }
            catch (Exception) { }

            try
            {
                result.value = (string)keyValues["value"];
            }
            catch (Exception) { }

            return result;
        }
    }
}
