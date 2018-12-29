namespace TicketBooking_WebAPI_Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingOrders",
                c => new
                    {
                        OrderID = c.Long(nullable: false, identity: true),
                        UserID = c.String(),
                        OrderStatus = c.String(),
                        OrderAmount = c.Double(nullable: false),
                        TravelBy = c.Int(nullable: false),
                        Source_City = c.String(nullable: false),
                        Source_State = c.String(),
                        Source_BoardingAddress = c.String(),
                        Source_PinCode = c.Long(nullable: false),
                        Destination_City = c.String(nullable: false),
                        Destination_State = c.String(),
                        Destination_BoardingAddress = c.String(),
                        Destination_PinCode = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userId = c.Long(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 10),
                        Rating = c.String(),
                        EmailId = c.String(nullable: false),
                        MobileNo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.BookingOrders");
        }
    }
}
