using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.IO;


namespace seer_fiddler.core
{
    public static class DBServise
    {
        private static string petDBPath = Directory.GetCurrentDirectory() + "\\bin\\DB\\pet.db";
        private static SqliteConnection db;
        public static List<PetSkinsReplacePlan> PetSkinsPlanTableSelectData(string petName)
        {
            try
            {
                using (db = new SqliteConnection($"Filename={petDBPath}"))
                {
                    db.Open();
                    string selectSql = "SELECT pet_name,pet_id,pet_skins_name,pet_skins_id FROM petskinsreplaceplan WHERE pet_name LIKE @pet_name;";
                    SqliteCommand selectCmd = new SqliteCommand(selectSql, db);
                    selectCmd.Parameters.Add(new SqliteParameter("@pet_name", $"%{petName}%"));
                    SqliteDataReader reader = selectCmd.ExecuteReader();
                    List<PetSkinsReplacePlan> result = new List<PetSkinsReplacePlan>();
                    while (reader.Read())
                    {
                        PetSkinsReplacePlan plan = new PetSkinsReplacePlan();
                        plan.petName = reader.GetString(0);
                        plan.petId = reader.GetInt32(1);
                        plan.skinsName = reader.GetString(2);
                        plan.skinsId = reader.GetInt32(3);
                        result.Add(plan);
                    }
                    //Console.WriteLine(result.Count);
                    return result.Count > 0 ? result : null;
                }
            }
            catch (Exception)
            {
                //Console.WriteLine($"数据库精灵皮肤替换方案数据信息查询失败！ errorMessage：{ex.Message}");
                return null;
            }
        }
        public static int PetTableGetRealId(int petId)
        {
            try
            {
                using (db)
                {
                    db.Open();
                    SqliteCommand selectCmd;
                    if (petId < 1400000)
                    {
                        string selectSql = "SELECT pet_realId " +
                        "FROM pet WHERE pet_id = @petId;";
                        selectCmd = new SqliteCommand(selectSql, db);
                        selectCmd.Parameters.Add(new SqliteParameter("@petId", $"{petId}"));
                    }
                    else
                    {
                        string selectSql = "SELECT pet_skins_realid " +
                        "FROM petskins WHERE pet_skins_id = @petId;";
                        selectCmd = new SqliteCommand(selectSql, db);
                        selectCmd.Parameters.Add(new SqliteParameter("@petId", $"{petId}"));
                    }
                    SqliteDataReader reader = selectCmd.ExecuteReader();
                    int realId = 0;
                    while (reader.Read())
                    {
                        realId = reader.GetInt32(0);
                    }
                    return realId == 0 ? petId : realId;

                }
            }
            catch (Exception)
            {
                return petId;
            }
        }
        public class PetSkinsReplacePlan
        {
            public PetSkinsReplacePlan() { }
            public PetSkinsReplacePlan(int petId, string petName, int skinsId, string skinsName)
            {
                this.petId = petId;
                this.petName = petName;
                this.skinsId = skinsId;
                this.skinsName = skinsName;
            }
            public int id { get; set; }
            public int petId { get; set; }
            public string petName { get; set; }
            public int skinsId { get; set; }
            public string skinsName { get; set; }
        }
    }
}
