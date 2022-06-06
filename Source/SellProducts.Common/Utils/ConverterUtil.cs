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
        internal static ACTION Dictionary2Action(Dictionary<string, string> keyValues)
        {
            ACTION a = new ACTION();

            try
            {
                a.id = int.Parse(keyValues["id"]);
            }
            catch (Exception) { }

            try
            {
                a.idref = keyValues["idref"];
            }
            catch (Exception) { }

            try
            {
                a.time = DateTime.Parse(keyValues["time"]);
            }
            catch (Exception) { }

            try
            {
                a.detail = keyValues["detail"];
            }
            catch (Exception) { }

            try
            {
                a.manager = keyValues["manager"];
            }
            catch (Exception) { }

            return a;
        }

        internal static CART Dictionary2Cart(Dictionary<string, string> i)
        {
            CART c = new CART();

            try
            {
                c.idorder = int.Parse(i["idorder"]);
            }
            catch (Exception) { }

            try
            {
                c.idproduct = int.Parse(i["idproduct"]);
            }
            catch (Exception) { }

            try
            {
                c.amount = int.Parse(i["amount"]);
            }
            catch (Exception) { }

            try
            {
                c.price = int.Parse(i["price"]);
            }
            catch (Exception) { }

            return c;
        }

        internal static CATEGORY Dictionary2Categoty(Dictionary<string, string> keyValues)
        {
            CATEGORY result = new CATEGORY();

            try
            {
                result.id = int.Parse(keyValues["id"]);
            }
            catch (Exception) { }

            try
            {
                result.name = keyValues["name"];
            }
            catch (Exception) { }

            try
            {
                result.detail = keyValues["detail"];
            }
            catch (Exception) { }

            try
            {
                result.cat_parent = int.Parse(keyValues["cat_parent"]);
            }
            catch (Exception) { }

            return result;
        }

        internal static CLASSIFY Dictionary2Classify(Dictionary<string, string> keyValues)
        {
            CLASSIFY result = new CLASSIFY();

            try
            {
                result.category = int.Parse(keyValues["category"]);
            }
            catch (Exception) { }

            try
            {
                result.product = int.Parse(keyValues["product"]);
            }
            catch (Exception) { }

            return result;
        }

        internal static CUSTOMER Dictionary2Customer(Dictionary<string, string> keyValues)
        {
            CUSTOMER result = new CUSTOMER();

            try
            {
                result.phone = keyValues["phone"];
            }
            catch (Exception) { }

            try
            {
                result.name = keyValues["name"];
            }
            catch (Exception) { }

            try
            {
                result.address = keyValues["address"];
            }
            catch (Exception) { }

            return result;
        }

        internal static HISTORY Dictionary2History(Dictionary<string, string> keyValues)
        {
            HISTORY result = new HISTORY();

            try
            {
                result.idorder = int.Parse(keyValues["idorder"]);
            }
            catch (Exception) { }

            try
            {
                result.datetime = DateTime.Parse( keyValues["datetime"]);
            }
            catch (Exception) { }

            try
            {
                result.detail = keyValues["detail"];
            }
            catch (Exception) { }

            try
            {
                result.act = keyValues["act"];
            }
            catch (Exception) { }

            return result;
        }

        internal static MADEIN Dictionary2MadeIn(Dictionary<string, string> keyValues)
        {
            MADEIN result = new MADEIN();

            try
            {
                result.id = int.Parse(keyValues["id"]);
            }
            catch (Exception) { }

            try
            {
                result.location = keyValues["location"];
            }
            catch (Exception) { }

            try
            {
                result.detail = keyValues["detail"];
            }
            catch (Exception) { }

            return result;
        }

        internal static MANAGER Dictionary2Manager(Dictionary<string, string> keyValues)
        {
            MANAGER result = new MANAGER();

            try
            {
                result.account = keyValues["account"];
            }
            catch (Exception) { }

            try
            {
                result.address = keyValues["address"];
            }
            catch (Exception) { }

            try
            {
                result.comment = keyValues["comment"];
            }
            catch (Exception) { }

            try
            {
                result.email = keyValues["email"];
            }
            catch (Exception) { }

            try
            {
                result.is_disable = Boolean.Parse(keyValues["is_disable"]);
            }
            catch (Exception) { }

            try
            {
                result.name = keyValues["name"];
            }
            catch (Exception) { }

            try
            {
                result.password = keyValues["password"];
            }
            catch (Exception) { }

            try
            {
                result.phone = keyValues["phone"];
            }
            catch (Exception) { }

            try
            {
                result.type = keyValues["type"];
            }
            catch (Exception) { }

            return result;
        }

        internal static MANUFACTURER Dictionary2Manufacturer(Dictionary<string, string> keyValues)
        {
            MANUFACTURER result = new MANUFACTURER();

            try
            {
                result.id = int.Parse(keyValues["id"]);
            }
            catch (Exception) { }

            try
            {
                result.name = keyValues["name"];
            }
            catch (Exception) { }

            try
            {
                result.detail = keyValues["detail"];
            }
            catch (Exception) { }

            return result;
        }

        internal static ORDER Dictionary2Order(Dictionary<string, string> keyValues)
        {
            ORDER result = new ORDER();

            try
            {
                result.id = int.Parse(keyValues["id"]);
            }
            catch (Exception) { }

            try
            {
                result.time = DateTime.Parse(keyValues["time"]);
            }
            catch (Exception) { }

            try
            {
                result.customer = keyValues["customer"];
            }
            catch (Exception) { }

            try
            {
                result.promotion = int.Parse(keyValues["promotion"]);
            }
            catch (Exception) { }

            try
            {
                result.total = int.Parse(keyValues["total"]);
            }
            catch (Exception) { }

            try
            {
                result.comment = keyValues["comment"];
            }
            catch (Exception) { }

            return result;
        }

        internal static PRODUCT Dictionary2Product(Dictionary<string, string> keyValues)
        {
            PRODUCT result = new PRODUCT();

            try
            {
                result.id = int.Parse(keyValues["id"]);
            }
            catch (Exception) { }

            try
            {
                result.code = keyValues["code"];
            }
            catch (Exception) { }

            try
            {
                result.name = keyValues["name"];
            }
            catch (Exception) { }

            try
            {
                result.price = int.Parse(keyValues["price"]);
            }
            catch (Exception) { }

            try
            {
                result.price_sale = int.Parse(keyValues["price_sale"]);
            }
            catch (Exception) { }

            try
            {
                result.describe = keyValues["describe"];
            }
            catch (Exception) { }

            try
            {
                result.detail = keyValues["detail"];
            }
            catch (Exception) { }

            try
            {
                result.avatar = keyValues["avatar"];
            }
            catch (Exception) { }

            try
            {
                result.amount_current = int.Parse(keyValues["amount_current"]);
            }
            catch (Exception) { }

            try
            {
                result.madein = int.Parse(keyValues["madein"]);
            }
            catch (Exception) { }

            try
            {
                result.manufacturer = int.Parse(keyValues["manufacturer"]);
            }
            catch (Exception) { }

            try
            {
                result.is_hide = bool.Parse(keyValues["is_hide"]);
            }
            catch (Exception) { }

            return result;
        }

        internal static PROMOTION Dictionary2Promotion(Dictionary<string, string> keyValues)
        {
            PROMOTION result = new PROMOTION();

            try
            {
                result.id = int.Parse(keyValues["id"]);
            }
            catch (Exception) { }

            try
            {
                result.code = keyValues["code"];
            }
            catch (Exception) { }

            try
            {
                result.title = keyValues["title"];
            }
            catch (Exception) { }

            try
            {
                result.detail = keyValues["detail"];
            }
            catch (Exception) { }

            try
            {
                result.date_start = DateTime.Parse(keyValues["date_start"]);
            }
            catch (Exception) { }

            try
            {
                result.date_end = DateTime.Parse(keyValues["date_end"]);
            }
            catch (Exception) { }

            try
            {
                result.type = keyValues["type"];
            }
            catch (Exception) { }

            try
            {
                result.percent_discount = decimal.Parse(keyValues["percent_discount"]);
            }
            catch (Exception) { }

            try
            {
                result.discount = int.Parse(keyValues["discount"]);
            }
            catch (Exception) { }

            try
            {
                result.is_stop = bool.Parse(keyValues["is_stop"]);
            }
            catch (Exception) { }

            try
            {
                result.is_hide = bool.Parse(keyValues["is_hide"]);
            }
            catch (Exception) { }

            try
            {
                result.amount = int.Parse(keyValues["amount"]);
            }
            catch (Exception) { }

            return result;
        }

        internal static SETTING Dictionary2Setting(Dictionary<string, string> keyValues)
        {
            SETTING result = new SETTING();

            try
            {
                result.account = keyValues["account"];
            }
            catch (Exception) { }

            try
            {
                result.name = keyValues["name"];
            }
            catch (Exception) { }

            try
            {
                result.value = keyValues["value"];
            }
            catch (Exception) { }

            return result;
        }
    }
}
