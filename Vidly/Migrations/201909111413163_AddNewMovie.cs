namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewMovie : DbMigration
    {
        public override void Up()
        {
            //Sql.AddColumn();
            Sql("INSERT INTO Movies (Id, Name, GenreId, ReleaseDate, NumberInStock) VALUES (1, 'Pyaar Impossible',1,09/11/2019,5)");

        }
        
        public override void Down()
        {
        }
    }
}
