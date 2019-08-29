using FluentSql.Models;
using Microsoft.Data.Sqlite;

namespace hkampcontrol.data
{
    public static class DataAccess
    {
        public static void InitializeDatabase()
        {
            // https://docs.microsoft.com/en-us/windows/uwp/data-access/sqlite-databases#initialize-the-sqlite-database
            using (SqliteConnection db = new SqliteConnection("Filename=hkampcontrol.db"))
            {
                db.Open();
                
                new SqliteCommand(
                    FluentSql.FluentSql
                        .CreateTable("Presets")
                            .IfNotExists()
                            .WithColumn("Id", DataType.Integer)
                                .AsPrimaryKey()
                            .EndColumn()
                            .WithColumn("Name", DataType.Text).EndColumn()
                            .WithColumn("Bass", DataType.Integer).EndColumn()
                            .WithColumn("Mid", DataType.Integer).EndColumn()
                            .WithColumn("Treble", DataType.Integer).EndColumn()
                            .WithColumn("Presence", DataType.Integer).EndColumn()
                            .WithColumn("Resonance", DataType.Integer).EndColumn()
                            .WithColumn("Volume", DataType.Integer).EndColumn()
                            .WithColumn("Gain", DataType.Integer).EndColumn()
                            .WithColumn("Channel", DataType.Integer).EndColumn()
                            .WithColumn("IsBoostOn", DataType.Integer).EndColumn()
                            .WithColumn("IsNoiseGateOn", DataType.Integer).EndColumn()
                            .WithColumn("IsFxLoopOn", DataType.Integer).EndColumn()
                            .WithColumn("IsReverbOn", DataType.Integer).EndColumn()
                            .WithColumn("ReverbLevel", DataType.Integer).EndColumn()
                            .WithColumn("IsDelayOn", DataType.Integer).EndColumn()
                            .WithColumn("DelayLevel", DataType.Integer).EndColumn()
                            .WithColumn("DelayFeedback", DataType.Integer).EndColumn()
                            .WithColumn("DelayTime", DataType.Integer).EndColumn()
                            .WithColumn("IsModulationOn", DataType.Integer).EndColumn()
                            .WithColumn("ModulationType", DataType.Integer).EndColumn()
                            .WithColumn("ModulationIntensity", DataType.Integer).EndColumn()
                            .WithColumn("ModulationSpeed", DataType.Integer).EndColumn()
                        .End(),
                    db).ExecuteReader();
            }
        }
    }
}