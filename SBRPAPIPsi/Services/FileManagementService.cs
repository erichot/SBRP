


namespace SBRPAPIPsi.Services
{
    public class FileManagementService
    {








        public async Task<BusinessProcessResult> SaveFileAsync(IFormFile _uploadFile
            , string _saveToPath, string _saveToFileName)
        {
            //var bInValid = false;
            var result = new BusinessProcessResult();
            var targetPathFileName = Path.Combine(_saveToPath, _saveToFileName);


           


            if (!System.IO.File.Exists(targetPathFileName))
            {
                // 檢查目標路徑是否存在
                if (!System.IO.Directory.Exists(_saveToPath))
                {
                    
                    try
                    {
                        // 建立目標路徑
                        System.IO.Directory.CreateDirectory(_saveToPath);
                    }
                    catch (Exception e)
                    {
                        result.SetErrorMessage("IOException_Error_20230820");
                    }                

                }


                try
                {
                    using (FileStream fs = System.IO.File.Create(targetPathFileName))
                    {
                        await _uploadFile.CopyToAsync(fs);
                        fs.Flush();
                    }
                }
                catch (System.IO.IOException ex)
                {
                    result.SetErrorMessage(ex.ComposeExceptionMessage());
                    return result;
                    //HResult = 0x80070020
                    //Message = The process cannot access the file 'D:\Project\2-研發中\CHT-CAREER\Source\CHT-CareerApi\upload\5\IMGP1897.jpg' because it is being used by another process.
                }

            }
            else
            {
                try
                {
                    using (FileStream fs = System.IO.File.Open(targetPathFileName, FileMode.Append))
                    {
                        await _uploadFile.CopyToAsync(fs);
                        fs.Flush();
                    }
                }
                catch (Exception ex)
                {
                    result.SetErrorMessage(ex.ComposeExceptionMessage());
                    return result;
                    //HResult = 0x80070020
                    //Message = The process cannot access the file 'CHT-CareerApi\upload\5\IMGP1897.jpg' because it is being used by another process.
                }
            }

            result.ResultId = targetPathFileName;
            return result;
        }







    }
}
