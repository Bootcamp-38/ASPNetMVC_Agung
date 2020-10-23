namespace crud_mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDivision : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_m_Division",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Department_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_m_Department", t => t.Department_Id)
                .Index(t => t.Department_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_m_Division", "Department_Id", "dbo.tb_m_Department");
            DropIndex("dbo.tb_m_Division", new[] { "Department_Id" });
            DropTable("dbo.tb_m_Division");
        }
    }
}
