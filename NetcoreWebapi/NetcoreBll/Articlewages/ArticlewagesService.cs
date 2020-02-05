using NetcoreInfrastructure.Interface.Repository;
using NetcoreInfrastructure.Interface.Service.Articlewages;
using NetcoreInfrastructure.Model.Articlewages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreBll.Articlewages
{
    public class ArticlewagesService: IArticlewagesService
    {
        private readonly IArticlewagesRepository _articlewagesRepository;
        public ArticlewagesService(IArticlewagesRepository articlewagesRepository)
        {
            _articlewagesRepository = articlewagesRepository;
        }

        public int ReadExcel(string projectFileName)
        {
            ReadArticlewagesModel data = new ReadArticlewagesModel();
            //数据开始行(排除标题行)
            int startRow = 7;
            try
            {
                if (!File.Exists(fileName))
                {
                    return null;
                }
                //根据指定路径读取文件
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                //根据文件流创建excel数据结构
                IWorkbook workbook = WorkbookFactory.Create(fs);

                //excel工作表
                ISheet sheet;
                //IWorkbook workbook = new HSSFWorkbook(fs);
                //如果有指定工作表名称
                if (!string.IsNullOrEmpty(sheetName))
                {
                    sheet = workbook.GetSheet(sheetName);
                    //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    if (sheet == null)
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    //如果没有指定的sheetName，则尝试获取第一个sheet
                    sheet = workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    data.SUP_ID = sheet.GetRow(0).GetCell(1).ToString();
                    data.PO_NUMBER = sheet.GetRow(1).GetCell(1).ToString();
                    data.DELIVERY_NUMBER = sheet.GetRow(2).GetCell(1).ToString();
                    data.PART_NUMBER = sheet.GetRow(3).GetCell(1).ToString();

                    //IRow firstRow = sheet.GetRow(0);
                    IRow firstRow = sheet.GetRow(6);
                    //一行最后一个cell的编号 即总的列数
                    int cellCount = firstRow.LastCellNum;

                    List<OrderDetailModel> list = new List<OrderDetailModel>();
                    int f = 0;
                    for (int i = startRow; ; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null)
                        {
                            data.OrderDetailList = list;
                            break;
                        }
                        else
                        {
                            IRow rowUp = sheet.GetRow(i - 1);
                            if (row.GetCell(0).ToString() != rowUp.GetCell(0).ToString()) { f++; }
                            OrderDetailModel OrderDetail = new OrderDetailModel
                            {
                                LOT_ID = row.GetCell(0).ToString(),
                                LOT_ID_NO = f,
                                QUANTITY = Convert.ToInt32(row.GetCell(1).ToString()),
                                QTY_UNIT = row.GetCell(2).ToString(),
                                PARAMETER_SEQUENCE = row.GetCell(3).ToString(),
                                PARAMETER = row.GetCell(4).ToString(),
                                UNIT = row.GetCell(5).ToString(),
                                REMARK = row.GetCell(9).ToString()
                            };
                            if (OrderDetail.UNIT != null && OrderDetail.UNIT != "")
                            {
                                OrderDetail.DATA_VALUE = Convert.ToDouble(row.GetCell(6).ToString());
                                OrderDetail.SUP_USL = Convert.ToDouble(row.GetCell(7).ToString());
                                OrderDetail.SUP_LSL = Convert.ToDouble(row.GetCell(8).ToString());
                                OrderDetail.DATA_TYPE = "Y";
                            }
                            else
                            {
                                OrderDetail.DATA_STRING = row.GetCell(6).ToString();
                                OrderDetail.DATA_TYPE = "N";
                            }
                            list.Add(OrderDetail);
                        }
                    }
                }
                return 0;
        }
    }
}
