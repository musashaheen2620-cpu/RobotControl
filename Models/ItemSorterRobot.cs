namespace Inventory_system_1.Models
{
    public class ItemSorterRobot : Robot
    {
        public const string UrsriptTemplate = @"
def move_item_to_shipment_box():
    SBOX_X = 3
    SBOX_Y = 3
    ITEM_X = {0}
    ITEM_Y = 1
    DOWN_Z = 1

    def moveto(x, y, z = 0):
        textmsg(""Moving to:"", x, y, z)
    end

    moveto(ITEM_X, ITEM_Y, 0)
    moveto(ITEM_X, ITEM_Y, DOWN_Z)
    moveto(SBOX_X, SBOX_Y, DOWN_Z)
    moveto(SBOX_X, SBOX_Y, 0)
end
";

        public void PickUp(uint itemId)
        {
            var code = string.Format(UrsriptTemplate, itemId);
            SendUrsript(code);
        }
    }
}