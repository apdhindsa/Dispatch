namespace Dispatch.Model
{
    public class MasterTypes
    {
        // Primary key
        public int MasterTypeId { get; set; }
        public string Name { get; set; }

        //Navigation Property
        public Master Master { get; set; }
    }
}
