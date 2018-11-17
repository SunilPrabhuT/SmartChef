namespace SmartChef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OMS_Master_Account",
                c => new
                    {
                        AccountId = c.Guid(nullable: false),
                        Customer = c.String(nullable: false, maxLength: 7),
                        Name = c.String(maxLength: 30),
                        Telephone = c.String(maxLength: 20),
                        Contact = c.String(maxLength: 40),
                        AddTelephone = c.String(maxLength: 20),
                        Fax = c.String(maxLength: 20),
                        TelephoneExtn = c.String(maxLength: 5),
                        Email = c.String(maxLength: 50),
                        SoldToAddr1 = c.String(maxLength: 40),
                        SoldToAddr2 = c.String(maxLength: 40),
                        SoldToAddr3 = c.String(maxLength: 40),
                        SoldToAddr4 = c.String(maxLength: 40),
                        SoldToAddr5 = c.String(maxLength: 40),
                        SoldPostalCode = c.String(maxLength: 9),
                        PoNumberMandatory = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OMS_Master_Account");
        }
    }
}
