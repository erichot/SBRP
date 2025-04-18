
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json.Serialization;

namespace SBRPWebPsi.Models
{
    /// <summary>
    /// App (web application) 的資料模型
    /// </summary>
    public class AppDataModel
    {

        

    }







    public class AppSettingsModel
    {
        public string Portal_WEB_RootUrl { get; set; }



        // 以web client broswer 的角度來解析API url
        public string PSI_API_RootUrl { get; set; }

        // 以Web的角度來解析API url
        public string PSI_API_FromWeb_RootUrl { get; set; }

        public string PSI_WEB_RootUrl { get; set; }



        public int ApiLoginExpireTime { get; set; }

        public int WebLoginExpireTime { get; set; }
    }







    public class PagePromptSwalEntity
    {
        public string Title { get; set; }
        public string Message { get; set; }

        public string RedirectURL { get; set; }
    }


    public class PageHeaderEntity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string FullTitle => Title + " " + SubTitle;
        public string PageId { get; set; }


    }





    public class ClientHttpContext
    {
        public ClientHttpContext(string _localIpAddress, string _remoteIpAddress)
        {
            LocalIpAddress = _localIpAddress;
            RemoteIpAddress = _remoteIpAddress;
        }

        public ClientHttpContext(IHttpContextAccessor _accessor)
        {
            if (_accessor != null && _accessor.HttpContext != null && _accessor.HttpContext.Connection != null)
            {
                string sRemoteIpAddress = string.Empty;
                if (_accessor.HttpContext.Connection.RemoteIpAddress != null)
                    LocalIpAddress = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();

                string sLocalIpAddress = string.Empty;
                if (_accessor.HttpContext.Connection.LocalIpAddress != null)
                    RemoteIpAddress = _accessor.HttpContext.Connection.LocalIpAddress.ToString();
            }
        }

        public string RemoteIpAddress { get; set; }
        public string LocalIpAddress { get; set; }

    }





    public class SelectItemEntity
    {
        public string SelectItemText { get; set; }
        public string SelectItemValue { get; set; }

    }







    #region "Editor"


    public class EdOptionEntity
    {
        public string label { get; set; }
        public string value { get; set; }
    }



    public enum EdFieldTypeEnum : byte
    {
        [Display(Name = "Text")]
        text = 1,
       
        [Display(Name = "Date")]
        date = 12,

        [Display(Name = "Select")]
        select = 35,

        [Display(Name = "Radio")]
        radio = 39,
    }


    /*
        attr: {
            "type": "number"
        }
     */
    public class EdFieldOptionsAttr
    {
        public EdFieldOptionsAttr() { }

        public EdFieldOptionsAttr(string _className) 
        {
            this.className = _className;        
        }

        public EdFieldOptionsAttr(int _maxLength)
        {
            this.maxLength = _maxLength;
        }

        public EdFieldOptionsAttr(int _maxLength, string _className)
        {
            this.className = _className;
            this.maxLength = _maxLength;
        }


        [JsonPropertyName("maxlength")]
        public int? maxLength { get; set; }

        [JsonPropertyName("class")]
        public string? className { get;set;}

        [JsonPropertyName("type")]
        public string? typeName { get; set; }
    }



    public class EdFieldOptionsEntity<TModel> where TModel : new()
    {
        private TModel _instance;
        //public string displayName { get; set; }

        public EdFieldOptionsEntity(Expression<Func<TModel, object>> expression)
        {
            _instance = new TModel();
            this.label = ModelPropertyHelper.GetDisplayName(expression);
            this.name = ModelPropertyHelper.GetPropertyName(expression);
        }


        public EdFieldOptionsEntity(Expression<Func<TModel, object>> expression, EdFieldTypeEnum _type)
        {
            _instance = new TModel();
            this.label = ModelPropertyHelper.GetDisplayName(expression);
            this.name = ModelPropertyHelper.GetPropertyName(expression);
            this.type = Enum.GetName(typeof(EdFieldTypeEnum), _type);
        }

        public EdFieldOptionsEntity(Expression<Func<TModel, object>> expression, EdFieldOptionsAttr _attr, bool? _required = false)
        {
            _instance = new TModel();
            this.label = ModelPropertyHelper.GetDisplayName(expression);
            this.name = ModelPropertyHelper.GetPropertyName(expression);

            if (_attr.maxLength == null)
                _attr.maxLength = ModelPropertyHelper.GetMaxLength(expression);

            this.attr = _attr;
            this.required = _required ?? false;
        }

        public EdFieldOptionsEntity(Expression<Func<TModel, object>> expression, EdFieldOptionsAttr _attr, object _def, bool? _required = false)
        {
            _instance = new TModel();
            this.label = ModelPropertyHelper.GetDisplayName(expression);
            this.name = ModelPropertyHelper.GetPropertyName(expression);

            if (_attr.maxLength == null)
                _attr.maxLength = ModelPropertyHelper.GetMaxLength(expression);

            this.attr = _attr;
            this.def = _def;
            this.required = _required ?? false;
        }


        public EdFieldOptionsEntity(Expression<Func<TModel, object>> expression, bool _isReadonly)
        {
            _instance = new TModel();
            this.label = ModelPropertyHelper.GetDisplayName(expression);
            this.name = ModelPropertyHelper.GetPropertyName(expression);

            IsReadonly = _isReadonly;            
        }



        public int index { get; set; }

        public EdFieldOptionsAttr? attr { get; set; }

        public string? className { get; set; }

        public object def { get; set; }

        public string label { get; set; }

        public string? labelInfo { get; set; }

        public string name { get; set; }


        private bool m_IsReadonly;
        public bool IsReadonly 
        {
            get { return m_IsReadonly; }
            set
            {
                m_IsReadonly = value;
                if (m_IsReadonly)
                    this.type = "readonly";
            }
        }

        /// <summary>
        /// Editor fields type:select, readonly, radio
        /// </summary>
        public string type { get; set; } = "text";

        public bool required { get; set; }

        public string? options { get; set; }





        //private string GetPropertyName<TProperty>(Expression<Func<TModel, TProperty>> expression)
        //{

        //    Type type = typeof(TModel);

        //    MemberExpression memberExpression = (MemberExpression)expression.Body;
        //    if (expression.Body is UnaryExpression unaryExpression)
        //    {
        //        memberExpression = unaryExpression.Operand as MemberExpression;
        //    }
        //    else if (expression.Body is MemberExpression body)
        //    {
        //        memberExpression = body;
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException("Invalid expression type.");
        //    }

        //    if (memberExpression == null)
        //    {
        //        throw new InvalidOperationException("Invalid member expression.");
        //    }
        //    string propertyName = ((memberExpression.Member is PropertyInfo) ? memberExpression.Member.Name : null);

        //    return propertyName ?? string.Empty;
        //}



        private int? GetMaxLengthAttribute<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            Type type = typeof(TModel);

            MemberExpression memberExpression = (MemberExpression)expression.Body;
            string propertyName = ((memberExpression.Member is PropertyInfo) ? memberExpression.Member.Name : null);

            return ModelPropertyHelper.GetMaxLengthAttributeValue(type, propertyName);
        }



        //public string GetDisplayName<TProperty>(Expression<Func<TModel, TProperty>> expression)
        //{
        //    //return ModelMetadataExtensions.GetDisplayName(new T(), expression);
        //    return ModelMetadataExtensions.GetDisplayName(_instance, expression);
        //}
    }




    public class EdFieldOptionsList<TModel> where TModel : new()
    {
        public EdFieldOptionsList() 
        {
            this.FieldsList = new List<EdFieldOptionsEntity<TModel>>();
        }

        public List<EdFieldOptionsEntity<TModel>> FieldsList { get; set; }


        public int AddElement(EdFieldOptionsEntity<TModel> _obj)
        {
            // index 0-based
            var index = this.FieldsList.Count;
            _obj.index = index;
            this.FieldsList.Add(_obj);
            return index;
        }


    }

    #endregion










    public class KdOptionEntity
    {
        public string text { get; set; }
        public string value { get; set; }
    }



















    public class EntityEditBriefHistory : SBRPData.Interfaces.IEntityEditBriefHistory
    {
        //public EntityEditBriefHistory() { }

        //public EntityEditBriefHistory(short _createPerson, short? _editPerson, short? _approvePerson) 
        //{ 
        //    this.CreatePerson = _createPerson;
        //    this.EditPerson = _editPerson;
        //    this.ApprovedPerson = _approvePerson;
        //}


        public short CreatedPerson { get; set; }
        public short? UpdatedPerson { get; set; }
        public short? DeletedPerson { get; set; }
        public short? ApprovedPerson { get; set; }

        public string CreatedPersonId { get; set; }
        public string UpdatedPersonId { get; set; }
        public string ApprovedPersonId { get; set; }

        public string CreatedPersonName { get; set; }
        public string UpdatedPersonName { get; set; }
        public string ApprovedPersonName { get; set; }


        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? SubbmittedDate { get; set; }
        public DateTime? ApprovedDate { get; set; }


        public string CreateDateText => CreatedDate.ToString();
        public string UpdatedDateText => UpdatedDate?.ToString();
        public string ApprovedDateText => ApprovedDate?.ToString();



        public IEnumerable<short> ToUserEnumerator()
        {
            var list = new List<short>();
            list.Add(CreatedPerson);

            if (UpdatedPerson != null)
                list.Add((short)UpdatedPerson);

            if (ApprovedPerson != null)
                list.Add((short)ApprovedPerson);

            return list.AsEnumerable();
        }



        // 傳入人員名單（內部系統代碼, 員工外部代碼）
        public void SetUserID(List<KeyValuePair<short, string>> _userIdKvp)
        {
            _userIdKvp.ForEach(kvp =>
            {
                if (this.CreatedPerson == kvp.Key)
                    this.CreatedPersonId = kvp.Value;

                if (this.UpdatedPerson != null && this.UpdatedPerson == kvp.Key)
                    this.UpdatedPersonId = kvp.Value;

                if (this.ApprovedPerson != null && this.ApprovedPerson == kvp.Key)
                    this.ApprovedPersonId = kvp.Value;
            });

        }
        public void SetUserName(List<KeyValuePair<short, string>> _userNameKvp)
        {
            _userNameKvp.ForEach(kvp =>
            {
                if (this.CreatedPerson == kvp.Key)
                    this.CreatedPersonName = kvp.Value;

                if (this.UpdatedPerson != null && this.UpdatedPerson == kvp.Key)
                    this.UpdatedPersonName = kvp.Value;

                if (this.ApprovedPerson != null && this.ApprovedPerson == kvp.Key)
                    this.ApprovedPersonName = kvp.Value;
            });

        }





    }



    public class EntityEditBriefHistory<T> : EntityEditBriefHistory where T : SBRPData.Interfaces.IEntityEditBriefHistory
    {
        public EntityEditBriefHistory(T _info)
        {
            base.CreatedPerson = _info.CreatedPerson;
        }
    }











    public class PageSelectorHelperEntity
    {
        [ValidateNever]
        public string SourcePageID { get; set; }
        [ValidateNever]
        public string DestinationPage { get; set; }
        [ValidateNever]
        public string DestinationPageUrl { get; set; }

      


        public string TargetAspPage { get; set; }
        public string TargetPageHandle { get; set; }
    }





}


