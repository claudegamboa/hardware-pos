using hardware_pos.Domain.AggregatesModel.ItemAggregate.ValueObjects;

namespace hardware_pos.Domain.AggregatesModel.ItemAggregate;

public static class DomainEvents
{
    public static class CategoryEvents
    {
        public class CategoryCreated
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string UnitOfMeasure { get; set; }
        }

        public class CategoryNameUpdated
        {
            public Guid Id { get; set; }

        }

        public class CategoryDescriptionUpdated
        {
            public Guid Id { get; set; }

        }

        public class CategoryImageUploaded
        {
            public Guid Id { get; set; }

        }

        public class CategoryUnitOfMeasureUpdated
        {
            public Guid Id { get; set; }
        }
    }

    public static class ItemEvents
    {
        public class ItemCreated
        {
            public Guid CategoryId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal SalesPrice { get; set; }
            public string TaxType { get; set; }
            public string UnitOfMeasure { get; set; }
        }

        public class QrCodeGenerated
        {
            public Guid Id { get; set; }
            public QrCode QrCode { get; set; }
        }

        public class BarcodeNumberGenerated
        {
            public Guid Id { get; set; }
            public int BarcodeNumber { get; set; }
        }

        public class ImageUploaded
        {
            public Guid Id { get; set; }
            public Uri ImageUrl { get; set; }
        }

        public class DescriptionUpdated
        {
            public Guid Id { get; set; }
            public string Description { get; set; }
        }

        public class SalesPriceUpdated
        {
            public Guid Id { get; set; }
            public decimal SalesPrice { get; set; }
        }

        public class TaxTypeUpdated
        {
            public Guid Id { get; set; }
            public string TaxType { get; set; }
        }

        public class ItemRemoved
        {
            public Guid Id { get; set; }
        }
    }
}