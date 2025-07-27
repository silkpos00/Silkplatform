namespace CoreApi.Model.MenuBuilder
{
    public class AddItemParams
    {
        public int MyProperty { get; set; }
        public string Title { get; set; }
        public string DisplayName { get; set; }
        public int GroupID { get; set; }
        public int IsActive { get; set; }
        public int ItemSizeID { get; set; }
        public string ImageFile { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public string BackgroundColor { get; set; }
        public int PrinterID { get; set; }
        public int TaxRateValue { get; set; }
        public int MinQty { get; set; }
        public int OrderSort { get; set; }
        public int FamilyID { get; set; }
        public string Barcode { get; set; }
        public int MinModifier { get; set; }
        public int MaxModifier { get; set; }
        public string PageNo { get; set; }
        public int ModifierGroupID { get; set; }
        public int IsWeightRequired { get; set; }
        public string ItemNumber { get; set; }
        public int KitchenDisplayID { get; set; }
        public int FoodStampable { get; set; }
        public string UnitName { get; set; }
        public string Manufacture { get; set; }
        public string SKUCode { get; set; }
        public string IncludedModifiers { get; set; }
        public int PageNoSort { get; set; }
        public int MixAndMatchGroupID { get; set; }
        public int isVisable { get; set; }
        public int MaxFreeModifiersCount { get; set; } = 0;
        public string Description { get; set; } = "";
    }
}
