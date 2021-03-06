﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace WebChat
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class ChatDBContainer : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new ChatDBContainer object using the connection string found in the 'ChatDBContainer' section of the application configuration file.
        /// </summary>
        public ChatDBContainer() : base("name=ChatDBContainer", "ChatDBContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new ChatDBContainer object.
        /// </summary>
        public ChatDBContainer(string connectionString) : base(connectionString, "ChatDBContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new ChatDBContainer object.
        /// </summary>
        public ChatDBContainer(EntityConnection connection) : base(connection, "ChatDBContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<ChatLog> ChatLogSet
        {
            get
            {
                if ((_ChatLogSet == null))
                {
                    _ChatLogSet = base.CreateObjectSet<ChatLog>("ChatLogSet");
                }
                return _ChatLogSet;
            }
        }
        private ObjectSet<ChatLog> _ChatLogSet;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the ChatLogSet EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToChatLogSet(ChatLog chatLog)
        {
            base.AddObject("ChatLogSet", chatLog);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ChatDB", Name="ChatLog")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class ChatLog : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new ChatLog object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="chatMessage">Initial value of the ChatMessage property.</param>
        /// <param name="createdate">Initial value of the Createdate property.</param>
        /// <param name="fromUserName">Initial value of the FromUserName property.</param>
        /// <param name="toUserName">Initial value of the ToUserName property.</param>
        public static ChatLog CreateChatLog(global::System.Int32 id, global::System.String chatMessage, global::System.DateTime createdate, global::System.String fromUserName, global::System.String toUserName)
        {
            ChatLog chatLog = new ChatLog();
            chatLog.Id = id;
            chatLog.ChatMessage = chatMessage;
            chatLog.Createdate = createdate;
            chatLog.FromUserName = fromUserName;
            chatLog.ToUserName = toUserName;
            return chatLog;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ChatMessage
        {
            get
            {
                return _ChatMessage;
            }
            set
            {
                OnChatMessageChanging(value);
                ReportPropertyChanging("ChatMessage");
                _ChatMessage = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("ChatMessage");
                OnChatMessageChanged();
            }
        }
        private global::System.String _ChatMessage;
        partial void OnChatMessageChanging(global::System.String value);
        partial void OnChatMessageChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Createdate
        {
            get
            {
                return _Createdate;
            }
            set
            {
                OnCreatedateChanging(value);
                ReportPropertyChanging("Createdate");
                _Createdate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Createdate");
                OnCreatedateChanged();
            }
        }
        private global::System.DateTime _Createdate;
        partial void OnCreatedateChanging(global::System.DateTime value);
        partial void OnCreatedateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String FromUserName
        {
            get
            {
                return _FromUserName;
            }
            set
            {
                OnFromUserNameChanging(value);
                ReportPropertyChanging("FromUserName");
                _FromUserName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("FromUserName");
                OnFromUserNameChanged();
            }
        }
        private global::System.String _FromUserName;
        partial void OnFromUserNameChanging(global::System.String value);
        partial void OnFromUserNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ToUserName
        {
            get
            {
                return _ToUserName;
            }
            set
            {
                OnToUserNameChanging(value);
                ReportPropertyChanging("ToUserName");
                _ToUserName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("ToUserName");
                OnToUserNameChanged();
            }
        }
        private global::System.String _ToUserName;
        partial void OnToUserNameChanging(global::System.String value);
        partial void OnToUserNameChanged();

        #endregion
    
    }

    #endregion
    
}
