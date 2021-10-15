using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace InheritanceHierachyDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var tvContracts = new List<TvContract>();
            var mobileContracts = new List<MobileContract>();
            var broadbandContracts = new List<BroadBandContract>();
            var sql = @"select * from contracts";
            using (var connection = new SqliteConnection("Data Source = Projects"))
            {
                using (var reader = connection.ExecuteReader(sql))
                {
                    var tvContractParser = reader.GetRowParser<TvContract>();
                    var mobileContractParser = reader.GetRowParser<MobileContract>();
                    var broadbandContractParser = reader.GetRowParser<BroadBandContract>();

                    while (reader.Read())
                    {
                        var discriminator = (ContractType)reader.GetInt32(reader.GetOrdinal(nameof(ContractType)));
                        switch (discriminator)
                        {
                            case ContractType.TV:
                                tvContracts.Add(tvContractParser(reader));
                                break;
                            case ContractType.Broadband:
                                broadbandContracts.Add(broadbandContractParser(reader));
                                break;
                            case ContractType.Mobile:
                                mobileContracts.Add(mobileContractParser(reader));
                                break;
                        }
                    }
                }

            }
            Console.WriteLine("TV Contracts");
            tvContracts.ForEach(c => Console.WriteLine($"Duration: {c.DurationMonths} months, Package Type: {c.TVPackageType.ToString()}"));
            Console.WriteLine("Broadband Contracts");
            broadbandContracts.ForEach(c => Console.WriteLine($"Duration: {c.DurationMonths} months, Cost: {c.Charge}, Download: {c.DownloadSpeed} Mbps"));
            Console.WriteLine("Mobile Contracts");
            mobileContracts.ForEach(c => Console.WriteLine($"Duration: {c.DurationMonths} months, Number: {c.MobileNumber}"));
        }
    }
}
