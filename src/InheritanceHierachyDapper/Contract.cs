using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceHierachyDapper
{
    public abstract class Contract
    {
        public int ContractId { get; set; }
        public DateTime StartDate { get; set; }
        public int DurationMonths { get; set; }
        public decimal Charge { get; set; }
        public ContractType ContractType { get; set; }
        public int CustomerId { get; set; }
    }
    public class MobileContract : Contract
    {
        public MobileContract() => ContractType = ContractType.Mobile;
        public string MobileNumber { get; set; }
    }
    public class TvContract : Contract
    {
        public TvContract() => ContractType = ContractType.TV;
        public TVPackageType TVPackageType { get; set; }
    }
    public class BroadBandContract : Contract
    {
        public BroadBandContract() => ContractType = ContractType.Broadband;
        public int DownloadSpeed { get; set; }
    }
    public enum TVPackageType
    {
        S, M, L, XL
    }
    public enum ContractType
    {
        Mobile = 1, TV, Broadband
    }
}
