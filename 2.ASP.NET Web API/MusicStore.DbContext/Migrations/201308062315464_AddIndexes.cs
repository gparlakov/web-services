namespace MusicStore.SQLServerContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndexes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Artists", "Name", n => n.String(maxLength: 150));
            AlterColumn("Albums", "Title", t => t.String(maxLength: 150));
            AlterColumn("Songs", "Title", t => t.String(maxLength: 150));

            CreateIndex("Artists", "Name", unique: true);
            CreateIndex("Albums", "Title", unique: true);
            CreateIndex("Songs", "Title", unique: true);            
        }

        public override void Down()
        {
            DropIndex("Artists", new string[] { "Name" });
            DropIndex("Albums", new string[] { "Title" });
            DropIndex("Songs", new string[] { "Title" });
        }
    }
}
