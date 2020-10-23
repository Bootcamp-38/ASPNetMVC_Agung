namespace crud_mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDivision : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.tb_m_Division", name: "Department_Id", newName: "DepartmentID");
            RenameIndex(table: "dbo.tb_m_Division", name: "IX_Department_Id", newName: "IX_DepartmentID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.tb_m_Division", name: "IX_DepartmentID", newName: "IX_Department_Id");
            RenameColumn(table: "dbo.tb_m_Division", name: "DepartmentID", newName: "Department_Id");
        }
    }
}
