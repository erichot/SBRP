using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace SBRPAPITms.BindingModels
{
    public class KendoBindingModel
    {



        




    }





    public class EdResponseList<T>
    {
        [BindRequired]
        public List<T> data { get; set; }
    }

    public class EdRequestList<T>
    {
        [BindRequired]
        public List<T> data { get; set; }
        [BindRequired]
        public string action { get; set; }
    }

    public class EdRequestEntity<T>
    {
        [BindRequired]
        public T data { get; set; }

        [BindRequired]
        public string action { get; set; }
    }







    public class KendoChunkMetaDataResponse
    {
        private string m_FileUid = default;
        public KendoChunkMetaDataResponse(string _fileUid)
        {
            m_FileUid = _fileUid;
        }

        // false instructs the Upload to send the next chunk of data.
        // true indicates that the last chunk is processed, the upload was successful
        // and the upload of the next file can continue.
        [BindRequired]
        public bool uploaded { get; set; }

        [BindRequired]
        // The UID of the uploaded chunk, so that the Upload can get the next chunk and send it.
        public string fileUid
        {
            get
            {
                return m_FileUid;
            }

            set
            {
                m_FileUid = value;
            }
        }

        public int responseNo { get; set; }
    }





    public class KendoMetadataRequest
    {
        //public KendoMetadataRequest() { }


        //public KendoMetadataRequest(Dictionary<string, string> _kendoUploadRequest) 
        //{
        //    var uploadDataValue = _kendoUploadRequest.FirstOrDefault().Value;
        //    var des = JsonSerializer.Deserialize<KendoMetadataRequest>(uploadDataValue);
        //    this.relativePath = des.relativePath;
        //    this.chunkIndex = des.chunkIndex;
        //    this.contentType = des.contentType;
        //    this.uploadUid = des.uploadUid;
        //    this.fileName = des.fileName;
        //    this.chunkIndex= des.chunkIndex;
        //    this.uploadUid= des.uploadUid;
        //}


        public int chunkIndex { get; set; }
        public string contentType { get; set; }

        public string fileName { get; set; }

        public string relativePath { get; set; }

        public int totalFileSize { get; set; }

        public int totalChunks { get; set; }

        public string uploadUid { get; set; }





        //public KendoMetadataRequest ConvertFrom(Dictionary<string, string> _kendoUploadRequest)
        //{
        //    KendoMetadataRequest kendoMetadataInfo = new KendoMetadataRequest();
        //    var uploadDataValue = _kendoUploadRequest.FirstOrDefault().Value;
        //    kendoMetadataInfo = JsonSerializer.Deserialize<KendoMetadataRequest>(uploadDataValue);

        //    return kendoMetadataInfo;
        //}
    }







}
