using NetcoreInfrastructure.Interface.Repository;
using NetcoreInfrastructure.Interface.Service.Articlewages;
using NetcoreInfrastructure.Model.Articlewages;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
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

        public int ReadExcel(string fileName )
        {
            string sheetName = null;
            List<ReadArticlewagesModel> data = new List<ReadArticlewagesModel>();
            //数据开始行(排除标题行)
            int startRow = 3;
            try
            {
                if (!File.Exists(fileName))
                {
                    return 0;
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
                    string Year = sheet.GetRow(0).GetCell(1).ToString();
                    string Month = sheet.GetRow(1).GetCell(1).ToString();

                    //IRow firstRow = sheet.GetRow(0);
                    IRow firstRow = sheet.GetRow(3);
                    //一行最后一个cell的编号 即总的列数
                    int cellCount = firstRow.LastCellNum;

                    for (int i = startRow; ; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row != null)
                        {
                            IRow rowUp = sheet.GetRow(i - 1);
                            ReadArticlewagesModel OrderDetail = new ReadArticlewagesModel
                            {
                                UserId = Convert.ToInt32(row.GetCell(0).ToString()),
                                UserName = row.GetCell(1).ToString(),
                                YearMonth = Year + " " + Month,
                                AllMoney = Convert.ToDouble(row.GetCell(2).ToString()),
                                Insurance = Convert.ToDouble(row.GetCell(3).ToString()),
                                AccumulationFund = Convert.ToDouble(row.GetCell(4).ToString()),
                                PracticalMoney = Convert.ToDouble(row.GetCell(5).ToString())
                            };
                            data.Add(OrderDetail);
                        }
                        else {
                            break;
                        }

                    }
                }
                int d =this._articlewagesRepository.AddArticlewagesInfo(data);
                return d;
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }

        public IEnumerable<ReadArticlewagesModel> GetArticlewages(int UserId)
        {
            var data = this._articlewagesRepository.GetArticlewages(UserId);
            return data;
        }
    }
}
