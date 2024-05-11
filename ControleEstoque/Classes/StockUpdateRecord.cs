using System;

namespace ControleEstoque.Classes
{
    internal class StockUpdateRecord
    {
        private int id;
        private StockItem stockItem;
        private double startAmount;
        private EnumMovementType movementType;
        private double movementedAmount;
        private double endAmount;
        private string reason;
        private string justification;
        private DateTime updateDateTime;

        public StockUpdateRecord(StockItem stockItem, double startAmount, EnumMovementType movementType, double movementedAmount, double endAmount, string reason, string justification, DateTime updateDateTime)
        {
            this.ItemEstoque = stockItem;
            this.StartAmount = startAmount;
            this.MovementType = movementType;
            this.MovementedAmount = movementedAmount;
            this.EndAmount = endAmount;
            this.Reason = reason;
            this.Justification = justification;
            this.updateDateTime = updateDateTime;
        }

        public int Id { get => id; set => id = value; }
        public double StartAmount { get => startAmount; set => startAmount = value; }
        public EnumMovementType MovementType { get => movementType; set => movementType = value; }
        public double MovementedAmount { get => movementedAmount; set => movementedAmount = value; }
        public double EndAmount { get => endAmount; set => endAmount = value; }
        public string Reason { get => reason; set => reason = value; }
        public string Justification { get => justification; set => justification = value; }
        public DateTime UpdateDateTime { get => updateDateTime; set => updateDateTime = value; }
        internal StockItem ItemEstoque { get => stockItem; set => stockItem = value; }
    }
}
