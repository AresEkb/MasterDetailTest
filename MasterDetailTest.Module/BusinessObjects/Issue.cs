using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace MasterDetailTest.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Issue : BaseObject
    {
        public Issue(Session session)
            : base(session)
        {
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetPropertyValue("Name", ref _Name, value); }
        }

        Project _Project;
        [Association]
        public Project Project
        {
            get { return _Project; }
            set { SetPropertyValue("Project", ref _Project, value); }
        }

        Developer _Developer;
        public Developer Developer
        {
            get { return _Developer; }
            set { SetPropertyValue("Developer", ref _Developer, value); }
        }
    }
}