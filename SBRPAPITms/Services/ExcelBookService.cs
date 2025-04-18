

namespace SBRPAPITms.Services
{
    public class ExcelBookService
    {

        public List<ChowFaceUserExportEntity> UploadToUserList(string _pathFileName)
        {
            var msg = string.Empty;

            var result = new List<ChowFaceUserExportEntity>();

            using (var wb = new XLWorkbook(_pathFileName))
            {
                var sheet = wb.Worksheet(1);
                var rows = sheet.RowsUsed().Skip(1);
                short itemNo = 1;

                if (rows == null || rows.Any() == false)
                {
                    msg = "無資料";
                    throw new Exception(msg);
                }


                if (rows.FirstOrDefault().CellCount() < 10)
                {
                    msg = "欄位數量不正確";
                    throw new Exception(msg);
                }



                foreach (var row in rows)
                {
                    var cells = row.Cells(false);
                    var user = new ChowFaceUserExportEntity();
                    user.ItemNo = itemNo++;
                    // A
                    user.UserID = cells.Skip(0).Take(1).FirstOrDefault()?.Value.ToString();
                    // B
                    user.UserName = cells.Skip(1).Take(2).FirstOrDefault()?.Value.ToString();
                    // C
                    user.EmployeeType = cells.Skip(2).Take(3).FirstOrDefault()?.Value.ToString();
                    // D
                    user.Company = cells.Skip(3).Take(4).FirstOrDefault()?.Value.ToString();
                    // E
                    user.DepartmentName = cells.Skip(4).Take(5).FirstOrDefault()?.Value.ToString();
                    user.Sex = cells.Skip(5).Take(6).FirstOrDefault()?.Value.ToString();
                    // G
                    user.CardID = cells.Skip(6).Take(7).FirstOrDefault()?.Value.ToString();
                    // H
                    user.Email = cells.Skip(7).Take(8).FirstOrDefault()?.Value.ToString();
                    user.Phone = cells.Skip(8).Take(9).FirstOrDefault()?.Value.ToString();
                    user.ValidDate = cells.Skip(9).Take(10).FirstOrDefault()?.Value.ToString();

                    result.Add(user);
                }
                
            }

            return result;
        }

    }
}
