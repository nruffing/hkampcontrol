using FluentSql.Models;
using hkampcontrol.data.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace hkampcontrol.data
{
    public static class DataAccess
    {
        private const string ConnectionString = "Filename=hkampcontrol.db";
        private const string PresetsTableName = "Presets";

        public static void InitializeDatabase()
        {
            // https://docs.microsoft.com/en-us/windows/uwp/data-access/sqlite-databases#initialize-the-sqlite-database
            using (SqliteConnection db = new SqliteConnection(ConnectionString))
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

        public static IEnumerable<Preset> GetAllPresets()
        {
            List<Preset> presets = new List<Preset>();

            using (SqliteConnection db = new SqliteConnection(ConnectionString))
            {
                SqliteCommand command = new SqliteCommand(
                    FluentSql.FluentSql
                        .Select()
                        .All()
                        .From(PresetsTableName)
                        .End(),
                    db);
                SqliteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    presets.Add(new Preset(
                        reader.GetInt64(0),
                        reader.GetString(1),
                        reader.GetByte(2),
                        reader.GetByte(3),
                        reader.GetByte(4),
                        reader.GetByte(5),
                        reader.GetByte(6),
                        reader.GetByte(7),
                        reader.GetByte(8),
                        reader.GetByte(9),
                        reader.GetBoolean(10),
                        reader.GetBoolean(11),
                        reader.GetBoolean(12),
                        reader.GetBoolean(13),
                        reader.GetByte(14),
                        reader.GetBoolean(15),
                        reader.GetByte(16),
                        reader.GetByte(17),
                        reader.GetByte(17),
                        reader.GetBoolean(18),
                        reader.GetByte(19),
                        reader.GetByte(20),
                        reader.GetByte(21)));
                }
            }

            return presets;
        }
    }
}