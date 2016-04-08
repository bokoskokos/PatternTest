using System.Data.Entity.Migrations;

namespace MyPegasus.DataAccess.Migrations
{
    public partial class AddTranStationIdsToTrip : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trips", "DepartureTrainStationId", c => c.Int(nullable: false));
            AddColumn("dbo.Trips", "ArrivalTrainStationId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trips", "ArrivalTrainStationId");
            DropColumn("dbo.Trips", "DepartureTrainStationId");
        }
    }
}
