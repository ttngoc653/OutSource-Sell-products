using IronXL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SellProducts.Common.Imports
{
    struct Point
    {
       public int x, y;
    }

public    class Excel
    {
        public const string columnNameCategoryName = "Tên loại";
        public const string columnNameCategoryDetail = "Chi tiết";

        // [code], [name], [price], [price_sale], [describe], [detail], [avatar], [amount_current]
        public const string columnNameProductCode = "Mã sản phẩm";
        public const string columnNameProductName = "Tên sản phẩm";
        public const string columnNameProductPrice = "Giá";
        public const string columnNameProductPriceSale = "Giá khuyến mãi";
        public const string columnNameProductDecribe = "Mô tả ngắn";
        public const string columnNameProductDetail = "Chi tiết";
        public const string columnNameProductAmount = "Số lượng";

        WorkBook workBook = null;
        WorkSheet workSheet = null;

        public Excel(string filename)
        {
            workBook = WorkBook.Load(filename);
            workSheet = workBook.DefaultWorkSheet;
        }

        public List<Model.CATEGORY> GetCategories()
        {
            List<Model.CATEGORY> result = new List<Model.CATEGORY>();

            Point pHeaderName = new Point() { x = -1, y = -1 };
            Point pHeaderDetail = new Point() { x = -1, y = -1 };

            for (int x = 0; x < workSheet.ColumnCount; x++)
            {
                for (int y = 0; y < workSheet.RowCount; y++)
                {
                    string textCell;
                    try
                    {
                        textCell = workSheet.GetCellAt(y, x)?.Text;
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    if (textCell == columnNameCategoryName)
                    {
                        pHeaderName.x = x;
                        pHeaderName.y = y;
                    }
                    else if (textCell == columnNameCategoryDetail)
                    {
                        pHeaderDetail.x = x;
                        pHeaderDetail.y = y;
                    }

                    if (pHeaderName.y != -1 && pHeaderDetail.x != -1)
                    {
                        break;
                    }
                }
            }

            for (int i = pHeaderName.y + 1; workSheet.GetCellAt(i, pHeaderName.x) != null; i++)
            {
                Model.CATEGORY c = new Model.CATEGORY()
                {
                    name = workSheet.GetCellAt(i, pHeaderName.x)?.Text
                };

                if (pHeaderDetail.x>-1)
                {
                    c.detail = workSheet.GetCellAt(i + (pHeaderDetail.y - pHeaderName.y), pHeaderDetail.x)?.Text;
                }

                result.Add(c);
            }

            return result;
        }

        public List<Model.PRODUCT> GetProducts()
        {
            List<Model.PRODUCT> result = new List<Model.PRODUCT>();

            Point pHeaderCode = new Point() { x = -1, y = -1 };
            Point pHeaderName = new Point() { x = -1, y = -1 };
            Point pHeaderPrice = new Point() { x = -1, y = -1 };
            Point pHeaderPriceSale = new Point() { x = -1, y = -1 };
            Point pHeaderDescribe = new Point() { x = -1, y = -1 };
            Point pHeaderDetail = new Point() { x = -1, y = -1 };
            Point pHeaderAmount = new Point() { x = -1, y = -1 };

            int headerFind = 0;
            for (int x = 0; x < workSheet.ColumnCount; x++)
            {
                for (int y = 0; y < workSheet.RowCount; y++)
                {
                    string textCell;
                    try
                    {
                        textCell = workSheet.GetCellAt(y, x)?.Text;
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    if (textCell == columnNameProductAmount)
                    {
                        pHeaderAmount.x = x;
                        pHeaderAmount.y = y;
                        headerFind++;
                    }
                    else if (textCell == columnNameProductCode)
                    {
                        pHeaderCode.x = x;
                        pHeaderCode.y = y;
                        headerFind++;
                    }
                    else if (textCell == columnNameProductDecribe)
                    {
                        pHeaderDescribe.x = x;
                        pHeaderDescribe.y = y;
                        headerFind++;
                    }
                    else if (textCell == columnNameProductDetail)
                    {
                        pHeaderDetail.x = x;
                        pHeaderDetail.y = y;
                        headerFind++;
                    }
                    else if (textCell == columnNameProductName)
                    {
                        pHeaderName.x = x;
                        pHeaderName.y = y;
                        headerFind++;
                    }
                    else if (textCell == columnNameProductPrice)
                    {
                        pHeaderPrice.x = x;
                        pHeaderPrice.y = y;
                        headerFind++;
                    }
                    else if (textCell == columnNameProductPriceSale)
                    {
                        pHeaderPriceSale.x = x;
                        pHeaderPriceSale.y = y;
                        headerFind++;
                    }

                    if (headerFind == 7)
                    {
                        break;
                    }
                }
            }

            for (int i = pHeaderName.y + 1; workSheet.GetCellAt(i, pHeaderName.x) != null; i++)
            {
                Model.PRODUCT c = new Model.PRODUCT()
                {
                    is_hide = false
                };

                if (pHeaderCode.x > -1)
                {
                    c.code = workSheet.GetCellAt(i + (pHeaderCode.y - pHeaderName.y), pHeaderCode.x)?.Text;
                }
                if (pHeaderName.x > -1)
                {
                    c.name = workSheet.GetCellAt(i, pHeaderName.x).Text;
                }

                if (pHeaderDetail.x > -1)
                {
                    c.detail = workSheet.GetCellAt(i + (pHeaderDetail.y - pHeaderName.y), pHeaderDetail.x)?.Text;
                }

                if (pHeaderDescribe.x > -1)
                {
                    c.describe = workSheet.GetCellAt(i + (pHeaderDescribe.y - pHeaderName.y), pHeaderDescribe.x)?.Text;
                }

                if (pHeaderPrice.x > -1)
                    try
                    {
                        c.price = workSheet.GetCellAt(i + (pHeaderPrice.y - pHeaderName.y), pHeaderPrice.x)?.IntValue;
                    }
                    catch (Exception) { }

                if (pHeaderPriceSale.x > -1)
                    try
                    {
                        c.price_sale = workSheet.GetCellAt(i + (pHeaderPriceSale.y - pHeaderName.y), pHeaderPriceSale.x)?.IntValue;
                    }
                    catch (Exception) { }

                if (pHeaderAmount.x > -1)
                    try
                    {
                        c.amount_current = workSheet.GetCellAt(i + (pHeaderAmount.y - pHeaderName.y), pHeaderAmount.x)?.IntValue;
                    }
                    catch (Exception) { }

                result.Add(c);
            }

            return result;
        }
    }
}
