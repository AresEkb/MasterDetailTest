using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using MasterDetailTest.Module.BusinessObjects;

namespace MasterDetailTest.Module.DatabaseUpdate {
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppUpdatingModuleUpdatertopic.aspx
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) {
        }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            if (ObjectSpace.GetObjects<Developer>().Count == 0 &&
                ObjectSpace.GetObjects<Issue>().Count == 0 &&
                ObjectSpace.GetObjects<Project>().Count == 0)
            {
                var ivan = ObjectSpace.CreateObject<Developer>();
                ivan.Name = "Ivan";
                var jhon = ObjectSpace.CreateObject<Developer>();
                jhon.Name = "Jhon";
                var issue11 = ObjectSpace.CreateObject<Issue>();
                issue11.Name = "Issue 1.1";
                issue11.Developer = ivan;
                var issue12 = ObjectSpace.CreateObject<Issue>();
                issue12.Name = "Issue 1.2";
                issue12.Developer = jhon;
                var issue21 = ObjectSpace.CreateObject<Issue>();
                issue21.Name = "Issue 2.1";
                issue21.Developer = ivan;
                var issue22 = ObjectSpace.CreateObject<Issue>();
                issue22.Name = "Issue 2.2";
                issue22.Developer = jhon;
                var issue23 = ObjectSpace.CreateObject<Issue>();
                issue23.Name = "Issue 2.3";
                issue23.Developer = ivan;
                var project1 = ObjectSpace.CreateObject<Project>();
                project1.Name = "Project 1";
                project1.Issues.Add(issue11);
                project1.Issues.Add(issue12);
                var project2 = ObjectSpace.CreateObject<Project>();
                project2.Name = "Project 2";
                project2.Issues.Add(issue21);
                project2.Issues.Add(issue22);
                project2.Issues.Add(issue23);
            }
            ObjectSpace.CommitChanges();
        }
        public override void UpdateDatabaseBeforeUpdateSchema() {
            base.UpdateDatabaseBeforeUpdateSchema();
            //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
            //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
            //}
        }
    }
}
