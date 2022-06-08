﻿namespace MvcOnlineTicariOtamasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kargotest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KargoDetays",
                c => new
                    {
                        KargoDetayid = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 300, unicode: false),
                        Personel = c.String(maxLength: 30, unicode: false),
                        TakipKodu = c.String(maxLength: 30, unicode: false),
                        Alici = c.String(maxLength: 30, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KargoDetayid);
            
            CreateTable(
                "dbo.KargoTakips",
                c => new
                    {
                        KargoTakipid = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 100, unicode: false),
                        TakipKodu = c.String(maxLength: 30, unicode: false),
                        TarihZaman = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KargoTakipid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KargoTakips");
            DropTable("dbo.KargoDetays");
        }
    }
}
