using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace MasterDetailTest.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Project : BaseObject
    {
        public Project(Session session)
            : base(session)
        {
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetPropertyValue("Name", ref _Name, value); }
        }

        [Association, Aggregated]
        public XPCollection<Issue> Issues
        {
            get { return GetCollection<Issue>("Issues"); }
        }
    }
}